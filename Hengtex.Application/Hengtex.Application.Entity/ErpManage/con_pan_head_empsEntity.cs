using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-05-22 15:57
    /// 描 述：con_pan_head_up
    /// </summary>
    public class con_pan_head_empsEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PHE_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? phe_id { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        /// <returns></returns>
        [Column("PHE_NUM")]
        public string phe_num { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        /// <returns></returns>
        [Column("PHE_EMPNO")]
        public string phe_empNo { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        /// <returns></returns>
        [Column("PHE_NAME")]
        public string phe_name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("PHE_REMARKS")]
        public string phe_remarks { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.phe_id = 0;
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.phe_id = int.Parse(keyValue);
                                            }
        #endregion
    }
}