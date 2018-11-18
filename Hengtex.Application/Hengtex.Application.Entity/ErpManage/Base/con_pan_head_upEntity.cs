using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;
using System.Collections.Generic;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-05-22 15:57
    /// 描 述：con_pan_head_up
    /// </summary>
    public class con_pan_head_upEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PHU_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? phu_id { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        /// <returns></returns>
        [Column("PHU_NUM")]
        public string phu_num { get; set; }
        /// <summary>
        /// 登记时间
        /// </summary>
        /// <returns></returns>
        [Column("PHU_DATETIME")]
        public DateTime? phu_datetime { get; set; }
        /// <summary>
        /// 盘头ID
        /// </summary>
        /// <returns></returns>
        [Column("PHU_PANNUM")]
        public string phu_panNum { get; set; }
        /// <summary>
        /// 盘头号
        /// </summary>
        /// <returns></returns>
        [Column("PHU_PANNO")]
        public string phu_panno { get; set; }
        /// <summary>
        /// 盘头类型
        /// </summary>
        /// <returns></returns>
        [Column("PHU_TYPE")]
        public string phu_type { get; set; }
        /// <summary>
        /// 计划明细编号
        /// </summary>
        /// <returns></returns>
        [Column("PHU_PLANDETAIL")]
        public string phu_planDetail { get; set; }
        /// <summary>
        /// 工序ID
        /// </summary>
        /// <returns></returns>
        [Column("PHU_PROCEDUREID")]
        public string phu_procedureID { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        /// <returns></returns>
        [Column("PHU_PROCEDURENAME")]
        public string phu_procedureName { get; set; }
        /// <summary>
        /// 批次
        /// </summary>
        /// <returns></returns>
        [Column("PHU_BATCH")]
        public string phu_batch { get; set; }
        /// <summary>
        /// 品号
        /// </summary>
        /// <returns></returns>
        [Column("PHU_PINHAO")]
        public string phu_pinhao { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        /// <returns></returns>
        [Column("PHU_COLOR")]
        public string phu_color { get; set; }
        /// <summary>
        /// 经长
        /// </summary>
        /// <returns></returns>
        [Column("PHU_LENGTHWARP")]
        public decimal? phu_lengthWarp { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        /// <returns></returns>
        [Column("PHU_CUSTNUM")]
        public string phu_custNum { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        /// <returns></returns>
        [Column("PHU_CUSTNAME")]
        public string phu_custName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        /// <returns></returns>
        [Column("PHU_COUNT")]
        public decimal? phu_count { get; set; }
        /// <summary>
        /// 盘头个数
        /// </summary>
        /// <returns></returns>
        [Column("PHU_COUNT_PAN")]
        public int? phu_count_pan { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        /// <returns></returns>
        [Column("PHU_CLASSID")]
        public string phu_classId { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        /// <returns></returns>
        [Column("PHU_CLASS")]
        public string phu_class { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        /// <returns></returns>
        [Column("PHU_EMPNO")]
        public string phu_empNo { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        /// <returns></returns>
        [Column("PHU_NAME")]
        public string phu_name { get; set; }
        /// <summary>
        /// 盘头净重
        /// </summary>
        /// <returns></returns>
        [Column("PHU_WEIGHT")]
        public decimal? phu_weight { get; set; }
        /// <summary>
        /// 盘头剩余
        /// </summary>
        /// <returns></returns>
        [Column("PHU_WEIGHT_REMAIN")]
        public decimal? phu_weight_remain { get; set; }
        /// <summary>
        /// 织机机号
        /// </summary>
        /// <returns></returns>
        [Column("PHU_MACHINEID_CON")]
        public string phu_machineID_con { get; set; }
        /// <summary>
        /// 织机机号
        /// </summary>
        /// <returns></returns>
        [Column("PHU_MACHINENAME_CON")]
        public string phu_machineName_con { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        /// <returns></returns>
        [Column("PHU_NO_POS")]
        public string phu_no_pos { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        /// <returns></returns>
        [Column("PHU_NAME_POS")]
        public string phu_name_pos { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("PHU_REMARKS")]
        public string phu_remarks { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        /// <returns></returns>
        [Column("PHU_STATUS")]
        public string phu_status { get; set; }
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

        /// <summary>
        /// 明细数据
        /// </summary>
        /// <returns></returns>
        //[Column("emps")]
        [NotMapped]
        public List<con_pan_head_empsEntity> emps { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
           // this.phu_num = DateTime.Now.ToString("MM-dd-HH-MM_sss");
            //phu_id = 0;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.phu_num = keyValue;
            //this.phu_id = int.Parse(keyValue);
                                            }
        #endregion
    }
}