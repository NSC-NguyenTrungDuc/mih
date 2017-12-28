using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Messaging;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Results.Invs;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;

namespace IHIS.CloudConnector.Converters
{
    public class OtisConverter
    {
        public static void ConvertList<TResult, TResponse>(ref TResult result, ref TResponse response)
        {
            PropertyInfo[] resultPropertyInfos = result.GetType().GetProperties();
            PropertyInfo[] responsePropertyInfos = response.GetType().GetProperties();
            // The properties order of Result and Response should be similar
            if (resultPropertyInfos.Length != 0 && resultPropertyInfos.Length == responsePropertyInfos.Length)
            {
                for (int i = 0; i < resultPropertyInfos.Length; i ++)
                {
                    resultPropertyInfos[i].SetValue(result, responsePropertyInfos[i].GetValue(response, null), null);    
                } 
            }
        }

        public static void ConvertKinki(ref SyncKinkiCacheResult result, ref SyncKinkiCacheResponse response)
        {
            result.Data = response.data;
            result.KinkiType = response.kinki_type;
        }
        public static void ConvertKinkiMasterData(ref BAS2015U00MasterDataResult result, ref BAS2015U00MasterDataResponse response)
        {
            result.Data = response.data;
            result.KinkiType = response.kinki_type;
            result.Msg = response.msg;
            result.Result = response.result;
        }
        public static void ConvertPatientExport(ref OUT0101U02PatientExportResult result, ref OUT0101U02PatientExportResponse response)
        {
            result.Data = response.data;
        }

        public static void ConvertKinkiRequestData(ref BAS2015U00MasterDataRequest request, ref BAS2015U00MasterDataArgs args)
        {
            request.data = args.Data;
            request.kinki_type = args.KinkiType;
            request.user_id = args.UserId;
            request.action_type = args.ActionType;
        }

        public static void ConvertINV4001U00Export(ref INV4001U00ExportResult result, ref INV4001U00ExportResponse response)
        {
            result.Data = response.data;
        }

        public static void ConvertCPL3020U02Import(ref CPL3020U02ImportFileResult result, ref CPL3020U02ImportFileResponse response)
        {
            result.Data = response.data;
            result.Message = response.message;
        }

        public static void ConvertCPLMASTERUPLOADERProcess(ref CPLMASTERUPLOADERProcessRequest request, ref CPLMASTERUPLOADERProcessArgs args)
        {
            request.data = args.Data;
            request.type = args.Type;
        }

        public static void ConvertUploadIFMstProcess(ref CPLMASTERUPLOADERProcessUploadIFRequest request, ref CPLMASTERUPLOADERProcessUploadIFArgs args)
        {
            request.data = args.Data;
        }
    }
}
