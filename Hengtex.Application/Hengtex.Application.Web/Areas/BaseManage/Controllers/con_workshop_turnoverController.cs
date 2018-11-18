using Hengtex.Application.Entity.BaseManage;
using Hengtex.Application.Busines.BaseManage;
using Hengtex.Util;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Hengtex.Application.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// �� �� 1.0
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-01-19 15:26
    /// �� ����con_workshop_turnover
    /// </summary>
    public class con_workshop_turnoverController : MvcControllerBase
    {
        private con_workshop_turnoverBLL con_workshop_turnoverbll = new con_workshop_turnoverBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult con_workshop_turnoverIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult con_workshop_turnoverForm()
        {
            return View();
        }
        #endregion

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = con_workshop_turnoverbll.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = con_workshop_turnoverbll.GetEntity(keyValue);
            var childData = con_workshop_turnoverbll.GetDetails(keyValue);
            var jsonData = new
            {
                entity = data,
                childEntity = childData
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetDetailsJson(string keyValue)
        {
            var data = con_workshop_turnoverbll.GetDetails(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            con_workshop_turnoverbll.RemoveForm(keyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="strEntity">ʵ�����</param>
        /// <param name="strChildEntitys">�ӱ����</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strEntity,string strChildEntitys)
        {
            var entity = strEntity.ToObject<con_workshop_turnoverEntity>();
            List<con_workshop_turnover_detailEntity> childEntitys = strChildEntitys.ToList<con_workshop_turnover_detailEntity>();
            con_workshop_turnoverbll.SaveForm(keyValue, entity, childEntitys);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
