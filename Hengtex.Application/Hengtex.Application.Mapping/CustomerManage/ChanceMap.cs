using Hengtex.Application.Entity.CustomerManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.CustomerManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ����������
    /// �� �ڣ�2016-03-12 10:50
    /// �� �����̻���Ϣ
    /// </summary>
    public class ChanceMap : EntityTypeConfiguration<ChanceEntity>
    {
        public ChanceMap()
        {
            #region ������
            //��
            this.ToTable("Client_Chance");
            //����
            this.HasKey(t => t.ChanceId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
