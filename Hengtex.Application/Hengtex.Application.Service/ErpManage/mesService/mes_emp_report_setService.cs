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
    public class mes_emp_report_setService : RepositoryFactory<mes_emp_report_setEntity>, Imes_emp_report_setService
    {
       

        #region 获取数据
        /// <summary>
        /// 根据人员账户获取工序
        /// </summary>
        /// <returns></returns>
        public IEnumerable<mes_emp_report_setEntity> GetList(string empAccount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    mes_emp_report_set
                            WHERE   mprs_account  = @mprs_account 
                            AND FlagDelete = 0  ");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@mprs_account",empAccount)
            };
            return this.ERPRepository().FindList(strSql.ToString(), parameter);
        }
        /// <summary>
        /// 工序权限表
        /// </summary>
        
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<mes_emp_report_setEntity> GetPageList(string queryJson)
        {
            var expression = LinqExtensions.True<mes_emp_report_setEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "mprs_account":            //电表编号
                        expression = expression.And(t => t.mprs_account.Equals(keyword));
                        break;                 
                    default:
                        break;
                }
            }
            expression = expression.And(t => t.FlagDelete == "0");
            return this.ERPRepository().IQueryable(expression).OrderByDescending(t => t.CreationDate).ToList();
        }
      
        /// <summary>
        /// 电表档案实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public mes_emp_report_setEntity GetEntity(string keyValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    mes_emp_report_set
                            WHERE   mprs_id  = @mprs_id 
                            AND FlagDelete = 0  ");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@mprs_id",keyValue)
            };
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<mes_emp_report_setEntity>();
         //  return this.ERPRepository().FindList(strSql.ToString(),parameter);
           // return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

      
    }
}
