using Hengtex.Data.Repository;
using Hengtex.Util;
using Hengtex.Util.WebControl;
using Hengtex.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Hengtex.Data;
using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Application.Entity.Sale;
using System;

namespace Hengtex.Application.Service.SaleManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：发货管理
    /// </summary>
    public class ProDeliveryService : RepositoryFactory<ProDeliveryEntity>, IProDeliveryService
    {
       

        #region 获取数据
        /// <summary>
        /// 发货列表
        /// </summary>
        /// <returns></returns>
        public    IEnumerable<ProDeliveryEntity> GetList()
        {
            var expression = LinqExtensions.True<ProDeliveryEntity>();
           // expression = expression.And(t => t.FlagDelete == "0").And(t => t.aa_Dept != "废表");
            return this.ERPRepository().IQueryable(expression).OrderByDescending(t => t.pd_date).ToList();
        }
        /// <summary>
        /// 发货列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<ProDeliveryEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<ProDeliveryEntity>();
            var queryParam = queryJson.ToJObject();
            string sqlCondation = "  ";

            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "pdd_spec":            //品号
                        expression = expression.And(t => t.pdd_spec.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%"+keyword+"%'"; ;
                        break;
                    case "pdd_batch":          //批号
                        expression = expression.And(t => t.pdd_batch.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "pdd_name":          //产品名称
                        expression = expression.And(t => t.pdd_name.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "pdd_color":          //颜色
                        expression = expression.And(t => t.pdd_color.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "pdd_zhishu":          //支数
                        expression = expression.And(t => t.pdd_zhishu.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "pd_custName":          //客户名称
                        expression = expression.And(t => t.pd_custName.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;

                    default:
                        break;
                }
            }

            string sql = "select a.*,b.* from inv_product_deliveries a left join inv_product_delivery_details b on a.pd_num=b.pdd_delivery where a.FlagDelete=0 ";
            sql += sqlCondation;
          
            return this.ERPRepository().FindList(sql, pagination);
        }
      
        /// <summary>
        /// 发货档案实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ProDeliveryEntity GetEntity(string keyValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    fclt_ammeters
                            WHERE   a_ammeNo  = @a_ammeNo 
                            AND FlagDelete = 0  AND a_Dept <> '废表' Order By a_ammeNo");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@a_ammeNo",keyValue)
            };
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<ProDeliveryEntity>();
         
        }
        #endregion

      
    }
}
