package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.ocso.OUTSANGU00findBoxToGwaInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OUTSANGU00findBoxToGwaHandler extends ScreenHandler<OcsoServiceProto.OUTSANGU00findBoxToGwaRequest, OcsoServiceProto.OUTSANGU00findBoxToGwaResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OUTSANGU00findBoxToGwaHandler.class);                                    
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OUTSANGU00findBoxToGwaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUTSANGU00findBoxToGwaRequest request) throws Exception {
		OcsoServiceProto.OUTSANGU00findBoxToGwaResponse.Builder response = OcsoServiceProto.OUTSANGU00findBoxToGwaResponse.newBuilder();
		List<OUTSANGU00findBoxToGwaInfo> listOUTSANGU00findBoxToGwaInfo = bas0260Repository.getOUTSANGU00findBoxToGwaInfo(getHospitalCode(vertx, sessionId),
				DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD),request.getFind1(), getLanguage(vertx, sessionId));
		if (listOUTSANGU00findBoxToGwaInfo != null && !listOUTSANGU00findBoxToGwaInfo.isEmpty()){
			for(OUTSANGU00findBoxToGwaInfo item : listOUTSANGU00findBoxToGwaInfo){
				OcsoModelProto.OUTSANGU00findBoxToGwaInfo.Builder info = OcsoModelProto.OUTSANGU00findBoxToGwaInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGwaInfo(info);
			}
		}
		return response.build();
	}                                                                                                                 
}