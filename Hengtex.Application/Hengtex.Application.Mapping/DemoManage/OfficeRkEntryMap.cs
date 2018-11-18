using Hengtex.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.WeChatManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2016-12-06 17:29
    /// �� ����OfficeRk
    /// </summary>
    public class OfficeRkEntryMap : EntityTypeConfiguration<OfficeRkEntryEntity>
    {
        public OfficeRkEntryMap()
        {
            #region ������
            //��
            this.ToTable("OfficeRkEntry");
            //����
            this.HasKey(t => t.RkEntryId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
