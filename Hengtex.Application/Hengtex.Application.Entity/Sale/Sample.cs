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
    public class SampleEntity : BaseEntity
    {

        /// <summary>
        /// ID
        /// </summary>
        [Column("s_id")]
        public string s_id { set; get; }
        /// <summary>
        /// 产品编码
        /// </summary>
        [Column("s_code")]
        public string s_code { set; get; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [Column("p_name")]
        public string p_name { set; get; }

        /// <summary>
        /// 属性码
        /// </summary>
        [Column("p_model")]
        public string p_model { set; get; }

        /// <summary>
        /// 盘点库存
        /// </summary>
        [Column("s_countCheck")]
        public string s_countCheck { set; get; }

        /// <summary>
        /// 当前库存
        /// </summary>
        [Column("s_count")]
        public string s_count { set; get; }

        /// <summary>
        /// 支数
        /// </summary>
        [Column("p_zhishu")]
        public string p_zhishu { set; get; }

        /// <summary>
        /// 批号
        /// </summary>
        [Column("p_batch")]
        public string p_batch { set; get; }

        /// <summary>
        /// 当前规格
        /// </summary>
        [Column("p_spec")]
        public string p_spec { set; get; }
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
        /// 样品说明
        /// </summary>
        [Column("s_desc")]
        public string s_desc { set; get; }


        /// <summary>
        /// 备注
        /// </summary>
        [Column("s_note")]
        public string s_note { set; get; }
    }
}
