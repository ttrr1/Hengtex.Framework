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
    /// 日 期：2015.10.29 15:13
    /// 描 述：系统视图
    /// </summary>
    public class AppModuleColumnService : RepositoryFactory<AppModuleColumnEntity>, IAppModuleColumnService
    {
        #region 获取数据
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <returns></returns>
        public List<AppModuleColumnEntity> GetList()
        {
            return this.ERPRepository().IQueryable().OrderBy(t => t.SortCode).ToList();
        }
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public List<AppModuleColumnEntity> GetList(string moduleId)
        {
            var expression = LinqExtensions.True<AppModuleColumnEntity>();
            expression = expression.And(t => t.ModuleId.Equals(moduleId));
            return this.ERPRepository().IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AppModuleColumnEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 添加视图
        /// </summary>
        /// <param name="moduleButtonEntity">视图实体</param>
        public void AddEntity(AppModuleColumnEntity moduleColumnEntity)
        {
            moduleColumnEntity.Create();
            this.ERPRepository().Insert(moduleColumnEntity);
        }
        #endregion
    }
}
