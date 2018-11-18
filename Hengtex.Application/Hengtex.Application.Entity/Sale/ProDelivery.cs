using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;
namespace Hengtex.Application.Entity.Sale
{
    /// <summary>
    /// 营销平台样品实体类
    /// </summary>
    public class ProDeliveryEntity : BaseEntity
    {


        /// <summary>
        /// 是否样品
        /// </summary>
        [Column("pd_flagSample")]
        public string pd_flagSample { set; get; }

        /// <summary>
        /// 单据号
        /// </summary>
        [Column("pd_num")]
        public string pd_num { set; get; }

        /// <summary>
        /// 日期
        /// </summary>
        [Column("pd_date")]
        public string pd_date { set; get; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [Column("pdd_name")]
        public string pdd_name { set; get; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Column("pd_custName")]
        public string pd_custName { set; get; }

        /// <summary>
        /// 客户区域
        /// </summary>
        [Column("pd_custArea")]
        public string pd_custArea { set; get; }

        /// <summary>
        /// 数量
        /// </summary>
        [Column("pdd_count")]
        public string pdd_count { set; get; }

        /// <summary>
        /// 支数
        /// </summary>
        [Column("pdd_zhishu")]
        public string pdd_zhishu { set; get; }

        /// <summary>
        /// 批号
        /// </summary>
        [Column("pdd_batch")]
        public string pdd_batch { set; get; }

        /// <summary>
        /// 当前规格
        /// </summary>
        [Column("pdd_spec")]
        public string pdd_spec { set; get; }
        /// <summary>
        /// 当前颜色
        /// </summary>
        [Column("pdd_color")]
        public string pdd_color { set; get; }
        /// <summary>
        /// 单位
        /// </summary>
        [Column("pdd_unit")]
        public string pdd_unit { set; get; }

        /// <summary>
        /// 单价
        /// </summary>
        [Column("pdd_unitPrice")]
        public string pdd_unitPrice { set; get; }


        /// <summary>
        /// 金额
        /// </summary>
        [Column("pdd_amount")]
        public string pdd_amount { set; get; }


        /// <summary>
        /// 业务部门
        /// </summary>
        [Column("pd_departName")]
        public string pd_departName { set; get; }
    }
}
