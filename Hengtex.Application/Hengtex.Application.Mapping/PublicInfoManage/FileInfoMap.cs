using Hengtex.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.PublicInfoManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.12.15 10:56
    /// 描 述：文件
    /// </summary>
    public class FileInfoMap : EntityTypeConfiguration<FileInfoEntity>
    {
        public FileInfoMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_FileInfo");
            //主键
            this.HasKey(t => t.FileId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
