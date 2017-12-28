package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00GridOSC0503ListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00gridOSC0503ListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00gridOSC0503ListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class OcsaOCS0503U00GridOSC0503ListHandler
	extends ScreenHandler<OcsaServiceProto.OCS0503U00gridOSC0503ListRequest, OcsaServiceProto.OCS0503U00gridOSC0503ListResponse> {
	@Resource
	private Ocs0503Repository osc0503Repository;
	@Override
	@Transactional(readOnly = true)
	public OCS0503U00gridOSC0503ListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0503U00gridOSC0503ListRequest request) throws Exception {
		 OcsaServiceProto.OCS0503U00gridOSC0503ListResponse.Builder response=OcsaServiceProto.OCS0503U00gridOSC0503ListResponse.newBuilder();
		 List<OcsaOCS0503U00GridOSC0503ListInfo> listItem = osc0503Repository.getOcsaOCS0503U00GridOSC0503ListInfo(getHospitalCode(vertx, sessionId),getLanguage(vertx, sessionId), request.getBunho(), request.getReqDoctor());
		 if(listItem !=null && !listItem.isEmpty()){
			for(OcsaOCS0503U00GridOSC0503ListInfo item: listItem){
				OcsaModelProto.OCS0503U00gridOSC0503ListInfo.Builder info= OcsaModelProto.OCS0503U00gridOSC0503ListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getPkocs0503() != null) {
					info.setPkocs0503(String.format("%.0f",item.getPkocs0503()));
				}
				if (item.getConsultFkout1001() != null) {
					info.setConsultFkout1001(String.format("%.0f",item.getConsultFkout1001()));
				}
				if (item.getFkinp1001() != null) {
					info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
				}
				response.addGridOSC0503(info);
			}
		 }
		 return response.build();
	}

}
