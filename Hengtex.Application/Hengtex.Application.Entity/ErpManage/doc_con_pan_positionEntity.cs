using System;
using Hengtex.Application.Code;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：lvh
    /// 日 期：2018-02-10 10:17
    /// 描 述：doc_con_pan_position
    /// </summary>
    public class doc_con_pan_positionEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? dcpp_id { get; set; }
        /// <summary>
        /// 货位类型
        /// </summary>
        /// <returns></returns>
        public string dcpp_kind { get; set; }
        /// <summary>
        /// 货位类型
        /// </summary>
        /// <returns></returns>
        public string dcpp_type { get; set; }
        /// <summary>
        /// 货位编号
        /// </summary>
        /// <returns></returns>
        public string dcpp_num { get; set; }
        /// <summary>
        /// 所在部门编码
        /// </summary>
        /// <returns></returns>
        public string dcpp_departNum { get; set; }
        /// <summary>
        /// 所在部门名称
        /// </summary>
        /// <returns></returns>
        public string dcpp_departName { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        /// <returns></returns>
        public string dcpp_no { get; set; }
        /// <summary>
        /// 货位名称
        /// </summary>
        /// <returns></returns>
        public string dcpp_name { get; set; }
        /// <summary>
        /// 位置描述
        /// </summary>
        /// <returns></returns>
        public string dcpp_position { get; set; }
        /// <summary>
        /// 助记符
        /// </summary>
        /// <returns></returns>
        public string dcpp_symbol { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public string dcpp_status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string dcpp_remark { get; set; }
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
            this.dcpp_num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.dcpp_num = keyValue;
                                            }
        #endregion
    }
}