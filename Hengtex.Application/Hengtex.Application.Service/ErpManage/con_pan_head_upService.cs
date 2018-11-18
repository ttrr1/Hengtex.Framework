using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Data.Repository;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using Hengtex.Util;
using Hengtex.Util.Extension;

namespace Hengtex.Application.Service.ErpManage
{
    /// <summary>
    /// �� �� 1.0
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-05-22 15:57
    /// �� ����con_pan_head_up
    /// </summary>
    public class con_pan_head_upService : RepositoryFactory, con_pan_head_upIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<con_pan_head_upEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return this.ERPRepository().FindList<con_pan_head_upEntity>(pagination);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public con_pan_head_upEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity<con_pan_head_upEntity>(keyValue);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<con_pan_head_empsEntity> GetDetails(string keyValue)
        {
            return this.ERPRepository().FindList<con_pan_head_empsEntity>("select * from con_pan_head_emps where phe_num='" + keyValue + "'");
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            IRepository db = new RepositoryFactory().ERPRepository().BeginTrans();
            try
            {
                db.Delete<con_pan_head_upEntity>(keyValue);
                db.Delete<con_pan_head_empsEntity>(t => t.phe_id.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// ����������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, con_pan_head_upEntity entity, List<con_pan_head_empsEntity> entryList)
        {
            IRepository db = this.ERPRepository().BeginTrans();
        try
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                //����
                entity.Modify(keyValue);
                db.Update(entity);
                //��ϸ
                db.Delete<con_pan_head_empsEntity>(t => t.phe_num.Equals(keyValue));
                foreach (con_pan_head_empsEntity item in entryList)
                {
                    item.Create();
                    item.phe_num = entity.phu_num;
                    db.Insert(item);
                }
            }
            else
            {
                //����
                entity.Create();
                db.Insert(entity);
                //��ϸ
                foreach (con_pan_head_empsEntity item in entryList)
                {
                    item.Create();
                    item.phe_num = entity.phu_num;
                    db.Insert(item);
                }
            }
            db.Commit();
        }
        catch (Exception)
        {
            db.Rollback();
            throw;
        }
        }
        #endregion
    }
}