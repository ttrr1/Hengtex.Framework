using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-02-05 18:06
    /// �� ����doc_con_pan_head
    /// </summary>
    public class doc_con_pan_headMap : EntityTypeConfiguration<doc_con_pan_headEntity>
    {
        public doc_con_pan_headMap()
        {
            #region ������
            //��
            this.ToTable("doc_con_pan_head");
            //����
            this.HasKey(t => t.dcph_num);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
