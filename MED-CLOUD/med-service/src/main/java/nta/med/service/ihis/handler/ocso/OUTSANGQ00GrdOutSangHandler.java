package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocso.OUTSANGQ00GrdOutSangInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

@Service                                                                                                          
@Scope("prototype")  
public class OUTSANGQ00GrdOutSangHandler extends ScreenHandler<OcsoServiceProto.OUTSANGQ00GrdOutSangRequest, OcsoServiceProto.OUTSANGQ00GrdOutSangResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OUTSANGQ00GrdOutSangHandler.class); 
	
	@Resource                                                                                                       
	private OutsangRepository outsangRepository;                                                                    
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OUTSANGQ00GrdOutSangRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getGijunDate()) && DateUtil.toDate(request.getGijunDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OUTSANGQ00GrdOutSangResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUTSANGQ00GrdOutSangRequest request) throws Exception {
		OcsoServiceProto.OUTSANGQ00GrdOutSangResponse.Builder response = OcsoServiceProto.OUTSANGQ00GrdOutSangResponse.newBuilder(); 
		List<OUTSANGQ00GrdOutSangInfo> list = outsangRepository.getOUTSANGQ00GrdOutSangInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), request.getGwa(),
				request.getIoGubun(), request.getAllSangYn(), DateUtil.toDate(request.getGijunDate(), DateUtil.PATTERN_YYMMDD));
		if(!CollectionUtils.isEmpty(list)){
			for(OUTSANGQ00GrdOutSangInfo item : list){
				OcsoModelProto.OUTSANGQ00GrdOutSangInfo.Builder info = OcsoModelProto.OUTSANGQ00GrdOutSangInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListItem(info);
			}
		}
		return response.build();
	}  

}
