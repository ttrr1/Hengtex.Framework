using Hengtex.Application.Entity.BaseManage;
using Hengtex.Application.IService.BaseManage;
using Hengtex.Data.Repository;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using Hengtex.Util;
using Hengtex.Util.Extension;

namespace Hengtex.Application.Service.BaseManage
{
    /// <summary>
    /// �� �� 1.0
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-01-19 15:26
    /// �� ����con_workshop_turnover
    /// </summary>
    public class con_workshop_turnoverService : RepositoryFactory, con_workshop_turnoverIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<con_workshop_turnoverEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return this.ERPRepository().FindList<con_workshop_turnoverEntity>(pagination);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public con_workshop_turnoverEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity<con_workshop_turnoverEntity>(keyValue);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<con_workshop_turnover_detailEntity> GetDetails(string keyValue)
        {
            return this.ERPRepository().FindList<con_workshop_turnover_detailEntity>("select * from con_workshop_turnover_detail where wtd_num='" + keyValue + "'");
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
                db.Delete<con_workshop_turnoverEntity>(keyValue);
                db.Delete<con_workshop_turnover_detailEntity>(t => t.wtd_id.Equals(keyValue));
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
        public void SaveForm(string keyValue, con_workshop_turnoverEntity entity,List<con_workshop_turnover_detailEntity> entryList)
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
                db.Delete<con_workshop_turnover_detailEntity>(t => t.wtd_num.Equals(keyValue));
                foreach (con_workshop_turnover_detailEntity item in entryList)
                {
                    item.Create();
                    item.wtd_num = entity.wt_num;
                    db.Insert(item);
                }
            }
            else
            {
                //����
                entity.Create();
                db.Insert(entity);
                //��ϸ
                foreach (con_workshop_turnover_detailEntity item in entryList)
                {
                    item.Create();
                    item.wtd_num = entity.wt_num;
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