using Hengtex.Application.Busines.AppManage;
using Hengtex.Application.Cache;
using Hengtex.Application.Code;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Util;
using Hengtex.Util.Extension;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Hengtex.Application.Web.Areas.AppManage.Controllers
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.3 5:35
    /// 描 述：角色权限
    /// </summary>
    public class AppPermissionRoleController : MvcControllerBase
    {
        private AppOrganizeBLL organizeBLL = new AppOrganizeBLL();
        private AppDepartmentBLL departmentBLL = new AppDepartmentBLL();
        private AppDepartmentCache departmentCache = new AppDepartmentCache();
        private AppRoleBLL roleBLL = new AppRoleBLL();
        private AppUserBLL userBLL = new AppUserBLL();
        private AppPermissionBLL permissionBLL = new AppPermissionBLL();
        private AppAuthorizeBLL authorizeBLL = new AppAuthorizeBLL();

        #region 视图功能
        /// <summary>
        /// 角色权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult AllotAuthorize()
        {
            return View();
        }
        /// <summary>
        /// 角色成员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult AllotMember()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 部门列表 
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetDepartmentTreeJson(string roleId)
        {
            var roleEntity = roleBLL.GetEntity(roleId);
            var organizeEntity = organizeBLL.GetEntity(roleEntity.OrganizeId);
            var data = departmentCache.GetList(roleEntity.OrganizeId);

            var treeList = new List<TreeEntity>();
            TreeEntity tree = new TreeEntity();
            tree.id = organizeEntity.OrganizeId;
            tree.text = organizeEntity.FullName;
            tree.value = organizeEntity.OrganizeId;
            tree.isexpand = true;
            tree.complete = true;
            tree.hasChildren = true;
            tree.parentId = "0";
            treeList.Add(tree);
            foreach (AppDepartmentEntity item in data)
            {
                tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.ParentNo == item.DepartCode) == 0 ? false : true;
                tree.id = item.DepartCode;
                tree.text = item.DepartName;
                tree.value = item.DepartCode;
                if (item.ParentNo == "01")
                {
                    tree.parentId = roleEntity.OrganizeId;
                }
                else
                {
                    tree.parentId = item.ParentNo;
                }
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUserListJson(string roleId)
        {
            var existMember = permissionBLL.GetMemberList(roleId);
            var userdata = userBLL.GetTable();
            userdata.Columns.Add("ischeck", Type.GetType("System.Int32"));
            userdata.Columns.Add("isdefault", Type.GetType("System.Int32"));
            foreach (DataRow item in userdata.Rows)
            {
                string UserId = item["isid"].ToString();
                int ischeck = existMember.Count(t => t.UserId == UserId);
                item["ischeck"] = ischeck;
                if (ischeck > 0)
                {
                    item["isdefault"] = existMember.First(t => t.UserId == UserId).IsDefault;
                }
                else
                {
                    item["isdefault"] = 0;
                }
            }
            userdata = DataHelper.DataFilter(userdata, "", "ischeck desc");
            return Content(userdata.ToJson());
        }
        /// <summary>
        /// 系统功能列表
        /// </summary>
        /// <param name="RoleId">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleTreeJson(string roleId)
        {
            var existModule = permissionBLL.GetModuleList(roleId);
            var data = authorizeBLL.GetModuleList(SystemInfo.CurrentUserId);
            var treeList = new List<TreeEntity>();
            foreach (AppModuleEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.ParentId == item.ModuleId) == 0 ? false : true;
                tree.id = item.ModuleId;
                tree.text = item.FullName;
                tree.value = item.ModuleId;
                tree.title = "";
                tree.checkstate = existModule.Count(t => t.ItemId == item.ModuleId);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId;
                tree.img = item.Icon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 系统按钮列表
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleButtonTreeJson(string roleId)
        {
            var existModuleButton = permissionBLL.GetModuleButtonList(roleId);
            var moduleData = authorizeBLL.GetModuleList(SystemInfo.CurrentUserId);
            var moduleButtonData = authorizeBLL.GetModuleButtonList(SystemInfo.CurrentUserId);
            var treeList = new List<TreeEntity>();
            foreach (AppModuleEntity item in moduleData)
            {
                if (item.IsMenu == 1)
                {
                    bool hasChildren = moduleButtonData.Count(t => t.ModuleId == item.ModuleId) == 0 ? false : true;
                    if (hasChildren == false)
                    {
                        continue;
                    }
                }
                TreeEntity tree = new TreeEntity();
                tree.id = item.ModuleId;
                tree.text = item.FullName;
                tree.value = item.ModuleId;
                tree.checkstate = existModuleButton.Count(t => t.ItemId == item.ModuleId);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = true;
                tree.parentId = item.ParentId;
                tree.img = item.Icon;
                treeList.Add(tree);
            }
            foreach (AppModuleButtonEntity item in moduleButtonData)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = moduleButtonData.Count(t => t.ParentId == item.ModuleButtonId) == 0 ? false : true;
                tree.id = item.ModuleButtonId;
                tree.text = item.FullName;
                tree.value = item.ModuleButtonId;
                if (item.ParentId == "0")
                {
                    tree.parentId = item.ModuleId;
                }
                else
                {
                    tree.parentId = item.ParentId;
                }
                tree.checkstate = existModuleButton.Count(t => t.ItemId == item.ModuleButtonId);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.img = "fa fa-wrench " + item.ModuleId;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 系统视图列表
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleColumnTreeJson(string roleId)
        {
            var existModuleColumn = permissionBLL.GetModuleColumnList(roleId);
            var moduleData = authorizeBLL.GetModuleList(SystemInfo.CurrentUserId);
            var moduleColumnData = authorizeBLL.GetModuleColumnList(SystemInfo.CurrentUserId);
            var treeList = new List<TreeEntity>();
            foreach (AppModuleEntity item in moduleData)
            {
                TreeEntity tree = new TreeEntity();
                tree.id = item.ModuleId;
                tree.text = item.FullName;
                tree.value = item.ModuleId;
                tree.checkstate = existModuleColumn.Count(t => t.ItemId == item.ModuleId);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = true;
                tree.parentId = item.ParentId;
                tree.img = item.Icon;
                treeList.Add(tree);
            }
            foreach (AppModuleColumnEntity item in moduleColumnData)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = moduleColumnData.Count(t => t.ParentId == item.ModuleColumnId) == 0 ? false : true;
                tree.id = item.ModuleColumnId;
                tree.text = item.FullName;
                tree.value = item.ModuleColumnId;
                if (item.ParentId == "0")
                {
                    tree.parentId = item.ModuleId;
                }
                else
                {
                    tree.parentId = item.ParentId;
                }
                tree.checkstate = existModuleColumn.Count(t => t.ItemId == item.ModuleColumnId);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.img = "fa fa-filter " + item.ModuleId;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 数据权限列表
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OrganizeTreeJson(string roleId)
        {
            var existAuthorizeData = permissionBLL.GetAuthorizeDataList(roleId);
            var organizedata = organizeBLL.GetList();
            var departmentdata = departmentBLL.GetList();
            var treeList = new List<TreeEntity>();
            foreach (AppOrganizeEntity item in organizedata)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = organizedata.Count(t => t.ParentId == item.OrganizeId) == 0 ? false : true;
                //if (hasChildren == false)
                //{
                //    hasChildren = departmentdata.Count(t => t.OrganizeId == item.OrganizeId) == 0 ? false : true;
                //    if (hasChildren == false)
                //    {
                //        continue;
                //    }
                //}
                if (hasChildren == false)
                {
                    continue;
                }
                tree.id = item.OrganizeId;
                tree.text = item.FullName;
                tree.value = item.OrganizeId;
                tree.parentId = item.ParentId;
                if (item.ParentId == "0")
                {
                    tree.img = "fa fa-sitemap";
                }
                else
                {
                    tree.img = "fa fa-home";
                }
                tree.checkstate = existAuthorizeData.Count(t => t.ResourceId == item.OrganizeId);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            foreach (AppDepartmentEntity item in departmentdata)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = departmentdata.Count(t => t.ParentNo == item.DepartNo) == 0 ? false : true;
                tree.id = item.DepartCode;
                tree.text = item.DepartName;
                tree.value = item.DepartCode;
                if (item.ParentNo == "01")
                {
                    tree.parentId = item.ParentNo;
                }
                else
                {
                    tree.parentId = item.ParentNo;
                }
                tree.checkstate = existAuthorizeData.Count(t => t.ResourceId == item.DepartNo);
                tree.showcheck = true;
                tree.isexpand = true;
                tree.complete = true;
                tree.img = "fa fa-umbrella";
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            int authorizeType = -1;
            if (existAuthorizeData.ToList().Count > 0)
            {
                authorizeType = existAuthorizeData.ToList()[0].AuthorizeType.ToInt();
            }
            var JsonData = new
            {
                authorizeType = authorizeType,
                authorizeData = existAuthorizeData,
                treeJson = treeList.TreeToJson(),
            };
            return Content(JsonData.ToJson());
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存角色成员
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="userIds">成员Id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveMember(string roleId, string userIds)
        {
            permissionBLL.SaveMember(AuthorizeTypeEnum.Role, roleId, userIds);
            return Success("保存成功。");
        }
        /// <summary>
        /// 保存角色授权
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <param name="authorizeDataJson">数据权限</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveAuthorize(string roleId, string moduleIds, string moduleButtonIds, string moduleColumnIds, string authorizeDataJson)
        {
            permissionBLL.SaveAuthorize(AuthorizeTypeEnum.Role, roleId, moduleIds, moduleButtonIds, moduleColumnIds, authorizeDataJson);
            return Success("保存成功。");
        }
        #endregion
    }
}
