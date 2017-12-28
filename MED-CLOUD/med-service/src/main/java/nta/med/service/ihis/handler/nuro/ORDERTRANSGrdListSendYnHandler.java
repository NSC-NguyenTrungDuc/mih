package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1003Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListSendYnInfo;
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
public class ORDERTRANSGrdListSendYnHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSGrdListSendYnRequest, NuroServiceProto.ORDERTRANSGrdListSendYnResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSGrdListSendYnHandler.class);                                    
	@Resource                                                                                                       
	private Out1003Repository out1003Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSGrdListSendYnResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSGrdListSendYnRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSGrdListSendYnResponse.Builder response = NuroServiceProto.ORDERTRANSGrdListSendYnResponse.newBuilder();
		List<ORDERTRANSGrdListSendYnInfo> listResult = out1003Repository.getORDERTRANSGrdListSendYnInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSGrdListSendYnInfo item : listResult){
				NuroModelProto.ORDERTRANSGrdListSendYnInfo.Builder info = NuroModelProto.ORDERTRANSGrdListSendYnInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getFkout1001() != null) {
					info.setFkout1001(String.format("%.0f",item.getFkout1001()));
				}
				response.addGrdListSendItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}