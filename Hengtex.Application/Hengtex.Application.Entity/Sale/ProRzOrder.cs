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
    public class ProRzOrderEntity : BaseEntity
    {


        /// <summary>
        /// 分类
        /// </summary>
        [Column("o_type")]
        public string o_type { set; get; }

        /// <summary>
        /// 订单类型
        /// </summary>
        [Column("o_dealType")]
        public string o_dealType { set; get; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Column("o_custName")]
        public string o_custName { set; get; }

        /// <summary>
        /// 客户等级
        /// </summary>
        [Column("khlx")]
        public string khlx { set; get; }

        /// <summary>
        /// 客户区域
        /// </summary>
        [Column("custregion")]
        public string custregion { set; get; }

        /// <summary>
        /// 数量
        /// </summary>
        [Column("b_count")]
        public string b_count { set; get; }

        /// <summary>
        /// 批号
        /// </summary>
        [Column("b_num")]
        public string b_num { set; get; }

        /// <summary>
        /// 品号
        /// </summary>
        [Column("b_pinhao")]
        public string b_pinhao { set; get; }

        /// <summary>
        /// 颜色
        /// </summary>
        [Column("b_color")]
        public string b_color { set; get; }

        /// <summary>
        /// 坯布下机米数
        /// </summary>
        [Column("hr_completeNum")]
        public string hr_completeNum { set; get; }
        /// <summary>
        /// 包装数量
        /// </summary>
        [Column("countPack")]
        public string countPack { set; get; }
        /// <summary>
        /// 发货数量
        /// </summary>
        [Column("countDelivery")]
        public string countDelivery { set; get; }

        /// <summary>
        /// 原始交期
        /// </summary>
        [Column("b_dateDeliveryArig")]
        public string b_dateDeliveryArig { set; get; }


        /// <summary>
        /// 最近发货日期
        /// </summary>
        [Column("dateLastDelivery")]
        public string dateLastDelivery { set; get; }


        /// <summary>
        /// 完工日期
        /// </summary>
        [Column("b_timeComplete")]
        public string b_timeComplete { set; get; }

        /// <summary>
        /// 调度员
        /// </summary>
        [Column("o_dispatcher")]
        public string o_dispatcher { set; get; }

        /// <summary>
        /// 签单部门
        /// </summary>
        [Column("o_departName")]
        public string o_departName { set; get; }

        /// <summary>
        /// 日期
        /// </summary>
        [Column("o_dateOrder")]
        public string o_dateOrder { set; get; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [Column("o_num")]
        public string o_num { set; get; }
    }
}
