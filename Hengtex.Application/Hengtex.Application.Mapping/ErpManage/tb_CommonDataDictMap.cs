using Hengtex.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.SystemManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-02-03 17:07
    /// �� ����tb_CommonDataDict
    /// </summary>
    public class tb_CommonDataDictMap : EntityTypeConfiguration<tb_CommonDataDictEntity>
    {
        public tb_CommonDataDictMap()
        {
            #region ������
            //��
            this.ToTable("tb_CommonDataDict");
            //����
            this.HasKey(t => t.ISID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
