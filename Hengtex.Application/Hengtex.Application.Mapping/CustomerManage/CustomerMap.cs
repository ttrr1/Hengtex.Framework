using Hengtex.Application.Entity.CustomerManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.CustomerManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：菠萝绒
    /// 日 期：2016-03-14 09:47
    /// 描 述：客户信息
    /// </summary>
    public class CustomerMap : EntityTypeConfiguration<CustomerEntity>
    {
        public CustomerMap()
        {
            #region 表、主键
            //表
            this.ToTable("Client_Customer");
            //主键
            this.HasKey(t => t.CustomerId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
