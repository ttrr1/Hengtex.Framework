using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-05-24 17:21
    /// �� ����con_pan_head_in
    /// </summary>
    public class con_pan_head_inMap : EntityTypeConfiguration<con_pan_head_inEntity>
    {
        public con_pan_head_inMap()
        {
            #region ������
            //��
            this.ToTable("con_pan_head_in");
            //����
            this.HasKey(t => t.phi_Num);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
