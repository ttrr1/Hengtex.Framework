using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-05-24 17:23
    /// �� ����con_pan_head_out
    /// </summary>
    public class con_pan_head_outMap : EntityTypeConfiguration<con_pan_head_outEntity>
    {
        public con_pan_head_outMap()
        {
            #region ������
            //��
            this.ToTable("con_pan_head_out");
            //����
            this.HasKey(t => t.pho_Num);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
