using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-02-05 18:06
    /// 描 述：doc_con_pan_head
    /// </summary>
    public class doc_con_pan_headEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? dcph_id { get; set; }
        /// <summary>
        /// 盘头类型
        /// </summary>
        /// <returns></returns>
        public string dcph_type { get; set; }
        /// <summary>
        /// 盘头编号
        /// </summary>
        /// <returns></returns>
        public string dcph_num { get; set; }
        /// <summary>
        /// 所属部门编码
        /// </summary>
        /// <returns></returns>
        public string dcph_departNum { get; set; }
        /// <summary>
        /// 所属部门名称
        /// </summary>
        /// <returns></returns>
        public string dcph_departName { get; set; }
        /// <summary>
        /// 盘头号
        /// </summary>
        /// <returns></returns>
        public string dcph_no { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        /// <returns></returns>
        public decimal? dcph_weight { get; set; }
        /// <summary>
        /// 助记符
        /// </summary>
        /// <returns></returns>
        public string dcph_symbol { get; set; }
        /// <summary>
        /// 购置时间
        /// </summary>
        /// <returns></returns>
        public DateTime? dcph_dateIn { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public string dcph_status { get; set; }
        /// <summary>
        /// 期初位置
        /// </summary>
        /// <returns></returns>
        public string dcph_position { get; set; }
        /// <summary>
        /// 期初位置
        /// </summary>
        /// <returns></returns>
        public string dcph_positionName { get; set; }
        /// <summary>
        /// 期初位置
        /// </summary>
        /// <returns></returns>
        public string dcph_positionNew { get; set; }
        /// <summary>
        /// 期初位置
        /// </summary>
        /// <returns></returns>
        public string dcph_positionNameNew { get; set; }
        /// <summary>
        /// 期初位置
        /// </summary>
        /// <returns></returns>
        public string dcph_batch { get; set; }
        /// <summary>
        /// 下工序机台号
        /// </summary>
        /// <returns></returns>
        public string dcph_fcltNumWarp { get; set; }
        /// <summary>
        /// 下工序机台名称
        /// </summary>
        /// <returns></returns>
        public string dcph_fcltNameWarp { get; set; }
        /// <summary>
        /// 下工序机台号
        /// </summary>
        /// <returns></returns>
        public string dcph_fcltNumNext { get; set; }
        /// <summary>
        /// 下工序机台名称
        /// </summary>
        /// <returns></returns>
        public string dcph_fcltNameNext { get; set; }
        /// <summary>
        /// 任务单
        /// </summary>
        /// <returns></returns>
        public string dcph_taskNum { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string dcph_remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        public string CreatedBy { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        /// <returns></returns>
        public DateTime? LastUpdateDate { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        /// <returns></returns>
        public string LastUpdatedBy { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        /// <returns></returns>
        public string AppUser { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        /// <returns></returns>
        public DateTime? AppDate { get; set; }
        /// <summary>
        /// 审核标志
        /// </summary>
        /// <returns></returns>
        public bool? FlagApp { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        /// <returns></returns>
        public string DelMan { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        /// <returns></returns>
        public DateTime? DelDate { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        /// <returns></returns>
        public bool? FlagDelete { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            //this.dcph_num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.dcph_num = keyValue;
                                            }
        #endregion
    }
}