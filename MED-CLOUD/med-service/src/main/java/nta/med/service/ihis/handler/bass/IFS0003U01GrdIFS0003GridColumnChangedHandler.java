package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ifs.Ifs0002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U01GrdIFS0003GridColumnChangedRequest;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U01StringResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0003U01GrdIFS0003GridColumnChangedHandler extends ScreenHandler<BassServiceProto.IFS0003U01GrdIFS0003GridColumnChangedRequest, BassServiceProto.IFS0003U01StringResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0003U01GrdIFS0003GridColumnChangedHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0002Repository ifs0002Repository;    
	@Resource
	private CommonRepository commonRepository;
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public IFS0003U01StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			IFS0003U01GrdIFS0003GridColumnChangedRequest request)
					throws Exception {
  	   	BassServiceProto.IFS0003U01StringResponse.Builder response = BassServiceProto.IFS0003U01StringResponse.newBuilder();                      
		String result = null;
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		if("ocs_code".equalsIgnoreCase(request.getColName())){
			result = commonRepository.callFnLoadOcsCodeName(hospitalCode, request.getMapGubun(), request.getCode(), language);
		}else if("if_code".equalsIgnoreCase(request.getColName())){
			result = ifs0002Repository.callPkgIfsBasFnLoadIfCodeName(hospitalCode, request.getMapGubun(), request.getCode());
		}
		if(!StringUtils.isEmpty(result)){
			response.setStrRes(result);
		}
		return response.build();
	}
}