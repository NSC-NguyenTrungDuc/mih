package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSLayOut0101Info;
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
public class ORDERTRANSLayOut0101Handler  extends ScreenHandler<NuroServiceProto.ORDERTRANSLayOut0101Request, NuroServiceProto.ORDERTRANSLayOut0101Response> {                    
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSLayOut0101Handler.class);                                    
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSLayOut0101Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSLayOut0101Request request) throws Exception {
		NuroServiceProto.ORDERTRANSLayOut0101Response.Builder response = NuroServiceProto.ORDERTRANSLayOut0101Response.newBuilder();
		List<ORDERTRANSLayOut0101Info> listResult = out0101Repository.getORDERTRANSLayOut0101Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSLayOut0101Info item : listResult){
				NuroModelProto.ORDERTRANSLayOut0101Info.Builder info = NuroModelProto.ORDERTRANSLayOut0101Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayOut0101Item(info);
			}
		}
		return response.build();
	}                                                                                                                 
}