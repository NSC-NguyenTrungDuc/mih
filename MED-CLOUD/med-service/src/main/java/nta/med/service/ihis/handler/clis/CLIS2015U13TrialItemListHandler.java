package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U13TrialItemListRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U13TrialItemListResponse;


@Service
@Scope("prototype")
public class CLIS2015U13TrialItemListHandler extends ScreenHandler<CLIS2015U13TrialItemListRequest, CLIS2015U13TrialItemListResponse>{
	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CLIS2015U13TrialItemListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CLIS2015U13TrialItemListRequest request) throws Exception {
		CLIS2015U13TrialItemListResponse.Builder response = CLIS2015U13TrialItemListResponse.newBuilder();
		List<ComboListItemInfo> list = ocs0103Repository.getClis2015U13TrialItemListInfo(getHospitalCode(vertx, sessionId), request.getClisProtocolId());
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addTrialList(info);
			}
		}
		return response.build();
	}

}
