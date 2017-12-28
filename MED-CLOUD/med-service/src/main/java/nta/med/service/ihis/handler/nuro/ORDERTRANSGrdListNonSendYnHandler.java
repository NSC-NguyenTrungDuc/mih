package nta.med.service.ihis.handler.nuro;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListNonSendYnInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ORDERTRANSGrdListNonSendYnHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSGrdListNonSendYnRequest, NuroServiceProto.ORDERTRANSGrdListNonSendYnResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSGrdListNonSendYnHandler.class);                                    
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;                                                                    
	
	@Override
	public boolean isValid(NuroServiceProto.ORDERTRANSGrdListNonSendYnRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getActingDate()) && DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSGrdListNonSendYnResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSGrdListNonSendYnRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSGrdListNonSendYnResponse.Builder response = NuroServiceProto.ORDERTRANSGrdListNonSendYnResponse.newBuilder();
		Date actingDate = DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD);
		List<ORDERTRANSGrdListNonSendYnInfo> listResult = ocs1003Repository.getORDERTRANSGrdListNonSendYnInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), actingDate, request.getBunho());
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSGrdListNonSendYnInfo item : listResult){
				NuroModelProto.ORDERTRANSGrdListNonSendYnInfo.Builder info = NuroModelProto.ORDERTRANSGrdListNonSendYnInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdListNonSendItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}