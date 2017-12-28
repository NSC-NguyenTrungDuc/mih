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
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg3041Repository;
import nta.med.data.model.ihis.drgs.DRG3041P01grdChulgoListInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P01grdChulgoListRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P01grdChulgoListResponse;

@Service
@Scope("prototype")
public class DRG3041P01grdChulgoListHandler extends
		ScreenHandler<DrgsServiceProto.DRG3041P01grdChulgoListRequest, DrgsServiceProto.DRG3041P01grdChulgoListResponse> {

	@Resource
	private Drg3041Repository drg3041Repository;

	@Override
	@Transactional(readOnly = true)
	public DRG3041P01grdChulgoListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3041P01grdChulgoListRequest request) throws Exception {
		DrgsServiceProto.DRG3041P01grdChulgoListResponse.Builder response = DrgsServiceProto.DRG3041P01grdChulgoListResponse
				.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<DRG3041P01grdChulgoListInfo> infos = drg3041Repository.getDRG3041P01grdChulgoListInfo(hospCode,
				request.getBunho(), request.getHoDong(),
				request.getChulgoDate());

		if(!CollectionUtils.isEmpty(infos)){
			for (DRG3041P01grdChulgoListInfo info : infos) {
				DrgsModelProto.DRG3041P01grdChulgoListInfo.Builder pInfo = DrgsModelProto.DRG3041P01grdChulgoListInfo.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addItems(pInfo);
			}
		}
		
		return response.build();
	}

}
