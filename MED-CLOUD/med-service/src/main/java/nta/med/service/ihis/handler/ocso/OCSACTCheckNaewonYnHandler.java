package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSACTCheckNaewonYnHandler extends ScreenHandler<OcsoServiceProto.OCSACTCheckNaewonYnRequest, OcsoServiceProto.OCSACTSingleStringResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTCheckNaewonYnHandler.class);                                    
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTSingleStringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTCheckNaewonYnRequest request) throws Exception {
		OcsoServiceProto.OCSACTSingleStringResponse.Builder response = OcsoServiceProto.OCSACTSingleStringResponse.newBuilder(); 
		Double pkout1001 = CommonUtils.parseDouble(request.getPkout1001());
		List<String> listNaewonYn = out1001Repository.OcsaOCS0503U00GetNaewonYn(getHospitalCode(vertx, sessionId), pkout1001);
		if(!CollectionUtils.isEmpty(listNaewonYn)){
			String naewonYn = "E".equalsIgnoreCase(listNaewonYn.get(0)) ? "Y" : "N";
			if(!StringUtils.isEmpty(naewonYn)){
				response.setResponseStr(naewonYn);
			}
		}
		return response.build();
	}                                                                                                                 
}