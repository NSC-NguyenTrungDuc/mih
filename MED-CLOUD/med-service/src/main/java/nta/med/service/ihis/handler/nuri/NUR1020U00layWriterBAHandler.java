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
import nta.med.data.dao.medi.nur.Nur7002Repository;
import nta.med.data.model.ihis.nuri.NUR1020U00layWriterBAInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00layWriterBARequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00layWriterBAResponse;

@Service
@Scope("prototype")
public class NUR1020U00layWriterBAHandler extends
		ScreenHandler<NuriServiceProto.NUR1020U00layWriterBARequest, NuriServiceProto.NUR1020U00layWriterBAResponse> {

	@Resource
	private Nur7002Repository nur7002Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020U00layWriterBAResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00layWriterBARequest request) throws Exception {
		NuriServiceProto.NUR1020U00layWriterBAResponse.Builder response = NuriServiceProto.NUR1020U00layWriterBAResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1020U00layWriterBAInfo> items = nur7002Repository.getNUR1020U00layWriterBAInfo(hospCode,
				request.getYmd(), request.getBunho(), CommonUtils.parseDouble(request.getFkinp1001()));
		
		for (NUR1020U00layWriterBAInfo item : items) {
			NuriModelProto.NUR1020U00layWriterBAInfo.Builder info = NuriModelProto.NUR1020U00layWriterBAInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayItem(info);
		}
		
		return response.build();
	}

}
