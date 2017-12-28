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
import nta.med.data.dao.medi.nur.Nur1022Repository;
import nta.med.data.model.ihis.nuri.NUR1020Q00layIOInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layIORequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layIOResponse;

@Service
@Scope("prototype")
public class NUR1020Q00layIOHandler
		extends ScreenHandler<NuriServiceProto.NUR1020Q00layIORequest, NuriServiceProto.NUR1020Q00layIOResponse> {

	@Resource
	private Nur1022Repository nur1022Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020Q00layIOResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020Q00layIORequest request) throws Exception {
		NuriServiceProto.NUR1020Q00layIOResponse.Builder response = NuriServiceProto.NUR1020Q00layIOResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1020Q00layIOInfo> items = nur1022Repository.getNUR1020Q00layIOInfo(hospCode, language,
				request.getBunho(), CommonUtils.parseDouble(request.getFkinp1001()), request.getYmd());
		
		for (NUR1020Q00layIOInfo item : items) {
			NuriModelProto.NUR1020Q00layIOInfo.Builder info = NuriModelProto.NUR1020Q00layIOInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayItem(info);
		}
		
		return response.build();
	}

}
