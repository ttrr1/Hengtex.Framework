using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.IService.AppManage;
using Hengtex.Data.Repository;
using Hengtex.Util.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using Hengtex.Application.Service.AppManage;
namespace Hengtex.Application.Service.AppManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.02 14:27
    /// 描 述：机构管理
    /// </summary>
    public class AppOrganizeService : RepositoryFactory<AppOrganizeEntity>, IAppOrganizeService
    {
        private IAppAuthorizeService<AppOrganizeEntity> iauthorizeservice = new AppAuthorizeService<AppOrganizeEntity>();
        #region 获取数据
        /// <summary>
        /// 机构列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AppOrganizeEntity> GetList()
        {
            return this.ERPRepository().IQueryable().OrderByDescending(t => t.SortCode).ToList();
        }
        /// <summary>
        /// 机构实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AppOrganizeEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 公司名称不能重复
        /// </summary>
        /// <param name="organizeName">公司名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            var expression = LinqExtensions.True<AppOrganizeEntity>();
            expression = expression.And(t => t.FullName == fullName);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.OrganizeId != keyValue);
            }
            return this.ERPRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        /// <summary>
        /// 外文名称不能重复
        /// </summary>
        /// <param name="enCode">外文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            var expression = LinqExtensions.True<AppOrganizeEntity>();
            expression = expression.And(t => t.EnCode == enCode);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.OrganizeId != keyValue);
            }
            return this.ERPRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        /// <summary>
        /// 中文名称不能重复
        /// </summary>
        /// <param name="shortName">中文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistShortName(string shortName, string keyValue)
        {
            var expression = LinqExtensions.True<AppOrganizeEntity>();
            expression = expression.And(t => t.ShortName == shortName);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.OrganizeId != keyValue);
            }
            return this.ERPRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除机构
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            int count = this.ERPRepository().IQueryable(t => t.ParentId == keyValue).Count();
            if (count > 0)
            {
                throw new Exception("当前所选数据有子节点数据！");
            }
            this.ERPRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存机构表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="organizeEntity">机构实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, AppOrganizeEntity organizeEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                organizeEntity.Modify(keyValue);
                this.ERPRepository().Update(organizeEntity);
            }
            else
            {
                organizeEntity.Create();
                this.ERPRepository().Insert(organizeEntity);
            }
        }
        #endregion
    }
}
