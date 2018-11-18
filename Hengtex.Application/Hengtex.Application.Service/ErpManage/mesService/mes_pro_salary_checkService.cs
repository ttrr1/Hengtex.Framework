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
    public class  mes_pro_salary_checkService : RepositoryFactory< mes_pro_salary_checkEntity>, Imes_pro_salary_checkService
    {
       

        #region 获取数据
        /// <summary>
        /// 根据完工工序ID获取工序设定表
        /// </summary>
        /// <returns></returns>
        public IEnumerable< mes_pro_salary_checkEntity> GetList(Dictionary<string,string> fields)
        {
            string sql = "SELECT  *  FROM mes_pro_salary_check WHERE  FlagDelete = 0 ";
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
        public IEnumerable<mes_pro_salary_checkEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<mes_pro_salary_checkEntity>();
            var queryParam = queryJson.ToJObject();
            string sqlCondation = "  ";
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {               
            
            		case "mpsc_id":
                		sqlCondation = sqlCondation + " and mpsc_id like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_empName":
                		sqlCondation = sqlCondation + " and mpsc_empName like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_batch":
                		sqlCondation = sqlCondation + " and mpsc_batch like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_panNo":
                		sqlCondation = sqlCondation + " and mpsc_panNo like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_horseNo":
                		sqlCondation = sqlCondation + " and mpsc_horseNo like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_decript":
                		sqlCondation = sqlCondation + " and mpsc_decript like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_remarks":
                		sqlCondation = sqlCondation + " and mpsc_remarks like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_Person":
                		sqlCondation = sqlCondation + " and mpsc_Person like '%" + keyword + "%'";
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
                        
            		case "mpsc_mprNum":
                		sqlCondation = sqlCondation + " and mpsc_mprNum like '%" + keyword + "%'";
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
                        
            		case "mpsc_date":
                		sqlCondation = sqlCondation + " and mpsc_date like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_procedureID":
                		sqlCondation = sqlCondation + " and mpsc_procedureID like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_procedureName":
                		sqlCondation = sqlCondation + " and mpsc_procedureName like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_contentCheck":
                		sqlCondation = sqlCondation + " and mpsc_contentCheck like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_contentResult":
                		sqlCondation = sqlCondation + " and mpsc_contentResult like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_group":
                		sqlCondation = sqlCondation + " and mpsc_group like '%" + keyword + "%'";
                	break;
                        
            		case "mpsc_empNum":
                		sqlCondation = sqlCondation + " and mpsc_empNum like '%" + keyword + "%'";
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
                string sql = "select * from  mes_pro_salary_check where    FlagDelete=0 " ;
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
        public mes_pro_salary_checkEntity GetEntity(string keyValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    mes_pro_salary_check
                            WHERE  
                           mpsc_id =@mpsc_id                           			
                            AND FlagDelete = 0  ");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@mpsc_id",keyValue)
            };
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<mes_pro_salary_checkEntity>();
        }
        #endregion

      
    }
}