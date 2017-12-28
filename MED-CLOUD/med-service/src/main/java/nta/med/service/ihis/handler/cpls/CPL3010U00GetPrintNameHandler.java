package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm3300;
import nta.med.data.dao.medi.adm.Adm3300Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00GetPrintNameRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00GetPrintNameResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00GetPrintNameHandler extends ScreenHandler<CplsServiceProto.CPL3010U00GetPrintNameRequest, CplsServiceProto.CPL3010U00GetPrintNameResponse> {
	@Resource
	private Adm3300Repository adm3300Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00GetPrintNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U00GetPrintNameRequest request) throws Exception {
		CplsServiceProto.CPL3010U00GetPrintNameResponse.Builder response = CplsServiceProto.CPL3010U00GetPrintNameResponse.newBuilder();
		List<Adm3300> listResult = adm3300Repository.findByIpAddr(getHospitalCode(vertx, sessionId), request.getIpAddr());
		if (!CollectionUtils.isEmpty(listResult)) {
			for (Adm3300 item : listResult) {
		       if (!StringUtils.isEmpty(item.getBPrintName())) {
		       	CommonModelProto.DataStringListItemInfo.Builder builder = CommonModelProto.DataStringListItemInfo.newBuilder();
		       	builder.setDataValue(item.getBPrintName());
		   		response.addAddr(builder);
		   		}
			}
		}
		return response.build();
	}
}
