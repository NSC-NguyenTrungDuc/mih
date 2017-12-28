package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00cboDungsyochiRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00cboDungsyochiResponse;

@Service
@Scope("prototype")
public class NUR1020U00cboDungsyochiHandler extends
		ScreenHandler<NuriServiceProto.NUR1020U00cboDungsyochiRequest, NuriServiceProto.NUR1020U00cboDungsyochiResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020U00cboDungsyochiResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00cboDungsyochiRequest request) throws Exception {
		NuriServiceProto.NUR1020U00cboDungsyochiResponse.Builder response = NuriServiceProto.NUR1020U00cboDungsyochiResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		NuriModelProto.NUR1020U00cboDungsyochiInfo.Builder firstInfo = NuriModelProto.NUR1020U00cboDungsyochiInfo
				.newBuilder().setCode("").setCodeName("").setSortKey("0");
		response.addCmbItem(firstInfo);
		
		List<Nur0102> listNur0102 = nur0102Repository.findByCodeTypeLanguage(hospCode, "VSPATN_AS", language);
		for (Nur0102 nur0102 : listNur0102) {
			NuriModelProto.NUR1020U00cboDungsyochiInfo.Builder info = NuriModelProto.NUR1020U00cboDungsyochiInfo
					.newBuilder()
					.setCode(nur0102.getCode())
					.setCodeName(nur0102.getCodeName())
					.setSortKey(nur0102.getSortKey() == null ? "" : String.format("%.0f",nur0102.getSortKey()));
			response.addCmbItem(info);
		}
		
		return response.build();
	}

}
