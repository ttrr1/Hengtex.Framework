using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-05-24 17:24
    /// 描 述：con_pan_head_down
    /// </summary>
    public class con_pan_head_downEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PHD_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? phd_id { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        /// <returns></returns>
        [Column("PHD_NUM")]
        public string phd_num { get; set; }
        /// <summary>
        /// 登记时间
        /// </summary>
        /// <returns></returns>
        [Column("PHD_DATETIME")]
        public DateTime? phd_datetime { get; set; }
        /// <summary>
        /// 盘头ID
        /// </summary>
        /// <returns></returns>
        [Column("PHD_PANNUM")]
        public string phd_panNum { get; set; }
        /// <summary>
        /// 盘头号
        /// </summary>
        /// <returns></returns>
        [Column("PHD_PANNO")]
        public string phd_panno { get; set; }
        /// <summary>
        /// 盘头类型
        /// </summary>
        /// <returns></returns>
        [Column("PHD_TYPE")]
        public string phd_type { get; set; }
        /// <summary>
        /// 计划明细编号
        /// </summary>
        /// <returns></returns>
        [Column("PHD_PLANDETAIL")]
        public string phd_planDetail { get; set; }
        /// <summary>
        /// 工序ID
        /// </summary>
        /// <returns></returns>
        [Column("PHD_PROCEDUREID")]
        public string phd_procedureID { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        /// <returns></returns>
        [Column("PHD_PROCEDURENAME")]
        public string phd_procedureName { get; set; }
        /// <summary>
        /// 批次
        /// </summary>
        /// <returns></returns>
        [Column("PHD_BATCH")]
        public string phd_batch { get; set; }
        /// <summary>
        /// 品号
        /// </summary>
        /// <returns></returns>
        [Column("PHD_PINHAO")]
        public string phd_pinhao { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        /// <returns></returns>
        [Column("PHD_COLOR")]
        public string phd_color { get; set; }
        /// <summary>
        /// 经长
        /// </summary>
        /// <returns></returns>
        [Column("PHD_LENGTHWARP")]
        public decimal? phd_lengthWarp { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        /// <returns></returns>
        [Column("PHD_CUSTNUM")]
        public string phd_custNum { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        /// <returns></returns>
        [Column("PHD_CUSTNAME")]
        public string phd_custName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        /// <returns></returns>
        [Column("PHD_COUNT")]
        public decimal? phd_count { get; set; }
        /// <summary>
        /// 盘头个数
        /// </summary>
        /// <returns></returns>
        [Column("PHD_COUNT_PAN")]
        public int? phd_count_pan { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        /// <returns></returns>
        [Column("PHD_CLASSID")]
        public string phd_classId { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        /// <returns></returns>
        [Column("PHD_CLASS")]
        public string phd_class { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        /// <returns></returns>
        [Column("PHD_EMPNO")]
        public string phd_empNo { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        /// <returns></returns>
        [Column("PHD_NAME")]
        public string phd_name { get; set; }
        /// <summary>
        /// 盘头净重
        /// </summary>
        /// <returns></returns>
        [Column("PHD_WEIGHT")]
        public decimal? phd_weight { get; set; }
        /// <summary>
        /// 盘头剩余
        /// </summary>
        /// <returns></returns>
        [Column("PHD_WEIGHT_REMAIN")]
        public decimal? phd_weight_remain { get; set; }
        /// <summary>
        /// 织机机号
        /// </summary>
        /// <returns></returns>
        [Column("PHD_MACHINEID_CON")]
        public string phd_machineID_con { get; set; }
        /// <summary>
        /// 织机机号
        /// </summary>
        /// <returns></returns>
        [Column("PHD_MACHINENAME_CON")]
        public string phd_machineName_con { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        /// <returns></returns>
        [Column("PHD_NO_POS")]
        public string phd_no_pos { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        /// <returns></returns>
        [Column("PHD_NAME_POS")]
        public string phd_name_pos { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("PHD_REMARKS")]
        public string phd_remarks { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        /// <returns></returns>
        [Column("PHD_STATUS")]
        public string phd_status { get; set; }
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
            this.phd_num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.phd_num = keyValue;
                                            }
        #endregion
    }
}