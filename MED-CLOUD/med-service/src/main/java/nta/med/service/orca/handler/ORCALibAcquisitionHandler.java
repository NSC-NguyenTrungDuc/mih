package nta.med.service.orca.handler;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.oif.Oif1101Repository;
import nta.med.data.model.ihis.orca.ORCALibAcquisitionInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.orca.proto.OrcaModelProto;
import nta.med.service.orca.proto.OrcaServiceProto;
import nta.med.service.orca.proto.OrcaServiceProto.ORCALibAcquisitionRequest;
import nta.med.service.orca.proto.OrcaServiceProto.ORCALibAcquisitionResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ORCALibAcquisitionHandler extends ScreenHandler<OrcaServiceProto.ORCALibAcquisitionRequest, OrcaServiceProto.ORCALibAcquisitionResponse>{                      
	private static final Log LOGGER = LogFactory.getLog(ORCALibAcquisitionHandler.class);                                    
	@Resource                                                                                                       
	private Oif1101Repository oif1101Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public ORCALibAcquisitionResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, ORCALibAcquisitionRequest request)
			throws Exception {
		OrcaServiceProto.ORCALibAcquisitionResponse.Builder response = OrcaServiceProto.ORCALibAcquisitionResponse.newBuilder();
		List<ORCALibAcquisitionInfo > listAcquistion = oif1101Repository.getORCALibAcquisitionInfo(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getFkoif1101()));
		if(!CollectionUtils.isEmpty(listAcquistion)){
			for(ORCALibAcquisitionInfo  item : listAcquistion){
				OrcaModelProto.ORCALibAcquisitionInfo .Builder info = OrcaModelProto.ORCALibAcquisitionInfo .newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addAcqItem(info);
    		}
		}
		return response.build();
	}                                                                                                                 
}