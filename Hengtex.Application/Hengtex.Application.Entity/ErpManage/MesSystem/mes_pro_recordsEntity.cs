using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage 
{
	 	//mes_pro_records
		public class mes_pro_recordsEntity  : BaseEntity
	{
   		     
      	/// <summary>
		/// ID
        /// </summary>		
		 public string mpr_id { get; set ;}     
		/// <summary>
		/// 报工单据号
        /// </summary>		
		 public string mpr_num { get; set ;}     
		/// <summary>
		/// 计划明细编号
        /// </summary>		
		 public string mpr_taskNum { get; set ;}     
		/// <summary>
		/// 登记日期
        /// </summary>		
		 public string mpr_date { get; set ;}     
		/// <summary>
		/// 工序ID
        /// </summary>		
		 public string mpr_procedureID { get; set ;}     
		/// <summary>
		/// 工序名称
        /// </summary>		
		 public string mpr_procedureName { get; set ;}     
		/// <summary>
		/// 开完工标志
        /// </summary>		
		 public string mpr_SEFlag { get; set ;}     
		/// <summary>
		/// 机台号
        /// </summary>		
		 public string mpr_fcltNum { get; set ;}     
		/// <summary>
		/// 机台名称
        /// </summary>		
		 public string mpr_fcltName { get; set ;}     
		/// <summary>
		/// 班组
        /// </summary>		
		 public string mpr_group { get; set ;}     
		/// <summary>
		/// 批次
        /// </summary>		
		 public string mpr_batch { get; set ;}     
		/// <summary>
		/// 品号
        /// </summary>		
		 public string mpr_pinhao { get; set ;}     
		/// <summary>
		/// mpr_color
        /// </summary>		
		 public string mpr_color { get; set ;}     
		/// <summary>
		/// mpr_attr
        /// </summary>		
		 public string mpr_attr { get; set ;}     
		/// <summary>
		/// 数量
        /// </summary>		
		 public string mpr_count { get; set ;}     
		/// <summary>
		/// 比例
        /// </summary>		
		 public string mpr_bl { get; set ;}     
		/// <summary>
		/// 单位
        /// </summary>		
		 public string mpr_unit { get; set ;}     
		/// <summary>
		/// 职工编号
        /// </summary>		
		 public string mpr_empNum { get; set ;}     
		/// <summary>
		/// 职工姓名
        /// </summary>		
		 public string mpr_empName { get; set ;}     
		/// <summary>
		/// 工资标志
        /// </summary>		
		 public string mpr_salaryFlag { get; set ;}     
		/// <summary>
		/// 追加标志
        /// </summary>		
		 public string mpr_addFlag { get; set ;}     
		/// <summary>
		/// 超量标志
        /// </summary>		
		 public string mpr_moreFlag { get; set ;}     
		/// <summary>
		/// 代报工标志
        /// </summary>		
		 public string mpr_placeFlag { get; set ;}     
		/// <summary>
		/// 回修标志
        /// </summary>		
		 public string mpr_reworkFlag { get; set ;}     
		/// <summary>
		/// 回修次数
        /// </summary>		
		 public string mpr_reworkCount { get; set ;}     
		/// <summary>
		/// 盘头号
        /// </summary>		
		 public string mpr_panNo { get; set ;}     
		/// <summary>
		/// 绞数
        /// </summary>		
		 public string mpr_hankCount { get; set ;}     
		/// <summary>
		/// 明细单据号
        /// </summary>		
		 public string mpr_numDetail { get; set ;}     
		/// <summary>
		/// 坯布匹次
        /// </summary>		
		 public string mpr_horseNo { get; set ;}     
		/// <summary>
		/// 遍数
        /// </summary>		
		 public string mpr_timeCount { get; set ;}     
		/// <summary>
		/// 货位
        /// </summary>		
		 public string mpr_location { get; set ;}     
		/// <summary>
		/// 货位名称
        /// </summary>		
		 public string mpr_locationName { get; set ;}     
		/// <summary>
		/// 合格判定结果
        /// </summary>		
		 public string mpr_checkResult { get; set ;}     
		/// <summary>
		/// 描述
        /// </summary>		
		 public string mpr_decript { get; set ;}     
		/// <summary>
		/// 备注
        /// </summary>		
		 public string mpr_remarks { get; set ;}     
		/// <summary>
		/// 责任人
        /// </summary>		
		 public string mpr_Person { get; set ;}     
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
            this.FlagApp = "0";
            this.FlagDelete = "0";          
            this.mpr_date = DateTime.Now.ToString();
            this.CreationDate = DateTime.Today.ToString();

        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.mpr_num = keyValue;
        }
        #endregion
    }
}