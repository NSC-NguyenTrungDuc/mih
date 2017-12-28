package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00layHangmogRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00layHangmogResponse;

@Service
@Scope("prototype")
public class NUR1020U00layHangmogHandler extends
		ScreenHandler<NuriServiceProto.NUR1020U00layHangmogRequest, NuriServiceProto.NUR1020U00layHangmogResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020U00layHangmogResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00layHangmogRequest request) throws Exception {
		NuriServiceProto.NUR1020U00layHangmogResponse.Builder response = NuriServiceProto.NUR1020U00layHangmogResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<ComboListItemInfo> listData = nur0102Repository.getCbxNUR1020U00layHangmog(hospCode, request.getBunho(),
				CommonUtils.parseDouble(request.getFkinp1001()));
		
		for (ComboListItemInfo item : listData) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addLayItem(info);
		}
		
		return response.build();
	}

}
