using System;
using System.Collections.Generic;
using System.Text;
using IHIS.Framework;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlTypes;
using System.Globalization;

namespace INVS.Libs
{
    public static class INVHelpers
    {
        /// <summary>
        /// Exports a grid content to CSV file, include header
        /// </summary>
        /// <param name="xGrid"></param>
        /// <param name="fileName"></param>
        public static bool ExportCSV(XEditGrid xGrid, string fileName)
        {
            bool ret = true;

            try
            {
                DataTable dt = new DataTable("PrintTable");

                // Header text
                //MED-12596
                // https://sofiamedix.atlassian.net/browse/MED-12830
                for (int i = 0; i < xGrid.LayoutTable.Columns.Count; i++)
                {
                    dt.Columns.Add(xGrid.CellInfos[i].HeaderText);
                }

                foreach (DataRow dr in xGrid.LayoutTable.Rows)
                {
                    // Skip DataTable header row
                    //if (xGrid.LayoutTable.Rows.IndexOf(dr) == 0) continue;

                    // Import to print table
                    dt.Rows.Add(dr.ItemArray);
                }

                // Writes to CSV
                string csvContent = Utilities.ToCSV(dt);
                using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.UTF8))
                {
                    sw.WriteLine(csvContent);
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.Message);
                Service.WriteLog(ex.StackTrace);

                ret = false;
            }
            finally { }

            return ret;
        }

        public static string FormatDateStrByLocale(string dateStr)
        {
            DateTime dt;
            string date = "";

            try
            {
                dt = DateTime.ParseExact(dateStr, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                date = dt.ToString();
            }
            catch (Exception ex)
            {
                date = "";
                Service.WriteLog(ex.Message);
                Service.WriteLog(ex.StackTrace);
            }
            finally { }

            return date;
        }
    }
    public class CsvExport<T> where T : class
    {
        public List<T> Objects;

        public List<string> Headers;

        public CsvExport(List<T> objects)
        {
            Objects = objects;
        }

        public CsvExport(List<T> objects, List<string> headers)
        {
            Objects = objects;
            Headers = headers;
        }

        public string Export()
        {
            return Export(true);
        }

        public string Export(bool includeHeaderLine)
        {

            StringBuilder sb = new StringBuilder();
            //Get properties using reflection.
            IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();

            if (includeHeaderLine && Headers != null)
            {
                //add header line.
                foreach (string header in Headers)
                {
                    sb.Append(header).Append(",");
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            //add value for each property.
            foreach (T obj in Objects)
            {
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(",");
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            return sb.ToString();
        }

        //export to a file.
        public void ExportToFile(string path)
        {
            File.WriteAllText(path, Export(),Encoding.UTF8);
        }

        //export as binary data.
        public byte[] ExportToBytes()
        {
            return Encoding.UTF8.GetBytes(Export());
        }

        //get the csv value for field.
        private string MakeValueCsvFriendly(object value)
        {
            if (value == null) return "";
            if (value is Nullable && ((INullable)value).IsNull) return "";

            if (value is DateTime)
            {
                if ((DateTime)value == DateTime.ParseExact("1970/01/01", "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture))
                    return "";
                if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                    if(CultureInfo.CurrentCulture.Name.Equals("vi-VN"))
                        return ((DateTime)value).ToString("dd/MM/yyyy");
                    return ((DateTime)value).ToString("yyyy/MM/dd");
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            string output = value.ToString();

            if (output.Contains(",") || output.Contains("\""))
                output = '"' + output.Replace("\"", "\"\"") + '"';

            return output;

        }
    }
}
