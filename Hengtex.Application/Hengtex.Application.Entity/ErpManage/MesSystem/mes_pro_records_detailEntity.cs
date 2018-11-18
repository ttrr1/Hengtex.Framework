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
		/// ��ϸ���ݺ�
        /// </summary>		
		 public string mprd_numDetail { get; set ;}     
		/// <summary>
		/// ����ƥ��
        /// </summary>		
		 public string mprd_horseNo { get; set ;}     
		/// <summary>
		/// ����
        /// </summary>		
		 public string mprd_count { get; set ;}     
		/// <summary>
		/// ��ע
        /// </summary>		
		 public string mprd_remarks { get; set ;}     
		/// <summary>
		/// ������
        /// </summary>		
		 public string mprd_Person { get; set ;}     
		/// <summary>
		/// ����ʱ��
        /// </summary>		
		 public string CreationDate { get; set ;}     
		/// <summary>
		/// ������
        /// </summary>		
		 public string CreatedBy { get; set ;}     
		/// <summary>
		/// �����˱��
        /// </summary>		
		 public string CreatedByNum { get; set ;}     
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

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.mprd_numDetail = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.mprd_numDetail = keyValue;
        }
        #endregion
    }
}