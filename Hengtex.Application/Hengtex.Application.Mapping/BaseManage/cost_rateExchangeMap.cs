using Hengtex.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.BaseManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-01-19 14:56
    /// �� ����cost_rateExchange
    /// </summary>
    public class cost_rateExchangeMap : EntityTypeConfiguration<cost_rateExchangeEntity>
    {
        public cost_rateExchangeMap()
        {
            #region ������
            //��
            this.ToTable("cost_rateExchange");
            //����
            this.HasKey(t => t.re_id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
