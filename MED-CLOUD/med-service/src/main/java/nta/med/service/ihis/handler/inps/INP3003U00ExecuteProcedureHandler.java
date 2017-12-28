package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.omg.CORBA.OMGVMCID;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.PrIfsMakeIpwonHistoryResultInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00ExecuteProcedureRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00ExecuteProcedureResponse;

@Service
@Scope("prototype")
public class INP3003U00ExecuteProcedureHandler extends
		ScreenHandler<InpsServiceProto.INP3003U00ExecuteProcedureRequest, InpsServiceProto.INP3003U00ExecuteProcedureResponse> {

	private static final Log LOGGER = LogFactory.getLog(INP3003U00ExecuteProcedureHandler.class);  
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional
	public INP3003U00ExecuteProcedureResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP3003U00ExecuteProcedureRequest request) throws Exception {
		InpsServiceProto.INP3003U00ExecuteProcedureResponse.Builder response = InpsServiceProto.INP3003U00ExecuteProcedureResponse.newBuilder();
		
		String procName = request.getProcName();
		List<CommonModelProto.DataStringListItemInfo> inputList = request.getInpListList();
		
		if("PR_IFS_MAKE_IPWON_HISTORY".equals(procName)){
			if(CollectionUtils.isEmpty(inputList) || inputList.size() < 13){
				LOGGER.info("PR_IFS_MAKE_IPWON_HISTORY: input_list was not valid");
				return response.build();
			}
			
			PrIfsMakeIpwonHistoryResultInfo info = inp1001Repository.callPrIfsMakeIpwonHistory(
					  inputList.get(0).getDataValue()
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
			
			CommonModelProto.DataStringListItemInfo.Builder pkifs3011 = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(String.valueOf(info.getPkifs3011()));
			CommonModelProto.DataStringListItemInfo.Builder err = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(String.valueOf(info.getErr()));
			
			response.addOutList(pkifs3011);
			response.addOutList(err);
			return response.build();
		} 
		
		if("PR_INP_TOIWON_CANCEL".equals(procName)){
			if(CollectionUtils.isEmpty(inputList) || inputList.size() < 2){
				LOGGER.info("PR_INP_TOIWON_CANCEL: input_list was not valid");
				return response.build();
			}
			
			String rs = inp1001Repository.callPrInpToiwonCancel(
					  getHospitalCode(vertx, sessionId)
					, CommonUtils.parseInteger(CommonUtils.parseString(CommonUtils.parseDouble(inputList.get(0).getDataValue())))
					, inputList.get(1).getDataValue());
			
			CommonModelProto.DataStringListItemInfo.Builder protoInfo = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(String.valueOf(rs));
			response.addOutList(protoInfo);
			return response.build();
		}
		
		return response.build();
	}
}

	