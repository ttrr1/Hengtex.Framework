using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-05-10 16:57
    /// �� ����sale_order_batches
    /// </summary>
    public class sale_order_batchesMap : EntityTypeConfiguration<sale_order_batchesEntity>
    {
        public sale_order_batchesMap()
        {
            #region ������
            //��
            this.ToTable("sale_order_batches");
            //����
            this.HasKey(t => t.b_num);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
