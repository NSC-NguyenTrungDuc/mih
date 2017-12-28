package nta.med.service.emr.handler;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.emr.OCS2015U03OrderGubunInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U03OrderGubunRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U03OrderGubunResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U03OrderGubunHandler extends ScreenHandler<EmrServiceProto.OCS2015U03OrderGubunRequest, EmrServiceProto.OCS2015U03OrderGubunResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS2015U03OrderGubunHandler.class);                                    
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;                                                                    
	                                                                                                                
	@Override       
	@Transactional(readOnly = true)
	public OCS2015U03OrderGubunResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS2015U03OrderGubunRequest request) throws Exception {
  	   	EmrServiceProto.OCS2015U03OrderGubunResponse.Builder response = EmrServiceProto.OCS2015U03OrderGubunResponse.newBuilder();                      
		List<OCS2015U03OrderGubunInfo> listGubun = ocs1003Repository.getOCS2015U03OrderGubunInfo(request.getFHopitalCode(), request.getFPatientCode(), CommonUtils.parseDouble(request.getFReservationCode()));
		if (!CollectionUtils.isEmpty(listGubun)) {
			for (OCS2015U03OrderGubunInfo item : listGubun) {
				EmrModelProto.OCS2015U03OrderGubunInfo.Builder info = EmrModelProto.OCS2015U03OrderGubunInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addOrderGubunList(info);
			}
		}
				
		return response.build();
	}                                                                                                                 
}