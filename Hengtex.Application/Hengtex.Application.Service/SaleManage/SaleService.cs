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
    /// 描 述：样品档案管理
    /// </summary>
    public class SaleService : RepositoryFactory<SampleEntity>, ISaleService
    {
       

        #region 获取数据
        /// <summary>
        /// 样品列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SampleEntity> GetList()
        {
            var expression = LinqExtensions.True<SampleEntity>();
           // expression = expression.And(t => t.FlagDelete == "0").And(t => t.aa_Dept != "废表");
            return this.ERPRepository().IQueryable(expression).OrderByDescending(t => t.s_id).ToList();
        }
        /// <summary>
        /// 样品列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<SampleEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<SampleEntity>();
            var queryParam = queryJson.ToJObject();
            string sqlCondation = "  ";

            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "p_spec":            //品号
                        expression = expression.And(t => t.p_spec.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%"+keyword+"%'"; ;
                        break;
                    case "p_batch":          //批号
                        expression = expression.And(t => t.p_batch.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "p_model":          //属性吗
                        expression = expression.And(t => t.p_model.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "p_color":          //颜色
                        expression = expression.And(t => t.p_color.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "p_zhishu":          //支数
                        expression = expression.And(t => t.p_zhishu.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                   
                    default:
                        break;
                }
            }
            string t1 = " (select s.*,p.*   from inv_samples s left join inv_products p on s.s_code=p.p_code where s_stock='样品库'   AND s_flagUnused=0) ";
            string t2 = " (select code,SUM(count_in) as countAll_in,SUM(count_out) as countAll_out  from ( select sid_count as count_in,0 as count_out,sid_code as code from inv_product_stock_in_details d left join inv_product_stock_in m on d.sid_doc=m.psi_num where  FlagDelete=0 and psi_flagAccount=0 and psi_flagSample=1    union all select 0, sod_count,sod_code from inv_product_stock_out_details d left join inv_product_stock_out m on d.sod_doc=m.pso_num  where  FlagDelete=0 and pso_flagAccount=0 and pso_flagSample=1   union all select 0,pdd_count,pdd_code from inv_product_delivery_details d  left join inv_product_deliveries m on d.pdd_delivery=m.pd_num  where  FlagDelete=0 and pdd_flagAccount=0 and pd_flagSample=1     union all select case when psa_direction='库存增加' then psa_countAdjust else 0 end,case when psa_direction='库存增加' then 0 else psa_countAdjust end,psa_code from inv_product_stock_adjust where psa_flagAccount=0 and psa_stock='样品库' union all select pstd_count,0,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryTo in (select inv_name from doc_inv_inventorys where inv_typeStock='样品' ) union all select 0, pstd_count,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryFrom in (select inv_name from doc_inv_inventorys where inv_typeStock='样品' ) ) a group by code  ) ";
            string sql = " select * from "+t1+" a left join "+t2+ " b  on a.s_code =b.code  where  (ISNULL(a.s_count,0)+ ISNULL(b.countAll_in,0)-ISNULL(b.countAll_out,0)) >0 ";
            sql += sqlCondation;
            return this.ERPRepository().FindList(sql, pagination);
        }
      
        /// <summary>
        /// 样品档案实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public SampleEntity GetEntity(string keyValue)
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
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<SampleEntity>();
         //  return this.ERPRepository().FindList(strSql.ToString(),parameter);
           // return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

      
    }
}
