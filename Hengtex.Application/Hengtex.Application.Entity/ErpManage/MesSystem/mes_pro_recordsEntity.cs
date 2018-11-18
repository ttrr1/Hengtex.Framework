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
		/// �������ݺ�
        /// </summary>		
		 public string mpr_num { get; set ;}     
		/// <summary>
		/// �ƻ���ϸ���
        /// </summary>		
		 public string mpr_taskNum { get; set ;}     
		/// <summary>
		/// �Ǽ�����
        /// </summary>		
		 public string mpr_date { get; set ;}     
		/// <summary>
		/// ����ID
        /// </summary>		
		 public string mpr_procedureID { get; set ;}     
		/// <summary>
		/// ��������
        /// </summary>		
		 public string mpr_procedureName { get; set ;}     
		/// <summary>
		/// ���깤��־
        /// </summary>		
		 public string mpr_SEFlag { get; set ;}     
		/// <summary>
		/// ��̨��
        /// </summary>		
		 public string mpr_fcltNum { get; set ;}     
		/// <summary>
		/// ��̨����
        /// </summary>		
		 public string mpr_fcltName { get; set ;}     
		/// <summary>
		/// ����
        /// </summary>		
		 public string mpr_group { get; set ;}     
		/// <summary>
		/// ����
        /// </summary>		
		 public string mpr_batch { get; set ;}     
		/// <summary>
		/// Ʒ��
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
		/// ����
        /// </summary>		
		 public string mpr_count { get; set ;}     
		/// <summary>
		/// ����
        /// </summary>		
		 public string mpr_bl { get; set ;}     
		/// <summary>
		/// ��λ
        /// </summary>		
		 public string mpr_unit { get; set ;}     
		/// <summary>
		/// ְ�����
        /// </summary>		
		 public string mpr_empNum { get; set ;}     
		/// <summary>
		/// ְ������
        /// </summary>		
		 public string mpr_empName { get; set ;}     
		/// <summary>
		/// ���ʱ�־
        /// </summary>		
		 public string mpr_salaryFlag { get; set ;}     
		/// <summary>
		/// ׷�ӱ�־
        /// </summary>		
		 public string mpr_addFlag { get; set ;}     
		/// <summary>
		/// ������־
        /// </summary>		
		 public string mpr_moreFlag { get; set ;}     
		/// <summary>
		/// ��������־
        /// </summary>		
		 public string mpr_placeFlag { get; set ;}     
		/// <summary>
		/// ���ޱ�־
        /// </summary>		
		 public string mpr_reworkFlag { get; set ;}     
		/// <summary>
		/// ���޴���
        /// </summary>		
		 public string mpr_reworkCount { get; set ;}     
		/// <summary>
		/// ��ͷ��
        /// </summary>		
		 public string mpr_panNo { get; set ;}     
		/// <summary>
		/// ����
        /// </summary>		
		 public string mpr_hankCount { get; set ;}     
		/// <summary>
		/// ��ϸ���ݺ�
        /// </summary>		
		 public string mpr_numDetail { get; set ;}     
		/// <summary>
		/// ����ƥ��
        /// </summary>		
		 public string mpr_horseNo { get; set ;}     
		/// <summary>
		/// ����
        /// </summary>		
		 public string mpr_timeCount { get; set ;}     
		/// <summary>
		/// ��λ
        /// </summary>		
		 public string mpr_location { get; set ;}     
		/// <summary>
		/// ��λ����
        /// </summary>		
		 public string mpr_locationName { get; set ;}     
		/// <summary>
		/// �ϸ��ж����
        /// </summary>		
		 public string mpr_checkResult { get; set ;}     
		/// <summary>
		/// ����
        /// </summary>		
		 public string mpr_decript { get; set ;}     
		/// <summary>
		/// ��ע
        /// </summary>		
		 public string mpr_remarks { get; set ;}     
		/// <summary>
		/// ������
        /// </summary>		
		 public string mpr_Person { get; set ;}     
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
            this.FlagApp = "0";
            this.FlagDelete = "0";          
            this.mpr_date = DateTime.Now.ToString();
            this.CreationDate = DateTime.Today.ToString();

        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.mpr_num = keyValue;
        }
        #endregion
    }
}