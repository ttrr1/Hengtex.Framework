using Hengtex.Application.Entity.ErpManage;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.IService.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2018 ��̩��֯
    /// �����ˣ��ܱ�
    /// �� �ڣ�2018.02.08
    /// �� �������򵵰�����
    /// </summary>
    public interface Imes_pro_recordsService
    {
        #region ��ȡ����

        /// <summary>
        /// <mes_pro_records
        /// </summary>
        /// <param name="fields">��ѯ</param>
        /// <returns></returns>
        IEnumerable<mes_pro_recordsEntity> GetList(Dictionary<string, string> fields);


		/// <summary>
        /// <mes_pro_records
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        IEnumerable<mes_pro_recordsEntity> GetPageList(Pagination pagination, string queryJson);
        
        /// <summary>
        /// <mes_pro_records
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        mes_pro_recordsEntity GetEntity(string keyValue);
        #endregion

        void SaveForm(string keyValue, mes_pro_recordsEntity model);
        void UpdateByKey(string table, Dictionary<string, string> keys, Dictionary<string, string> fields);
    }
}