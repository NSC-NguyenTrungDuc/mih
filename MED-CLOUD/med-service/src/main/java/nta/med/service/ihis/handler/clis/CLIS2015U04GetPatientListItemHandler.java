/**
 * 
 */
package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.clis.ClisProtocolPatientRepository;
import nta.med.data.model.ihis.clis.CLIS2015U04GetPatientListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U04GetPatientListItemRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U04GetPatientListItemResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CLIS2015U04GetPatientListItemHandler
		extends
		ScreenHandler<ClisServiceProto.CLIS2015U04GetPatientListItemRequest, ClisServiceProto.CLIS2015U04GetPatientListItemResponse> {
	@Resource
	private ClisProtocolPatientRepository clisProtocolPatientRepository;

	@Override
	@Transactional(readOnly = true)
	public CLIS2015U04GetPatientListItemResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CLIS2015U04GetPatientListItemRequest request) throws Exception {
		ClisServiceProto.CLIS2015U04GetPatientListItemResponse.Builder response = ClisServiceProto.CLIS2015U04GetPatientListItemResponse
				.newBuilder();
		List<CLIS2015U04GetPatientListItemInfo> listResult = clisProtocolPatientRepository
				.getCLIS2015U04GetPatientListItemInfo(request.getClisProtocolId());
		if (!CollectionUtils.isEmpty(listResult)) {
			for (CLIS2015U04GetPatientListItemInfo item : listResult) {
				ClisModelProto.CLIS2015U04GetPatientListItemInfo.Builder info = ClisModelProto.CLIS2015U04GetPatientListItemInfo
						.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addNum(info);
			}
		}
		return response.build();
	}
}