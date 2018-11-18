using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-01-19 15:26
    /// 描 述：con_workshop_turnover
    /// </summary>
    public class con_workshop_turnover_detailEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("WTD_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? wtd_id { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        /// <returns></returns>
        [Column("WTD_NUM")]
        public string wtd_num { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        /// <returns></returns>
        [Column("WTD_WS")]
        public string wtd_ws { get; set; }
        /// <summary>
        /// 原料编码
        /// </summary>
        /// <returns></returns>
        [Column("WTD_BATCHCODE")]
        public string wtd_batchCode { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        /// <returns></returns>
        [Column("WTD_BATCH")]
        public string wtd_batch { get; set; }
        /// <summary>
        /// 原料名称
        /// </summary>
        /// <returns></returns>
        [Column("WTD_NAME")]
        public string wtd_name { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        /// <returns></returns>
        [Column("WTD_SPEC")]
        public string wtd_spec { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        /// <returns></returns>
        [Column("WTD_TYPE")]
        public string wtd_type { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        /// <returns></returns>
        [Column("WTD_COLOR")]
        public string wtd_color { get; set; }
        /// <summary>
        /// 产地
        /// </summary>
        /// <returns></returns>
        [Column("WTD_FROM")]
        public string wtd_from { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        /// <returns></returns>
        [Column("WTD_UNIT")]
        public string wtd_unit { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        /// <returns></returns>
        [Column("WTD_COUNT")]
        public decimal? wtd_count { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        /// <returns></returns>
        [Column("WTD_UNITPRICE")]
        public decimal? wtd_unitPrice { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        /// <returns></returns>
        [Column("WTD_AMOUNT")]
        public decimal? wtd_amount { get; set; }
        /// <summary>
        /// 成本单价
        /// </summary>
        /// <returns></returns>
        [Column("WTD_UNITPRICECOST")]
        public decimal? wtd_unitPriceCost { get; set; }
        /// <summary>
        /// 成本金额
        /// </summary>
        /// <returns></returns>
        [Column("WTD_AMOUNTCOST")]
        public decimal? wtd_amountCost { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("WTD_REMARKS")]
        public string wtd_remarks { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [Column("CREATIONDATE")]
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        [Column("CREATEDBY")]
        public string CreatedBy { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        /// <returns></returns>
        [Column("LASTUPDATEDATE")]
        public DateTime? LastUpdateDate { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        /// <returns></returns>
        [Column("LASTUPDATEDBY")]
        public string LastUpdatedBy { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        /// <returns></returns>
        [Column("APPUSER")]
        public string AppUser { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        /// <returns></returns>
        [Column("APPDATE")]
        public DateTime? AppDate { get; set; }
        /// <summary>
        /// 审核标志
        /// </summary>
        /// <returns></returns>
        [Column("FLAGAPP")]
        public bool FlagApp { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        /// <returns></returns>
        [Column("DELMAN")]
        public string DelMan { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        /// <returns></returns>
        [Column("DELDATE")]
        public DateTime? DelDate { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        /// <returns></returns>
        [Column("FLAGDELETE")]
        public bool FlagDelete { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.wtd_id = 0;
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.wtd_id = int.Parse(keyValue);
                                            }
        #endregion
    }
}