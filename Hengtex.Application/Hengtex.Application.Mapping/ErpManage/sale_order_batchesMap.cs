using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-05-10 16:57
    /// 描 述：sale_order_batches
    /// </summary>
    public class sale_order_batchesMap : EntityTypeConfiguration<sale_order_batchesEntity>
    {
        public sale_order_batchesMap()
        {
            #region 表、主键
            //表
            this.ToTable("sale_order_batches");
            //主键
            this.HasKey(t => t.b_num);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
