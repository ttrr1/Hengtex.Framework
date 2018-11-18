using Hengtex.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.SystemManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-02-03 17:07
    /// 描 述：tb_CommonDataDict
    /// </summary>
    public class tb_CommonDataDictMap : EntityTypeConfiguration<tb_CommonDataDictEntity>
    {
        public tb_CommonDataDictMap()
        {
            #region 表、主键
            //表
            this.ToTable("tb_CommonDataDict");
            //主键
            this.HasKey(t => t.ISID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
