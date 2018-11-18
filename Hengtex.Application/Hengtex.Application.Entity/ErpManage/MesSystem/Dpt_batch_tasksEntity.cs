using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage
{
    /// <summary>
    /// 在产批次任务
    /// </summary>


    public class Dpt_batch_tasksEntity:BaseEntity
    {
        private string bpt_id;
        public string Bpt_id
        {
            get { return bpt_id; }
            set { bpt_id = value; }
        }

        private string bpt_taskNum;
        public string Bpt_taskNum
        {
            get { return bpt_taskNum; }
            set { bpt_taskNum = value; }
        }

        private string bpt_date;
        public string Bpt_date
        {
            get { return bpt_date; }
            set { bpt_date = value; }
        }

        private string bpt_status;
        public string Bpt_status
        {
            get { return bpt_status; }
            set { bpt_status = value; }
        }

        private string bpt_materialNum;
        public string Bpt_materialNum
        {
            get { return bpt_materialNum; }
            set { bpt_materialNum = value; }
        }

        private string bpt_batch;
        public string Bpt_batch
        {
            get { return bpt_batch; }
            set { bpt_batch = value; }
        }

        private string bpt_procedureID;
        public string Bpt_procedureID
        {
            get { return bpt_procedureID; }
            set { bpt_procedureID = value; }
        }

        private string bpt_procedureName;
        public string Bpt_procedureName
        {
            get { return bpt_procedureName; }
            set { bpt_procedureName = value; }
        }

        private string bpt_fcltNum;
        public string Bpt_fcltNum
        {
            get { return bpt_fcltNum; }
            set { bpt_fcltNum = value; }
        }

        private string bpt_fcltName;
        public string Bpt_fcltName
        {
            get { return bpt_fcltName; }
            set { bpt_fcltName = value; }
        }

        private string bpt_pinhao;
        public string Bpt_pinhao
        {
            get { return bpt_pinhao; }
            set { bpt_pinhao = value; }
        }

        private string bpt_attr;
        public string Bpt_attr
        {
            get { return bpt_attr; }
            set { bpt_attr = value; }
        }

        private string bpt_color;
        public string Bpt_color
        {
            get { return bpt_color; }
            set { bpt_color = value; }
        }

        private string bpt_designNum;
        public string Bpt_designNum
        {
            get { return bpt_designNum; }
            set { bpt_designNum = value; }
        }

        private string bpt_sortNum;
        public string Bpt_sortNum
        {
            get { return bpt_sortNum; }
            set { bpt_sortNum = value; }
        }

        private string bpt_taskType;
        public string Bpt_taskType
        {
            get { return bpt_taskType; }
            set { bpt_taskType = value; }
        }

        private string bpt_panType;
        public string Bpt_panType
        {
            get { return bpt_panType; }
            set { bpt_panType = value; }
        }

        private string bpt_countIned;
        public string Bpt_countIned
        {
            get { return bpt_countIned; }
            set { bpt_countIned = value; }
        }

        private string bpt_timeStartPlan;
        public string Bpt_timeStartPlan
        {
            get { return bpt_timeStartPlan; }
            set { bpt_timeStartPlan = value; }
        }

        private string bpt_timeEndPlan;
        public string Bpt_timeEndPlan
        {
            get { return bpt_timeEndPlan; }
            set { bpt_timeEndPlan = value; }
        }

        private string bpt_timeStartReal;
        public string Bpt_timeStartReal
        {
            get { return bpt_timeStartReal; }
            set { bpt_timeStartReal = value; }
        }

        private string bpt_timeEndReal;
        public string Bpt_timeEndReal
        {
            get { return bpt_timeEndReal; }
            set { bpt_timeEndReal = value; }
        }

        private string bpt_count;
        public string Bpt_count
        {
            get { return bpt_count; }
            set { bpt_count = value; }
        }

        private string bpt_countPan;
        public string Bpt_countPan
        {
            get { return bpt_countPan; }
            set { bpt_countPan = value; }
        }

        private string bpt_unit;
        public string Bpt_unit
        {
            get { return bpt_unit; }
            set { bpt_unit = value; }
        }

        private string bpt_classWarp;
        public string Bpt_classWarp
        {
            get { return bpt_classWarp; }
            set { bpt_classWarp = value; }
        }

        private string bpt_lengthPan;
        public string Bpt_lengthPan
        {
            get { return bpt_lengthPan; }
            set { bpt_lengthPan = value; }
        }

        private string bpt_quotaClass;
        public string Bpt_quotaClass
        {
            get { return bpt_quotaClass; }
            set { bpt_quotaClass = value; }
        }

        private string bpt_weft;
        public string Bpt_weft
        {
            get { return bpt_weft; }
            set { bpt_weft = value; }
        }

        private string bpt_warpCount;
        public string Bpt_warpCount
        {
            get { return bpt_warpCount; }
            set { bpt_warpCount = value; }
        }

        private string bpt_fcltNumNext;
        public string Bpt_fcltNumNext
        {
            get { return bpt_fcltNumNext; }
            set { bpt_fcltNumNext = value; }
        }

        private string bpt_fcltNameNext;
        public string Bpt_fcltNameNext
        {
            get { return bpt_fcltNameNext; }
            set { bpt_fcltNameNext = value; }
        }

        private string bpt_remarks;
        public string Bpt_remarks
        {
            get { return bpt_remarks; }
            set { bpt_remarks = value; }
        }

        private string bpt_Person;
        public string Bpt_Person
        {
            get { return bpt_Person; }
            set { bpt_Person = value; }
        }

        private string bpt_order;
        public string Bpt_order
        {
            get { return bpt_order; }
            set { bpt_order = value; }
        }

        private string bpt_iscomplete;
        public string Bpt_iscomplete
        {
            get { return bpt_iscomplete; }
            set { bpt_iscomplete = value; }
        }

        private string bpt_iseffect;
        public string Bpt_iseffect
        {
            get { return bpt_iseffect; }
            set { bpt_iseffect = value; }
        }

        private string bpt_groupId;
        public string Bpt_groupId
        {
            get { return bpt_groupId; }
            set { bpt_groupId = value; }
        }

        private string bpt_groupName;
        public string Bpt_groupName
        {
            get { return bpt_groupName; }
            set { bpt_groupName = value; }
        }

        private string bpt_portie;
        public string Bpt_portie
        {
            get { return bpt_portie; }
            set { bpt_portie = value; }
        }

        private string creationDate;
        public string CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        private string createdBy;
        public string CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        private string createdByNum;
        public string CreatedByNum
        {
            get { return createdByNum; }
            set { createdByNum = value; }
        }

        private string lastUpdateDate;
        public string LastUpdateDate
        {
            get { return lastUpdateDate; }
            set { lastUpdateDate = value; }
        }

        private string lastUpdatedBy;
        public string LastUpdatedBy
        {
            get { return lastUpdatedBy; }
            set { lastUpdatedBy = value; }
        }

        private string appUser;
        public string AppUser
        {
            get { return appUser; }
            set { appUser = value; }
        }

        private string appDate;
        public string AppDate
        {
            get { return appDate; }
            set { appDate = value; }
        }

        private string flagApp;
        public string FlagApp
        {
            get { return flagApp; }
            set { flagApp = value; }
        }

        private string delMan;
        public string DelMan
        {
            get { return delMan; }
            set { delMan = value; }
        }

        private string delDate;
        public string DelDate
        {
            get { return delDate; }
            set { delDate = value; }
        }

        private string flagDelete;
        public string FlagDelete
        {
            get { return flagDelete; }
            set { flagDelete = value; }
        }
    }


}
