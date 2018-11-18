using System;
using Hengtex.Application.Code;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hengtex.Application.Entity.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-01-19 14:56
    /// 描 述：cost_rateExchange
    /// </summary>
    public class cost_rateExchangeEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? re_id { get; set; }
        /// <summary>
        /// 出口标志
        /// </summary>
        /// <returns></returns>
        public bool? re_flagExport { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        /// <returns></returns>
        public string re_currency { get; set; }
        /// <summary>
        /// 汇率
        /// </summary>
        /// <returns></returns>
        public decimal? re_rate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string re_remarks { get; set; }
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
            this.re_id =0;
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.re_id = int.Parse(keyValue);
                                            }
        #endregion
    }
}