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
    public class con_pan_head_in_detailMap : EntityTypeConfiguration<con_pan_head_in_detailEntity>
    {
        public con_pan_head_in_detailMap()
        {
            #region ������
            //��
            this.ToTable("con_pan_head_in_detail");
            //����
            this.HasKey(t => t.phid_id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
