using Hengtex.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    ///mes项目动态定义
    /// </summary>
    public class mes_dynamic_controlsEntity : BaseEntity
    {
        public string mdc_id { set; get; }        
        public string mdc_num { set; get; }//编号      
        public string mdc_name { set; get; }//名称
        public string mdc_fieldName { set; get; }//物理名
        public string mdc_type { set; get; }//控件类型
        public string mdc_checkType { set; get; }//检查类型
        public string mdc_sql { set; get; }//数据源       
        public string mdc_remarks { set; get; }//备注       
        public string CreationDate { set; get; }//创建时间
        public string CreatedBy { set; get; }//创建人
        public string LastUpdateDate { set; get; }//最后修改时间
        public string LastUpdatedBy { set; get; }//最后修改人
        public string DelMan { set; get; }//删除人
        public string DelDate { set; get; }//删除时间
        public string FlagDelete { set; get; }//删除标志

    }

   
}
