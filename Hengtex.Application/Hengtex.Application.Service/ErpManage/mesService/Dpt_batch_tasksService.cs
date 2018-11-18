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
    public class Dpt_batch_tasksService : RepositoryFactory<Dpt_batch_tasksEntity>, IDpt_batch_tasksService
    {
       

        #region 获取数据
        /// <summary>
        /// 根据完工工序ID获取工序设定表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Dpt_batch_tasksEntity> GetList(Dictionary<string,string> fields)
        {
            string sql = "SELECT  *  FROM Dpt_batch_tasks WHERE  FlagDelete = 0 ";
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
        public IEnumerable<Dpt_batch_tasksEntity> GetPageList(string queryJson)
        {
            var expression = LinqExtensions.True<Dpt_batch_tasksEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "Bpt_batch":            //批次
                        expression = expression.And(t => t.Bpt_batch.Equals(keyword));
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
        /// <param name="keyValue">bpt_fcltNum</param>
        /// <returns></returns>
        public Dpt_batch_tasksEntity GetEntity(string keyValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT top 1  *
                            FROM    Dpt_batch_tasks
                            WHERE   bpt_fcltNum  = @bpt_fcltNum 
                            AND FlagDelete = 0  and bpt_status = '未执行' order by bpt_timeStartPlan ");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@bpt_fcltNum",keyValue)
            };
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<Dpt_batch_tasksEntity>();
         //  return this.ERPRepository().FindList(strSql.ToString(),parameter);
           // return this.ERPRepository().FindEntity(keyValue);
        }

        
        #endregion


    }
}
