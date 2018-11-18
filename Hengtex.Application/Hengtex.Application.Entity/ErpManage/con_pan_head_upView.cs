using System;
using System.ComponentModel.DataAnnotations.Schema;
using Hengtex.Application.Code;
using System.Collections.Generic;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2012-2017 ��̩��֯
    /// �� ������������Ա
    /// �� �ڣ�2018-05-22 15:57
    /// �� ����con_pan_head_up
    /// </summary>
    [NotMapped]
    public class con_pan_head_upView : con_pan_head_upEntity
    {
       
        /// <summary>
        /// ��ϸ����
        /// </summary>
        /// <returns></returns>
        [Column("emps")]
        public List<con_pan_head_empsEntity> emps { get; set; }

        
    }
}