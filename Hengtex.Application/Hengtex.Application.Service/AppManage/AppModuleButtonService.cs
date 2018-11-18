using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.IService.AppManage;
using Hengtex.Data.Repository;
using Hengtex.Util.Extension;
using System.Collections.Generic;
using System.Linq;

namespace Hengtex.Application.Service.AppManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.08.01 14:00
    /// 描 述：系统按钮
    /// </summary>
    public class AppModuleButtonService : RepositoryFactory<AppModuleButtonEntity>, IAppModuleButtonService
    {
        #region 获取数据
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <returns></returns>
        public List<AppModuleButtonEntity> GetList()
        {
            return this.ERPRepository().IQueryable().OrderBy(t => t.SortCode).ToList();
        }
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public List<AppModuleButtonEntity> GetList(string moduleId)
        {
            var expression = LinqExtensions.True<AppModuleButtonEntity>();
            expression = expression.And(t => t.ModuleId.Equals(moduleId));
            return this.ERPRepository().IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AppModuleButtonEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="moduleButtonEntity">按钮实体</param>
        public void AddEntity(AppModuleButtonEntity moduleButtonEntity)
        {
            moduleButtonEntity.Create();
            this.ERPRepository().Insert(moduleButtonEntity);
        }
        #endregion
    }
}
