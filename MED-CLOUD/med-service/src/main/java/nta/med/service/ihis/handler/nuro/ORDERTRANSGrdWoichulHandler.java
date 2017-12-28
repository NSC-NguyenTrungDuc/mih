package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1014Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdWoichulInfo;
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
public class ORDERTRANSGrdWoichulHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSGrdWoichulRequest, NuroServiceProto.ORDERTRANSGrdWoichulResponse> {                   
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSGrdWoichulHandler.class);                                    
	@Resource                                                                                                       
	private Nur1014Repository nur1014Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSGrdWoichulResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSGrdWoichulRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSGrdWoichulResponse.Builder response = NuroServiceProto.ORDERTRANSGrdWoichulResponse.newBuilder();
		Double pk1001 = CommonUtils.parseDouble(request.getPk1001());
		List<ORDERTRANSGrdWoichulInfo> listResult = nur1014Repository.getORDERTRANSGrdWoichulInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getSendYn(), request.getBunho(),  pk1001, request.getOrderDate());
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSGrdWoichulInfo item : listResult){
				NuroModelProto.ORDERTRANSGrdWoichulInfo.Builder info = NuroModelProto.ORDERTRANSGrdWoichulInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdWoiChulItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}