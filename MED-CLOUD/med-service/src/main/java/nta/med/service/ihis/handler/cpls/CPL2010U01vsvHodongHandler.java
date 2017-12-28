package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01vsvHodongRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01vsvHodongResponse;

@Service
@Scope("prototype")
public class CPL2010U01vsvHodongHandler extends
		ScreenHandler<CplsServiceProto.CPL2010U01vsvHodongRequest, CplsServiceProto.CPL2010U01vsvHodongResponse> {

	@Resource
	private Bas0260Repository bas0260Repository;

	@Override
	@Transactional(readOnly = true)
	public CPL2010U01vsvHodongResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U01vsvHodongRequest request) throws Exception {
		CplsServiceProto.CPL2010U01vsvHodongResponse.Builder response = CplsServiceProto.CPL2010U01vsvHodongResponse
				.newBuilder();
		String buseoName = bas0260Repository.getBuseoNameByCode(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), "2", request.getCode());
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder()
				.setDataValue(buseoName);
		
		response.addVsvItem(info);
		return response.build();
	}

}
