using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage 
{
	 	//mes_pro_salary_check
		public class mes_pro_salary_checkEntity  : BaseEntity
	{
   		     
      	/// <summary>
		/// ID
        /// </summary>		
		 public string mpsc_id { get; set ;}     
		/// <summary>
		/// 报工单据号
        /// </summary>		
		 public string mpsc_mprNum { get; set ;}     
		/// <summary>
		/// 检验日期
        /// </summary>		
		 public string mpsc_date { get; set ;}     
		/// <summary>
		/// 工序ID
        /// </summary>		
		 public string mpsc_procedureID { get; set ;}     
		/// <summary>
		/// 工序名称
        /// </summary>		
		 public string mpsc_procedureName { get; set ;}     
		/// <summary>
		/// 检验记录
        /// </summary>		
		 public string mpsc_contentCheck { get; set ;}     
		/// <summary>
		/// 检验结果
        /// </summary>		
		 public string mpsc_contentResult { get; set ;}     
		/// <summary>
		/// 班组
        /// </summary>		
		 public string mpsc_group { get; set ;}     
		/// <summary>
		/// 检验职工编号
        /// </summary>		
		 public string mpsc_empNum { get; set ;}     
		/// <summary>
		/// 检验职工姓名
        /// </summary>		
		 public string mpsc_empName { get; set ;}     
		/// <summary>
		/// 批次
        /// </summary>		
		 public string mpsc_batch { get; set ;}     
		/// <summary>
		/// 盘头号
        /// </summary>		
		 public string mpsc_panNo { get; set ;}     
		/// <summary>
		/// 坯布匹次
        /// </summary>		
		 public string mpsc_horseNo { get; set ;}     
		/// <summary>
		/// 描述
        /// </summary>		
		 public string mpsc_decript { get; set ;}     
		/// <summary>
		/// 备注
        /// </summary>		
		 public string mpsc_remarks { get; set ;}     
		/// <summary>
		/// 责任人
        /// </summary>		
		 public string mpsc_Person { get; set ;}     
		/// <summary>
		/// 创建时间
        /// </summary>		
		 public string CreationDate { get; set ;}     
		/// <summary>
		/// 创建人
        /// </summary>		
		 public string CreatedBy { get; set ;}     
		/// <summary>
		/// 创建人编号
        /// </summary>		
		 public string CreatedByNum { get; set ;}     
		/// <summary>
		/// 最后修改时间
        /// </summary>		
		 public string LastUpdateDate { get; set ;}     
		/// <summary>
		/// 最后修改人
        /// </summary>		
		 public string LastUpdatedBy { get; set ;}     
		/// <summary>
		/// 审核人
        /// </summary>		
		 public string AppUser { get; set ;}     
		/// <summary>
		/// 审核时间
        /// </summary>		
		 public string AppDate { get; set ;}     
		/// <summary>
		/// 审核标志
        /// </summary>		
		 public string FlagApp { get; set ;}     
		/// <summary>
		/// 删除人
        /// </summary>		
		 public string DelMan { get; set ;}     
		/// <summary>
		/// 删除时间
        /// </summary>		
		 public string DelDate { get; set ;}     
		/// <summary>
		/// 删除标志
        /// </summary>		
		 public string FlagDelete { get; set ;}

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.mpsc_mprNum = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.mpsc_mprNum = keyValue;
        }
        #endregion
    }
}