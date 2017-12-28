package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.inps.PrIfsMakeIpwonHistoryResultInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01ExecuteProcedureRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01ExecuteProcedureResponse;

@Service
@Scope("prototype")
public class INP1001U01ExecuteProcedureHandler extends
		ScreenHandler<InpsServiceProto.INP1001U01ExecuteProcedureRequest, InpsServiceProto.INP1001U01ExecuteProcedureResponse> {

	private static final Log LOGGER = LogFactory.getLog(INP1001U01ExecuteProcedureHandler.class);  
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(rollbackFor = Exception.class)
	public INP1001U01ExecuteProcedureResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01ExecuteProcedureRequest request) throws Exception {
		
		InpsServiceProto.INP1001U01ExecuteProcedureResponse.Builder response = InpsServiceProto.INP1001U01ExecuteProcedureResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String procName = request.getProcName();
		List<CommonModelProto.DataStringListItemInfo> inputList = request.getInpListList();
		
		LOGGER.info(String.format("Execute procedure %s, hosp_code = %s", request.getProcName(), hospCode));

		if(StringUtils.isEmpty(procName) || CollectionUtils.isEmpty(inputList)){
			LOGGER.info(String.format("Invalid proc_name or input_list, hosp_code = %s", hospCode));
			return response.build();
		}
		
		CommonProcResultInfo commonResult = null;
		
		switch (procName) {
		case "PR_INP_CHECK_IPWON_TRANS":
			if(inputList.size() < 3){
				LOGGER.info(String.format("Execute PR_INP_CHECK_IPWON_TRANS, hosp_code = %s: invalid input_param", hospCode));
				return response.build();
			}
			
			commonResult = inp1001Repository.callPrInpCheckIpwonTrans(inputList.get(0).getDataValue()
					, inputList.get(1).getDataValue()
					, DateUtil.toDate(inputList.get(2).getDataValue(), DateUtil.PATTERN_YYMMDD));
			break;
		case "PR_INP_IPWON_CANCEL":
			if(inputList.size() < 3){
				LOGGER.info(String.format("Execute PR_INP_IPWON_CANCEL, hosp_code = %s: invalid input_param", hospCode));
				return response.build();
			}
			
			commonResult = inp1001Repository.callPrInpIpwonCancel(hospCode
					, inputList.get(0).getDataValue()
					, CommonUtils.parseDouble(inputList.get(1).getDataValue())
					, DateUtil.toDate(inputList.get(2).getDataValue(), DateUtil.PATTERN_YYMMDD));
			break;
		case "PR_INP_UPDATE_OUT0103":
			if(inputList.size() < 11){
				LOGGER.info(String.format("Execute PR_INP_UPDATE_OUT0103, hosp_code = %s: invalid input_param", hospCode));
				return response.build();
			}
			
			commonResult = inp1001Repository.callPrInpUpdateOut0103(hospCode
					, inputList.get(0).getDataValue()
					, DateUtil.toDate(inputList.get(1).getDataValue(), DateUtil.PATTERN_YYMMDD)
					, inputList.get(2).getDataValue()
					, inputList.get(3).getDataValue()
					, inputList.get(4).getDataValue()
					, inputList.get(5).getDataValue()
					, inputList.get(6).getDataValue()
					, inputList.get(7).getDataValue()
					, CommonUtils.parseInteger(inputList.get(8).getDataValue())
					, inputList.get(9).getDataValue()
					, DateUtil.toDate(inputList.get(10).getDataValue(), DateUtil.PATTERN_YYMMDD));
			
			break;
		case "PR_OCS_INIT_CREATE_SIKSA":
			if(inputList.size() < 5){
				LOGGER.info(String.format("Execute PR_OCS_INIT_CREATE_SIKSA, hosp_code = %s: invalid input_param", hospCode));
				return response.build();
			}
			
			// procedure return nothing
			inp1001Repository.callPrOcsInitCreateSiksa(inputList.get(0).getDataValue()
					, CommonUtils.parseDouble(inputList.get(1).getDataValue())
					, inputList.get(2).getDataValue()
					, DateUtil.toDate(inputList.get(3).getDataValue(), DateUtil.PATTERN_YYMMDD)
					, inputList.get(4).getDataValue()
					, language);
			break;
		case "PR_IFS_MAKE_IPWON_HISTORY":
			if(inputList.size() < 13){
				LOGGER.info(String.format("Execute PR_IFS_MAKE_IPWON_HISTORY, hosp_code = %s: invalid input_param", hospCode));
				return response.build();
			}
			
			PrIfsMakeIpwonHistoryResultInfo rsInfo = inp1001Repository.callPrIfsMakeIpwonHistory(inputList.get(0).getDataValue()
					, inputList.get(1).getDataValue()
					, inputList.get(2).getDataValue()
					, DateUtil.toDate(inputList.get(3).getDataValue(), DateUtil.PATTERN_YYMMDD)
					, inputList.get(4).getDataValue()
					, inputList.get(5).getDataValue()
					, inputList.get(6).getDataValue()
					, inputList.get(7).getDataValue()
					, inputList.get(8).getDataValue()
					, CommonUtils.parseDouble(inputList.get(9).getDataValue())
					, inputList.get(10).getDataValue()
					, inputList.get(11).getDataValue()
					, inputList.get(12).getDataValue());
			
			CommonModelProto.DataStringListItemInfo.Builder pkifs3011Proto = CommonModelProto.DataStringListItemInfo.newBuilder()
					.setDataValue(rsInfo.getPkifs3011() == null ? "" : String.valueOf(rsInfo.getPkifs3011()));
			
			CommonModelProto.DataStringListItemInfo.Builder errProto = CommonModelProto.DataStringListItemInfo.newBuilder()
					.setDataValue(rsInfo.getErr() == null ? "" : String.valueOf(rsInfo.getErr()));
			
			response.addOutList(pkifs3011Proto);
			response.addOutList(errProto);
			
			break;
		case "PR_INP_MAKE_PKINP1002":
			if(inputList.size() < 2){
				LOGGER.info(String.format("Execute PR_INP_MAKE_PKINP1002, hosp_code = %s: invalid input_param", hospCode));
				return response.build();
			}
			
			commonResult = inp1001Repository.callPrInpMakePkinp1002(CommonUtils.parseInteger(inputList.get(0).getDataValue())
					, inputList.get(1).getDataValue()
					, hospCode);
			
			break;
		case "PR_OCS_UPDATE_INP_ORDER_RES":
			if(inputList.size() < 3){
				LOGGER.info(String.format("Execute PR_OCS_UPDATE_INP_ORDER_RES, hosp_code = %s: invalid input_param", hospCode));
				return response.build();
			}
			
			commonResult = inp1001Repository.callPrOcsUpdateInpOrderRes(hospCode
					, inputList.get(0).getDataValue()
					, inputList.get(1).getDataValue()
					, CommonUtils.parseInteger(inputList.get(2).getDataValue()));
			
			break;
		default:
			break;
		}
		
		if(commonResult == null){
			LOGGER.info(String.format("Execute procedure %s, hosp_code = %s: result is null", procName, hospCode));
			return response.build();
		}
		
		if(!StringUtils.isEmpty(commonResult.getStrResult1())){
			CommonModelProto.DataStringListItemInfo.Builder infoProto1 = CommonModelProto.DataStringListItemInfo.newBuilder()
					.setDataValue(commonResult.getStrResult1());
			response.addOutList(infoProto1);
		}
		
		if(!StringUtils.isEmpty(commonResult.getStrResult2())){
			CommonModelProto.DataStringListItemInfo.Builder infoProto2 = CommonModelProto.DataStringListItemInfo.newBuilder()
					.setDataValue(commonResult.getStrResult2());
			response.addOutList(infoProto2);
		}
		
		if(!StringUtils.isEmpty(commonResult.getStrResult3())){
			CommonModelProto.DataStringListItemInfo.Builder infoProto3 = CommonModelProto.DataStringListItemInfo.newBuilder()
					.setDataValue(commonResult.getStrResult3());
			response.addOutList(infoProto3);
		}
		
		return response.build();
	}

}
