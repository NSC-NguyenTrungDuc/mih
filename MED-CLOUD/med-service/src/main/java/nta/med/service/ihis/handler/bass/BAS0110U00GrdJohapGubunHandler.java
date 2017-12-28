package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00GrdJohapGubunRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00GrdJohapGubunResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0110U00GrdJohapGubunHandler extends ScreenHandler<BassServiceProto.BAS0110U00GrdJohapGubunRequest, BassServiceProto.BAS0110U00GrdJohapGubunResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0110U00GrdJohapGubunHandler.class);                                        
	@Resource                                                                                                       
	private Bas0102Repository  bas0102Repository;     
	@Resource
	private Bas0123Repository bas0123Repository;
	                                                                                                                
	@Override        
	@Transactional(readOnly = true)
	public BAS0110U00GrdJohapGubunResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
		BAS0110U00GrdJohapGubunRequest request) throws Exception {                                                                   
  	   	BassServiceProto.BAS0110U00GrdJohapGubunResponse.Builder response = BassServiceProto.BAS0110U00GrdJohapGubunResponse.newBuilder();
  	   	String hospitalCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		String result = "";
		if(request.getColName().equalsIgnoreCase("johap_gubun")){
			result = bas0102Repository.getTChkBAS0101U00Execute(hospitalCode, "JOHAP_GUBUN", request.getCode(), language);
		}else if(request.getColName().equalsIgnoreCase("zip_code2")){
			result = bas0123Repository.getBAS0110U00GrdJohapGubunZipCode(request.getZipCode1(), request.getZipCode2());
		}
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}                                                                                                                 
}