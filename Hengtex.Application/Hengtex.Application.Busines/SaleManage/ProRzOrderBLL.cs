using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.Entity.Sale;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Application.Service.ErpManage;
using Hengtex.Application.Service.SaleManage;
using Hengtex.Cache.Factory;
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
    public class ProRzOrderBLL
    {
        private IProRzOrderService service = new ProRzOrderService();
        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "AppRoleCache";

        #region 获取数据
        /// <summary>
        /// 样品列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProRzOrderEntity> GetList()
        {
            return service.GetList();
        }
        /// <summary>
        /// 绒布订单列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<ProRzOrderEntity> GetPageList(Pagination pagination, string queryJson,string user)
        {
            return service.GetPageList(pagination, queryJson,user);
        }

        public DataTable GetDataListByDt(Pagination pagination, string queryJson, string user)
        {
            DataTable dataTable = service.GetPageListByDt(pagination, queryJson, user);

            dataTable.Columns.Add("countDelivery", typeof(decimal));//已发货数量
            dataTable.Columns.Add("countPack", typeof(decimal));//包装数量
            dataTable.Columns.Add("dateLastDelivery", typeof(DateTime));//最近发货时间

            if (dataTable.Rows.Count > 0)
            {
                string strBatches = "";
                foreach (DataRow row in dataTable.Rows)
                {
                    strBatches = strBatches + "'" + row["b_num"].ToString() + "',";
                }
                strBatches = strBatches.TrimEnd(',');
                DataTable dthrcom = service.GetBatchesData(strBatches);

                dataTable.Columns.Add("hr_completeNum", typeof(decimal));//已坯布下机数量

                DataTable dtDelivery = service.GetDeliveryByNums(user);
                dtDelivery.PrimaryKey = new DataColumn[] { dtDelivery.Columns["batch"] };
                DataTable dtPacks = service.GetPacksByNums(user);
                dtPacks.PrimaryKey = new DataColumn[] { dtPacks.Columns["ppg_batch"] };
                foreach (DataRow row in dataTable.Rows)
                {
                    decimal hr_completeNum = 0;
                    DataRow[] drshr = dthrcom.Select("op_batch" + "='" + row["b_num"].ToString() + "'");
                    if (drshr.Length > 0)
                    {
                        if (drshr[0]["op_mcount"].ToString() != "")
                        {
                            hr_completeNum = Decimal.Parse(drshr[0]["op_mcount"].ToString());
                        }
                    }
                    if (hr_completeNum != 0) row["hr_completeNum"] = hr_completeNum;


                    DataRow rowDelivery = dtDelivery.Rows.Find(row["b_num"].ToString());
                    if (rowDelivery != null)
                    {
                        row["dateLastDelivery"] = rowDelivery["dateF"].ToString().Trim();
                        row["countDelivery"] = rowDelivery["countF"].ToString().Trim();
                    }
                    DataRow rowPack = dtPacks.Rows.Find(row["b_num"].ToString());
                    if (rowPack != null)
                    {
                        row["countPack"] = rowPack["countAll"];
                    }
                }

            }

            return dataTable;
        }

        /// <summary>
        /// 样品实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ProRzOrderEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

    }
}
