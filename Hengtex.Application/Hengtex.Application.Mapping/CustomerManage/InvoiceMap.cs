using Hengtex.Application.Entity.CustomerManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.CustomerManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2016-04-01 14:33
    /// 描 述：开票信息
    /// </summary>
    public class InvoiceMap : EntityTypeConfiguration<InvoiceEntity>
    {
        public InvoiceMap()
        {
            #region 表、主键
            //表
            this.ToTable("Client_Invoice");
            //主键
            this.HasKey(t => t.InvoiceId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
