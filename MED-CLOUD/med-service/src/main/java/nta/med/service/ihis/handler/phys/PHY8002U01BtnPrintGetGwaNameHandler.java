package nta.med.service.ihis.handler.phys;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.ocs.Ocs0115Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01BtnPrintGetGwaNameRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01BtnPrintGetGwaNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U01BtnPrintGetGwaNameHandler
	extends ScreenHandler<PhysServiceProto.PHY8002U01BtnPrintGetGwaNameRequest, PhysServiceProto.PHY8002U01BtnPrintGetGwaNameResponse> {                     
	@Resource                                                                                                       
	private Ocs0115Repository ocs0115Repository;   
	@Resource
	private Bas0102Repository bas0102Repository;
	                                                                                                                
	@Override            
	@Transactional(readOnly=true)
	public PHY8002U01BtnPrintGetGwaNameResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PHY8002U01BtnPrintGetGwaNameRequest request) throws Exception {                                                                   
  	   	PhysServiceProto.PHY8002U01BtnPrintGetGwaNameResponse.Builder response = PhysServiceProto.PHY8002U01BtnPrintGetGwaNameResponse.newBuilder(); 
  	   	String hospCode = getHospitalCode(vertx, sessionId);
	   	String language = getLanguage(vertx, sessionId);
		String result = "";
		if(request.getColName().equalsIgnoreCase("sinryouka")){
			result = ocs0115Repository.getPhy8002U01BtnPrintGetGwaNameSinryouka(hospCode, request.getGwa());
		}else if(request.getColName().equalsIgnoreCase("irai_date")){
			result = bas0102Repository.getJapanDateInfo(hospCode, language, request.getIraiDate());
		}
		if(!StringUtils.isEmpty(result)){
			response.setGwaName(result);
		}
		return response.build();
	}
}