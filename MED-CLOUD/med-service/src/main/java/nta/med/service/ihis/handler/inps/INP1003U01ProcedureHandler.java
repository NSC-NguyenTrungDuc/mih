package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01ProcedureRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01ProcedureResponse;

@Service                                                                                                        
@Scope("prototype")
public class INP1003U01ProcedureHandler extends ScreenHandler<InpsServiceProto.INP1003U01ProcedureRequest, InpsServiceProto.INP1003U01ProcedureResponse>{
	
	@Resource
	private Inp1003Repository inp1003Repository;	

	@Override
	@Transactional
	public INP1003U01ProcedureResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U01ProcedureRequest request) throws Exception {
		InpsServiceProto.INP1003U01ProcedureResponse.Builder response = InpsServiceProto.INP1003U01ProcedureResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		if(request.getNameControl().equals("CancelReserVation")){
			ComboListItemInfo result1 = inp1003Repository.prcINP1003U01ProcedureDelete(hospCode, request.getBunho(), request.getFkinp1001()
					, DateUtil.toDate(request.getIpwonDate(), DateUtil.PATTERN_YYMMDD)
					, request.getGubun(), request.getUserId(), request.getIpwonType(), request.getNameControl());
			
			response.setMsg(result1.getCode());
			response.setResult(result1.getCodeName());
		}else{
			List<DataStringListItemInfo> listInfo = inp1003Repository.prcINP1003U01Procedure(hospCode, request.getBunho(), request.getFkinp1001()
					, DateUtil.toDate(request.getIpwonDate(), DateUtil.PATTERN_YYMMDD)
					, request.getGubun(), request.getUserId(), request.getIpwonType(), request.getNameControl());
			if(CollectionUtils.isEmpty(listInfo)){
				return response.build();
			}
			
			response.setMsg(listInfo.get(0).getItem());
			response.setResult(listInfo.get(1).getItem());
		}
	
	return response.build();
	}
	
}
