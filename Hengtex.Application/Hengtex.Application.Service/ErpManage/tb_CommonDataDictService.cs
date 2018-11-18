using Hengtex.Application.Entity.SystemManage;
using Hengtex.Application.IService.SystemManage;
using Hengtex.Data.Repository;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

using Hengtex.Util;

using Hengtex.Util.Extension;

namespace Hengtex.Application.Service.SystemManage
{
    /// <summary>
    /// �� �� 1.0
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-02-03 17:07
    /// �� ����tb_CommonDataDict
    /// </summary>
    public class tb_CommonDataDictService : RepositoryFactory<tb_CommonDataDictEntity>, tb_CommonDataDictIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<tb_CommonDataDictEntity> GetList(string queryJson)
        {
            int dataType = 0;
            dataType = int.Parse(queryJson);
            return this.ERPRepository().IQueryable(t => t.DataType == dataType).OrderBy(t => t.DataCode).ToList();
           // return this.ERPRepository().FindList<tb_CommonDataDictEntity>("select * from tb_CommonDataDictEntity where DataType='" + queryJson + "'");
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public tb_CommonDataDictEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            this.ERPRepository().Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, tb_CommonDataDictEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.ERPRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.ERPRepository().Insert(entity);
            }
        }
        #endregion
    }
}
