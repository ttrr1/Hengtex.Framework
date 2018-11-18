using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.IService.AppManage;
using Hengtex.Application.Service.AppManage;
using System;
using System.Collections.Generic;

namespace Hengtex.Application.Busines.AppManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.10.29 15:13
    /// 描 述：系统视图
    /// </summary>
    public class AppModuleColumnBLL
    {
        private IAppModuleColumnService service = new AppModuleColumnService();

        #region 获取数据
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <returns></returns>
        public List<AppModuleColumnEntity> GetList()
        {
            return service.GetList();
        }
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public List<AppModuleColumnEntity> GetList(string moduleId)
        {
            return service.GetList(moduleId);
        }
        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AppModuleColumnEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 复制视图 
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="moduleId">功能主键</param>
        /// <returns></returns>
        public void CopyForm(string keyValue, string moduleId)
        {
            try
            {
                AppModuleColumnEntity AppModuleColumnEntity = this.GetEntity(keyValue);
                AppModuleColumnEntity.ModuleId = moduleId;
                service.AddEntity(AppModuleColumnEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
