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
using System;
using Hengtex.Application.Entity;
using System.Data;

namespace Hengtex.Application.Service.SaleManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：染整档案管理
    /// </summary>
    public class ProRbStockService : RepositoryFactory<ProRbStockEntity>, IProRbStockService
    {
       

        #region 获取数据
        /// <summary>
        /// 染整列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProRbStockEntity> GetList()
        {
            var expression = LinqExtensions.True<ProRbStockEntity>();
           // expression = expression.And(t => t.FlagDelete == "0").And(t => t.aa_Dept != "废表");
            return this.ERPRepository().IQueryable(expression).OrderByDescending(t => t.p_dateLastIn).ToList();
        }
        /// <summary>
        /// 染整列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<ProRbStockEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<ProRbStockEntity>();
            var queryParam = queryJson.ToJObject();
            string sqlCondation = "  ";

            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "b_pinhao":            //品号
                       // expression = expression.And(t => t.p_spec.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%"+keyword+"%'"; ;
                        break;
                    case "b_num":          //批号
                      //  expression = expression.And(t => t.p_batch.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "o_custName":          //属性吗
                       // expression = expression.And(t => t.o_custName.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "p_color":          //颜色
                        //expression = expression.And(t => t.p_color.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "p_zhishu":          //支数
                        expression = expression.And(t => t.p_zhishu.Contains(keyword));
                        sqlCondation = sqlCondation + " and " + condition + "like '%" + keyword + "%'"; ;

                        break;
                   
                    default:
                        break;
                }
            }
            //   string t1 = "(select  a.*,o_num,b_num,b_pinhao,o_custNum,o_custName,o_departName,c_region,o_dispatcher  from inv_products a  left join  sal_order_batches b on a.p_batch=b.b_num left join sal_orders o on b.b_order=o.o_num left join doc_sale_customers c on o.o_custNum=c.c_num  where (o.FlagDelete=0 or o.FlagDelete is null)   and (b.FlagDelete=0 or b.FlagDelete is null) and (p_spec like 'R%'  or p_code like 'R%')) ";
            //   string t2 = "(select code,SUM(count_in) as countAll_in,SUM(count_out) as countAll_out from ( select sid_count as count_in,0 as count_out,sid_code as code from inv_product_stock_in_details d left join inv_product_stock_in m on d.sid_doc=m.psi_num where  FlagDelete=0 and psi_flagAccount=0 and psi_flagSample=0 and psi_flagTech=0   union all select 0, sod_count,sod_code from inv_product_stock_out_details d left join inv_product_stock_out m on d.sod_doc=m.pso_num  where  FlagDelete=0 and pso_flagAccount=0 and pso_flagSample=0 and pso_flagTech=0   union all select 0,pdd_count,pdd_code from inv_product_delivery_details d  left join inv_product_deliveries m on d.pdd_delivery=m.pd_num  where  FlagDelete=0 and pdd_flagAccount=0 and pd_flagSample=0  and pd_flagTemp=0   union all select pid_count,0,pid_code from inv_product_outwardProcess_in_details d  left join inv_product_outwardProcess_in m on d.pid_doc=m.ppi_num  where  FlagDelete=0 and ppi_flagAccount=0  union all select 0,pod_count,pod_code from inv_product_outwardProcess_out_details d left join inv_product_outwardProcess_out m on d.pod_doc=m.ppo_num  where  FlagDelete=0 and ppo_flagAccount=0   union all select case when psa_direction='库存增加' then psa_countAdjust else 0 end,case when psa_direction='库存增加' then 0 else psa_countAdjust end,psa_code from inv_product_stock_adjust where psa_flagAccount=0 and psa_stock!='样品库' and psa_stock!='技术部' union all select pstd_count,0,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryTo in (select inv_name from doc_inv_inventorys where inv_typeStock='成品' ) union all select 0, pstd_count,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryFrom in (select inv_name from doc_inv_inventorys where inv_typeStock='成品' ) ) a group by code ) ";
            //   string sql = "select * from "+ t1 + " a left join "+t2+" b on a.p_code =b.code  where  (ISNULL(a.p_count,0)+ ISNULL(b.countAll_in,0)-ISNULL(b.countAll_out,0)) >0 ";
            //   sql += sqlCondation;
            string t1 = "select  a.*,o_num,b_num,b_pinhao,o_custNum,o_custName,o_departName,c_region,o_dispatcher   from inv_products a  left join  sale_order_batches b on a.p_batch=b.b_num left join sale_orders o on b.b_order=o.o_num left join doc_sale_customers c on o.o_custNum=c.c_num  where (o.FlagDelete=0 or o.FlagDelete is null)   and (b.FlagDelete=0 or b.FlagDelete is null) and p_spec not like 'R%'  and p_code not like 'R%'  ";
            string t2 = "select code,SUM(count_in) as countAll_in,SUM(count_out) as countAll_out  from ( select sid_count as count_in,0 as count_out,sid_code as code from inv_product_stock_in_details d left join inv_product_stock_in m on d.sid_doc=m.psi_num where  FlagDelete=0 and psi_flagAccount=0 and psi_flagSample=0 and psi_flagTech=0   union all select 0, sod_count,sod_code from inv_product_stock_out_details d left join inv_product_stock_out m on d.sod_doc=m.pso_num  where  FlagDelete=0 and pso_flagAccount=0 and pso_flagSample=0 and pso_flagTech=0   union all select 0,pdd_count,pdd_code from inv_product_delivery_details d  left join inv_product_deliveries m on d.pdd_delivery=m.pd_num  where  FlagDelete=0 and pdd_flagAccount=0 and pd_flagSample=0  and pd_flagTemp=0   union all select pid_count,0,pid_code from inv_product_outwardProcess_in_details d  left join inv_product_outwardProcess_in m on d.pid_doc=m.ppi_num  where  FlagDelete=0 and ppi_flagAccount=0  union all select 0,pod_count,pod_code from inv_product_outwardProcess_out_details d left join inv_product_outwardProcess_out m on d.pod_doc=m.ppo_num  where  FlagDelete=0 and ppo_flagAccount=0   union all select case when psa_direction='库存增加' then psa_countAdjust else 0 end,case when psa_direction='库存增加' then 0 else psa_countAdjust end,psa_code from inv_product_stock_adjust where psa_flagAccount=0 and psa_stock!='样品库' and psa_stock!='技术部' union all select pstd_count,0,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryTo in (select inv_name from doc_inv_inventorys where inv_typeStock='成品' ) union all select 0, pstd_count,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryFrom in (select inv_name from doc_inv_inventorys where inv_typeStock='成品' ) ) a group by code  ";
            string sql = "select * from "+t1+" a left join "+t2+" b on a.p_code =b.code  where  (ISNULL(a.p_count,0)+ ISNULL(b.countAll_in,0)-ISNULL(b.countAll_out,0)) >0";
            sql += sqlCondation;
            return this.ERPRepository().FindList(sql, pagination);
        }
      
        /// <summary>
        /// 染整档案实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ProRbStockEntity GetEntity(string keyValue)
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
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<ProRbStockEntity>();
         //  return this.ERPRepository().FindList(strSql.ToString(),parameter);
           // return this.ERPRepository().FindEntity(keyValue);
        }

        public DataTable GetProSumCount(string date)
        {
            string sql = "select code,SUM(count_in) as countAll_in,SUM(count_out) as countAll_out from " +
                 "( " +
                 "select sid_count as count_in,0 as count_out,sid_code as code from inv_product_stock_in_details d left join inv_product_stock_in m on d.sid_doc=m.psi_num " +
                 "where  FlagDelete=0 and psi_flagSample=0 and psi_flagTech=0   and psi_date='" + date + "' " +
                 "union all " +
                 "select 0, sod_count,sod_code from inv_product_stock_out_details d left join inv_product_stock_out m on d.sod_doc=m.pso_num  " +
                 "where  FlagDelete=0  and pso_flagSample=0 and pso_flagTech=0   and pso_date='" + date + "' " +
                 "union all " +
                 "select 0,pdd_count,pdd_code from inv_product_delivery_details d  left join inv_product_deliveries m on d.pdd_delivery=m.pd_num  " +
                 "where  FlagDelete=0  and pd_flagSample=0  and pd_flagTemp=0   and pd_date='" + date + "' " +
                 "union all " +
                 "select pid_count,0,pid_code from inv_product_outwardProcess_in_details d  left join inv_product_outwardProcess_in m on d.pid_doc=m.ppi_num  " +
                 "where  FlagDelete=0 and ppi_date='" + date + "' " +
                 "union all " +
                 "select 0,pod_count,pod_code from inv_product_outwardProcess_out_details d left join inv_product_outwardProcess_out m on d.pod_doc=m.ppo_num  " +
                 "where  FlagDelete=0 and ppo_date='" + date + "' " +
                 "union all " +
                 "select case when psa_direction='库存增加' then psa_countAdjust else 0 end,case when psa_direction='库存增加' then 0 else psa_countAdjust end,psa_code from inv_product_stock_adjust " +
                 "where psa_flagAccount=0 and psa_stock!='样品库' and psa_stock!='技术部'  and psa_dateAdjust='" + date + "' " +
                 "union all " +//产品调拨单入
                "select pstd_count,0,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num " +
                "where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryTo in (select inv_name from doc_inv_inventorys where inv_typeStock='成品' and pst_date='" + date + "'  ) " +
                "union all " +//产品调拨单出
                "select 0, pstd_count,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num " +
                "where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryFrom in (select inv_name from doc_inv_inventorys where inv_typeStock='成品'  and pst_date='" + date + "'  ) " +
                 ") a " +
                 "group by code  ";
            return this.ERPRepository().FindTable(sql);
        }

        public DataTable GetProductSumCountNotAccounted()
        {
            string sql = "select code,SUM(count_in) as countAll_in,SUM(count_out) as countAll_out from " +
                 "( " +
                 "select sid_count as count_in,0 as count_out,sid_code as code from inv_product_stock_in_details d left join inv_product_stock_in m on d.sid_doc=m.psi_num " +
                 "where  FlagDelete=0 and psi_flagAccount=0 and psi_flagSample=0 and psi_flagTech=0   " +
                 "union all " +
                 "select 0, sod_count,sod_code from inv_product_stock_out_details d left join inv_product_stock_out m on d.sod_doc=m.pso_num  " +
                 "where  FlagDelete=0 and pso_flagAccount=0 and pso_flagSample=0 and pso_flagTech=0   " +
                 "union all " +
                 "select 0,pdd_count,pdd_code from inv_product_delivery_details d  left join inv_product_deliveries m on d.pdd_delivery=m.pd_num  " +
                 "where  FlagDelete=0 and pdd_flagAccount=0 and pd_flagSample=0  and pd_flagTemp=0   " +
                 "union all " +
                 "select pid_count,0,pid_code from inv_product_outwardProcess_in_details d  left join inv_product_outwardProcess_in m on d.pid_doc=m.ppi_num  " +
                 "where  FlagDelete=0 and ppi_flagAccount=0  " +
                 "union all " +
                 "select 0,pod_count,pod_code from inv_product_outwardProcess_out_details d left join inv_product_outwardProcess_out m on d.pod_doc=m.ppo_num  " +
                 "where  FlagDelete=0 and ppo_flagAccount=0   " +
                 "union all " +
                 "select case when psa_direction='库存增加' then psa_countAdjust else 0 end,case when psa_direction='库存增加' then 0 else psa_countAdjust end,psa_code from inv_product_stock_adjust " +
                 "where psa_flagAccount=0 and psa_stock!='样品库' and psa_stock!='技术部' " +
                 "union all " +//产品调拨单入
                "select pstd_count,0,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num " +
                "where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryTo in (select inv_name from doc_inv_inventorys where inv_typeStock='成品' ) " +
                "union all " +//产品调拨单出
                "select 0, pstd_count,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num " +
                "where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryFrom in (select inv_name from doc_inv_inventorys where inv_typeStock='成品' ) " +
                 ") a " +
                 "group by code  ";
            return this.ERPRepository().FindTable(sql);
        }

        public DataTable GetProductSumCountNotAccounted1()
        {
            string sql = "select code,SUM(count_in) as countAll_in,SUM(count_out) as countAll_out from " +
                "( " +
                "select sid_count as count_in,0 as count_out,sid_code as code from inv_product_stock_in_details d left join inv_product_stock_in m on d.sid_doc=m.psi_num " +
                "where  FlagDelete=0 and psi_flagAccount=0 and psi_flagSample=1    " +
                "union all " +
                "select 0, sod_count,sod_code from inv_product_stock_out_details d left join inv_product_stock_out m on d.sod_doc=m.pso_num  " +
                "where  FlagDelete=0 and pso_flagAccount=0 and pso_flagSample=1   " +
                "union all " +
                "select 0,pdd_count,pdd_code from inv_product_delivery_details d  left join inv_product_deliveries m on d.pdd_delivery=m.pd_num  " +
                "where  FlagDelete=0 and pdd_flagAccount=0 and pd_flagSample=1     " +
                "union all " +
                "select case when psa_direction='库存增加' then psa_countAdjust else 0 end,case when psa_direction='库存增加' then 0 else psa_countAdjust end,psa_code from inv_product_stock_adjust " +
                "where psa_flagAccount=0 and psa_stock='样品库' " +
                "union all " +//产品调拨单入
               "select pstd_count,0,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num " +
               "where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryTo in (select inv_name from doc_inv_inventorys where inv_typeStock='样品' ) " +
               "union all " +//产品调拨单出
               "select 0, pstd_count,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num " +
               "where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryFrom in (select inv_name from doc_inv_inventorys where inv_typeStock='样品' ) " +
                ") a " +
                "group by code  ";
            return this.ERPRepository().FindTable(sql);
        }

        /// <summary>
        /// 查询样品实存
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="code"></param>
        /// <param name="BNum"></param>
        /// <param name="color"></param>
        /// <param name="spec"></param>
        /// <param name="model"></param>
        /// <param name="dispather"></param>
        /// <param name="Used"></param>
        /// <returns></returns>
        public DataTable SearchBy(string stock, string code, string BNum, string color, string spec, string model, string dispather, bool Used)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select  s.*,p.* from inv_samples s left join inv_products p on s.s_code=p.p_code where s_stock='" + stock + "'  ");

            if (Used)
            {
                sql.Append(" AND s_flagUnused=0 ");
            }

            if (String.IsNullOrEmpty(code) == false)
                sql.Append(" AND s_code like '%" + code + "%'");//产品编码
            if (String.IsNullOrEmpty(BNum) == false)
                sql.Append(" AND p_batch like '%" + BNum + "%'");//批次
            if (String.IsNullOrEmpty(color) == false)
                sql.Append(" AND p_color like '%" + color + "%'");
            if (String.IsNullOrEmpty(spec) == false)
                sql.Append(" AND p_spec like '%" + spec + "%'");
            if (String.IsNullOrEmpty(model) == false)
                sql.Append(" AND p_model like '%" + model + "%'");
            if (String.IsNullOrEmpty(dispather) == false)
                sql.Append(" AND p_dispatcher like '%" + dispather + "%'");//调度员

            return this.ERPRepository().FindTable(sql.ToString());
        }

        public DataTable GetPageListByDt(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            string sqlCondation = "  ";

            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "b_pinhao":            //品号
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;
                        break;
                    case "b_num":          //批号
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "o_custName":          //属性吗
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "p_color":          //颜色
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "p_zhishu":          //支数
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;

                    default:
                        break;
                }
            }
            string t1 = "(select  a.*,o_num,b_num,b_pinhao,o_custNum,o_custName,o_departName,c_region,o_dispatcher   from inv_products a  left join  sale_order_batches b on a.p_batch=b.b_num left join sale_orders o on b.b_order=o.o_num left join doc_sale_customers c on o.o_custNum=c.c_num  where (o.FlagDelete=0 or o.FlagDelete is null)   and (b.FlagDelete=0 or b.FlagDelete is null) and p_spec not like 'R%'  and p_code not like 'R%')  ";
            string t2 = "(select code,SUM(count_in) as countAll_in,SUM(count_out) as countAll_out  from ( select sid_count as count_in,0 as count_out,sid_code as code from inv_product_stock_in_details d left join inv_product_stock_in m on d.sid_doc=m.psi_num where  FlagDelete=0 and psi_flagAccount=0 and psi_flagSample=0 and psi_flagTech=0   union all select 0, sod_count,sod_code from inv_product_stock_out_details d left join inv_product_stock_out m on d.sod_doc=m.pso_num  where  FlagDelete=0 and pso_flagAccount=0 and pso_flagSample=0 and pso_flagTech=0   union all select 0,pdd_count,pdd_code from inv_product_delivery_details d  left join inv_product_deliveries m on d.pdd_delivery=m.pd_num  where  FlagDelete=0 and pdd_flagAccount=0 and pd_flagSample=0  and pd_flagTemp=0   union all select pid_count,0,pid_code from inv_product_outwardProcess_in_details d  left join inv_product_outwardProcess_in m on d.pid_doc=m.ppi_num  where  FlagDelete=0 and ppi_flagAccount=0  union all select 0,pod_count,pod_code from inv_product_outwardProcess_out_details d left join inv_product_outwardProcess_out m on d.pod_doc=m.ppo_num  where  FlagDelete=0 and ppo_flagAccount=0   union all select case when psa_direction='库存增加' then psa_countAdjust else 0 end,case when psa_direction='库存增加' then 0 else psa_countAdjust end,psa_code from inv_product_stock_adjust where psa_flagAccount=0 and psa_stock!='样品库' and psa_stock!='技术部' union all select pstd_count,0,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryTo in (select inv_name from doc_inv_inventorys where inv_typeStock='成品' ) union all select 0, pstd_count,pstd_code from inv_product_stock_toStock_details d left join inv_product_stock_toStock m on d.pstd_doc=m.pst_num where  FlagDelete=0 and pst_flagAccount=0  and pst_inventoryFrom in (select inv_name from doc_inv_inventorys where inv_typeStock='成品' ) ) a group by code ) ";
            string sql = "select * from " + t1 + " a left join " + t2 + " b on a.p_code =b.code  where  (ISNULL(a.p_count,0)+ ISNULL(b.countAll_in,0)-ISNULL(b.countAll_out,0)) >0";
            sql += sqlCondation;
            
            return this.ERPRepository().FindTable(sql, pagination);
        }

        #endregion


    }
}
