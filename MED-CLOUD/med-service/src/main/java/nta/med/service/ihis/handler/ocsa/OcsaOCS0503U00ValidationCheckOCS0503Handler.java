package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00ValidationCheckInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00ValidationCheckRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00ValidationCheckResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class OcsaOCS0503U00ValidationCheckOCS0503Handler
	extends ScreenHandler<OcsaServiceProto.OCS0503U00ValidationCheckRequest, OcsaServiceProto.OCS0503U00ValidationCheckResponse> {
	@Resource
	Ocs0503Repository ocs0503Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS0503U00ValidationCheckResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0503U00ValidationCheckRequest request) throws Exception {
		OcsaServiceProto.OCS0503U00ValidationCheckResponse.Builder response=OcsaServiceProto.OCS0503U00ValidationCheckResponse.newBuilder();
		List<OcsaOCS0503U00ValidationCheckInfo> listItem=ocs0503Repository.getOCS0503U00ValidationCheck(getHospitalCode(vertx, sessionId),CommonUtils.parseDouble(request.getFkout1001()));
		if(listItem !=null && !listItem.isEmpty()){
			for(OcsaOCS0503U00ValidationCheckInfo item : listItem){
				OcsaModelProto.OCS0503U00ValidationCheckInfo.Builder info=OcsaModelProto.OCS0503U00ValidationCheckInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getNaewon())){
					info.setNaewon(item.getNaewon());
				}
				if(!StringUtils.isEmpty(item.getOrderYn())){
					info.setOrderYn(item.getOrderYn());
				}
				response.addValidateCheck(info);	
			}
		}
		return response.build();
	}
}
