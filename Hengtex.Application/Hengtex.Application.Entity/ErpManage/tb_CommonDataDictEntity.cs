using System;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.SystemManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-02-03 17:07
    /// 描 述：tb_CommonDataDict
    /// </summary>
    public class tb_CommonDataDictEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ISID
        /// </summary>
        /// <returns></returns>
        public int? ISID { get; set; }
        /// <summary>
        /// DataType
        /// </summary>
        /// <returns></returns>
        public int? DataType { get; set; }
        /// <summary>
        /// DataCode
        /// </summary>
        /// <returns></returns>
        public string DataCode { get; set; }
        /// <summary>
        /// NativeName
        /// </summary>
        /// <returns></returns>
        public string NativeName { get; set; }
        /// <summary>
        /// EnglishName
        /// </summary>
        /// <returns></returns>
        public string EnglishName { get; set; }
        /// <summary>
        /// CreationDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        /// <returns></returns>
        public string CreatedBy { get; set; }
        /// <summary>
        /// LastUpdateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? LastUpdateDate { get; set; }
        /// <summary>
        /// LastUpdatedBy
        /// </summary>
        /// <returns></returns>
        public string LastUpdatedBy { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ISID = 0;
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ISID = int.Parse(keyValue);
                                            }
        #endregion
    }
}