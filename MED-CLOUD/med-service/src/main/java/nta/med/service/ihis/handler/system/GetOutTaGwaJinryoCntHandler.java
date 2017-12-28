package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.OutTaGwaJinryoCntInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetOutTaGwaJinryoCntRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetOutTaGwaJinryoCntResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class GetOutTaGwaJinryoCntHandler
	extends ScreenHandler<SystemServiceProto.GetOutTaGwaJinryoCntRequest, SystemServiceProto.GetOutTaGwaJinryoCntResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public GetOutTaGwaJinryoCntResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			GetOutTaGwaJinryoCntRequest request) throws Exception {                                                                
  	   	SystemServiceProto.GetOutTaGwaJinryoCntResponse.Builder response = SystemServiceProto.GetOutTaGwaJinryoCntResponse.newBuilder();
		OutTaGwaJinryoCntInfo info = request.getCntInfo();
		Date naewonDate = DateUtil.toDate(info.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		Integer result = out1001Repository.getOutTaGwaJinryoCnt(getHospitalCode(vertx, sessionId), info.getBunho(), info.getGwa(), naewonDate);
		if(result != null){
			response.setRetVal(result.toString());
		}
		return response.build(); 
	}
}
