﻿using Hengtex.Application.Entity.FlowManage;
using System.Data.Entity.ModelConfiguration;

namespace Hengtex.Application.Mapping.FlowManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：陈彬彬
    /// 日 期：2016.03.18 09:58
    /// 描 述：工作流委托规则表
    /// </summary>
    public class WFDelegateRuleMap : EntityTypeConfiguration<WFDelegateRuleEntity>
    {
        public WFDelegateRuleMap()
        {
            #region 表、主键
            //表
            this.ToTable("WF_DelegateRule");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}