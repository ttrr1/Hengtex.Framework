using Hengtex.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.DemoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2017-02-21 09:18
    /// �� ��������1
    /// </summary>
    public class t2Map : EntityTypeConfiguration<t2Entity>
    {
        public t2Map()
        {
            #region ������
            //��
            this.ToTable("t2");
            //����
            this.HasKey(t => t.id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
