using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ����lvh
    /// �� �ڣ�2018-02-10 10:17
    /// �� ����doc_con_pan_position
    /// </summary>
    public class doc_con_pan_positionMap : EntityTypeConfiguration<doc_con_pan_positionEntity>
    {
        public doc_con_pan_positionMap()
        {
            #region ������
            //��
            this.ToTable("doc_con_pan_position");
            //����
            this.HasKey(t => t.dcpp_num);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
