using Hengtex.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.PublicInfoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ����������
    /// �� �ڣ�2016-04-25 10:45
    /// �� �����ճ̹���
    /// </summary>
    public class ScheduleMap : EntityTypeConfiguration<ScheduleEntity>
    {
        public ScheduleMap()
        {
            #region ������
            //��
            this.ToTable("Base_Schedule");
            //����
            this.HasKey(t => t.ScheduleId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
