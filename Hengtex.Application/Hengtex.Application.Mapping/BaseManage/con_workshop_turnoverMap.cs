using Hengtex.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.BaseManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-01-19 15:26
    /// �� ����con_workshop_turnover
    /// </summary>
    public class con_workshop_turnoverMap : EntityTypeConfiguration<con_workshop_turnoverEntity>
    {
        public con_workshop_turnoverMap()
        {
            #region ������
            //��
            this.ToTable("con_workshop_turnover");
            //����
            this.HasKey(t => t.wt_num);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
