using Hengtex.Application.Entity.CustomerManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.CustomerManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2016-04-01 14:33
    /// �� ������Ʊ��Ϣ
    /// </summary>
    public class InvoiceMap : EntityTypeConfiguration<InvoiceEntity>
    {
        public InvoiceMap()
        {
            #region ������
            //��
            this.ToTable("Client_Invoice");
            //����
            this.HasKey(t => t.InvoiceId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
