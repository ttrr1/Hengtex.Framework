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
		/// ����ID
        /// </summary>		
		 public string mpqi_procedureID { get; set ;}     
		/// <summary>
		/// ��������
        /// </summary>		
		 public string mpqi_procedureName { get; set ;}     
		/// <summary>
		/// ����
        /// </summary>		
		 public string mpqi_type { get; set ;}     
		/// <summary>
		/// ��Ŀ����
        /// </summary>		
		 public string mpqi_name { get; set ;}     
		/// <summary>
		/// ���
        /// </summary>		
		 public string mpqi_sort { get; set ;}     
		/// <summary>
		/// ���˷�ʽ
        /// </summary>		
		 public string mpqi_checkType { get; set ;}     
		/// <summary>
		/// ����(����%)
        /// </summary>		
		 public string mpqi_price { get; set ;}     
		/// <summary>
		/// ׷�ӿ��˽��
        /// </summary>		
		 public string mpqi_amountAdd { get; set ;}     
		/// <summary>
		/// ���˾���
        /// </summary>		
		 public string mpqi_checkAvg { get; set ;}     
		/// <summary>
		/// ��ע
        /// </summary>		
		 public string mpqi_remarks { get; set ;}     
		/// <summary>
		/// ����ʱ��
        /// </summary>		
		 public string CreationDate { get; set ;}     
		/// <summary>
		/// ������
        /// </summary>		
		 public string CreatedBy { get; set ;}     
		/// <summary>
		/// ����޸�ʱ��
        /// </summary>		
		 public string LastUpdateDate { get; set ;}     
		/// <summary>
		/// ����޸���
        /// </summary>		
		 public string LastUpdatedBy { get; set ;}     
		/// <summary>
		/// �����
        /// </summary>		
		 public string AppUser { get; set ;}     
		/// <summary>
		/// ���ʱ��
        /// </summary>		
		 public string AppDate { get; set ;}     
		/// <summary>
		/// ��˱�־
        /// </summary>		
		 public string FlagApp { get; set ;}     
		/// <summary>
		/// ɾ����
        /// </summary>		
		 public string DelMan { get; set ;}     
		/// <summary>
		/// ɾ��ʱ��
        /// </summary>		
		 public string DelDate { get; set ;}     
		/// <summary>
		/// ɾ����־
        /// </summary>		
		 public string FlagDelete { get; set ;}     
		   
	}
}