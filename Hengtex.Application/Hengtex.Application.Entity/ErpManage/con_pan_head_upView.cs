using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;
using System.Collections.Generic;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-05-22 15:57
    /// 描 述：con_pan_head_up
    /// </summary>
    [NotMapped]
    public class con_pan_head_upView : con_pan_head_upEntity
    {
       
        /// <summary>
        /// 明细数据
        /// </summary>
        /// <returns></returns>
        [Column("emps")]
        public List<con_pan_head_empsEntity> emps { get; set; }

        
    }
}