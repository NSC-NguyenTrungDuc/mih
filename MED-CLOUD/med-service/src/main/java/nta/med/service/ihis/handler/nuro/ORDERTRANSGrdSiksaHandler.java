package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdSiksaInfo;
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
public class ORDERTRANSGrdSiksaHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSGrdSiksaRequest, NuroServiceProto.ORDERTRANSGrdSiksaResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSGrdSiksaHandler.class);                                    
	@Resource                                                                                                       
	private Ocs2015Repository ocs2015Repository;                                                                    
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSGrdSiksaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSGrdSiksaRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSGrdSiksaResponse.Builder response = NuroServiceProto.ORDERTRANSGrdSiksaResponse.newBuilder();
		Double pk1001 = CommonUtils.parseDouble(request.getPk1001());
		List<ORDERTRANSGrdSiksaInfo> listResult = ocs2015Repository.getORDERTRANSGrdSiksaInfo(getHospitalCode(vertx, sessionId), request.getSendYn(),
				request.getBunho(),  pk1001, request.getActingDate());
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSGrdSiksaInfo item : listResult){
				NuroModelProto.ORDERTRANSGrdSiksaInfo.Builder info = NuroModelProto.ORDERTRANSGrdSiksaInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdSiksaItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}