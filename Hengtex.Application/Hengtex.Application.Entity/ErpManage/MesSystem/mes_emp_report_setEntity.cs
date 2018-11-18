using Hengtex.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    ///人员报工权限
    /// </summary>
    public class mes_emp_report_setEntity : BaseEntity
    {
        public string mprs_id { set; get; }
        public string mprs_account { set; get; }//职工账号     
        public string mprs_empnum { set; get; }//职工编号      
        public string mprs_empname { set; get; }//姓名
        public string mprs_type { set; get; }//分类
        public string mprs_proIDS { set; get; }//工序ID
        public string mprs_proNames { set; get; }//工序名称
        public string mprs_proIDsSub { set; get; }//辅助工序ID
        public string mprs_proNamesSub { set; get; }//辅助工序名称
        public string mprs_remarks { set; get; }//备注
       
        public string CreationDate { set; get; }//创建时间
        public string CreatedBy { set; get; }//创建人
        public string LastUpdateDate { set; get; }//最后修改时间
        public string LastUpdatedBy { set; get; }//最后修改人
        public string DelMan { set; get; }//删除人
        public string DelDate { set; get; }//删除时间
        public string FlagDelete { set; get; }//删除标志

    }

   
}
