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
using System.Data;

namespace Hengtex.Application.Service.SaleManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：发货管理
    /// </summary>
    public class ProRbOrderService : RepositoryFactory<ProRbOrderEntity>, IProRbOrderService
    {
       

        #region 获取数据
        /// <summary>
        /// 发货列表
        /// </summary>
        /// <returns></returns>
        public    IEnumerable<ProRbOrderEntity> GetList()
        {
            var expression = LinqExtensions.True<ProRbOrderEntity>();
           // expression = expression.And(t => t.FlagDelete == "0").And(t => t.aa_Dept != "废表");
            return this.ERPRepository().IQueryable(expression).OrderByDescending(t => t.b_num).ToList();
        }
        /// <summary>
        /// 发货列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<ProRbOrderEntity> GetPageList(Pagination pagination, string queryJson,string user)
        {
            var expression = LinqExtensions.True<ProRbOrderEntity>();
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
                       
                        sqlCondation = sqlCondation + " and " + condition + " like '%"+keyword+"%'"; ;
                        break;
                    case "b_num":          //批号
                        
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "o_custName":    // 客户    

                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "b_color":          //颜色
                       
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "p_zhishu":          //支数
                       
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "o_dispatcher":          //调度

                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;

                    default:
                        break;
                }
            }
            
            //string sqlDelete = " delete from temp_batches where userName='" + user + "'  insert into temp_batches(batch,userName) select distinct b_num,'" + user + "'  from sal_orders a left join sal_order_batches b on a.o_num=b.b_order left join doc_sale_customers c on a.o_custNum=c.c_num where (a.FlagDelete=0 ) and (b.FlagDelete=0 )  " + sqlCondation + "  and a.o_dealType!='委托加工'  and o_flagEffect = 1  ";
            string sqlDelete = " delete from temp_batches where userName='"+user +"'  insert into temp_batches(batch,userName) select distinct b_num,'"+user +"'  from sale_orders a left join sale_order_batches b on a.o_num=b.b_order left join doc_sale_customers c on a.o_custNum=c.c_num where (a.FlagDelete=0 ) and (b.FlagDelete=0 )   and o_flagEffect = 1 "+sqlCondation;
            string sql = "select a.o_num,a.o_dateOrder,a.o_type,a.o_typeDeal,a.o_custName,a.o_dispatcher,a.o_departName,b.*,c_grade as khlx,c_region as custRegion from sale_orders a left join sale_order_batches b on a.o_num=b.b_order left join doc_sale_customers c on a.o_custNum=c.c_num where (a.FlagDelete=0 ) and (b.FlagDelete=0 )   and o_flagEffect = 1  ";
           // string sql = "select  a.o_num,a.o_dateOrder,a.o_type,a.o_dealType,a.o_custName,a.o_dispatcher,a.o_departName,b.*,c_grade as khlx,c_region as custRegion from sal_orders a left join sal_order_batches b on a.o_num=b.b_order left join doc_sale_customers c on a.o_custNum=c.c_num where (a.FlagDelete=0 ) and (b.FlagDelete=0 )    and a.o_dealType!=''委托加工''  and o_flagEffect = 1   ';";
            sql += sqlCondation;
          
            return this.ERPRepository().FindList(sql, pagination);
        }
      
        /// <summary>
        /// 发货档案实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ProRbOrderEntity GetEntity(string keyValue)
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
          return  this.ERPRepository().FindList(strSql.ToString(), parameter).FirstOrDefault<ProRbOrderEntity>();
         
        }
        /// <summary>
        /// 绒布订单列表
        /// </summary>
        /// <param name="pagination">分页查询</param>
        /// <param name="queryJson">查询条件</param>
        /// <param name="user">当前用户</param>
        /// <returns></returns>
        public DataTable GetPageListByDt(Pagination pagination, string queryJson, string user)
        {
            var expression = LinqExtensions.True<ProRbOrderEntity>();
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
                    case "o_custName":    // 客户    

                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "b_color":          //颜色

                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "p_zhishu":          //支数

                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;
                    case "o_dispatcher":          //调度

                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'"; ;

                        break;

                    default:
                        break;
                }
            }

            string sqlDelete = " delete from temp_batches where userName='"+user +"'  insert into temp_batches(batch,userName) select distinct b_num,'"+user +"'  from sale_orders a left join sale_order_batches b on a.o_num=b.b_order left join doc_sale_customers c on a.o_custNum=c.c_num where (a.FlagDelete=0 ) and (b.FlagDelete=0 )   and o_flagEffect = 1";


            string sql = "select a.o_num,a.o_dateOrder,a.o_type,a.o_typeDeal,a.o_custName,a.o_dispatcher,a.o_departName,b.*,c_grade as khlx,c_region as custRegion from sale_orders a left join sale_order_batches b on a.o_num=b.b_order left join doc_sale_customers c on a.o_custNum=c.c_num where (a.FlagDelete=0 ) and (b.FlagDelete=0 )   and o_flagEffect = 1  ";
            sql += sqlCondation;
            try
            {
                this.ERPRepository().ExecuteBySql(sqlDelete);
                this.ERPRepository().FindTable(sql, pagination);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
            return this.ERPRepository().FindTable(sql, pagination);
        }

        public DataTable GetDeliveryByNums(string user)
        {
            string sql1 = "select pdd_batch as batch,SUM(ISNULL(pdd_count,0)) as countF,MAX(pd_date) as dateF from inv_product_delivery_details d left join inv_product_deliveries m on d.pdd_delivery=m.pd_num "
                +"where FlagDelete=0  and pd_flagSample=0  and pd_flagTemp=0  "
                + "AND (pdd_batch in (select batch  from temp_batches where userName='" + user + "') ) group by pdd_batch";

            string sql = "select pdd_batch as batch,SUM(ISNULL(pdd_count,0)) as countF,MAX(pd_date) as dateF from inv_product_delivery_details d left join inv_product_deliveries m on d.pdd_delivery=m.pd_num"
               + " where FlagDelete=0  and pd_flagSample=0  and pd_flagTemp=0 "//未删除 非样品 非缓存
               + " AND (pdd_batch in (select batch  from temp_batches where userName='" + user + "') )"
               + " group by pdd_batch ";
            return this.ERPRepository().FindTable(sql);
        }

        public DataTable GetPacksByNums(string user)
        {
           
            string sql = "select ppg_batch,SUM(ISNULL(ppg_lengthReal,0)) as countAll from mft_pack_packages d left join mft_pack_packs m on d.ppg_pack=m.mpp_num "
                +"where FlagDelete=0 and mpp_packType<>'重打卷'  AND (ppg_batch in (select batch  from temp_batches where userName='" + user + "') )"+
                " group by ppg_batch";
            return this.ERPRepository().FindTable(sql);
        }

        public DataTable GetBatchesData(string batches)
        {
            StringBuilder sql = new StringBuilder();           

            if (!string.IsNullOrEmpty(batches))
            {
                sql.Append(" and op_batch in (" + batches + ")");
            }

            string str = "select op_batch,sum(op_mcount) as op_mcount from (select a.*,Convert(decimal(18,2),case when a.op_weftDensity<>0 then case  when b.b_typeFac='圆机' then a.op_count * 6 / (op_weftDensity * 20) when b.b_typeFac='织机' then a.op_count/op_weftDensity*isnull(d.p_countLayer,2) when  b.b_typeFac='提花机' then a.op_count/op_weftDensity*2 else 0 end else case when c.fclt_typeDensity = '大机' then a.op_count*4 else a.op_count*2 end end ) as op_mcount from   hr_salary_output a  left join sale_order_batches b on a.op_batch = b.b_num  left join fclt_facilities c on a.op_facilityId = c.fclt_num left join (select p_name , p_countLayer from doc_sale_pinhao where p_countLayer is not null union select old_pinhao as p_name,max(p_countLayer) as p_countLayer from doc_sale_pinhao where isnull(old_pinhao,'') <>'' and p_countLayer is not null group by old_pinhao) d on b.b_pinhao = d.p_name where (op_processType='织造' OR op_processType='圆机' OR op_processType='经编工序') and op_count<>0 and op_facilityId in ( select fclt_num FROM [ERP.Normal].[dbo].[fclt_facilities]  where fclt_proId='0002' union all select rtrim(sbbm) as fclt_num from openrowset('sqloledb','192.168.0.108';'sa';'hengtai',fydata.dbo.asbk) where gxfl in ('经编工序','织造','圆机')) " + sql.ToString() + " ) t group by op_batch";

            return this.ERPRepository().FindTable(str);
        }
        #endregion


    }
}
