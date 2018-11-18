using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-05-24 17:23
    /// 描 述：con_pan_head_out
    /// </summary>
    public class con_pan_head_outEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PHO_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? pho_id { get; set; }
        /// <summary>
        /// 登记时间
        /// </summary>
        /// <returns></returns>
        [Column("PHO_DATETIME")]
        public DateTime? pho_datetime { get; set; }
        /// <summary>
        /// pho_Num
        /// </summary>
        /// <returns></returns>
        [Column("PHO_NUM")]
        public string pho_Num { get; set; }
        /// <summary>
        /// 盘头ID
        /// </summary>
        /// <returns></returns>
        [Column("PHO_PANNUM")]
        public string pho_panNum { get; set; }
        /// <summary>
        /// 盘头号
        /// </summary>
        /// <returns></returns>
        [Column("PHO_PANNO")]
        public string pho_panno { get; set; }
        /// <summary>
        /// 盘头类型
        /// </summary>
        /// <returns></returns>
        [Column("PHO_TYPE")]
        public string pho_type { get; set; }
        /// <summary>
        /// 计划明细编号
        /// </summary>
        /// <returns></returns>
        [Column("PHO_PLANDETAIL")]
        public string pho_planDetail { get; set; }
        /// <summary>
        /// 工序ID
        /// </summary>
        /// <returns></returns>
        [Column("PHO_PROCEDUREID")]
        public string pho_procedureID { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        /// <returns></returns>
        [Column("PHO_PROCEDURENAME")]
        public string pho_procedureName { get; set; }
        /// <summary>
        /// 批次
        /// </summary>
        /// <returns></returns>
        [Column("PHO_BATCH")]
        public string pho_batch { get; set; }
        /// <summary>
        /// 品号
        /// </summary>
        /// <returns></returns>
        [Column("PHO_PINHAO")]
        public string pho_pinhao { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        /// <returns></returns>
        [Column("PHO_COLOR")]
        public string pho_color { get; set; }
        /// <summary>
        /// 经长
        /// </summary>
        /// <returns></returns>
        [Column("PHO_LENGTHWARP")]
        public decimal? pho_lengthWarp { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        /// <returns></returns>
        [Column("PHO_CUSTNUM")]
        public string pho_custNum { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        /// <returns></returns>
        [Column("PHO_CUSTNAME")]
        public string pho_custName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        /// <returns></returns>
        [Column("PHO_COUNT")]
        public decimal? pho_count { get; set; }
        /// <summary>
        /// 盘头个数
        /// </summary>
        /// <returns></returns>
        [Column("PHO_COUNT_PAN")]
        public int? pho_count_pan { get; set; }
        /// <summary>
        /// 倒轴米数
        /// </summary>
        /// <returns></returns>
        [Column("PHO_LENGTH")]
        public decimal? pho_length { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        /// <returns></returns>
        [Column("PHO_CLASSID")]
        public string pho_classId { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        /// <returns></returns>
        [Column("PHO_CLASS")]
        public string pho_class { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        /// <returns></returns>
        [Column("PHO_EMPNO")]
        public string pho_empNo { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        /// <returns></returns>
        [Column("PHO_NAME")]
        public string pho_name { get; set; }
        /// <summary>
        /// 盘头净重
        /// </summary>
        /// <returns></returns>
        [Column("PHO_WEIGHT")]
        public decimal? pho_weight { get; set; }
        /// <summary>
        /// 回丝重量
        /// </summary>
        /// <returns></returns>
        [Column("PHO_WEIGHT_WASTE")]
        public decimal? pho_weight_waste { get; set; }
        /// <summary>
        /// 整经机号
        /// </summary>
        /// <returns></returns>
        [Column("PHO_MACHINEID_WARP")]
        public string pho_machineID_warp { get; set; }
        /// <summary>
        /// 整经机
        /// </summary>
        /// <returns></returns>
        [Column("PHO_MACHINENAME_WARP")]
        public string pho_machineName_warp { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        /// <returns></returns>
        [Column("PHO_NO_POS")]
        public string pho_no_pos { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        /// <returns></returns>
        [Column("PHO_NAME_POS")]
        public string pho_name_pos { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("PHO_REMARKS")]
        public string pho_remarks { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        /// <returns></returns>
        [Column("PHO_STATUS")]
        public string pho_status { get; set; }
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
            this.pho_Num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.pho_Num = keyValue;
                                            }
        #endregion
    }
}