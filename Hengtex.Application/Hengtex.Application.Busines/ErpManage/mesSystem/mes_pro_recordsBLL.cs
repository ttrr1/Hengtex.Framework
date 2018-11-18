using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Application.Service.ErpManage;
using Hengtex.Cache.Factory;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hengtex.Application.Busines.AppManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �����ˣ��ܱ�
    /// �� �ڣ�2018.10.4 14:31
    /// �� �������������
    /// </summary>
    public class mes_pro_recordsBLL
    {
        private Imes_pro_recordsService service = new mes_pro_recordsService();
        private Itb_CommonDataDictService tbservice = new tb_CommonDataDictService();

        #region ��ȡ����
        /// <summary>
        /// ����������ѯ�����趨��
        /// </summary>
        /// <returns></returns>
        public IEnumerable<mes_pro_recordsEntity> GetList(Dictionary<string, string> fields)
        {
            return service.GetList(fields);
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tb_CommonDataDictEntity> GetList(int dataType)
        {
            return tbservice.GetList(dataType);
        }
        /// <summary>
        ///����������ѯ�����趨��

        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public IEnumerable<mes_pro_recordsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// �����趨ʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public mes_pro_recordsEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        public void SaveForm(string keyValue, mes_pro_recordsEntity model)
        {
            service.SaveForm(keyValue, model);
        }
        public void UpdateByKey(string table, Dictionary<string, string> keys, Dictionary<string, string> fields)
        {
            service.UpdateByKey(table, keys, fields);
        }

    }
}