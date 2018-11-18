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
using System.Reflection;

namespace Hengtex.Application.Service.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：工序档案管理
    /// </summary>
    public class doc_flow_proceduresService : RepositoryFactory<doc_flow_proceduresEntity>, Idoc_flow_proceduresService
    {
       

        #region 获取数据
       
        /// <summary>
        /// 工序权限表
        /// </summary>
        
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<doc_flow_proceduresEntity> GetPageList(string queryJson)
        {
            var expression = LinqExtensions.True<doc_flow_proceduresEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();

                foreach (PropertyInfo info in typeof(doc_flow_proceduresEntity).GetProperties()) {
                    if (info.Name.Equals(condition)) {
                        expression = expression.And(t => info.GetValue(t).ToString().Equals(keyword));
                    }

                }
               
            }
           
            return this.ERPRepository().IQueryable(expression).OrderByDescending(t => t.dfp_id).ToList();
        }
      
        /// <summary>
        /// 工序档案实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public doc_flow_proceduresEntity GetEntity(string keyValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    doc_flow_procedures
                            WHERE   dfp_num  = @dfp_num 
                              Order By dfp_num desc");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@dfp_num",keyValue)
            };
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<doc_flow_proceduresEntity>();
         //  return this.ERPRepository().FindList(strSql.ToString(),parameter);
           // return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

      
    }
}
