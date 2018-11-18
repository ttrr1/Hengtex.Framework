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
    public class mes_pro_checkService : RepositoryFactory<mes_pro_checkEntity>, Imes_pro_checkService
    {
       

        #region 获取数据
        /// <summary>
        /// 根据完工工序ID获取工序设定表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<mes_pro_checkEntity> GetList(Dictionary<string,string> fields)
        {
            string sql = "SELECT  *  FROM mes_pro_check WHERE  FlagDelete = 0 ";
            foreach(string key in fields.Keys)
            {
                sql = sql + " and "+key +" = '"+fields[key]+"'";
            }
         
            return this.ERPRepository().FindList(sql);
        }

        public IEnumerable<mes_pro_checkEntity>  GetList(string where)
        {
            string sql = "SELECT  *  FROM mes_pro_check WHERE  FlagDelete = 0 ";
           
                sql = sql + where;          
            return this.ERPRepository().FindList(sql);
        }
        /// <summary>
        /// 工序设定表
        /// </summary>

        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<mes_pro_checkEntity> GetPageList(Pagination pagination, string queryJson)

        {
            var expression = LinqExtensions.True<mes_pro_checkEntity>();
            var queryParam = queryJson.ToJObject();
            string sqlCondation = "  ";
            string checktype = queryParam["checktype"].ToString();
            sqlCondation = sqlCondation + " and mpc_TypeFlag = '" + checktype + "'";

            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                
                switch (condition)
                {
                    case "mpc_panNo":            //盘头号
                        sqlCondation = sqlCondation + " and mpc_panNo like '%" + keyword + "%'";
                        break;
                    case "mpc_batch":            //批次
                        sqlCondation = sqlCondation + " and mpc_batch like '%" + keyword + "%'";
                        break;
                    case "mpc_qname":            //质量名称
                        sqlCondation = sqlCondation + " and mpc_qname like '%" + keyword + "%'";
                        break;
                    case "mpc_procedureName":            //工序名称
                        sqlCondation = sqlCondation + " and mpc_procedureName like '%" + keyword + "%'";
                        break;
                    case "All":

                         sqlCondation = sqlCondation + " and (mpc_panNo like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or mpc_procedureName like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or mpc_batch like '%" + keyword + "%'";
                         sqlCondation = sqlCondation + " or mpc_qname like '%" + keyword + "%')";
                        break;
                    default:
                        break;
                }
                
            }
            try
            {
                string sql = "select * from  mes_pro_check where    FlagDelete=0 ";
                sql += sqlCondation;
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
        public mes_pro_checkEntity GetEntity(string keyValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    mes_pro_check
                            WHERE   mpc_id  = @mpc_id 
                            AND FlagDelete = 0  ");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@mpc_id",keyValue)
            };
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<mes_pro_checkEntity>();
         
        }

        /// <summary>
        /// 应用（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="model">应用实体</param>
        /// <returns></returns>
      
        public void SaveForm(string keyValue, mes_pro_checkEntity model)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                model.Modify(keyValue);
                this.BaseRepository().Update(model);
            }
            else
            {
                try
                {

                    model.Create();
                    model.mpc_num = this.BaseRepository("server=192.168.0.245;database=ERP.Normal;uid=sa;pwd=hengtai").GetNumber("mes_pro_check");
                    // model.mpr_num = this.ERPRepository().GetNumber("mes_pro_records");
                    SqlOrperator<mes_pro_checkEntity> sqlHelper = new SqlOrperator<mes_pro_checkEntity>(model);
                    string sqlInsert = sqlHelper.GetStringForAdd("mes_pro_check", false, "mpc_id");
                    this.ERPRepository().ExecuteBySql(sqlInsert);

                }
                catch (Exception w)
                {
                    throw w;
                }

            }
        }
        #endregion


    }
}
