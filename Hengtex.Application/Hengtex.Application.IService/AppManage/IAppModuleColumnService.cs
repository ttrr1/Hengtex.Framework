using Hengtex.Application.Entity.AppManage;
using System.Collections.Generic;

namespace Hengtex.Application.IService.AppManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.10.29 15:13
    /// 描 述：系统视图
    /// </summary>
    public interface IAppModuleColumnService
    {
        #region 获取数据
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <returns></returns>
        List<AppModuleColumnEntity> GetList();
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        List<AppModuleColumnEntity> GetList(string moduleId);
        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        AppModuleColumnEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 添加视图
        /// </summary>
        /// <param name="moduleButtonEntity">视图实体</param>
        void AddEntity(AppModuleColumnEntity moduleColumnEntity);
        #endregion
    }
}
