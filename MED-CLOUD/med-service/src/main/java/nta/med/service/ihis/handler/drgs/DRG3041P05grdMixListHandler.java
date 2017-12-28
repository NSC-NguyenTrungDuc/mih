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
import nta.med.data.model.ihis.drgs.DRG3041P05grdMixListInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P05grdMixListRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P05grdMixListResponse;

@Service
@Scope("prototype")
public class DRG3041P05grdMixListHandler extends
		ScreenHandler<DrgsServiceProto.DRG3041P05grdMixListRequest, DrgsServiceProto.DRG3041P05grdMixListResponse> {

	@Resource
	private Drg3041Repository drg3041Repository;

	@Override
	@Transactional(readOnly = true)
	public DRG3041P05grdMixListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3041P05grdMixListRequest request) throws Exception {

		DrgsServiceProto.DRG3041P05grdMixListResponse.Builder response = DrgsServiceProto.DRG3041P05grdMixListResponse
				.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DRG3041P05grdMixListInfo> infos = drg3041Repository.getDRG3041P05grdMixListInfo(hospCode
				, request.getBunryu1()
				, request.getHoDong()
				, request.getIpgoDate()
				, request.getBunho());
		
		if(!CollectionUtils.isEmpty(infos)){
			for (DRG3041P05grdMixListInfo info : infos) {
				DrgsModelProto.DRG3041P05grdMixListInfo.Builder pInfo = DrgsModelProto.DRG3041P05grdMixListInfo.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addItems(pInfo);
			}
		}
		
		return response.build();
	}

}
