package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010Q12grdPalistInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010Q12grdPalistRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010Q12grdPalistResponse;

@Service
@Scope("prototype")
public class DRG3010Q12grdPalistHandler extends
		ScreenHandler<DrgsServiceProto.DRG3010Q12grdPalistRequest, DrgsServiceProto.DRG3010Q12grdPalistResponse> {

	@Resource
	private Drg3010Repository drg3010Repository;

	@Override
	@Transactional
	public DRG3010Q12grdPalistResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010Q12grdPalistRequest request) throws Exception {
		DrgsServiceProto.DRG3010Q12grdPalistResponse.Builder response = DrgsServiceProto.DRG3010Q12grdPalistResponse.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<DRG3010Q12grdPalistInfo> infos = drg3010Repository.getDRG3010Q12grdPalistInfo(hospCode,
				request.getHoDong());
		if (!CollectionUtils.isEmpty(infos)) {
			for (DRG3010Q12grdPalistInfo info : infos) {
				DrgsModelProto.DRG3010Q12grdPalistInfo.Builder pInfo = DrgsModelProto.DRG3010Q12grdPalistInfo
						.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addItems(pInfo);
			}
		}

		return response.build();
	}
}
