package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSMisaGetHangmogInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANSMisaGetHangmogRequest;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANSMisaGetHangmogResponse;

@Service
@Scope("prototype")
public class ORDERTRANSMisaGetHangmogHandler extends ScreenHandler<ORDERTRANSMisaGetHangmogRequest, ORDERTRANSMisaGetHangmogResponse> {
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public ORDERTRANSMisaGetHangmogResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			ORDERTRANSMisaGetHangmogRequest request) throws Exception {
		ORDERTRANSMisaGetHangmogResponse.Builder response = ORDERTRANSMisaGetHangmogResponse.newBuilder();
		List<ORDERTRANSMisaGetHangmogInfo> list = ocs1003Repository.getORDERTRANSMisaGetHangmogInfo(getHospitalCode(vertx, sessionId), request.getBunho(), request.getPkout1001());
		if(!CollectionUtils.isEmpty(list)){
			for(ORDERTRANSMisaGetHangmogInfo item : list){
				NuroModelProto.ORDERTRANSMisaGetHangmogInfo.Builder info = NuroModelProto.ORDERTRANSMisaGetHangmogInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLst(info);
			}
		}
		return response.build();
	}

}
