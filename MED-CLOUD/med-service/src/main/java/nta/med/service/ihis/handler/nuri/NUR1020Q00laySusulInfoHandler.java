package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.opr.Opr1001Repository;
import nta.med.data.model.ihis.nuri.NUR1020Q00laySusulInfoInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00laySusulInfoRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00laySusulInfoResponse;

@Service
@Scope("prototype")
public class NUR1020Q00laySusulInfoHandler extends
		ScreenHandler<NuriServiceProto.NUR1020Q00laySusulInfoRequest, NuriServiceProto.NUR1020Q00laySusulInfoResponse> {

	@Resource
	private Opr1001Repository opr1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020Q00laySusulInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020Q00laySusulInfoRequest request) throws Exception {
		NuriServiceProto.NUR1020Q00laySusulInfoResponse.Builder response = NuriServiceProto.NUR1020Q00laySusulInfoResponse
				.newBuilder();

		List<NUR1020Q00laySusulInfoInfo> items = opr1001Repository.getNUR1020Q00laySusulInfoInfo(
				getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(),
				CommonUtils.parseDouble(request.getFkinp1001()), request.getFromOpDate(), request.getToOpDate());
		
		
		for (NUR1020Q00laySusulInfoInfo item : items) {
			NuriModelProto.NUR1020Q00laySusulInfoInfo.Builder info = NuriModelProto.NUR1020Q00laySusulInfoInfo.newBuilder()
					.setOpReserDate(item.getOpReserDate())
					.setSusulName(item.getSusulName());
			response.addLayItem(info);
		}
		
		return response.build();
	}

}
