package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0503U00LoadOutSangRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0503U00LoadOutSangResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
@Transactional
public class OcsaOCS0503U00LoadOutSangOCS0503U00Handler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0503U00LoadOutSangRequest, OcsaServiceProto.OcsaOCS0503U00LoadOutSangResponse> {
	@Resource
	private OutsangRepository outSangRepository;

	@Override
	@Transactional(readOnly = true)
	public OcsaOCS0503U00LoadOutSangResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0503U00LoadOutSangRequest request) throws Exception {
		List<String> listResult = outSangRepository.loadOutSangOcsaOCS0503U00(getHospitalCode(vertx, sessionId), request.getBunho(), request.getGwa(),request.getIoGubun());
		OcsaServiceProto.OcsaOCS0503U00LoadOutSangResponse.Builder response = OcsaServiceProto.OcsaOCS0503U00LoadOutSangResponse.newBuilder();
		 if(!CollectionUtils.isEmpty(listResult)) {
			 for(String item : listResult) {
				 if(!StringUtils.isEmpty(item)){
					 response.addSangName(item);
				 }
			 }
		 }	
		 return response.build();
	}
}