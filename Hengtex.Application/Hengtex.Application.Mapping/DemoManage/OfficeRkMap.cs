using Hengtex.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.DemoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2016-12-06 17:29
    /// �� ����OfficeRk
    /// </summary>
    public class OfficeRkMap : EntityTypeConfiguration<OfficeRkEntity>
    {
        public OfficeRkMap()
        {
            #region ��������
            //��
            this.ToTable("OfficeRk");
            //����
            this.HasKey(t => t.OrderId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}