package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocso.OUTSANGQ00IsEnableSangCodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class OUTSANGQ00IsEnableSangCodeHandler extends ScreenHandler<OcsoServiceProto.OUTSANGQ00IsEnableSangCodeRequest, OcsoServiceProto.OUTSANGQ00IsEnableSangCodeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OUTSANGQ00IsEnableSangCodeHandler.class); 
	
	@Resource                                                                                                       
	private OutsangRepository outsangRepository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OUTSANGQ00IsEnableSangCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUTSANGQ00IsEnableSangCodeRequest request) throws Exception {
		OcsoServiceProto.OUTSANGQ00IsEnableSangCodeResponse.Builder response = OcsoServiceProto.OUTSANGQ00IsEnableSangCodeResponse.newBuilder();
		List<OUTSANGQ00IsEnableSangCodeInfo> list = outsangRepository.getOUTSANGQ00IsEnableSangCodeInfo(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkoutsang()), request.getBunho());
		if(!CollectionUtils.isEmpty(list)){
			for(OUTSANGQ00IsEnableSangCodeInfo item : list){
				OcsoModelProto.OUTSANGQ00IsEnableSangCodeInfo.Builder info = OcsoModelProto.OUTSANGQ00IsEnableSangCodeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListItem(info);
			}
		}
		return response.build();
	}  
}
