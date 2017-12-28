package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.ocsa.DOC4003U00GetHospInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.DOC4003U00GetHospRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.DOC4003U00GetHospResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class DOC4003U00GetHospHandler extends ScreenHandler<OcsaServiceProto.DOC4003U00GetHospRequest,OcsaServiceProto.DOC4003U00GetHospResponse>  {                     
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;                                                                    
	                                                                                                                
	@Override           
	@Transactional(readOnly = true)
	public DOC4003U00GetHospResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DOC4003U00GetHospRequest request) throws Exception {
		OcsaServiceProto.DOC4003U00GetHospResponse.Builder response = OcsaServiceProto.DOC4003U00GetHospResponse.newBuilder();
		List<DOC4003U00GetHospInfo> list = bas0001Repository.getDOC4003U00GetHospInfo(getHospitalCode(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(DOC4003U00GetHospInfo item : list){
				OcsaModelProto.DOC4003U00GetHospInfo.Builder info = OcsaModelProto.DOC4003U00GetHospInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.setHospInfoItem(info);
			}
		}
  	  	return response.build();
	}  

}
