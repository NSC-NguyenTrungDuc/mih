package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0311Repository;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdHangmogCodeListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00grdHangmogCodeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00grdHangmogCodeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class OCS0311U00grdHangmogCodeHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311U00grdHangmogCodeRequest,OcsaServiceProto.OCS0311U00grdHangmogCodeResponse> {                             
	@Resource                                                                                                       
	private Ocs0311Repository ocs0311Repository;                                                                    
	                                                                                                                
	@Override                        
	@Transactional(readOnly = true)
	public OCS0311U00grdHangmogCodeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0311U00grdHangmogCodeRequest request) throws Exception {                                                                   
		OcsaServiceProto.OCS0311U00grdHangmogCodeResponse.Builder response=OcsaServiceProto.OCS0311U00grdHangmogCodeResponse.newBuilder();
		List<OCS0311U00grdHangmogCodeListInfo> listGrdHangmogCode= ocs0311Repository.getOCS0311U00grdHangmogCodeListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),request.getSetPart());
		if(listGrdHangmogCode != null && !listGrdHangmogCode.isEmpty()){
			for(OCS0311U00grdHangmogCodeListInfo item : listGrdHangmogCode){
				OcsaModelProto.OCS0311U00grdHangmogCodeListInfo.Builder info= OcsaModelProto.OCS0311U00grdHangmogCodeListInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getSetPart())) {
					info.setSetPart(item.getSetPart());
				}
				if (!StringUtils.isEmpty(item.getHangmogCode())) {
					info.setHangmogCode(item.getHangmogCode());
				}
				if (!StringUtils.isEmpty(item.getHangmogName())) {
					info.setHangmogName(item.getHangmogName());
				}
				response.addGrdHangmog(info);
			}
		}
		return response.build();
	}

}                                                                                                                 
