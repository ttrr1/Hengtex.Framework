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
    public class con_workshop_turnover_detailMap : EntityTypeConfiguration<con_workshop_turnover_detailEntity>
    {
        public con_workshop_turnover_detailMap()
        {
            #region ������
            //��
            this.ToTable("con_workshop_turnover_detail");
            //����
            this.HasKey(t => t.wtd_id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
