﻿using Hengtex.Application.Entity.FlowManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.FlowManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：陈彬彬
    /// 日 期：2016.02.23 09:58
    /// 描 述：工作流模板信息表
    /// </summary>
    public class WFSchemeInfoMap : EntityTypeConfiguration<WFSchemeInfoEntity>
    {
        public WFSchemeInfoMap()
        {
            #region 表、主键
            //表
            this.ToTable("WF_SchemeInfo");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}