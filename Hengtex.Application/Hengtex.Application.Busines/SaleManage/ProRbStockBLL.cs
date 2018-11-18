using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.Entity.Sale;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Application.Service.ErpManage;
using Hengtex.Application.Service.SaleManage;
using Hengtex.Cache.Factory;
using Hengtex.Util;
using Hengtex.Util.Extension;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Hengtex.Application.Busines.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：样品管理
    /// </summary>
    public class ProRbStockBLL
    {
        private IProRbStockService service = new ProRbStockService();
        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "AppRoleCache";

        #region 获取数据
        /// <summary>
        /// 样品列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProRbStockEntity> GetList()
        {
            return service.GetList();
        }
        /// <summary>
        /// 样品列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<ProRbStockEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// 样品实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ProRbStockEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }


        public DataTable GetProSumCount(string date)
        {
            return service.GetProSumCount(date);
        }

        public DataTable GetProductSumCountNotAccounted()
        {
            return service.GetProductSumCountNotAccounted();
        }

        public DataTable GetProductSumCountNotAccounted1()
        {
            return service.GetProductSumCountNotAccounted1();
        }

        public DataTable SearchBy(string stock, string code, string BNum, string color, string spec, string model, string dispather, bool Used)
        {
            return service.SearchBy(stock, code, BNum, color, spec, model, dispather, Used);
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetPageListByDt(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();


            //查询条件
            string condition="" ;
            string keyword="";
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                 condition = queryParam["condition"].ToString();
                 keyword = queryParam["keyword"].ToString();
            }

                DataTable dtStock = service.GetPageListByDt(pagination, queryJson);

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable dtSumToday = this.GetProSumCount(date);
            dtSumToday.PrimaryKey = new DataColumn[] { dtSumToday.Columns["code"] };


            DataTable dtInOutSum = this.GetProductSumCountNotAccounted();

            dtStock.Columns.Add("s_count", typeof(decimal));//样品库存
            dtStock.Columns.Add("stockDays", typeof(int));//库存天数
            dtStock.Columns.Add("p_countDayIn", typeof(decimal));
            dtStock.Columns.Add("p_countDayOut", typeof(decimal));

            DataTable dtStockSample = getStockFromSample(condition,keyword);
            dtStockSample.PrimaryKey = new DataColumn[] { dtStockSample.Columns["s_code"] };

            for (int i = dtStock.Rows.Count - 1; i >= 0; i--)
            {
                DataRow rowProduct = dtStock.Rows[i];
                //当前实存
                decimal countReal = getCountBalance(dtInOutSum, ConvertEx.ToDecimal(rowProduct["p_count"]), rowProduct["p_code"].ToString());

                //库存天数
                int stockDays = 0;
                if (countReal > 0 && rowProduct["p_dateLastIn"] != null && rowProduct["p_dateLastIn"].ToString() != "")
                {

                    DateTime dateLastIn = Convert.ToDateTime(rowProduct["p_dateLastIn"]);
                    if (dateLastIn != null)
                    {
                        TimeSpan ts = DateTime.Today - dateLastIn;
                        rowProduct["stockDays"] = stockDays = ts.Days;
                    }
                }



                DataRow rowSample = dtStockSample.Rows.Find(rowProduct["p_code"]);
                if (rowSample != null)
                    rowProduct["s_count"] = rowSample["s_count"];

                //样品库存
                decimal countSample = ConvertEx.ToDecimal(rowProduct["s_count"]);



                rowProduct["p_count"] = countReal;

                DataRow row = dtSumToday.Rows.Find(rowProduct["p_code"].ToString());
                if (row != null)
                {
                    rowProduct["p_countDayIn"] = ConvertEx.ToDecimal(row["countAll_in"]);
                    rowProduct["p_countDayOut"] = ConvertEx.ToDecimal(row["countAll_out"]);
                }

            }

            return dtStock;
        }


        /// <summary>
        /// 获取当前实存
        /// </summary>
        /// <param name="dt">产品的出入库合计</param>
        /// <param name="count">产品的账面库存</param>
        /// <param name="code">产品编码</param>
        /// <returns></returns>
        private decimal getCountBalance(DataTable dt, decimal count, string code)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["code"].ToString() == code)
                {
                    count = count + ConvertEx.ToDecimal(row["countAll_in"]) - ConvertEx.ToDecimal(row["countAll_out"]);
                    break;
                }
            }

            return count;
        }
        /// <summary>
        /// 获取样品库实存
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        private DataTable getStockFromSample(string condation,string value)
        {
            string txtCode = condation.Equals("产品编码") ? value : "";
            string txtBNum = "";
            string txtColor = condation.Equals("颜色") ? value : "";
            string txtSpec = condation.Equals("品号") ? value : "";
            string txtModel = "";
            string txtDispather = condation.Equals("调度") ? value : "";
            if (condation == "批次")
            {
                txtBNum = value;
            }
            DataTable dtStock = this.SearchBy("样品库", txtCode, txtBNum, txtColor, txtSpec, txtModel, txtDispather, true);
            DataTable dtInOutSum = this.GetProductSumCountNotAccounted1();

            for (int i = dtStock.Rows.Count - 1; i >= 0; i--)
            {
                DataRow rowProduct = dtStock.Rows[i];

                //当前实存
                decimal countReal = getCountBalance(dtInOutSum, ConvertEx.ToDecimal(rowProduct["s_count"]), rowProduct["s_code"].ToString());
                //库存大于0

                rowProduct["s_count"] = countReal;
            }
            dtStock.AcceptChanges();

            return dtStock;
        }
        #endregion

    }
}
