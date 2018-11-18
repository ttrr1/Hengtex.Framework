using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.Entity.ErpManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：电表档案管理
    /// </summary>
    public class AmmeMap : EntityTypeConfiguration<AmmeEntity>
    {
        public AmmeMap()
        {
            #region 表、主键
            //表
            this.ToTable("fclt_ammeters");
            //主键
            this.HasKey(t => t.a_ammeNo);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
