using Hengtex.Application.Code;
using Hengtex.Application.Entity.AppManage;
//using Hengtex.Application.Entity.AppManage.ViewModel;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.Entity.AuthorizeManage.ViewModel;
//using Hengtex.Application.Entity.AppManage.ViewModel;
using System.Collections.Generic;

namespace Hengtex.Application.IService.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.12.5 22:35
    /// 描 述：授权认证
    /// </summary>
    public interface IAppAuthorizeService
    {
        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<AppModuleEntity> GetModuleList(string userId);

        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="menuName">父菜单名</param>
        /// <returns></returns>
        IEnumerable<AppModuleEntity> GetModuleList(string userId,string menuName);
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<AppModuleButtonEntity> GetModuleButtonList(string userId);
        /// <summary>
        /// 获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<AppModuleColumnEntity> GetModuleColumnList(string userId);
        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<AuthorizeUrlModel> GetUrlList(string userId);
        /// <summary>
        /// 获取关联用户关系
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<AppUserRelationEntity> GetUserRelationList(string userId);
        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        string GetDataAuthorUserId(Operator operators, bool isWrite = false);
        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        string GetDataAuthor(Operator operators, bool isWrite = false);
    }
}
