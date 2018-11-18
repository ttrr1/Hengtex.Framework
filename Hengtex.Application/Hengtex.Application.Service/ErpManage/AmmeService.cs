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
    public class AmmeService : RepositoryFactory<AmmeEntity>, IAmmeService
    {
       

        #region 获取数据
        /// <summary>
        /// 电表列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AmmeEntity> GetList()
        {
            var expression = LinqExtensions.True<AmmeEntity>();
            expression = expression.And(t => t.FlagDelete == "0").And(t => t.a_Dept != "废表");
            return this.ERPRepository().IQueryable(expression).OrderByDescending(t => t.CreationDate).ToList();
        }
        /// <summary>
        /// 电表列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<AmmeEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<AmmeEntity>();
            var queryParam = queryJson.ToJObject();
            string sqlCondation = "  ";
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
              
                    case "All":

                        sqlCondation = sqlCondation + " and (a_ammeName like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or a_ammeNo like '%" + keyword + "%'";

                        sqlCondation = sqlCondation + " or a_DeptTow like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or a_DeptThree like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or a_Dept like '%" + keyword + "%')";
                        break;
                    default:
                        break;
                }
            }
            try
            {
                string sql = "select * from  fclt_ammeters where    1=1    AND FlagDelete = 0  AND a_Dept <> '废表' ";
                sql += sqlCondation;
                return this.ERPRepository().FindList(sql, pagination).OrderBy(t => t.a_ammeNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



       

        /// <summary>
        /// 电表档案实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AmmeEntity GetEntity(string keyValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    fclt_ammeters
                            WHERE   a_ammeNo  = @a_ammeNo 
                            AND FlagDelete = 0  AND a_Dept <> '废表' Order By a_ammeNo");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@a_ammeNo",keyValue)
            };
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<AmmeEntity>();
         //  return this.ERPRepository().FindList(strSql.ToString(),parameter);
           // return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

      
    }
}
