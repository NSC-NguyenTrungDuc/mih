package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0210Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSLayCommonInfo;
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
public class ORDERTRANSLayCommonHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSLayCommonRequest, NuroServiceProto.ORDERTRANSLayCommonResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSLayCommonHandler.class);                                    
	@Resource                                                                                                       
	private Bas0210Repository bas0210Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSLayCommonResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSLayCommonRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSLayCommonResponse.Builder response = NuroServiceProto.ORDERTRANSLayCommonResponse.newBuilder();
		List<ORDERTRANSLayCommonInfo> listResult = bas0210Repository.getORDERTRANSLayCommonInfo(getHospitalCode(vertx, sessionId), request.getGubun(), 
				request.getActingDate(), request.getBunho(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSLayCommonInfo item : listResult){
				NuroModelProto.ORDERTRANSLayCommonInfo.Builder info = NuroModelProto.ORDERTRANSLayCommonInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayCommonItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}