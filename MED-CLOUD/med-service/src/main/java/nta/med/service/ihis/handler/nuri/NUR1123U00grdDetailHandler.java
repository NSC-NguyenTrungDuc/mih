package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1123;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur1123Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1123U00grdDetailRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1123U00grdDetailResponse;

@Service                                                                                                          
@Scope("prototype")
public class NUR1123U00grdDetailHandler extends ScreenHandler<NuriServiceProto.NUR1123U00grdDetailRequest, NuriServiceProto.NUR1123U00grdDetailResponse> {                     
	
	@Resource                                   
	private Nur1123Repository nur1123Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1123U00grdDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1123U00grdDetailRequest request) throws Exception {
		
		NuriServiceProto.NUR1123U00grdDetailResponse.Builder response = NuriServiceProto.NUR1123U00grdDetailResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String codeType = request.getCodeType();
		
		List<Nur1123> listInfo = nur1123Repository.findByHospCodeAndCodeType(hospCode, codeType);
		if(!CollectionUtils.isEmpty(listInfo)){
			for (Nur1123 nur1123 : listInfo) {
				NuriModelProto.NUR1123U00grdDetailInfo.Builder info = NuriModelProto.NUR1123U00grdDetailInfo.newBuilder()
						.setCodeType(nur1123.getCodeType() == null ? "" : nur1123.getCodeType())
						.setCode(nur1123.getCode() == null ? "" : nur1123.getCode())
						.setCodeName(nur1123.getCodeName() == null ? "" : nur1123.getCodeName())
						.setSortKey(nur1123.getSortKey() == null ? "" : nur1123.getSortKey() + "");
				
				response.addListDetail(info);
			}
		}
		
		return response.build();
	}
}
