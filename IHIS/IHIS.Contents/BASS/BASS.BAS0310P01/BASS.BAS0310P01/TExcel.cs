#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.OleDb;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
    #region TExcel Class
    public class TExcel
    {
        String _filepath = "";
        String _sheetname = "";

        /// <summary>
        /// Excel Data Conversion Class
        /// </summary>
        /// <param name="strFilePath">Excel File Path</param>
        /// <param name="strSheetName">Excel Sheet Name</param>
        public TExcel(String strFilePath, String strSheetName)
        {
            _filepath = strFilePath;
            _sheetname = strSheetName;
        }

        public System.Data.DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();

            try
            {
                String strConn = "Provider=Microsoft.ACE.OLEDB.12.0"
                           + ";Data Source=C:\\IHIS\\BASS\\" + _filepath
                           + ";Extended Properties=\"Excel 12.0"
                           + ";HDR=YES;\""
                           ;
                OleDbConnection oleDbConnection = new OleDbConnection(strConn);
                oleDbConnection.Open();

                String strSel = "SELECT * FROM [" + _sheetname + "$]";
                OleDbCommand oleDbCommand = new OleDbCommand(strSel, oleDbConnection);

                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);

                oleDbDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                dataTable.Columns.Add("Data Access failed in " + _filepath + " > " + _sheetname);
                dataTable.Columns.Add(ex.Message);
            }

            return dataTable;
        }
    }
    #endregion TExcel Class
}
