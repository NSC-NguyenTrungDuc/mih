package nta.med.service.ihis.handler.ocso;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class OCS1003P01OpenAllergyInforHandler extends ScreenHandler<OcsoServiceProto.OCS1003P01OpenAllergyInforRequest, OcsoServiceProto.OCS1003P01OpenAllergyInforResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003P01OpenAllergyInforHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0150Repository ocs0150Repository;                                                                    
	@Resource                                                                                                       
	private Nur1016Repository nur1016Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003P01OpenAllergyInforResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003P01OpenAllergyInforRequest request) throws Exception {
		OcsoServiceProto.OCS1003P01OpenAllergyInforResponse.Builder response = OcsoServiceProto.OCS1003P01OpenAllergyInforResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
		String  userOpt = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(hospCode, request.getDoctor(), request.getGwa(), request.getKeyword(), request.getIoGubun());
		if(!"N".equalsIgnoreCase(userOpt)){
			Date appDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
			String result = nur1016Repository.getOpenAllergyInfo(hospCode, request.getBunho(), appDate);
			if(!StringUtils.isEmpty(result)){
				response.setAllergyResult(result);
			}
		}
		return response.build();
	}                                                                                                                 
}