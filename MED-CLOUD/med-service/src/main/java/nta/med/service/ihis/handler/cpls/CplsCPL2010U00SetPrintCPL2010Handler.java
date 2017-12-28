package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3300Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00SetPrintRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL2010U00SetPrintCPL2010Handler extends ScreenHandler <CplsServiceProto.CPL2010U00SetPrintRequest, SystemServiceProto.UpdateResponse>{
	@Resource
	private Adm3300Repository adm3300Repository;
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL2010U00SetPrintRequest request)
			throws Exception {
			SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
			String hospCode = getHospitalCode(vertx, sessionId);
			boolean result = executeCPL2010U00SetPrintRequest(request, hospCode);
			response.setResult(result);
			return response.build();
	}

	public boolean executeCPL2010U00SetPrintRequest(CplsServiceProto.CPL2010U00SetPrintRequest request, String hospCode){
		boolean save = false;
		Integer resultUpdate = adm3300Repository.updateCPL2010U00SetPrint(hospCode,request.getUserId(),request.getBPrintName(),request.getIpAddr());
		if(resultUpdate > 0){
		 String getTTrimId = adm3300Repository.getTTrmIdCPL2010U00SetPrint(hospCode);
		 Integer resultInsert = adm3300Repository.insertCPL2010U00SetPrint(hospCode,getTTrimId,request.getIpAddr() , request.getUserId() ,request.getBPrintName());
		 	if(resultInsert > 0){
		 		save = true; // ??
		 	}
		}
		return save;
	}
}
