using System;
using Hengtex.Application.Code;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-05-10 16:57
    /// 描 述：sale_order_batches
    /// </summary>
    public class sale_order_batchesEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// b_id
        /// </summary>
        /// <returns></returns>
        public int? b_id { get; set; }
        /// <summary>
        /// b_number
        /// </summary>
        /// <returns></returns>
        public int? b_number { get; set; }
        /// <summary>
        /// b_num
        /// </summary>
        /// <returns></returns>
        public string b_num { get; set; }
        /// <summary>
        /// b_numCust
        /// </summary>
        /// <returns></returns>
        public string b_numCust { get; set; }
        /// <summary>
        /// b_code
        /// </summary>
        /// <returns></returns>
        public string b_code { get; set; }
        /// <summary>
        /// b_name
        /// </summary>
        /// <returns></returns>
        public string b_name { get; set; }
        /// <summary>
        /// b_order
        /// </summary>
        /// <returns></returns>
        public string b_order { get; set; }
        /// <summary>
        /// b_pinhao
        /// </summary>
        /// <returns></returns>
        public string b_pinhao { get; set; }
        /// <summary>
        /// b_pinhaoCust
        /// </summary>
        /// <returns></returns>
        public string b_pinhaoCust { get; set; }
        /// <summary>
        /// b_pinming
        /// </summary>
        /// <returns></returns>
        public string b_pinming { get; set; }
        /// <summary>
        /// 属性码
        /// </summary>
        /// <returns></returns>
        public string b_attr { get; set; }
        /// <summary>
        /// 支数
        /// </summary>
        /// <returns></returns>
        public string b_zhishu { get; set; }
        /// <summary>
        /// b_type2
        /// </summary>
        /// <returns></returns>
        public string b_type2 { get; set; }
        /// <summary>
        /// b_typeProCode
        /// </summary>
        /// <returns></returns>
        public string b_typeProCode { get; set; }
        /// <summary>
        /// b_typeProName
        /// </summary>
        /// <returns></returns>
        public string b_typeProName { get; set; }
        /// <summary>
        /// b_typeFac
        /// </summary>
        /// <returns></returns>
        public string b_typeFac { get; set; }
        /// <summary>
        /// b_flowNum
        /// </summary>
        /// <returns></returns>
        public string b_flowNum { get; set; }
        /// <summary>
        /// b_flowName
        /// </summary>
        /// <returns></returns>
        public string b_flowName { get; set; }
        /// <summary>
        /// b_color
        /// </summary>
        /// <returns></returns>
        public string b_color { get; set; }
        /// <summary>
        /// b_colorCust
        /// </summary>
        /// <returns></returns>
        public string b_colorCust { get; set; }
        /// <summary>
        /// b_dateDelivery
        /// </summary>
        /// <returns></returns>
        public DateTime? b_dateDelivery { get; set; }
        /// <summary>
        /// b_dateDeliveryNote
        /// </summary>
        /// <returns></returns>
        public string b_dateDeliveryNote { get; set; }
        /// <summary>
        /// b_dateDeliveryArig
        /// </summary>
        /// <returns></returns>
        public DateTime? b_dateDeliveryArig { get; set; }
        /// <summary>
        /// b_flagAnswer
        /// </summary>
        /// <returns></returns>
        public bool? b_flagAnswer { get; set; }
        /// <summary>
        /// b_dateDeliveryF
        /// </summary>
        /// <returns></returns>
        public DateTime? b_dateDeliveryF { get; set; }
        /// <summary>
        /// b_dateDeliveryNoteF
        /// </summary>
        /// <returns></returns>
        public string b_dateDeliveryNoteF { get; set; }
        /// <summary>
        /// b_dateDeliveryArigF
        /// </summary>
        /// <returns></returns>
        public DateTime? b_dateDeliveryArigF { get; set; }
        /// <summary>
        /// b_flagAnswerF
        /// </summary>
        /// <returns></returns>
        public bool? b_flagAnswerF { get; set; }
        /// <summary>
        /// b_fabricDelivery
        /// </summary>
        /// <returns></returns>
        public DateTime? b_fabricDelivery { get; set; }
        /// <summary>
        /// b_fabricComplete
        /// </summary>
        /// <returns></returns>
        public DateTime? b_fabricComplete { get; set; }
        /// <summary>
        /// b_count
        /// </summary>
        /// <returns></returns>
        public decimal? b_count { get; set; }
        /// <summary>
        /// b_countMin
        /// </summary>
        /// <returns></returns>
        public decimal? b_countMin { get; set; }
        /// <summary>
        /// b_countMax
        /// </summary>
        /// <returns></returns>
        public decimal? b_countMax { get; set; }
        /// <summary>
        /// b_unitprice
        /// </summary>
        /// <returns></returns>
        public decimal? b_unitprice { get; set; }
        /// <summary>
        /// b_amount
        /// </summary>
        /// <returns></returns>
        public decimal? b_amount { get; set; }
        /// <summary>
        /// b_height
        /// </summary>
        /// <returns></returns>
        public string b_height { get; set; }
        /// <summary>
        /// b_width
        /// </summary>
        /// <returns></returns>
        public string b_width { get; set; }
        /// <summary>
        /// b_weight
        /// </summary>
        /// <returns></returns>
        public string b_weight { get; set; }
        /// <summary>
        /// b_lenth
        /// </summary>
        /// <returns></returns>
        public string b_lenth { get; set; }
        /// <summary>
        /// b_state
        /// </summary>
        /// <returns></returns>
        public string b_state { get; set; }
        /// <summary>
        /// b_flagComplete
        /// </summary>
        /// <returns></returns>
        public bool? b_flagComplete { get; set; }
        /// <summary>
        /// b_timeComplete
        /// </summary>
        /// <returns></returns>
        public DateTime? b_timeComplete { get; set; }
        /// <summary>
        /// b_flagInTime
        /// </summary>
        /// <returns></returns>
        public bool? b_flagInTime { get; set; }
        /// <summary>
        /// b_lastBatch
        /// </summary>
        /// <returns></returns>
        public string b_lastBatch { get; set; }
        /// <summary>
        /// b_manDispatch
        /// </summary>
        /// <returns></returns>
        public string b_manDispatch { get; set; }
        /// <summary>
        /// b_timeDispatch
        /// </summary>
        /// <returns></returns>
        public DateTime? b_timeDispatch { get; set; }
        /// <summary>
        /// 包装截止日
        /// </summary>
        /// <returns></returns>
        public DateTime? b_timePack { get; set; }
        /// <summary>
        /// b_responsible
        /// </summary>
        /// <returns></returns>
        public string b_responsible { get; set; }
        /// <summary>
        /// b_flagPlan
        /// </summary>
        /// <returns></returns>
        public bool? b_flagPlan { get; set; }
        /// <summary>
        /// b_flagPlaned
        /// </summary>
        /// <returns></returns>
        public bool? b_flagPlaned { get; set; }
        /// <summary>
        /// b_flagPackAgain
        /// </summary>
        /// <returns></returns>
        public bool? b_flagPackAgain { get; set; }
        /// <summary>
        /// b_flagNewPro
        /// </summary>
        /// <returns></returns>
        public bool? b_flagNewPro { get; set; }
        /// <summary>
        /// b_note
        /// </summary>
        /// <returns></returns>
        public string b_note { get; set; }
        /// <summary>
        /// b_filePrintName
        /// </summary>
        /// <returns></returns>
        public string b_filePrintName { get; set; }
        /// <summary>
        /// 文件內容
        /// </summary>
        /// <returns></returns>
        public string b_filePrintData { get; set; }
        /// <summary>
        /// CreationDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        /// <returns></returns>
        public string CreatedBy { get; set; }
        /// <summary>
        /// CreatedByNum
        /// </summary>
        /// <returns></returns>
        public string CreatedByNum { get; set; }
        /// <summary>
        /// LastUpdateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? LastUpdateDate { get; set; }
        /// <summary>
        /// LastUpdatedBy
        /// </summary>
        /// <returns></returns>
        public string LastUpdatedBy { get; set; }
        /// <summary>
        /// AppUser
        /// </summary>
        /// <returns></returns>
        public string AppUser { get; set; }
        /// <summary>
        /// AppDate
        /// </summary>
        /// <returns></returns>
        public DateTime? AppDate { get; set; }
        /// <summary>
        /// FlagApp
        /// </summary>
        /// <returns></returns>
        public bool? FlagApp { get; set; }
        /// <summary>
        /// DelMan
        /// </summary>
        /// <returns></returns>
        public string DelMan { get; set; }
        /// <summary>
        /// DelDate
        /// </summary>
        /// <returns></returns>
        public DateTime? DelDate { get; set; }
        /// <summary>
        /// FlagDelete
        /// </summary>
        /// <returns></returns>
        public bool? FlagDelete { get; set; }
        /// <summary>
        /// Queue
        /// </summary>
        /// <returns></returns>
        public decimal? Queue { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.b_num = Guid.NewGuid().ToString();
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.b_num = keyValue;
                                            }
        #endregion
    }
}