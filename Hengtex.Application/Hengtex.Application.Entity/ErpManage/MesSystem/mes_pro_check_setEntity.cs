using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage
{   
    /// <summary>
    /// 工序把关设定
    /// </summary>
    public class mes_pro_check_setEntity : BaseEntity
    {

        public string mpcs_id { set; get; }
        
        public string mpcs_type { set; get; }//分类
        public string mpcs_proIDEnd { set; get; }//完工工序ID
        public string mpcs_proNameEnd { set; get; }//完工工序名称
        public string mpcs_proIDAc { set; get; }//合格验收工序ID
        public string mpcs_proNameAc { set; get; }//合格验收工序名称
        public string mpcs_proIDCheck { set; get; }//可把关完工工序ID
        public string mpcs_proNameCheck { set; get; }//可把关完工工序名称
        public string mpcs_remarks { set; get; }//备注

        public string CreationDate { set; get; }//创建时间
        public string CreatedBy { set; get; }//创建人
        public string LastUpdateDate { set; get; }//最后修改时间
        public string LastUpdatedBy { set; get; }//最后修改人
        public string DelMan { set; get; }//删除人
        public string DelDate { set; get; }//删除时间
        public string FlagDelete { set; get; }//删除标志

    }


}

