using System;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.AppManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.02 14:27
    /// 描 述：部门管理
    /// </summary>
    public class AppDepartmentEntity : BaseEntity
    {


        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        public int? id { get; set; }
        /// <summary>
        /// DepartNo
        /// </summary>
        /// <returns></returns>
        public string DepartNo { get; set; }
        /// <summary>
        /// DepartName
        /// </summary>
        /// <returns></returns>
        public string DepartName { get; set; }
        /// <summary>
        /// DepartCode
        /// </summary>
        /// <returns></returns>
        public string DepartCode { get; set; }
        /// <summary>
        /// DisplayOrder
        /// </summary>
        /// <returns></returns>
        public int? DisplayOrder { get; set; }
        /// <summary>
        /// ParentNo
        /// </summary>
        /// <returns></returns>
        public string ParentNo { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }
        /// <summary>
        /// Contact
        /// </summary>
        /// <returns></returns>
        public string Contact { get; set; }
        /// <summary>
        /// Tel
        /// </summary>
        /// <returns></returns>
        public string Tel { get; set; }
        /// <summary>
        /// InnerTel
        /// </summary>
        /// <returns></returns>
        public string InnerTel { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>
        /// <returns></returns>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// IsReal
        /// </summary>
        /// <returns></returns>
        public bool? IsReal { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.id = 0;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.id = int.Parse(keyValue);
        }
        #endregion
    }
}