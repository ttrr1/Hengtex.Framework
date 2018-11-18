using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-05-24 17:21
    /// 描 述：con_pan_head_in
    /// </summary>
    public class con_pan_head_in_detailEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PHID_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? phid_id { get; set; }
        /// <summary>
        /// 盘头编号
        /// </summary>
        /// <returns></returns>
        [Column("PHID_NUM")]
        public string phid_num { get; set; }
        /// <summary>
        /// 盘头编号
        /// </summary>
        /// <returns></returns>
        [Column("PHID_PANNUM")]
        public string phid_panNum { get; set; }
        /// <summary>
        /// 原料编码
        /// </summary>
        /// <returns></returns>
        [Column("PHID_NUMMATERIAL")]
        public string phid_numMaterial { get; set; }
        /// <summary>
        /// 原料批次
        /// </summary>
        /// <returns></returns>
        [Column("PHID_BATCHMATERIAL")]
        public string phid_batchMaterial { get; set; }
        /// <summary>
        /// 原料名称
        /// </summary>
        /// <returns></returns>
        [Column("PHID_AMEMATERIAL")]
        public string phid_ameMaterial { get; set; }
        /// <summary>
        /// 原料规格
        /// </summary>
        /// <returns></returns>
        [Column("PHID_SPECMATERIAL")]
        public string phid_specMaterial { get; set; }
        /// <summary>
        /// 原料产地
        /// </summary>
        /// <returns></returns>
        [Column("PHID_WHEREMATERIAL")]
        public string phid_whereMaterial { get; set; }
        /// <summary>
        /// 原料颜色
        /// </summary>
        /// <returns></returns>
        [Column("PHID_COLORMATERIAL")]
        public string phid_colorMaterial { get; set; }
        /// <summary>
        /// 原料单价
        /// </summary>
        /// <returns></returns>
        [Column("PHID_PRICE")]
        public decimal? phid_price { get; set; }
        /// <summary>
        /// 上机数量
        /// </summary>
        /// <returns></returns>
        [Column("PHID_COUNT")]
        public decimal? phid_count { get; set; }
        /// <summary>
        /// 剩余数量
        /// </summary>
        /// <returns></returns>
        [Column("PHID_COUNT_REMAIN")]
        public decimal? phid_count_remain { get; set; }
        /// <summary>
        /// 退库数量
        /// </summary>
        /// <returns></returns>
        [Column("PHID_COUNT_RETURN")]
        public decimal? phid_count_return { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("PHID_REMARKS")]
        public string phid_remarks { get; set; }
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
        /// 岗位编号
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
        public string FlagApp { get; set; }
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
        public string FlagDelete { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.phid_id = 0;
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.phid_id = int.Parse(keyValue);
                                            }
        #endregion
    }
}