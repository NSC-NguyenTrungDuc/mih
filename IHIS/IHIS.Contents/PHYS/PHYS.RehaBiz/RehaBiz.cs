using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Phys;
using IHIS.CloudConnector.Contracts.Models.Phys;
using IHIS.CloudConnector.Contracts.Results.Phys;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.PHYS
{
    /// <summary>
    /// 처방시스템에서 Business 로직 구현을 위한 그룹Level Class
    /// </summary>
    public class RehaBiz
    {
        public string GetServerIP(string code)
        {
//            string cmd = @"SELECT A.CODE_NAME
//                             FROM OCS0132 A
//                            WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
//                              AND A.CODE_TYPE = 'SERVER_IP'
//                              AND A.CODE      = '" + code + "'";

//            object obj = Service.ExecuteScalar(cmd);

//            return obj.ToString();

            // updated by Cloud
            PHY2001U04GetServerIPArgs args = new PHY2001U04GetServerIPArgs();
            args.Code = code;
            PHY2001U04StringResult res = CloudService.Instance.Submit<PHY2001U04StringResult, PHY2001U04GetServerIPArgs>(args);

            return res.ResStr;
        }
    }
}
