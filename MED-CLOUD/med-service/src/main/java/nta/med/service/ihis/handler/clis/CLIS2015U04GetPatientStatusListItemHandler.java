/**
 * 
 */
package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.clis.ClisPatientStatusRepository;
import nta.med.data.model.ihis.clis.CLIS2015U04GetPatientStatusListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U04GetPatientStatusListItemRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U04GetPatientStatusListItemResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CLIS2015U04GetPatientStatusListItemHandler
		extends
		ScreenHandler<ClisServiceProto.CLIS2015U04GetPatientStatusListItemRequest, ClisServiceProto.CLIS2015U04GetPatientStatusListItemResponse> {
	@Resource
	private ClisPatientStatusRepository clisPatientStatusRepository;

	@Override
	@Transactional(readOnly = true)
	public CLIS2015U04GetPatientStatusListItemResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CLIS2015U04GetPatientStatusListItemRequest request) throws Exception {
		ClisServiceProto.CLIS2015U04GetPatientStatusListItemResponse.Builder response = ClisServiceProto.CLIS2015U04GetPatientStatusListItemResponse
				.newBuilder();
		List<CLIS2015U04GetPatientStatusListItemInfo> listResult = clisPatientStatusRepository
				.getCLIS2015U04GetPatientStatusListItemInfo(request.getProtocolPatientId(), getHospitalCode(vertx, sessionId));
		if (!CollectionUtils.isEmpty(listResult)) {
			for (CLIS2015U04GetPatientStatusListItemInfo item : listResult) {
				ClisModelProto.CLIS2015U04GetPatientStatusListItemInfo.Builder info = ClisModelProto.CLIS2015U04GetPatientStatusListItemInfo
						.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addNum(info);
			}
		}
		return response.build();
	}
}