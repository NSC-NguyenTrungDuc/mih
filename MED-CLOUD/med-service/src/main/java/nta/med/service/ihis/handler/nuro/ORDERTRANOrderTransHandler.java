/**
 * 
 */
package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ifs.Ifs1004Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANOrderTransInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANOrderTransRequest;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANOrderTransResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class ORDERTRANOrderTransHandler extends ScreenHandler<NuroServiceProto.ORDERTRANOrderTransRequest, NuroServiceProto.ORDERTRANOrderTransResponse> {
	@Resource
	private Ifs1004Repository ifs1004Repository;

	@Override
	@Transactional(readOnly = true)
	public ORDERTRANOrderTransResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			ORDERTRANOrderTransRequest request) throws Exception {
		NuroServiceProto.ORDERTRANOrderTransResponse.Builder response = NuroServiceProto.ORDERTRANOrderTransResponse.newBuilder();
		List<ORDERTRANOrderTransInfo> listResult = ifs1004Repository.getORDERTRANOrderTransInfo(getHospitalCode(vertx, sessionId), request.getFkout1003(), request.getTransGubun());
		if (!CollectionUtils.isEmpty(listResult)) {
			for (ORDERTRANOrderTransInfo item : listResult) {
				NuroModelProto.ORDERTRANOrderTransInfo.Builder transInfo = NuroModelProto.ORDERTRANOrderTransInfo.newBuilder();
				BeanUtils.copyProperties(item, transInfo, getLanguage(vertx, sessionId));
				transInfo.setPkifs1004(String.valueOf(item.getPkifs1004().longValue()));
				response.addSangtransInfo(transInfo);
			}
		}
		return response.build();
	}
}