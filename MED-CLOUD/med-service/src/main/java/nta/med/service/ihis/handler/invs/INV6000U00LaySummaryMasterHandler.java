package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.model.ihis.invs.INV6000U00LaySummaryMasterInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV6000U00LaySummaryMasterRequest;
import nta.med.service.ihis.proto.InvsServiceProto.INV6000U00LaySummaryMasterResponse;

@Service
@Scope("prototype")
public class INV6000U00LaySummaryMasterHandler extends ScreenHandler<InvsServiceProto.INV6000U00LaySummaryMasterRequest, InvsServiceProto.INV6000U00LaySummaryMasterResponse> {

	@Resource
	private Inv0110Repository inv0110Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INV6000U00LaySummaryMasterResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV6000U00LaySummaryMasterRequest request) throws Exception {
		InvsServiceProto.INV6000U00LaySummaryMasterResponse.Builder response = InvsServiceProto.INV6000U00LaySummaryMasterResponse.newBuilder();
		List<INV6000U00LaySummaryMasterInfo> laySums = inv0110Repository.getINV6000U00LaySummaryMasterInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getMagamMonth());
		if(!CollectionUtils.isEmpty(laySums)){
			for(INV6000U00LaySummaryMasterInfo item : laySums){
				InvsModelProto.INV6000U00LaySummaryMasterInfo.Builder info = InvsModelProto.INV6000U00LaySummaryMasterInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLaySummaryM(info);
			}
		}
		return response.build();
	}

}
