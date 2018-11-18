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
    /// 日 期：2015.08.01 14:00
    /// 描 述：系统按钮
    /// </summary>
    public class AppModuleButtonBLL
    {
        private IAppModuleButtonService service = new AppModuleButtonService();

        #region 获取数据
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <returns></returns>
        public List<AppModuleButtonEntity> GetList()
        {
            return service.GetList();
        }
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public List<AppModuleButtonEntity> GetList(string moduleId)
        {
            return service.GetList(moduleId);
        }
        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AppModuleButtonEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 复制按钮
        /// </summary>
        /// <param name="KeyValue">主键</param>
        /// <param name="moduleId">功能主键</param>
        /// <returns></returns>
        public void CopyForm(string keyValue, string moduleId)
        {
            try
            {
                AppModuleButtonEntity AppModuleButtonEntity = this.GetEntity(keyValue);
                AppModuleButtonEntity.ModuleId = moduleId;
                service.AddEntity(AppModuleButtonEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
