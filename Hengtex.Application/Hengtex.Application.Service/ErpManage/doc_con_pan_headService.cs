using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Data.Repository;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

using Hengtex.Util;

using Hengtex.Util.Extension;
using Hengtex.Application.IService.AuthorizeManage;
using Hengtex.Application.IService.SystemManage;
using Hengtex.Application.Service.AuthorizeManage;
using Hengtex.Application.Service.SystemManage;
using System;

namespace Hengtex.Application.Service.ErpManage
{
    /// <summary>
    /// �� �� 1.0
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-02-05 18:06
    /// �� ����doc_con_pan_head
    /// </summary>
    public class doc_con_pan_headService : RepositoryFactory<doc_con_pan_headEntity>, doc_con_pan_headIService
    {
        private IAuthorizeService<doc_con_pan_headEntity> iauthorizeservice = new AuthorizeService<doc_con_pan_headEntity>();
        private ICodeRuleService coderuleService = new CodeRuleService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<doc_con_pan_headEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<doc_con_pan_headEntity>();
            var queryParam = queryJson.ToJObject();
            //expression.And(t => t.FlagDelete == false);
            //��ѯ����
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "dcph_num":              //���
                        expression = expression.And(t => t.dcph_num.Contains(keyword));
                        break;
                    case "dcph_no":            //����
                        expression = expression.And(t => t.dcph_no.Contains(keyword));
                        break;
                    case "dcph_symbol":             //���Ƿ�
                        expression = expression.And(t => t.dcph_symbol.Contains(keyword));
                        break;
                    case "dcph_status":       //״̬
                        expression = expression.And(t => t.dcph_status.Contains(keyword));
                        break;
                    case "dcph_positionName":       //λ��
                        expression = expression.And(t => t.dcph_positionName.Contains(keyword));
                        break;
                    case "dcph_fcltNameNext":       //��̨
                        expression = expression.And(t => t.dcph_fcltNameNext.Contains(keyword));
                        break;
                    case "dcph_batch":       //����
                        expression = expression.And(t => t.dcph_batch.Contains(keyword));
                        break;
                    case "All":
                        expression = expression.And(t => t.dcph_num.Contains(keyword)
                            || t.dcph_no.Contains(keyword)
                            || t.dcph_symbol.Contains(keyword)
                            || t.dcph_status.Contains(keyword)
                            || t.dcph_positionName.Contains(keyword)
                             || t.dcph_fcltNameNext.Contains(keyword)
                              || t.dcph_batch.Contains(keyword)
                            );
                        break;
                    default:
                        break;
                }
            }
            return this.ERPRepository().FindList(expression, pagination);
            //return iauthorizeservice.FindList(expression, pagination);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<doc_con_pan_headEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<doc_con_pan_headEntity>();
            var queryParam = queryJson.ToJObject();
            //expression.And(t => t.FlagDelete == false);
            string sqlCondation = "  ";
            //��ѯ����
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "dcph_num":              //���
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "dcph_no":            //����
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "dcph_symbol":             //���Ƿ�
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "dcph_status":       //״̬
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "dcph_positionName":       //λ��
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "dcph_fcltNameNext":       //��̨
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "dcph_batch":       //����
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "All":
                        sqlCondation = sqlCondation + " and (dcph_num like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or dcph_no like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or dcph_symbol like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or dcph_status like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or dcph_positionName like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or dcph_fcltNameNext like '%" + keyword + "%'";
                    
                        sqlCondation = sqlCondation + " or dcph_batch like '%" + keyword + "%')";
                        break;
                    default:
                        break;
                }
            }
            try
            {
                string sql = "select  * from  doc_con_pan_head where    FlagDelete=0 ";
                sql += sqlCondation;
               
                return this.ERPRepository().FindList(sql, pagination);

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
        public doc_con_pan_headEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, doc_con_pan_headEntity entity)
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
