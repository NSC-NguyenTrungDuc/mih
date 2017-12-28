package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl3010Repository;
import nta.med.data.model.ihis.cpls.CPL3020U02GrdPaListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02GrdPaRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02GrdPaResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U02GrdPaHandler extends ScreenHandler<CplsServiceProto.CPL3020U02GrdPaRequest, CplsServiceProto.CPL3020U02GrdPaResponse> {
	@Resource
	private Cpl3010Repository cpl3010Repository;

	@Override
	@Transactional(readOnly = true)
	public CPL3020U02GrdPaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3020U02GrdPaRequest request)
			throws Exception {
		CplsServiceProto.CPL3020U02GrdPaResponse.Builder response = CplsServiceProto.CPL3020U02GrdPaResponse.newBuilder();
		List<CPL3020U02GrdPaListItemInfo> listGrdPa = cpl3010Repository.getCPL3020U02GrdPaListItemInfo(
					getHospitalCode(vertx, sessionId), request.getFromDate(), request.getToDate(), request.getJangbiCode());
		if (!CollectionUtils.isEmpty(listGrdPa)) {
			for (CPL3020U02GrdPaListItemInfo item : listGrdPa) {
				CplsModelProto.CPL3020U00GrdPaListItemInfo.Builder info = CplsModelProto.CPL3020U00GrdPaListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdPaItemInfo(info);
			}
		}
		return response.build();
	}
}