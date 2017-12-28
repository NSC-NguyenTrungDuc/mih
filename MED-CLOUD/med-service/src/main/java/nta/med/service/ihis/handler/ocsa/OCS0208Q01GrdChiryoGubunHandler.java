package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0208Q01GrdChiryoGubunRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0208Q01GrdChiryoGubunResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0208Q01GrdChiryoGubunHandler
	extends ScreenHandler<OcsaServiceProto.OCS0208Q01GrdChiryoGubunRequest, OcsaServiceProto.OCS0208Q01GrdChiryoGubunResponse> {                     
	@Resource                                                                                                       
	private Drg0120Repository drg0120Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public OCS0208Q01GrdChiryoGubunResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0208Q01GrdChiryoGubunRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0208Q01GrdChiryoGubunResponse.Builder response = OcsaServiceProto.OCS0208Q01GrdChiryoGubunResponse.newBuilder();                      
		List<ComboListItemInfo> listGrd=drg0120Repository.getOCS0208Q01GrdChiryoGubun(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBogyongGubun(),
				request.getJaeryoCode(),request.getUseYn());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(ComboListItemInfo item : listGrd){
				CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addChiryoGubunInfo(info);
			}
		}
		return response.build();
	}
}