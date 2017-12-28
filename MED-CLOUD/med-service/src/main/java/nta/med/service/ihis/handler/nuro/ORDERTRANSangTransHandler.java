/**
 * 
 */
package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ifs.Ifs1011Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSangTransInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANSangTransRequest;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANSangTransResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class ORDERTRANSangTransHandler
		extends
		ScreenHandler<NuroServiceProto.ORDERTRANSangTransRequest, NuroServiceProto.ORDERTRANSangTransResponse> {
	@Resource
	private Ifs1011Repository ifs1011Repository;

	@Override
	@Transactional(readOnly = true)
	public ORDERTRANSangTransResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			ORDERTRANSangTransRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSangTransResponse.Builder response = NuroServiceProto.ORDERTRANSangTransResponse.newBuilder();
		List<ORDERTRANSangTransInfo> listResult = ifs1011Repository.getORDERTRANSangTransInfo(getHospitalCode(vertx, sessionId), request.getFkout1003());
		if (!CollectionUtils.isEmpty(listResult)) {
			for (ORDERTRANSangTransInfo item : listResult) {
				NuroModelProto.ORDERTRANSangTransInfo.Builder transInfo = NuroModelProto.ORDERTRANSangTransInfo
						.newBuilder();
				BeanUtils.copyProperties(item, transInfo, getLanguage(vertx, sessionId));
				transInfo.setPkifs1011(String.valueOf(item.getPkifs1011().longValue()));
				response.addSangtransInfo(transInfo);
			}
		}
		return response.build();
	}
}