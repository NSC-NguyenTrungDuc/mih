package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0311U00laySetHangmogListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00laySetHangmogRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00laySetHangmogResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class OCS0311U00laySetHangmogHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311U00laySetHangmogRequest, OcsaServiceProto.OCS0311U00laySetHangmogResponse> {                             
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override                                        
	@Transactional(readOnly = true)
	public OCS0311U00laySetHangmogResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0311U00laySetHangmogRequest request) throws Exception {                                                                  
		OcsaServiceProto.OCS0311U00laySetHangmogResponse.Builder response=OcsaServiceProto.OCS0311U00laySetHangmogResponse.newBuilder();
		List<OCS0311U00laySetHangmogListInfo> listLaySetHangmog= ocs0103Repository.getOCS0311U00laySetHangmogListInfo(getHospitalCode(vertx, sessionId),request.getCode());
		if(listLaySetHangmog != null && !listLaySetHangmog.isEmpty()){
			for(OCS0311U00laySetHangmogListInfo item : listLaySetHangmog){
				OcsaModelProto.OCS0311U00laySetHangmogListInfo.Builder info = OcsaModelProto.OCS0311U00laySetHangmogListInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getHangmogName())) {
					info.setHangmogName(item.getHangmogName());
				}
				if (!StringUtils.isEmpty(item.getOrdDanui())) {
					info.setOrdDanui(item.getOrdDanui());
				}
				if (!StringUtils.isEmpty(item.getCodeName())) {
					info.setCodeName(item.getCodeName());
				}
				response.addLaySetHangmog(info);
			}
		}
		return response.build();
	}

}                                                                                                                 
