package nta.med.service.ihis.handler.nuro;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdOutSangInfo;
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
public class ORDERTRANSGrdOutSangHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSGrdOutSangRequest, NuroServiceProto.ORDERTRANSGrdOutSangResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSGrdOutSangHandler.class);                                    
	@Resource                                                                                                       
	private OutsangRepository outsangRepository; 
	
	@Override
	public boolean isValid(NuroServiceProto.ORDERTRANSGrdOutSangRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getGijunDate()) && DateUtil.toDate(request.getGijunDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSGrdOutSangResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSGrdOutSangRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSGrdOutSangResponse.Builder response = NuroServiceProto.ORDERTRANSGrdOutSangResponse.newBuilder();
		Date gijunDate = DateUtil.toDate(request.getGijunDate(), DateUtil.PATTERN_YYMMDD);
		List<ORDERTRANSGrdOutSangInfo> listResult = outsangRepository.getORDERTRANSGrdOutSangInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getBunho(), request.getIoGubun(), gijunDate);
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSGrdOutSangInfo item : listResult){
				NuroModelProto.ORDERTRANSGrdOutSangInfo.Builder info = NuroModelProto.ORDERTRANSGrdOutSangInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOutSangItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}