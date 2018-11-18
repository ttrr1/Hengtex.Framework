using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 工序档案
    /// </summary>
    public   class doc_flow_proceduresEntity : BaseEntity
    {
        public string dfp_id { set; get; }
        public string dfp_num { set; get; }//工序编码
        public string dfp_name { set; get; }//工序名称
        public string dfp_standard { set; get; }//工作标准描述     
        public string dfp_mark { set; get; }//助记符      
        public string dfp_typeFlow { set; get; }//流程类型
        public string dfp_type { set; get; }//工序类型
        public string dfp_unit { set; get; }//工序计件单位
        public string dfp_departCode { set; get; }//所属部门编码
        public string dfp_departName { set; get; }//所属部门名称
        public string dfp_flagDye { set; get; }//需要染料标志
        public string dfp_flagAuxi { set; get; }//需要助剂标志
        public string dfp_MainNum { set; get; }//主工序编码
        public string dfp_MainName { set; get; }//主工序名称
        public string dfp_dinge { set; get; }//日工资定额
        public string dfp_maxCapacity { set; get; }//产能
        public string dfp_flagCapacity { set; get; }//是否参与产能统计
        public string dfp_flagEnd { set; get; }//是否了机工序

        public string dfp_flagSample { set; get; }//是否样品工序
        public string dfp_flagDispatch { set; get; }//

        public string dfp_flagStoreIssue { set; get; }//

        public string dfp_hrDepartCode { set; get; }//
        public string dfp_hrDepartName { set; get; }//
        public string dfp_appUrl { set; get; }//指向手机版页面连接



        public string dfp_note { set; get; }//备注

       

    }


}
