using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Entity.ErpManage
{
    //tb_CommonDataDict
    public class tb_CommonDataDictEntity : BaseEntity
    {

        /// <summary>
        /// ISID
        /// </summary>		
        public string ISID { get; set; }
        /// <summary>
        /// DataType
        /// </summary>		
        public string DataType { get; set; }
        /// <summary>
        /// DataCode
        /// </summary>		
        public string DataCode { get; set; }
        /// <summary>
        /// NativeName
        /// </summary>		
        public string NativeName { get; set; }
        /// <summary>
        /// EnglishName
        /// </summary>		
        public string EnglishName { get; set; }
        /// <summary>
        /// CreationDate
        /// </summary>		
        public string CreationDate { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>		
        public string CreatedBy { get; set; }
        /// <summary>
        /// LastUpdateDate
        /// </summary>		
        public string LastUpdateDate { get; set; }
        /// <summary>
        /// LastUpdatedBy
        /// </summary>		
        public string LastUpdatedBy { get; set; }

    }
}