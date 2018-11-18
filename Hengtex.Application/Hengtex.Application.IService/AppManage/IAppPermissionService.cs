using Hengtex.Application.Code;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.Entity.AppManage;
using System.Collections.Generic;

namespace Hengtex.Application.IService.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.5 22:35
    /// 描 述：权限配置管理（角色、岗位、职位、用户组、用户）
    /// </summary>
    public interface IAppPermissionService
    {
        #region 获取数据
        /// <summary>
        /// 获取成员列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        IEnumerable<AppUserRelationEntity> GetMemberList(string objectId);
         /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        IEnumerable<AppUserRelationEntity> GetObjectList(string userId);
        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        IEnumerable<AppAuthorizeEntity> GetModuleList(string objectId);
        /// <summary>
        /// 获取按钮列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        IEnumerable<AppAuthorizeEntity> GetModuleButtonList(string objectId);
        /// <summary>
        /// 获取视图列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        IEnumerable<AppAuthorizeEntity> GetModuleColumnList(string objectId);
        /// <summary>
        /// 获取数据权限列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        IEnumerable<AppAuthorizeDataEntity> GetAuthorizeDataList(string objectId);
        #endregion

        #region 提交数据
        /// <summary>
        /// 添加成员
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="userIds">成员Id</param>
        void SaveMember(AuthorizeTypeEnum authorizeType, string objectId, string[] userIds);
        /// <summary>
        /// 添加授权
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <param name="authorizeDataList">数据权限</param>
        void SaveAuthorize(AuthorizeTypeEnum authorizeType, string objectId, string[] moduleIds, string[] moduleButtonIds, string[] moduleColumnIds, IEnumerable<AppAuthorizeDataEntity> authorizeDataList);
        #endregion
    }
}
