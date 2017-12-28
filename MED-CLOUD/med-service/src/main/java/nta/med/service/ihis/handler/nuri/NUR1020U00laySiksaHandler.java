package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1021Repository;
import nta.med.data.model.ihis.nuri.NUR1020U00laySiksaInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00laySiksaRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00laySiksaResponse;

@Service
@Scope("prototype")
public class NUR1020U00laySiksaHandler
		extends ScreenHandler<NuriServiceProto.NUR1020U00laySiksaRequest, NuriServiceProto.NUR1020U00laySiksaResponse> {

	@Resource
	private Nur1021Repository nur1021Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020U00laySiksaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00laySiksaRequest request) throws Exception {
		NuriServiceProto.NUR1020U00laySiksaResponse.Builder response = NuriServiceProto.NUR1020U00laySiksaResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1020U00laySiksaInfo> items = nur1021Repository.getNUR1020U00laySiksaInfo(hospCode, request.getBunho(),
				CommonUtils.parseDouble(request.getFkinp1001()), request.getYmd());
		
		for (NUR1020U00laySiksaInfo item : items) {
			NuriModelProto.NUR1020U00laySiksaInfo.Builder info = NuriModelProto.NUR1020U00laySiksaInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayItem(info);
		}
		
		return response.build();
	}

}
