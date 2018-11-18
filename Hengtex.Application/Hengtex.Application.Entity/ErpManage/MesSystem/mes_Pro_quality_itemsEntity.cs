using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage 
{
	 	//mes_pro_quality_items
		public class mes_pro_quality_itemsEntity : BaseEntity
    {
   		     
      	/// <summary>
		/// ID
        /// </summary>		
		 public string mpqi_id { get; set ;}     
		/// <summary>
		/// 工序ID
        /// </summary>		
		 public string mpqi_procedureID { get; set ;}     
		/// <summary>
		/// 工序名称
        /// </summary>		
		 public string mpqi_procedureName { get; set ;}     
		/// <summary>
		/// 分类
        /// </summary>		
		 public string mpqi_type { get; set ;}     
		/// <summary>
		/// 项目名称
        /// </summary>		
		 public string mpqi_name { get; set ;}     
		/// <summary>
		/// 序号
        /// </summary>		
		 public string mpqi_sort { get; set ;}     
		/// <summary>
		/// 考核方式
        /// </summary>		
		 public string mpqi_checkType { get; set ;}     
		/// <summary>
		/// 单价(比例%)
        /// </summary>		
		 public string mpqi_price { get; set ;}     
		/// <summary>
		/// 追加考核金额
        /// </summary>		
		 public string mpqi_amountAdd { get; set ;}     
		/// <summary>
		/// 考核均分
        /// </summary>		
		 public string mpqi_checkAvg { get; set ;}     
		/// <summary>
		/// 备注
        /// </summary>		
		 public string mpqi_remarks { get; set ;}     
		/// <summary>
		/// 创建时间
        /// </summary>		
		 public string CreationDate { get; set ;}     
		/// <summary>
		/// 创建人
        /// </summary>		
		 public string CreatedBy { get; set ;}     
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
		   
	}
}