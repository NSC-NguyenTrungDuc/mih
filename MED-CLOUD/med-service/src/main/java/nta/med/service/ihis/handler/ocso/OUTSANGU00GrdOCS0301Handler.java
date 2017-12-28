package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0300Repository;
import nta.med.data.model.ihis.ocso.OUTSANGU00GrdOCS0301Info;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OUTSANGU00GrdOCS0301Request;
import nta.med.service.ihis.proto.OcsoServiceProto.OUTSANGU00GrdOCS0301Response;

@Service                                                                                                          
@Scope("prototype") 
public class OUTSANGU00GrdOCS0301Handler extends ScreenHandler<OcsoServiceProto.OUTSANGU00GrdOCS0301Request, OcsoServiceProto.OUTSANGU00GrdOCS0301Response> {
	private static final Log LOGGER = LogFactory.getLog(OUTSANGU00GetGwaNameHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0300Repository ocs0300Repository; 
	
	@Override
	@Transactional(readOnly = true)
	public OUTSANGU00GrdOCS0301Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OUTSANGU00GrdOCS0301Request request) throws Exception {
		OcsoServiceProto.OUTSANGU00GrdOCS0301Response.Builder response = OcsoServiceProto.OUTSANGU00GrdOCS0301Response.newBuilder();
		List<OUTSANGU00GrdOCS0301Info> listGrd = ocs0300Repository.getOUTSANGU00GrdOCS0301Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
				request.getMemb(), request.getSangCode(), request.getYaksokCode(), request.getInputTab());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OUTSANGU00GrdOCS0301Info item:listGrd){
				OcsoModelProto.OUTSANGU00GrdOCS0301Info.Builder info = OcsoModelProto.OUTSANGU00GrdOCS0301Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInfo(info);
			}
		}
		return response.build();
	}  

}
