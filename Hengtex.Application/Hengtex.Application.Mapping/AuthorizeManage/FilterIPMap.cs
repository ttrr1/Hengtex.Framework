﻿using Hengtex.Application.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.AuthorizeManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.20 13:32
    /// 描 述：过滤时段
    /// </summary>
    public class FilterIPMap : EntityTypeConfiguration<FilterIPEntity>
    {
        public FilterIPMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_FilterIP");
            //主键
            this.HasKey(t => t.FilterIPId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}