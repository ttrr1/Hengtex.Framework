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
    public class con_pan_head_inEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PHI_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? phi_id { get; set; }
        /// <summary>
        /// 登记时间
        /// </summary>
        /// <returns></returns>
        [Column("PHI_DATETIME")]
        public DateTime? phi_datetime { get; set; }
        /// <summary>
        /// 盘头ID
        /// </summary>
        /// <returns></returns>
        [Column("PHI_TASKNUM")]
        public string phi_taskNum { get; set; }
        /// <summary>
        /// 盘头ID
        /// </summary>
        /// <returns></returns>
        [Column("PHI_NUM")]
        public string phi_Num { get; set; }
        /// <summary>
        /// 盘头ID
        /// </summary>
        /// <returns></returns>
        [Column("PHI_PANNUM")]
        public string phi_panNum { get; set; }
        /// <summary>
        /// 盘头号
        /// </summary>
        /// <returns></returns>
        [Column("PHI_PANNO")]
        public string phi_panno { get; set; }
        /// <summary>
        /// 盘头类型
        /// </summary>
        /// <returns></returns>
        [Column("PHI_TYPE")]
        public string phi_type { get; set; }
        /// <summary>
        /// 计划明细编号
        /// </summary>
        /// <returns></returns>
        [Column("PHI_PLANDETAIL")]
        public string phi_planDetail { get; set; }
        /// <summary>
        /// 工序ID
        /// </summary>
        /// <returns></returns>
        [Column("PHI_PROCEDUREID")]
        public string phi_procedureID { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        /// <returns></returns>
        [Column("PHI_PROCEDURENAME")]
        public string phi_procedureName { get; set; }
        /// <summary>
        /// 批次
        /// </summary>
        /// <returns></returns>
        [Column("PHI_BATCH")]
        public string phi_batch { get; set; }
        /// <summary>
        /// 品号
        /// </summary>
        /// <returns></returns>
        [Column("PHI_PINHAO")]
        public string phi_pinhao { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        /// <returns></returns>
        [Column("PHI_COLOR")]
        public string phi_color { get; set; }
        /// <summary>
        /// 经长
        /// </summary>
        /// <returns></returns>
        [Column("PHI_LENGTHWARP")]
        public decimal? phi_lengthWarp { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        /// <returns></returns>
        [Column("PHI_CUSTNUM")]
        public string phi_custNum { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        /// <returns></returns>
        [Column("PHI_CUSTNAME")]
        public string phi_custName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        /// <returns></returns>
        [Column("PHI_COUNT")]
        public decimal? phi_count { get; set; }
        /// <summary>
        /// 盘头个数
        /// </summary>
        /// <returns></returns>
        [Column("PHI_COUNT_PAN")]
        public int? phi_count_pan { get; set; }
        /// <summary>
        /// 倒轴米数
        /// </summary>
        /// <returns></returns>
        [Column("PHI_LENGTH")]
        public decimal? phi_length { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        /// <returns></returns>
        [Column("PHI_CLASSID")]
        public string phi_classId { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        /// <returns></returns>
        [Column("PHI_CLASS")]
        public string phi_class { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        /// <returns></returns>
        [Column("PHI_EMPNO")]
        public string phi_empNo { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        /// <returns></returns>
        [Column("PHI_NAME")]
        public string phi_name { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        /// <returns></returns>
        [Column("PHI_EMPNO2")]
        public string phi_empNo2 { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        /// <returns></returns>
        [Column("PHI_NAME2")]
        public string phi_name2 { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        /// <returns></returns>
        [Column("PHI_EMPNO3")]
        public string phi_empNo3 { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        /// <returns></returns>
        [Column("PHI_NAME3")]
        public string phi_name3 { get; set; }
        /// <summary>
        /// 盘头净重
        /// </summary>
        /// <returns></returns>
        [Column("PHI_WEIGHT")]
        public decimal? phi_weight { get; set; }
        /// <summary>
        /// 回丝重量
        /// </summary>
        /// <returns></returns>
        [Column("PHI_WEIGHT_WASTE")]
        public decimal? phi_weight_waste { get; set; }
        /// <summary>
        /// 整经机号
        /// </summary>
        /// <returns></returns>
        [Column("PHI_MACHINEID_WARP")]
        public string phi_machineID_warp { get; set; }
        /// <summary>
        /// 整经机
        /// </summary>
        /// <returns></returns>
        [Column("PHI_MACHINENAME_WARP")]
        public string phi_machineName_warp { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        /// <returns></returns>
        [Column("PHI_NO_POS")]
        public string phi_no_pos { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        /// <returns></returns>
        [Column("PHI_NAME_POS")]
        public string phi_name_pos { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("PHI_REMARKS")]
        public string phi_remarks { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        /// <returns></returns>
        [Column("PHI_STATUS")]
        public string phi_status { get; set; }
        /// <summary>
        /// 异常原因
        /// </summary>
        /// <returns></returns>
        [Column("PHI_ERRINFO")]
        public string phi_errinfo { get; set; }
        /// <summary>
        /// 盘头ID
        /// </summary>
        /// <returns></returns>
        [Column("PHI_TASKNUMNEXT")]
        public string phi_taskNumNext { get; set; }
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
            this.phi_Num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.phi_Num = keyValue;
                                            }
        #endregion
    }
}