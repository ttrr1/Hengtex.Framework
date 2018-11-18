using Hengtex.Application.Entity.AppManage;
using Hengtex.Data;
using Hengtex.Data.Repository;
using Hengtex.Util.Extension;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Hengtex.Application.IService.AppManage;
using Hengtex.Application.Service.AppManage;
namespace Hengtex.Application.Service.AppManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.02 14:27
    /// 描 述：部门管理
    /// </summary>
    public class AppDepartmentService : RepositoryFactory<AppDepartmentEntity>, IAppDepartmentService
    {
        private IAppAuthorizeService<AppDepartmentEntity> iauthorizeservice = new AppAuthorizeService<AppDepartmentEntity>();
        #region 获取数据
        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AppDepartmentEntity> GetList()
        {
            return this.ERPRepository().IQueryable().OrderByDescending(t => t.DepartCode).ToList();
        }
        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AppDepartmentEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 部门编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            var expression = LinqExtensions.True<AppDepartmentEntity>();
            //expression = expression.And(t => t.EnCode == enCode);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.DepartCode != keyValue);
            }
            return this.ERPRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        /// <summary>
        /// 部门名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            var expression = LinqExtensions.True<AppDepartmentEntity>();
            expression = expression.And(t => t.DepartName == fullName);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.DepartCode != keyValue);
            }
            return this.ERPRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            int count = this.ERPRepository().IQueryable(t => t.ParentNo == keyValue).Count();
            if (count > 0)
            {
                throw new Exception("当前所选数据有子节点数据！");
            }
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存部门表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">机构实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, AppDepartmentEntity departmentEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                departmentEntity.Modify(keyValue);
                this.ERPRepository().Update(departmentEntity);
            }
            else
            {
                departmentEntity.Create();
                this.ERPRepository().Insert(departmentEntity);
            }
        }
        #endregion
    }
}
