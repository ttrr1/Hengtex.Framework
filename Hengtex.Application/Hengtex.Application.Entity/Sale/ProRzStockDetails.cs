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
    /// 营销平染整详情实体类
    /// </summary>
    public class ProRzStockDetailsEntity : BaseEntity
    {

        /// <summary>
        /// 日期
        /// </summary>
        [Column("mpp_dateCheck")]
        public string mpp_dateCheck { set; get; }
        /// <summary>
        /// 批次
        /// </summary>
        [Column("mpp_batch")]
        public string mpp_batch { set; get; }
        /// <summary>
        /// 品号
        /// </summary>
        [Column("mpp_pinhao")]
        public string mpp_pinhao { set; get; }

        /// <summary>
        /// 颜色
        /// </summary>
        [Column("mpp_color")]
        public string mpp_color { set; get; }

        /// <summary>
        /// 盘点库存
        /// </summary>
        [Column("s_countCheck")]
        public string s_countCheck { set; get; }

        /// <summary>
        /// 包号
        /// </summary>
        [Column("ppg_number")]
        public string ppg_number { set; get; }

        /// <summary>
        /// 等级
        /// </summary>
        [Column("ppg_grade")]
        public string ppg_grade { set; get; }

        /// <summary>
        /// 内降
        /// </summary>
        [Column("ppg_flagLower")]
        public string ppg_flagLower { set; get; }

        /// <summary>
        /// 匹重
        /// </summary>
        [Column("ppg_weight")]
        public string ppg_weight { set; get; }
        /// <summary>
        /// 段数
        /// </summary>
        [Column("ppg_counts")]
        public string ppg_counts { set; get; }
        /// <summary>
        /// 结辫
        /// </summary>
        [Column("ppg_jiebian")]
        public string ppg_jiebian { set; get; }

        /// <summary>
        /// 毛长
        /// </summary>
        [Column("ppg_lengthReal")]
        public string ppg_lengthReal { set; get; }


        /// <summary>
        /// 净长
        /// </summary>
        [Column("ppg_length")]
        public string ppg_length { set; get; }


        /// <summary>
        /// 零布
        /// </summary>
        [Column("ppg_pieces")]
        public string ppg_pieces { set; get; }

        /// <summary>
        /// 废料
        /// </summary>
        [Column("ppg_wastes")]
        public string ppg_wastes { set; get; }

        /// <summary>
        /// 幅宽
        /// </summary>
        [Column("ppg_width")]
        public string ppg_width { set; get; }


        /// <summary>
        /// 毛高
        /// </summary>
        [Column("ppg_height")]
        public string ppg_height { set; get; }


        /// <summary>
        /// 克重
        /// </summary>
        [Column("ppg_weightEvery")]
        public string ppg_weightEvery { set; get; }


        /// <summary>
        /// 客户包号
        /// </summary>
        [Column("ppg_numberCust")]
        public string ppg_numberCust { set; get; }

    }
}
