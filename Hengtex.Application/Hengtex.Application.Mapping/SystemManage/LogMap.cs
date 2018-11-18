using Hengtex.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.SystemManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2016.1.8 9:56
    /// 描 述：系统日志
    /// </summary>
    public class LogMap : EntityTypeConfiguration<LogEntity>
    {
        public LogMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_Log");
            //主键
            this.HasKey(t => t.LogId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
