using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage
{
    //mes_pro_check
    public class mes_pro_checkEntity : BaseEntity
    {

        /// <summary>
        /// ID
        /// </summary>		
        public string mpc_id { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>		
        public string mpc_num { get; set; }
        /// <summary>
        /// 报工单据号
        /// </summary>		
        public string mpc_mprNum { get; set; }
        /// <summary>
        /// 登记日期
        /// </summary>		
        public string mpc_date { get; set; }
        /// <summary>
        /// 工序ID
        /// </summary>		
        public string mpc_procedureID { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>		
        public string mpc_procedureName { get; set; }
        /// <summary>
        /// 质量项目ID
        /// </summary>		
        public string mpc_qid { get; set; }
        /// <summary>
        /// 质量项目名称
        /// </summary>		
        public string mpc_qname { get; set; }
        /// <summary>
        /// 考核方式
        /// </summary>		
        public string mpc_checkType { get; set; }
        /// <summary>
        /// 数量
        /// </summary>		
        public string mpc_count { get; set; }
        /// <summary>
        /// 个数
        /// </summary>		
        public string mpc_pcs { get; set; }
        /// <summary>
        /// 单价(比例%)
        /// </summary>		
        public string mpc_price { get; set; }
        /// <summary>
        /// 金额
        /// </summary>		
        public string mpc_amount { get; set; }
        /// <summary>
        /// 追加金额
        /// </summary>		
        public string mpc_amountAdd { get; set; }
        /// <summary>
        /// mpc_checkAvg
        /// </summary>		
        public string mpc_checkAvg { get; set; }
        /// <summary>
        /// 班组
        /// </summary>		
        public string mpc_group { get; set; }
        /// <summary>
        /// 工资标志
        /// </summary>		
        public string mpc_salaryFlag { get; set; }
        /// <summary>
        /// 分类
        /// </summary>		
        public string mpc_TypeFlag { get; set; }
        /// <summary>
        /// 批次
        /// </summary>		
        public string mpc_batch { get; set; }
        /// <summary>
        /// 盘头号
        /// </summary>		
        public string mpc_panNo { get; set; }
        /// <summary>
        /// 坯布匹次
        /// </summary>		
        public string mpc_horseNo { get; set; }
        /// <summary>
        /// 把关工序ID
        /// </summary>		
        public string mpc_proIDCheck { get; set; }
        /// <summary>
        /// 把关工序名称
        /// </summary>		
        public string mpc_proNameCheck { get; set; }
        /// <summary>
        /// 部门
        /// </summary>		
        public string mpc_depart { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>		
        public string mpc_departName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>		
        public string mpc_decript { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string mpc_remarks { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public string CreationDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>		
        public string CreatedBy { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>		
        public string CreatedByNum { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>		
        public string LastUpdateDate { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>		
        public string LastUpdatedBy { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>		
        public string AppUser { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>		
        public string AppDate { get; set; }
        /// <summary>
        /// 审核标志
        /// </summary>		
        public string FlagApp { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>		
        public string DelMan { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>		
        public string DelDate { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>		
        public string FlagDelete { get; set; }

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.FlagApp = "0";
            this.FlagDelete = "0";
            this.mpc_date = DateTime.Now.ToString();
            this.CreationDate = DateTime.Today.ToString();

        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.mpc_num = keyValue;
        }
        #endregion
    }
}