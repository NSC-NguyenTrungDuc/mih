package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.adm.Adm3200;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.service.ihis.proto.AdmaServiceProto.ADM104QGetPatientRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.ADM104QGetPatientResponse;

@Service
@Scope("prototype")
public class ADM104QGetPatientHandler extends ScreenHandler<ADM104QGetPatientRequest, ADM104QGetPatientResponse>{
	
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	public ADM104QGetPatientResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			ADM104QGetPatientRequest request) throws Exception {
		ADM104QGetPatientResponse.Builder response = ADM104QGetPatientResponse.newBuilder();
		List<Adm3200> adm3200s = adm3200Repository.findByHospCodeUserId(getHospitalCode(vertx, sessionId), request.getUserId());
		response.setExist(CollectionUtils.isEmpty(adm3200s) ? false : true);
		response.setUserName(CollectionUtils.isEmpty(adm3200s) ? "" : adm3200s.get(0).getUserNm());
		return response.build();
	}

}
