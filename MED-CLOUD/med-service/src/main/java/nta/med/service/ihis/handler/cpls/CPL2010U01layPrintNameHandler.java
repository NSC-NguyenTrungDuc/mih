package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3300Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01layPrintNameRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01layPrintNameResponse;

@Service
@Scope("prototype")
public class CPL2010U01layPrintNameHandler extends
		ScreenHandler<CplsServiceProto.CPL2010U01layPrintNameRequest, CplsServiceProto.CPL2010U01layPrintNameResponse> {
	@Resource
	private Adm3300Repository adm3300Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public CPL2010U01layPrintNameResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U01layPrintNameRequest request) throws Exception {
		CplsServiceProto.CPL2010U01layPrintNameResponse.Builder response = CplsServiceProto.CPL2010U01layPrintNameResponse.newBuilder();
		String result = adm3300Repository.getLayPrintName(getHospitalCode(vertx, sessionId), request.getIpAddr());
		if (!StringUtils.isEmpty(result)) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.addLayItem(info);
		}
		return response.build();
	}

}
