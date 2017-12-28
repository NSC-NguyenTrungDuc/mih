package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocsa.Ocs3003Q10GrdSangListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS3003Q10GrdSangRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS3003Q10GrdSangResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS3003Q10GrdSangHandler
	extends ScreenHandler<OcsaServiceProto.OCS3003Q10GrdSangRequest, OcsaServiceProto.OCS3003Q10GrdSangResponse> {                     
	@Resource                                                                                                       
	private OutsangRepository outsangRepository;                                                                    
	                                                                                                                
	@Override             
	@Transactional(readOnly = true)
	public OCS3003Q10GrdSangResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS3003Q10GrdSangRequest request)
			throws Exception {                                                                  
  	   	OcsaServiceProto.OCS3003Q10GrdSangResponse.Builder response = OcsaServiceProto.OCS3003Q10GrdSangResponse.newBuilder();                      
		List<Ocs3003Q10GrdSangListItemInfo> list =  outsangRepository.getOcs3003Q10GrdSangListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getIoGubun(), request.getJubsuNo(), DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD), request.getGwa(), request.getDoctor(),
				request.getNaewonType(), request.getBunho());
		if(!CollectionUtils.isEmpty(list)){
			for(Ocs3003Q10GrdSangListItemInfo item : list){
				OcsaModelProto.OCS3003Q10GrdSangListItemInfo.Builder info = OcsaModelProto.OCS3003Q10GrdSangListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListResult(info);
			}
		}
		return response.build();
	}
}