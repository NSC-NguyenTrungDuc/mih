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
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.nuri.NUR1020U00grdNUR1022INInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00grdNUR1022INRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00grdNUR1022INResponse;

@Service
@Scope("prototype")
public class NUR1020U00grdNUR1022INHandler extends
		ScreenHandler<NuriServiceProto.NUR1020U00grdNUR1022INRequest, NuriServiceProto.NUR1020U00grdNUR1022INResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020U00grdNUR1022INResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00grdNUR1022INRequest request) throws Exception {
		NuriServiceProto.NUR1020U00grdNUR1022INResponse.Builder response = NuriServiceProto.NUR1020U00grdNUR1022INResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1020U00grdNUR1022INInfo> listData = nur0102Repository.getNUR1020U00grdNUR1022INInfo(hospCode
				, request.getBunho()
				, CommonUtils.parseDouble(request.getFkinp1001())
				, request.getOrderDate()
				, request.getGubn()
				, request.getPrevqryflag()
				, request.getGubnType());
		
		for (NUR1020U00grdNUR1022INInfo item : listData) {
			NuriModelProto.NUR1020U00grdNUR1022INInfo.Builder info = NuriModelProto.NUR1020U00grdNUR1022INInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}
