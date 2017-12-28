﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

//namespace OCS2015U30
namespace IHIS.OCSO
{
    public class Utilities
    {

    }

    public class TableList<T> : List<T>
    {
        /// <summary>
        /// creates a datatable containing all the public properties
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();

            //special handling for value types and string
            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {

                DataColumn dc = new DataColumn("Value");

                dt.Columns.Add(dc);

                foreach (T item in this)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = item;

                    dt.Rows.Add(dr);
                }
            }

            else//for reference types other than  string
            {

                //find all the public properties of this Type using reflection
                PropertyInfo[] piT = typeof(T).GetProperties();

                foreach (PropertyInfo pi in piT)
                {
                    //create a datacolumn for each property
                    DataColumn dc = new DataColumn(pi.Name, pi.PropertyType);

                    dt.Columns.Add(dc);
                }

                //now we iterate through all the items in current instance, take the corresponding values and add a new row in dt
                for (int item = 0; item < this.Count; item++)
                {
                    DataRow dr = dt.NewRow();

                    for (int property = 0; property < dt.Columns.Count; property++)
                    {
                        dr[property] = piT[property].GetValue(this[item], null);
                    }

                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}
