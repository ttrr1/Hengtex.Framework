﻿using Hengtex.Application.Busines.FlowManage;
using Hengtex.Application.Code;
using Hengtex.Application.Entity.FlowManage;
using Hengtex.Util;
using Hengtex.Util.WebControl;
using System.Web.Mvc;

namespace Hengtex.Application.Web.Areas.FlowManage.Controllers
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：陈彬彬
    /// 日 期：2016.03.19 13:57
    /// 描 述:已办流程
    /// </summary>
    public class FlowBeforeProcessingController : MvcControllerBase
    {
        private WFRuntimeBLL wfProcessBll = new WFRuntimeBLL();
        #region 视图功能
        //
        // GET: /FlowManage/FlowBeforeProcessing/
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 审核流程
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VerificationFrom()
        {
            return View();
        }
        #endregion

        #region 提取数据
        /// <summary>
        /// 获取代办的工作流程,运行中(分页)
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            pagination.page++;
            var data = wfProcessBll.GetToMeBeforePageList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
            };
            return Content(JsonData.ToJson());
        } 


        #endregion
    }
}