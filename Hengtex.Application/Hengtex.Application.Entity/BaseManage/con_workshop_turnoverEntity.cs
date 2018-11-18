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
    public class con_workshop_turnoverEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("WT_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? wt_id { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        /// <returns></returns>
        [Column("WT_NUM")]
        public string wt_num { get; set; }
        /// <summary>
        /// 审核标识
        /// </summary>
        /// <returns></returns>
        [Column("WT_REVIEW")]
        public string wt_review { get; set; }
        /// <summary>
        /// 入库标识
        /// </summary>
        /// <returns></returns>
        [Column("WT_STOCKIN")]
        public string wt_stockin { get; set; }
        /// <summary>
        /// 报检类型
        /// </summary>
        /// <returns></returns>
        [Column("WT_INSPECTTYPE")]
        public string wt_inspectType { get; set; }
        /// <summary>
        /// 报检类型
        /// </summary>
        /// <returns></returns>
        [Column("WT_DS")]
        public string wt_ds { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        /// <returns></returns>
        [Column("WT_DATE")]
        public DateTime? wt_date { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        /// <returns></returns>
        [Column("WT_SNUM")]
        public string wt_sNum { get; set; }
        /// <summary>
        /// 调出部门编码
        /// </summary>
        /// <returns></returns>
        [Column("WT_OUTDEPARTNUM")]
        public string wt_outDepartNum { get; set; }
        /// <summary>
        /// 调出部门名称
        /// </summary>
        /// <returns></returns>
        [Column("WT_OUTDEPARTNAME")]
        public string wt_outDepartName { get; set; }
        /// <summary>
        /// 调入部门编码
        /// </summary>
        /// <returns></returns>
        [Column("WT_INDEPARTNUM")]
        public string wt_inDepartNum { get; set; }
        /// <summary>
        /// 调入部门名称
        /// </summary>
        /// <returns></returns>
        [Column("WT_INDEPARTNAME")]
        public string wt_inDepartName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        /// <returns></returns>
        [Column("WT_COUNT")]
        public decimal? wt_count { get; set; }
        /// <summary>
        /// 记账标志
        /// </summary>
        /// <returns></returns>
        [Column("WT_FLAGACCOUNT")]
        public string wt_flagAccount { get; set; }
        /// <summary>
        /// 成本记账标志
        /// </summary>
        /// <returns></returns>
        [Column("WT_FLAGCOSTACCOUNT")]
        public string wt_flagCostAccount { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("WT_REMARKS")]
        public string wt_remarks { get; set; }
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
        /// CreatedByNum
        /// </summary>
        /// <returns></returns>
        [Column("CREATEDBYNUM")]
        public string CreatedByNum { get; set; }
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
            this.wt_num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.wt_num = keyValue;
                                            }
        #endregion
    }
}