using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage 
{
	 	//mes_pro_records_detail
		public class mes_pro_records_detailEntity  : BaseEntity
	{
   		     
      	/// <summary>
		/// ID
        /// </summary>		
		 public string mprd_id { get; set ;}     
		/// <summary>
		/// 明细单据号
        /// </summary>		
		 public string mprd_numDetail { get; set ;}     
		/// <summary>
		/// 坯布匹次
        /// </summary>		
		 public string mprd_horseNo { get; set ;}     
		/// <summary>
		/// 数量
        /// </summary>		
		 public string mprd_count { get; set ;}     
		/// <summary>
		/// 备注
        /// </summary>		
		 public string mprd_remarks { get; set ;}     
		/// <summary>
		/// 责任人
        /// </summary>		
		 public string mprd_Person { get; set ;}     
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
            this.mprd_numDetail = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.mprd_numDetail = keyValue;
        }
        #endregion
    }
}