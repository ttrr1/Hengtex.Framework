using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 批次信息
    /// </summary>
    public   class bg_batchEntity : BaseEntity
    {
       
        public string b_num { set; get; }//编码
        public string b_color { set; get; }//颜色
        public string b_pinhao { set; get; }//品号  
        public string b_pinming { set; get; }//品号    
        public string b_attr { set; get; }//属性码      
        public string b_zhishu { set; get; }//支数
        public string b_count { set; get; }//数量
        public string b_dateDelivery { set; get; }//交期
   
        public string o_custNum { set; get; }
        public string o_custName { set; get; }



    }


}
