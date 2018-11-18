using Hengtex.Application.Code;
using Hengtex.Util;
using System.Web.Mvc;

namespace Hengtex.Application.Web.Areas.WeChatManage.Controllers
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.12.23 11:31
    /// 描 述：企业号设置
    /// </summary>
    public class TokenController : MvcControllerBase
    {
        #region 视图功能
        /// <summary>
        /// 企业号管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            ViewBag.CorpId = Config.GetValue("CorpId");
            ViewBag.CorpSecret = Config.GetValue("CorpSecret");
            return View();
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="CorpId">企业号CorpID</param>
        /// <param name="CorpSecret">管理组凭证密钥</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string CorpId, string CorpSecret)
        {
            Config.SetValue("CorpId", CorpId);
            Config.SetValue("CorpSecret", CorpSecret);
            return Success("操作成功。");
        }
        #endregion
    }
}
