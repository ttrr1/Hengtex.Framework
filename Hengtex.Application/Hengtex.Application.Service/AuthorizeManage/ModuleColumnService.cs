using Hengtex.Application.Entity.AuthorizeManage;
using Hengtex.Application.IService.AuthorizeManage;
using Hengtex.Data.Repository;
using Hengtex.Util.Extension;
using System.Collections.Generic;
using System.Linq;

namespace Hengtex.Application.Service.BaseManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.10.29 15:13
    /// 描 述：系统视图
    /// </summary>
    public class ModuleColumnService : RepositoryFactory<ModuleColumnEntity>, IModuleColumnService
    {
        #region 获取数据
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <returns></returns>
        public List<ModuleColumnEntity> GetList()
        {
            return this.BaseRepository().IQueryable().OrderBy(t => t.SortCode).ToList();
        }
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public List<ModuleColumnEntity> GetList(string moduleId)
        {
            var expression = LinqExtensions.True<ModuleColumnEntity>();
            expression = expression.And(t => t.ModuleId.Equals(moduleId));
            return this.BaseRepository().IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleColumnEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 添加视图
        /// </summary>
        /// <param name="moduleButtonEntity">视图实体</param>
        public void AddEntity(ModuleColumnEntity moduleColumnEntity)
        {
            moduleColumnEntity.Create();
            this.BaseRepository().Insert(moduleColumnEntity);
        }
        #endregion
    }
}
