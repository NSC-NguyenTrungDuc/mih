package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

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
public class OCSACTGrdSangByungHandler extends ScreenHandler<OcsoServiceProto.OCSACTGrdSangByungRequest, OcsoServiceProto.OCSACTGrdSangByungResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTGrdSangByungHandler.class);                                    
	@Resource                                                                                                       
	private OutsangRepository outsangRepository;                                                                    
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OCSACTGrdSangByungRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTGrdSangByungResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTGrdSangByungRequest request) throws Exception {
		OcsoServiceProto.OCSACTGrdSangByungResponse.Builder response = OcsoServiceProto.OCSACTGrdSangByungResponse.newBuilder(); 
		List<String> listResult = outsangRepository.getOCSACTGrdSangByungInfo(getHospitalCode(vertx, sessionId), request.getBunho(), DateUtil.toDate(request.getOrderDate(),DateUtil.PATTERN_YYMMDD));
		if(!CollectionUtils.isEmpty(listResult)){
			for(String item : listResult){
				OcsoModelProto.OCSACTGrdSangByungInfo.Builder info = OcsoModelProto.OCSACTGrdSangByungInfo.newBuilder();
				if(!StringUtils.isEmpty(item)){
					info.setSangName(item);
				}
				response.addGrdSangByungLst(info);
			}
		}
		return response.build();
	}                                                                                                                 
}