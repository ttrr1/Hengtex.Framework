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
using System;

namespace Hengtex.Application.Service.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：电表档案管理
    /// </summary>
    public class bg_batchService : RepositoryFactory<bg_batchEntity>, Ibg_batchService
    {
       

        #region 获取数据
        /// <summary>
        /// 根据完工工序ID获取工序设定表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<bg_batchEntity> GetList(Dictionary<string,string> fields)
        {
            string sql = "select b.b_num,b.b_color,b.b_pinhao,b.b_pinming,b.b_attr,b.b_zhishu,b.b_count,b.b_dateDelivery,o_custNum,o_custName  from sale_order_batches b left join sale_orders o on b.b_order=o.o_num where o.FlagDelete=0 and b.FlagDelete=0 and b.b_flagComplete=0  ";
            foreach(string key in fields.Keys)
            {
                sql = sql + " and "+key +" = '"+fields[key]+"'";
            }
         
            return this.ERPRepository().FindList(sql);
        }
        /// <summary>
        /// 工序设定表
        /// </summary>
        
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<bg_batchEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<bg_batchEntity>();
            var queryParam = queryJson.ToJObject();
            string sqlCondation = "  ";
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "b_color":            //颜色
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "b_zhishu":            //支数
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "b_attr":            //属性码
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "b_pinhao":            //品号
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "b_pinming":            //老品号
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    default:
                        break;
                }
                
            }

            string sql = "select b.b_num,b.b_color,b.b_pinhao,b.b_pinming,b.b_attr,b.b_zhishu,b.b_count,b.b_dateDelivery,o_custNum,o_custName  from sale_order_batches b left join sale_orders o on b.b_order=o.o_num where o.FlagDelete=0 and b.FlagDelete=0 and b.b_flagComplete=0  ";
            sql += sqlCondation;
            try
            {
                return this.ERPRepository().FindList(sql, pagination);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
      
        /// <summary>
        /// 工序定义实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public bg_batchEntity GetEntity(string keyValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select b.b_num,b.b_color,b.b_pinhao,b.b_pinming,b.b_attr,b.b_zhishu,b.b_count,b.b_dateDelivery,o_custNum,o_custName  from sale_order_batches b left join sale_orders o on b.b_order=o.o_num where o.FlagDelete=0 and b.FlagDelete=0 and b.b_flagComplete=0 
                            and   b_num  = @b_num 
                             ");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@b_num",keyValue)
            };
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<bg_batchEntity>();
         //  return this.ERPRepository().FindList(strSql.ToString(),parameter);
           // return this.ERPRepository().FindEntity(keyValue);
        }

      
        #endregion


    }
}
