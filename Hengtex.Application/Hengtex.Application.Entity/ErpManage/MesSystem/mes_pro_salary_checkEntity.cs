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
		/// �������ݺ�
        /// </summary>		
		 public string mpsc_mprNum { get; set ;}     
		/// <summary>
		/// ��������
        /// </summary>		
		 public string mpsc_date { get; set ;}     
		/// <summary>
		/// ����ID
        /// </summary>		
		 public string mpsc_procedureID { get; set ;}     
		/// <summary>
		/// ��������
        /// </summary>		
		 public string mpsc_procedureName { get; set ;}     
		/// <summary>
		/// �����¼
        /// </summary>		
		 public string mpsc_contentCheck { get; set ;}     
		/// <summary>
		/// ������
        /// </summary>		
		 public string mpsc_contentResult { get; set ;}     
		/// <summary>
		/// ����
        /// </summary>		
		 public string mpsc_group { get; set ;}     
		/// <summary>
		/// ����ְ�����
        /// </summary>		
		 public string mpsc_empNum { get; set ;}     
		/// <summary>
		/// ����ְ������
        /// </summary>		
		 public string mpsc_empName { get; set ;}     
		/// <summary>
		/// ����
        /// </summary>		
		 public string mpsc_batch { get; set ;}     
		/// <summary>
		/// ��ͷ��
        /// </summary>		
		 public string mpsc_panNo { get; set ;}     
		/// <summary>
		/// ����ƥ��
        /// </summary>		
		 public string mpsc_horseNo { get; set ;}     
		/// <summary>
		/// ����
        /// </summary>		
		 public string mpsc_decript { get; set ;}     
		/// <summary>
		/// ��ע
        /// </summary>		
		 public string mpsc_remarks { get; set ;}     
		/// <summary>
		/// ������
        /// </summary>		
		 public string mpsc_Person { get; set ;}     
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
            this.mpsc_mprNum = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.mpsc_mprNum = keyValue;
        }
        #endregion
    }
}