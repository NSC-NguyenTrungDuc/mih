package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00fwkWriterRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00fwkWriterResponse;

@Service
@Scope("prototype")
public class NUR1020U00fwkWriterHandler extends
		ScreenHandler<NuriServiceProto.NUR1020U00fwkWriterRequest, NuriServiceProto.NUR1020U00fwkWriterResponse> {

	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020U00fwkWriterResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00fwkWriterRequest request) throws Exception {
		NuriServiceProto.NUR1020U00fwkWriterResponse.Builder response = NuriServiceProto.NUR1020U00fwkWriterResponse.newBuilder();
		List<ComboListItemInfo> infos = adm3200Repository.getCbxNUR1020U00fwkWriter(getHospitalCode(vertx, sessionId)
				, request.getBuseoName()
				, DateUtil.toDate(request.getNurWrdt(), DateUtil.PATTERN_YYMMDD));
		
		for (ComboListItemInfo info : infos) {
			CommonModelProto.ComboListItemInfo.Builder pInfo = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(info.getCode())
					.setCodeName(info.getCodeName());
			response.addFwkItem(pInfo);
		}
		
		return response.build();
	}

}
