package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdINP2004Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ORDERTRANSGrdINP2004Handler extends ScreenHandler<NuroServiceProto.ORDERTRANSGrdINP2004Request, NuroServiceProto.ORDERTRANSGrdINP2004Response> {                     
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSGrdINP2004Handler.class);                                    
	@Resource                                                                                                       
	private Inp2004Repository inp2004Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSGrdINP2004Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSGrdINP2004Request request) throws Exception {
		NuroServiceProto.ORDERTRANSGrdINP2004Response.Builder response = NuroServiceProto.ORDERTRANSGrdINP2004Response.newBuilder();
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		List<ORDERTRANSGrdINP2004Info> listResult = inp2004Repository.getORDERTRANSGrdINP2004Info(getHospitalCode(vertx, sessionId),
			request.getBunho(), request.getSendYn(), request.getActingDate(), request.getSunabDate(), fkinp1001);
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSGrdINP2004Info item : listResult){
				NuroModelProto.ORDERTRANSGrdINP2004Info.Builder info = NuroModelProto.ORDERTRANSGrdINP2004Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdInp2004Item(info);
			}
		}
		return response.build();
	}                                                                                                                 
}