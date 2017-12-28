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
import nta.med.data.dao.medi.nur.impl.Nur1022RepositoryImpl;
import nta.med.data.model.ihis.nuri.NUR1020Q00layInOutTotalInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layInOutTotalRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layInOutTotalResponse;

@Service
@Scope("prototype")
public class NUR1020Q00layInOutTotalHandler extends
		ScreenHandler<NuriServiceProto.NUR1020Q00layInOutTotalRequest, NuriServiceProto.NUR1020Q00layInOutTotalResponse> {

	@Resource
	private Nur1022RepositoryImpl nur1022RepositoryImpl;

	@Override
	@Transactional(readOnly = true)
	public NUR1020Q00layInOutTotalResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020Q00layInOutTotalRequest request) throws Exception {
		NuriServiceProto.NUR1020Q00layInOutTotalResponse.Builder response = NuriServiceProto.NUR1020Q00layInOutTotalResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1020Q00layInOutTotalInfo> items = nur1022RepositoryImpl.getNUR1020Q00layInOutTotalInfo(hospCode,
				request.getBunho(), CommonUtils.parseDouble(request.getFkinp1001()), request.getFromOpDate(), request.getToOpDate());
		
		for (NUR1020Q00layInOutTotalInfo item : items) {
			NuriModelProto.NUR1020Q00layInOutTotalInfo.Builder info = NuriModelProto.NUR1020Q00layInOutTotalInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayItem(info);
		}
		
		return response.build();
	}

}
