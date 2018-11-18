using Hengtex.Application.Busines.AppManage;
using Hengtex.Application.Cache;
using Hengtex.Application.Code;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Util;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Hengtex.Application.Web.Areas.AppManage.Controllers
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.02 14:27
    /// 描 述：部门管理
    /// </summary>
    public class AppDepartmentController : MvcControllerBase
    {
        private AppOrganizeCache organizeCache = new AppOrganizeCache();
        private AppDepartmentBLL departmentBLL = new AppDepartmentBLL();
        private AppDepartmentCache departmentCache = new AppDepartmentCache();

        #region 视图功能
        /// <summary>
        /// 部门管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 部门表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 部门列表 
        /// </summary>
        /// <param name="organizeId">公司Id</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson(string organizeId, string keyword)
        {
            var data = departmentCache.GetList(organizeId).ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.DepartName.Contains(keyword), "DepartCode");
            }
            var treeList = new List<TreeEntity>();
            foreach (AppDepartmentEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.ParentNo == item.DepartCode) == 0 ? false : true;
                tree.id = item.DepartCode;
                tree.text = item.DepartName;
                tree.value = item.DepartCode;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentNo;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 部门列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回机构+部门树形Json</returns>
        public ActionResult GetOrganizeTreeJson(string keyword)
        {
            var organizedata = organizeCache.GetList();
            var departmentdata = departmentBLL.GetList();
            var treeList = new List<TreeEntity>();
            foreach (AppOrganizeEntity item in organizedata)
            {
                #region 机构
                TreeEntity tree = new TreeEntity();
                bool hasChildren = organizedata.Count(t => t.ParentId == item.OrganizeId) == 0 ? false : true;
                //if (hasChildren == false)
                //{
                //    hasChildren = departmentdata.Count(t => t.OrganizeId == item.OrganizeId) == 0 ? false : true;
                //    //if (hasChildren == false)
                //    //{
                //    //    continue;
                //    //}
                //}
                tree.id = item.OrganizeId;
                tree.text = item.FullName;
                tree.value = item.OrganizeId;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Organize";
                treeList.Add(tree);
                #endregion
            }
            foreach (AppDepartmentEntity item in departmentdata)
            {
                #region 部门
                TreeEntity tree = new TreeEntity();
                bool hasChildren = departmentdata.Count(t => t.ParentNo == item.DepartCode) == 0 ? false : true;
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
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Department";
                treeList.Add(tree);
                #endregion
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                treeList = treeList.TreeWhere(t => t.text.Contains(keyword), "id", "ParentNo");
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 部门列表 
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetTreeListJson(string condition, string keyword)
        {
            var organizedata = organizeCache.GetList();
            var departmentdata = departmentBLL.GetList().ToList();
            if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(keyword))
            {
                #region 多条件查询
                switch (condition)
                {
                    case "FullName":    //部门名称
                        departmentdata = departmentdata.TreeWhere(t => t.DepartName.Contains(keyword), "DepartmentId");
                        break;
                    case "EnCode":      //部门编号
                        departmentdata = departmentdata.TreeWhere(t => t.DepartCode.Contains(keyword), "DepartmentId");
                        break;
                    case "ShortName":   //部门简称
                        departmentdata = departmentdata.TreeWhere(t => t.DepartName.Contains(keyword), "DepartmentId");
                        break;
                    //case "Manager":     //负责人
                    //    departmentdata = departmentdata.TreeWhere(t => t.Manager.Contains(keyword), "DepartmentId");
                    //    break;
                    //case "OuterPhone":  //电话号
                    //    departmentdata = departmentdata.TreeWhere(t => t.OuterPhone.Contains(keyword), "DepartmentId");
                    //    break;
                    //case "InnerPhone":  //分机号
                    //    departmentdata = departmentdata.TreeWhere(t => t.Manager.Contains(keyword), "DepartmentId");
                    //    break;
                    default:
                        break;
                }
                #endregion
            }
            var treeList = new List<TreeGridEntity>();
            foreach (AppOrganizeEntity item in organizedata)
            {
                TreeGridEntity tree = new TreeGridEntity();
                bool hasChildren = organizedata.Count(t => t.ParentId == item.OrganizeId) == 0 ? false : true;
                //if (hasChildren == false)
                //{
                //    hasChildren = departmentdata.Count(t => t.OrganizeId == item.OrganizeId) == 0 ? false : true;
                //    if (hasChildren == false)
                //    {
                //        continue;
                //    }
                //}
                tree.id = item.OrganizeId;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId;
                tree.expanded = true;
                item.EnCode = ""; item.ShortName = ""; item.Nature = ""; item.Manager = ""; item.OuterPhone = ""; item.InnerPhone = ""; item.Description = "";
                string itemJson = item.ToJson();
                itemJson = itemJson.Insert(1, "\"DepartmentId\":\"" + item.OrganizeId + "\",");
                itemJson = itemJson.Insert(1, "\"Sort\":\"Organize\",");
                tree.entityJson = itemJson;
                treeList.Add(tree);
            }
            foreach (AppDepartmentEntity item in departmentdata)
            {
                TreeGridEntity tree = new TreeGridEntity();
                bool hasChildren = organizedata.Count(t => t.ParentId == item.DepartCode) == 0 ? false : true;
                tree.id = item.DepartCode;
                if (item.ParentNo == "01")
                {
                    tree.parentId = item.ParentNo;
                }
                else
                {
                    tree.parentId = item.ParentNo;
                }
                tree.expanded = true;
                tree.hasChildren = hasChildren;
                string itemJson = item.ToJson();
                itemJson = itemJson.Insert(1, "\"Sort\":\"Department\",");
                tree.entityJson = itemJson;
                treeList.Add(tree);
            }
            return Content(treeList.TreeJson());
        }
        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = departmentBLL.GetEntity(keyValue);
            return Content(data.ToJson());
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 部门编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistEnCode(string EnCode, string keyValue)
        {
            bool IsOk = departmentBLL.ExistEnCode(EnCode, keyValue);
            return Content(IsOk.ToString());
        }
        /// <summary>
        /// 部门名称不能重复
        /// </summary>
        /// <param name="FullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistFullName(string FullName, string keyValue)
        {
            bool IsOk = departmentBLL.ExistFullName(FullName, keyValue);
            return Content(IsOk.ToString());
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RemoveForm(string keyValue)
        {
            departmentBLL.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存部门表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">部门实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, AppDepartmentEntity departmentEntity)
        {
            departmentBLL.SaveForm(keyValue, departmentEntity);
            return Success("操作成功。");
        }
        #endregion
    }
}
