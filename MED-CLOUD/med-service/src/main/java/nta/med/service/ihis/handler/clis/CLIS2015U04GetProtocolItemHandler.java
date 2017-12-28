/**
 * 
 */
package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.clis.ClisProtocolRepository;
import nta.med.data.model.ihis.clis.CLIS2015U04GetProtocolItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U04GetProtocolItemRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U04GetProtocolItemResponse;
import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CLIS2015U04GetProtocolItemHandler
		extends
		ScreenHandler<ClisServiceProto.CLIS2015U04GetProtocolItemRequest, ClisServiceProto.CLIS2015U04GetProtocolItemResponse> {
	@Resource
	private ClisProtocolRepository clisProtocolRepository;

	@Override
	@Transactional(readOnly = true)
	public CLIS2015U04GetProtocolItemResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CLIS2015U04GetProtocolItemRequest request) throws Exception {
		ClisServiceProto.CLIS2015U04GetProtocolItemResponse.Builder response = ClisServiceProto.CLIS2015U04GetProtocolItemResponse
				.newBuilder();
		List<CLIS2015U04GetProtocolItemInfo> listResult = clisProtocolRepository
				.getCLIS2015U04ProtocolListItemInfo(getClisSmoId(vertx,
						sessionId));
		if (!CollectionUtils.isEmpty(listResult)) {
			for (CLIS2015U04GetProtocolItemInfo item : listResult) {
				ClisModelProto.CLIS2015U04GetProtocolItemInfo.Builder info = ClisModelProto.CLIS2015U04GetProtocolItemInfo
						.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addNum(info);
			}
		}
		return response.build();
	}
}