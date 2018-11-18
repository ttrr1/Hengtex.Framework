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
    public class ProRzStockEntity : BaseEntity
    {

       
        /// <summary>
        /// 产品编码
        /// </summary>
        [Column("p_code")]
        public string p_code { set; get; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [Column("p_name")]
        public string p_name { set; get; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Column("o_custName")]
        public string o_custName { set; get; }

        /// <summary>
        /// 业务区域
        /// </summary>
        [Column("c_region")]
        public string c_region { set; get; }

        /// <summary>
        /// 当前库存
        /// </summary>
        [Column("p_count")]
        public string p_count { set; get; }

        /// <summary>
        /// 支数
        /// </summary>
        [Column("p_zhishu")]
        public string p_zhishu { set; get; }

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
        /// 当前颜色
        /// </summary>
        [Column("p_color")]
        public string p_color { set; get; }
        /// <summary>
        /// 单位
        /// </summary>
        [Column("p_unit")]
        public string p_unit { set; get; }

        /// <summary>
        /// 等级
        /// </summary>
        [Column("p_grade")]
        public string p_grade { set; get; }


        /// <summary>
        /// 入库日期
        /// </summary>
        [Column("p_dateLastIn")]
        public string p_dateLastIn { set; get; }


        /// <summary>
        /// 业务部门
        /// </summary>
        [Column("o_departName")]
        public string o_departName { set; get; }


        /// <summary>
        /// 积压说明
        /// </summary>
        [Column("p_overstockDes")]
        public string p_overstockDes { set; get; }
    }
}
