using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-05-22 15:57
    /// �� ����con_pan_head_up
    /// </summary>
    public class con_pan_head_upMap : EntityTypeConfiguration<con_pan_head_upEntity>
    {
        public con_pan_head_upMap()
        {
            #region ������
            //��
            this.ToTable("con_pan_head_up");
            //����
            this.HasKey(t => t.phu_id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
