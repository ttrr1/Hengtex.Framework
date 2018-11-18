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

namespace Hengtex.Application.Service.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：电表档案管理
    /// </summary>
    public class mes_pro_check_setService : RepositoryFactory<mes_pro_check_setEntity>, Imes_pro_check_setService
    {
       

        #region 获取数据
        /// <summary>
        /// 根据完工工序ID获取工序设定表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<mes_pro_check_setEntity> GetList(Dictionary<string,string> fields)
        {
            string sql = "SELECT  *  FROM mes_pro_check_set WHERE  FlagDelete = 0 ";
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
        public IEnumerable<mes_pro_check_setEntity> GetPageList(string queryJson)
        {
            var expression = LinqExtensions.True<mes_pro_check_setEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "mecs_proIDEnd":            //工序权限表完工ID
                        expression = expression.And(t => t.mpcs_proIDEnd.Equals(keyword));
                        break;                 
                    default:
                        break;
                }
                
            }
            expression = expression.And(t => t.FlagDelete == "0");
            return this.ERPRepository().IQueryable(expression).OrderByDescending(t => t.CreationDate).ToList();
        }
      
        /// <summary>
        /// 工序定义实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public mes_pro_check_setEntity GetEntity(string keyValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    mes_pro_check_set
                            WHERE   mecs_id  = @mecs_id 
                            AND FlagDelete = 0  ");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@mecs_id",keyValue)
            };
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<mes_pro_check_setEntity>();
         //  return this.ERPRepository().FindList(strSql.ToString(),parameter);
           // return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

      
    }
}
