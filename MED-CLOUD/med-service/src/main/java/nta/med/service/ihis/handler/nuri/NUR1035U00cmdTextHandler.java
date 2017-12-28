package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1036Repository;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1035U00cmdTextHandler extends ScreenHandler<NuriServiceProto.NUR1035U00cmdTextRequest, NuriServiceProto.NUR1035U00cmdTextResponse> {   
	
	@Resource
	private Nur1036Repository nur1036Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1035U00cmdTextResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1035U00cmdTextRequest request) throws Exception {
				
		NuriServiceProto.NUR1035U00cmdTextResponse.Builder response = NuriServiceProto.NUR1035U00cmdTextResponse.newBuilder();
		
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
		info.setDataValue(nur1036Repository.getNUR1035U00cmdText(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPknur1035())));
		response.setCmditem(info);
		
		return response.build();
	}
}
