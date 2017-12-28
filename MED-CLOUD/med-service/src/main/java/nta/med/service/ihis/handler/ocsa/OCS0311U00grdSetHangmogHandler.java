package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0313Repository;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdSetHangmogListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00grdSetHangmogRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00grdSetHangmogResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class OCS0311U00grdSetHangmogHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311U00grdSetHangmogRequest, OcsaServiceProto.OCS0311U00grdSetHangmogResponse> {                             
	@Resource                                                                                                       
	private Ocs0313Repository ocs0313Repository;                                                                    
	                                                                                                                
	@Override             
	@Transactional(readOnly = true)
	public OCS0311U00grdSetHangmogResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0311U00grdSetHangmogRequest request) throws Exception {                                                                 
		OcsaServiceProto.OCS0311U00grdSetHangmogResponse.Builder response=OcsaServiceProto.OCS0311U00grdSetHangmogResponse.newBuilder();
		List<OCS0311U00grdSetHangmogListInfo> listGrdSetHangmog= ocs0313Repository.getOCS0311U00grdSetHangmogListInfo(getHospitalCode(vertx, sessionId),request.getSetPart() 
				,request.getHangmogCode(),request.getSetCode(), getLanguage(vertx, sessionId));
		if(listGrdSetHangmog != null && !listGrdSetHangmog.isEmpty()){
			for(OCS0311U00grdSetHangmogListInfo item : listGrdSetHangmog){
				OcsaModelProto.OCS0311U00grdSetHangmogListInfo.Builder info = OcsaModelProto.OCS0311U00grdSetHangmogListInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getSetPart())) {
					info.setSetPart(item.getSetPart());
				}
				if (!StringUtils.isEmpty(item.getHangCode())) {
					info.setHangCode(item.getHangCode());
				}
				if (!StringUtils.isEmpty(item.getSetCode())) {
					info.setSetCode(item.getSetCode());
				}
				if (!StringUtils.isEmpty(item.getSetHangmogCode())) {
					info.setSetHangmogCode(item.getSetHangmogCode());
				}
				if (!StringUtils.isEmpty(item.getHangmogName())) {
					info.setHangmogName(item.getHangmogName());
				}
				if (!StringUtils.isEmpty(item.getSuryang())) {
					info.setSuryang(item.getSuryang().toString());
				}
				if (!StringUtils.isEmpty(item.getDanui())) {
					info.setDanui(item.getDanui());
				}
				if (!StringUtils.isEmpty(item.getDanuiName())) {
					info.setDanuiName(item.getDanuiName());
				}
				if (!StringUtils.isEmpty(item.getBulyongYn())) {
					info.setBulyongYn(item.getBulyongYn());
				}
				response.addGrdSetHangmog(info);
			}
		}
		return response.build();
	}
}                                                                                                                 
