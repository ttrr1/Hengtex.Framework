using Hengtex.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 设备管理-水电表管理部分 2018-02-08
    /// </summary>
    public class AmmeEntity : BaseEntity
    {
        public string a_ID { set; get; }
        public string a_ammeNo { set; get; }//电表编号     
        public string a_ammeName { set; get; }//电表名称      
        public string a_ammeSpecification { set; get; }//电表规格
        public string a_amme { set; get; }//电表倍率
        public string a_ammeCofficient { set; get; }//电表系数
        public string a_ammeType { set; get; }//电表类别
        public string a_transformer { set; get; }//变压器
        public string a_transformerNo { set; get; }//变压器编码
        public string a_numDept { set; get; }//一级机构编码
        public string a_Dept { set; get; }//一级机构名称
        public string a_numDeptTow { set; get; }//二级机构编码
        public string a_DeptTow { set; get; }//二级机构名称
        public string a_numDeptThree { set; get; }//三级机构编码
        public string a_DeptThree { set; get; }//三级机构名称
        public string a_note { set; get; } //备注
        public string a_flagTotal { set; get; }//是否合计
        public string a_flagMain { set; get; }//是否总表
        public string a_processName { set; get; }//工序名称
        public string CreationDate { set; get; }//创建时间
        public string CreatedBy { set; get; }//创建人
        public string LastUpdateDate { set; get; }//最后修改时间
        public string LastUpdatedBy { set; get; }//最后修改人
        public string DelMan { set; get; }//删除人
        public string DelDate { set; get; }//删除时间
        public string FlagDelete { set; get; }//删除标志

    }

    public class AmmeDailyEntity : AmmeEntity
    {
        public  string ad_id { set; get; }
        public  string ad_date { set; get; }//日期      
        public  string ad_ammeNo { set; get; }//电表编号
        public  string ad_readingStart { set; get; }//起码
        public  string ad_readingEnd { set; get; }//止码
        public  string ad_realDegree { set; get; }//实际度数
        public  string ad_note { set; get; }//备注
        public  string ad_registrant { set; get; }//制单人
        public  string ad_registTime { set; get; }//制单时间
        public  string CreationDate { set; get; }//创建时间
        public  string CreatedBy { set; get; }//创建人
        public  string LastUpdateDate { set; get; }//最后修改时间
        public  string LastUpdatedBy { set; get; }//最后修改人



        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
         
            this.CreationDate = DateTime.Now.ToString("yyyyMMdd");         
            this.CreatedBy = OperatorProvider.Provider.Current().UserName;
            this.ad_date = DateTime.Now.ToString("yyyyMMdd");
            this.ad_registrant = OperatorProvider.Provider.Current().UserName;
            this.ad_registTime = DateTime.Now.ToString("yyyyMMdd");
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {

            this.LastUpdatedBy = OperatorProvider.Provider.Current().UserName;
            this.LastUpdateDate = DateTime.Now.ToString("yyyyMMdd");
        }
        #endregion
    }
}
