using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-05-24 17:24
    /// �� ����con_pan_head_down
    /// </summary>
    public class con_pan_head_empsMap : EntityTypeConfiguration<con_pan_head_empsEntity>
    {
        public con_pan_head_empsMap()
        {
            #region ������
            //��
            this.ToTable("con_pan_head_emps");
            //����
            this.HasKey(t => t.phe_id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
