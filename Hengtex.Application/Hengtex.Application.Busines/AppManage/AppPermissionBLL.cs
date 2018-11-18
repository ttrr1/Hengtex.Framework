using Hengtex.Application.Busines.AppManage;
using Hengtex.Application.Code;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.IService.AppManage;
using Hengtex.Application.Service.AppManage;
using Hengtex.Util;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Hengtex.Application.Busines.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.5 22:35
    /// 描 述：权限配置管理（角色、岗位、职位、用户组、用户）
    /// </summary>
    public class AppPermissionBLL
    {
        private IAppPermissionService service = new AppPermissionService();
        private AppUserBLL userBLL = new AppUserBLL();

        #region 获取数据
        /// <summary>
        /// 获取成员列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AppUserRelationEntity> GetMemberList(string objectId)
        {
            return service.GetMemberList(objectId);
        }
         /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public IEnumerable<AppUserRelationEntity> GetObjectList(string userId)
        {
            return service.GetObjectList(userId);
        }
        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string GetObjectStr(string userId)
        {
            StringBuilder sbId = new StringBuilder();
            try
            {
                List<AppUserRelationEntity> list = service.GetObjectList(userId).ToList();
                if (list.Count > 0)
                {
                    foreach (AppUserRelationEntity item in list)
                    {
                        sbId.Append(item.ObjectId + ",");
                    }
                    sbId.Append(userId);
                }
                else
                {
                    sbId.Append(userId + ",");
                }
            }
            catch (Exception ex) {
                throw ex;
            }
           
            return sbId.ToString();
        }
        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AppAuthorizeEntity> GetModuleList(string objectId)
        {
            return service.GetModuleList(objectId);
        }
        /// <summary>
        /// 获取按钮列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AppAuthorizeEntity> GetModuleButtonList(string objectId)
        {
            return service.GetModuleButtonList(objectId);
        }
        /// <summary>
        /// 获取视图列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AppAuthorizeEntity> GetModuleColumnList(string objectId)
        {
            return service.GetModuleColumnList(objectId);
        }
        /// <summary>
        /// 获取数据权限列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AppAuthorizeDataEntity> GetAuthorizeDataList(string objectId)
        {
            return service.GetAuthorizeDataList(objectId);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 添加成员
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="userIds">成员Id：1,2,3,4</param>
        public void SaveMember(AuthorizeTypeEnum authorizeType, string objectId, string userIds)
        {
            try
            {
                string[] arrayUserId = userIds.Split(',');
                service.SaveMember(authorizeType, objectId, arrayUserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存授权
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <param name="authorizeDataJson">数据权限</param>
        /// <returns></returns>
        public void SaveAuthorize(AuthorizeTypeEnum authorizeType, string objectId, string moduleIds, string moduleButtonIds, string moduleColumnIds, string authorizeDataJson)
        {
            try
            {
                string[] arrayModuleId = moduleIds.Split(',');
                string[] arrayModuleButtonId = moduleButtonIds.Split(',');
                string[] arrayModuleColumnId = moduleColumnIds.Split(',');
                IEnumerable<AppAuthorizeDataEntity> authorizeDataList = authorizeDataJson.ToList<AppAuthorizeDataEntity>();
                service.SaveAuthorize(authorizeType, objectId, arrayModuleId, arrayModuleButtonId, arrayModuleColumnId, authorizeDataList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
