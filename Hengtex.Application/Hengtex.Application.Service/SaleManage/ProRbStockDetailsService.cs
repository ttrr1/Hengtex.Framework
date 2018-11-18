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
using Hengtex.Application.Entity.Sale;

namespace Hengtex.Application.Service.SaleManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：染整详情档案管理
    /// </summary>
    public class ProRbStockDetailsService : RepositoryFactory<ProRbStockDetailsEntity>, IProRbStockDetailsService
    {
       

        #region 获取数据
        /// <summary>
        /// 染整详情列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProRbStockDetailsEntity> GetList()
        {
            var expression = LinqExtensions.True<ProRbStockDetailsEntity>();
           // expression = expression.And(t => t.FlagDelete == "0").And(t => t.aa_Dept != "废表");
            return this.ERPRepository().IQueryable(expression).OrderByDescending(t => t.mpp_batch).ToList();
        }
        /// <summary>
        /// 染整详情列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<ProRbStockDetailsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<ProRbStockDetailsEntity>();
            var queryParam = queryJson.ToJObject();
            string sqlCondation = "  ";

            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                sqlCondation = sqlCondation + " and " + condition + " = '" + keyword + "'"; 

            }
            //  string sql = "select d.*,m.* from mft_pack_packages d left join mft_pack_packs m on d.ppg_pack=m.mpp_num where FlagDelete=0   and ppg_stockIn is not null and ppg_sendNum is null and ppg_stockOut is null  ";
            string sql = "select d.*,m.* from con_pack_packages d left join con_pack_packs m on d.ppg_pack=m.mpp_num where FlagDelete=0   and ppg_stockIn is not null and ppg_sendNum is null and ppg_stockOut is null ";
            sql += sqlCondation;
            return this.ERPRepository().FindList(sql, pagination);
        }
      
        /// <summary>
        /// 染整详情档案实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ProRbStockDetailsEntity GetEntity(string keyValue)
        {

          return  null;
         //  return this.ERPRepository().FindList(strSql.ToString(),parameter);
           // return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

      
    }
}
