using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Service.ErpManage
{
    public class SqlOrperator<T>
    {
        private T model;
        public SqlOrperator(T model)
        {
            this.model = model;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="idFlag">false:不包含ID</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetStringForAdd(string table, bool idFlag,string id)
        {
            string sql = "insert into " + table + " ( ";

            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                if (!idFlag)
                {
                    if (!info.Name.ToLower().Equals(id))
                    {
                        sql = sql + info.Name + ",";

                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    sql = sql + info.Name + ",";
                }



            }

            sql = sql.Substring(0, sql.Length - 1);
            sql += ") values ( '";

            foreach (PropertyInfo info in typeof(T).GetProperties())
            {


                if (!idFlag)
                {
                    if (!info.Name.ToLower().Equals(id))
                    {
                        sql = sql + info.GetValue(model, null) + "','";

                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    sql = sql + info.GetValue(model, null) + "','";
                }
            }
            sql = sql.Substring(0, sql.Length - 2);
            sql += ")";
            sql = sql.Replace("''", "null");
            return sql;
        }

        public string GetStringForUpdate(string table, string key, string keyvalue)
        {
            string sql = "update " + table + " set ";
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                sql += info.Name + " = '" + info.GetValue(model, null) + "','";

            }
            sql = sql.Substring(0, sql.Length - 2);

            sql += " where " + key + " = '" + keyvalue + "'";
            sql = sql.Replace("''", "null");

            return sql;
        }
    }

}
