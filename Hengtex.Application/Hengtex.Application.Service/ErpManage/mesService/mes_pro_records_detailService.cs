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
    public class  mes_pro_records_detailService : RepositoryFactory< mes_pro_records_detailEntity>, Imes_pro_records_detailService
    {
       

        #region 获取数据
        /// <summary>
        /// 根据完工工序ID获取工序设定表
        /// </summary>
        /// <returns></returns>
        public IEnumerable< mes_pro_records_detailEntity> GetList(Dictionary<string,string> fields)
        {
            string sql = "SELECT  *  FROM mes_pro_records_detail WHERE  FlagDelete = 0 ";
            foreach(string key in fields.Keys)
            {
                sql = sql + " and "+key +" = '"+fields[key]+"'";
            }
         
            return this.ERPRepository().FindList(sql);
        }
       
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<mes_pro_records_detailEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<mes_pro_records_detailEntity>();
            var queryParam = queryJson.ToJObject();
            string sqlCondation = "  ";
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {               
            
            		case "mprd_id":
                		sqlCondation = sqlCondation + " and mprd_id like '%" + keyword + "%'";
                	break;
                        
            		case "LastUpdateDate":
                		sqlCondation = sqlCondation + " and LastUpdateDate like '%" + keyword + "%'";
                	break;
                        
            		case "LastUpdatedBy":
                		sqlCondation = sqlCondation + " and LastUpdatedBy like '%" + keyword + "%'";
                	break;
                        
            		case "AppUser":
                		sqlCondation = sqlCondation + " and AppUser like '%" + keyword + "%'";
                	break;
                        
            		case "AppDate":
                		sqlCondation = sqlCondation + " and AppDate like '%" + keyword + "%'";
                	break;
                        
            		case "FlagApp":
                		sqlCondation = sqlCondation + " and FlagApp like '%" + keyword + "%'";
                	break;
                        
            		case "DelMan":
                		sqlCondation = sqlCondation + " and DelMan like '%" + keyword + "%'";
                	break;
                        
            		case "DelDate":
                		sqlCondation = sqlCondation + " and DelDate like '%" + keyword + "%'";
                	break;
                        
            		case "FlagDelete":
                		sqlCondation = sqlCondation + " and FlagDelete like '%" + keyword + "%'";
                	break;
                        
            		case "mprd_numDetail":
                		sqlCondation = sqlCondation + " and mprd_numDetail like '%" + keyword + "%'";
                	break;
                        
            		case "mprd_horseNo":
                		sqlCondation = sqlCondation + " and mprd_horseNo like '%" + keyword + "%'";
                	break;
                        
            		case "mprd_count":
                		sqlCondation = sqlCondation + " and mprd_count like '%" + keyword + "%'";
                	break;
                        
            		case "mprd_remarks":
                		sqlCondation = sqlCondation + " and mprd_remarks like '%" + keyword + "%'";
                	break;
                        
            		case "mprd_Person":
                		sqlCondation = sqlCondation + " and mprd_Person like '%" + keyword + "%'";
                	break;
                        
            		case "CreationDate":
                		sqlCondation = sqlCondation + " and CreationDate like '%" + keyword + "%'";
                	break;
                        
            		case "CreatedBy":
                		sqlCondation = sqlCondation + " and CreatedBy like '%" + keyword + "%'";
                	break;
                        
            		case "CreatedByNum":
                		sqlCondation = sqlCondation + " and CreatedByNum like '%" + keyword + "%'";
                	break;
                      	              
                    case "All":             
                       
                       // sqlCondation = sqlCondation + " and (fclt_num like '%" + keyword + "%'";
                       // sqlCondation = sqlCondation + " or fclt_name like '%" + keyword + "%'";
                       // sqlCondation = sqlCondation + " or fclt_symbol like '%" + keyword + "%')";
                        break;                  
                    default:
                        break;
                }
            }
            try 
            {                
                string sql = "select * from  mes_pro_records_detail where    FlagDelete=0 " ;
                sql += sqlCondation;              
                return this.ERPRepository().FindList(sql, pagination);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public mes_pro_records_detailEntity GetEntity(string keyValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    mes_pro_records_detail
                            WHERE  
                           mprd_id =@mprd_id                           			
                            AND FlagDelete = 0  ");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@mprd_id",keyValue)
            };
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<mes_pro_records_detailEntity>();
        }
        #endregion

      
    }
}