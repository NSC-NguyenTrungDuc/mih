package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0313Repository;
import nta.med.data.model.ihis.ocsa.OCS0311Q00LayDownListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311Q00LayDownListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311Q00LayDownListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0311Q00LayDownListHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311Q00LayDownListRequest, OcsaServiceProto.OCS0311Q00LayDownListResponse> {                     
	@Resource                                                                                                       
	private Ocs0313Repository ocs0313Repository;                                                                    
	                                                                                                                
	@Override       
	@Transactional(readOnly = true)
	public OCS0311Q00LayDownListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0311Q00LayDownListRequest request) throws Exception {                                                                
  	   	OcsaServiceProto.OCS0311Q00LayDownListResponse.Builder response = OcsaServiceProto.OCS0311Q00LayDownListResponse.newBuilder();                      
		List<OCS0311Q00LayDownListInfo> listLayDown = ocs0313Repository.getOCS0311Q00LayDownListInfo(getHospitalCode(vertx, sessionId),request.getSetPart(),request.getHangmogCode(),request.getSetCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listLayDown)){
			for(OCS0311Q00LayDownListInfo item : listLayDown){
				OcsaModelProto.OCS0311Q00LayDownListInfo.Builder info = OcsaModelProto.OCS0311Q00LayDownListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getSuryang() != null) {
					info.setSuryang(String.format("%.0f",item.getSuryang()));
				}
				response.addLayDownListItem(info);
			}
		}
		return response.build();
	}
}