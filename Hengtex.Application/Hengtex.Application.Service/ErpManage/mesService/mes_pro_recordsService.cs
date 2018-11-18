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
    public class  mes_pro_recordsService : RepositoryFactory<mes_pro_recordsEntity>, Imes_pro_recordsService
    {


        #region 获取数据
        /// <summary>
        /// 根据完工工序ID获取工序设定表
        /// </summary>
        /// <returns></returns>
        public IEnumerable< mes_pro_recordsEntity> GetList(Dictionary<string,string> fields)
        {
            string sql = "SELECT  *  FROM mes_pro_records WHERE  FlagDelete = 0 ";
            foreach(string key in fields.Keys)
            {
                if (key == "where")
                {
                    sql = sql + " and " + fields[key];
                }
                else
                {
                    sql = sql + " and " + key + " = '" + fields[key] + "'";

                }
            }
         
            return this.ERPRepository().FindList(sql);
        }
       
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<mes_pro_recordsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<mes_pro_recordsEntity>();
            var queryParam = queryJson.ToJObject();
            string sqlCondation = "  ";
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {               
                        	                        
            		case "mpr_group":
                		sqlCondation = sqlCondation + " and mpr_group like '%" + keyword + "%'";
                	break;
                        
            		case "mpr_batch":
                		sqlCondation = sqlCondation + " and mpr_batch like '%" + keyword + "%'";
                	break;
                        
            		case "mpr_pinhao":
                		sqlCondation = sqlCondation + " and mpr_pinhao like '%" + keyword + "%'";
                	break;
                        
            		case "mpr_color":
                		sqlCondation = sqlCondation + " and mpr_color like '%" + keyword + "%'";
                	break;
                        
            		case "mpr_attr":
                		sqlCondation = sqlCondation + " and mpr_attr like '%" + keyword + "%'";
                	break;
                                                            		            		                        
            		case "mpr_empNum":
                		sqlCondation = sqlCondation + " and mpr_empNum like '%" + keyword + "%'";
                	break;
                        
            		case "mpr_empName":
                		sqlCondation = sqlCondation + " and mpr_empName like '%" + keyword + "%'";
                	break;
                        
            		case "mpr_num":
                		sqlCondation = sqlCondation + " and mpr_num like '%" + keyword + "%'";
                	break;
                                    	            		                                    		                        
            		case "mpr_panNo":
                		sqlCondation = sqlCondation + " and mpr_panNo like '%" + keyword + "%'";
                	break;
                                    		                       
            		case "mpr_taskNum":
                		sqlCondation = sqlCondation + " and mpr_taskNum like '%" + keyword + "%'";
                	break;
                                   		                        
            		case "mpr_location":
                		sqlCondation = sqlCondation + " and mpr_location like '%" + keyword + "%'";
                	break;
                        
            		case "mpr_locationName":
                		sqlCondation = sqlCondation + " and mpr_locationName like '%" + keyword + "%'";
                	break;
                        
            		case "mpr_checkResult":
                		sqlCondation = sqlCondation + " and mpr_checkResult like '%" + keyword + "%'";
                	break;
                                    		                        
            		case "mpr_Person":
                		sqlCondation = sqlCondation + " and mpr_Person like '%" + keyword + "%'";
                	break;
                                    		           	                                   	                                    		                                    	                        
            		case "mpr_procedureName":
                		sqlCondation = sqlCondation + " and mpr_procedureName like '%" + keyword + "%'";
                	break;
                                    		                        
            		case "mpr_fcltNum":
                		sqlCondation = sqlCondation + " and mpr_fcltNum like '%" + keyword + "%'";
                	break;
                        
            		case "mpr_fcltName":
                		sqlCondation = sqlCondation + " and mpr_fcltName like '%" + keyword + "%'";
                	break;
                      	              
                    case "All":             
                       
                        sqlCondation = sqlCondation + " and (mpr_fcltNum like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or mpr_panNo like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or mpr_procedureName like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or mpr_Person like '%" + keyword + "%')";
                        break;                  
                    default:
                        break;
                }
            }
            try 
            {                
                string sql = "select * from  mes_pro_records where    FlagDelete=0 " ;
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
        public mes_pro_recordsEntity GetEntity(string keyValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    mes_pro_records
                            WHERE  
                           mpr_id =@mpr_id                           			
                            AND FlagDelete = 0  ");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@mpr_id",keyValue)
            };
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<mes_pro_recordsEntity>();
        }
        #endregion


        /// <summary>
        /// 应用（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="model">应用实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, mes_pro_recordsEntity model)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                model.Modify(keyValue);
                SqlOrperator<mes_pro_recordsEntity> sqlHelper = new SqlOrperator<mes_pro_recordsEntity>(model);
                string sql = sqlHelper.GetStringForUpdate("mes_pro_records", "mpr_num", keyValue);
                this.ERPRepository().ExecuteBySql(sql);
            }
            else
            {
                try
                {

                    model.Create();
                    model.mpr_num = this.BaseRepository("server=192.168.0.245;database=ERP.Normal;uid=sa;pwd=hengtai").GetNumber("mes_pro_records");
                   // model.mpr_num = this.ERPRepository().GetNumber("mes_pro_records");
                    SqlOrperator<mes_pro_recordsEntity> sqlHelper = new SqlOrperator<mes_pro_recordsEntity>(model);
                    string sqlInsert = sqlHelper.GetStringForAdd("mes_pro_records",false, "mpr_id");
                    this.ERPRepository().ExecuteBySql(sqlInsert);

                }
                catch (Exception w)
                {
                    throw w;
                }
               
            }
        }


        public void UpdateByKey(string table,Dictionary<string,string> keys,Dictionary<string,string> fields)
        {
            string sql = "update "+ table + " set ";
            foreach(var str in fields.Keys)
            {
                sql += str + "= '" + fields[str] + "',";
            }
            sql = sql.Substring(0, sql.Length - 1);
            foreach(var key in keys.Keys)
            {
                sql = sql + " where " + key + "= '"+keys[key]+"'";

            }         
            this.ERPRepository().ExecuteBySql(sql);

        }
    }
}