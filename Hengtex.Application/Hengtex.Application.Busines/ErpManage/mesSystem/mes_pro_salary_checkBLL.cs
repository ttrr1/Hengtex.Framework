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
    public class mes_pro_salary_checkBLL
    {
        private Imes_pro_salary_checkService service = new mes_pro_salary_checkService();
        

        #region ��ȡ����
        /// <summary>
        /// ����������ѯ�����趨��
        /// </summary>
        /// <returns></returns>
        public IEnumerable<mes_pro_salary_checkEntity> GetList(Dictionary<string, string> fields)
        {
            return service.GetList(fields);
        }
        /// <summary>
        ///����������ѯ�����趨��

        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public IEnumerable<mes_pro_salary_checkEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// �����趨ʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public mes_pro_salary_checkEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

    }
}