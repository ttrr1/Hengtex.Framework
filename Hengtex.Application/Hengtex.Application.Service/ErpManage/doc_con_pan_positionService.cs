using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Data.Repository;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

using Hengtex.Util;

using Hengtex.Util.Extension;
using System;

namespace Hengtex.Application.Service.ErpManage
{
    /// <summary>
    /// �� �� 1.0
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ����lvh
    /// �� �ڣ�2018-02-10 10:17
    /// �� ����doc_con_pan_position
    /// </summary>
    public class doc_con_pan_positionService : RepositoryFactory<doc_con_pan_positionEntity>, doc_con_pan_positionIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<doc_con_pan_positionEntity> GetList(string fieldName,string keyword)
        {
            var expression = LinqExtensions.True<doc_con_pan_positionEntity>();
            string sqlCondation = "  ";
            //��ѯ����

            switch (fieldName)
                {
                    
                    case "All":            //����
                    sqlCondation = sqlCondation + " and (dcpp_num like '%" + keyword + "%'";
                    
                    sqlCondation = sqlCondation + " or dcpp_type like '%" + keyword + "%')";
                    break;
                    default:
                        break;
                }

            try
            {

                string sql = "select * from  doc_con_pan_position where    FlagDelete=0 ";
                sql += sqlCondation;
                
                return this.ERPRepository().FindList(sql);

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public doc_con_pan_positionEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, doc_con_pan_positionEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
