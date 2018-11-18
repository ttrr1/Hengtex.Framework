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
    public class Fclt_facilitiesService : RepositoryFactory<Fclt_facilitiesEntity>, IFclt_facilitiesService
    {
       

        #region 获取数据
        /// <summary>
        /// 根据完工工序ID获取工序设定表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Fclt_facilitiesEntity> GetList(Dictionary<string,string> fields)
        {
            string sql = "SELECT  *  FROM Fclt_facilities WHERE  FlagDelete = 0 ";
            foreach(string key in fields.Keys)
            {
                sql = sql + " and "+key +" = '"+fields[key]+"'";
            }
         
            return this.ERPRepository().FindList(sql);
        }
        /// <summary>
        /// 工序设定表
        /// </summary>

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<Fclt_facilitiesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<Fclt_facilitiesEntity>();
            var queryParam = queryJson.ToJObject();
            string sqlCondation = "  ";
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "All":              //设备编码
                       
                        sqlCondation = sqlCondation + " and (fclt_num like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or fclt_name like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or fclt_symbol like '%" + keyword + "%')";
                        break;
                   
                    
                   
                    default:
                        break;
                }
            }
            try 
            {
                
                string sql = "select top 5000 * from  fclt_facilities where    FlagDelete=0 " ;
                sql += sqlCondation;
                sql += " order by fclt_num";
                return this.ERPRepository().FindList(sql, pagination);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 工序定义实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Fclt_facilitiesEntity GetEntity(string keyValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Fclt_facilities
                            WHERE   Fclt_num  = @Fclt_num 
                            AND FlagDelete = 0  ");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@Fclt_num",keyValue)
            };
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<Fclt_facilitiesEntity>();
        }
        #endregion

      
    }
}
