package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.nuro.NuroInspectionOrderInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroInspectionOrderHandler extends ScreenHandler<NuroServiceProto.NuroInspectionOrderRequest, NuroServiceProto.NuroInspectionOrderResponse> {
	private static final Log LOG = LogFactory.getLog(NuroInspectionOrderHandler.class);
	@Resource
	private Sch0201Repository sch0201Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroInspectionOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroInspectionOrderRequest request) throws Exception {
		NuroServiceProto.NuroInspectionOrderResponse.Builder response = NuroServiceProto.NuroInspectionOrderResponse.newBuilder();
		List<NuroInspectionOrderInfo> listObject = sch0201Repository.getNuroInspectionOrderInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getPatientCode(), request.getReserDate());
        if (!CollectionUtils.isEmpty(listObject)) {
            for (NuroInspectionOrderInfo item : listObject) {
            	NuroModelProto.NuroInspectionOrderInfo.Builder info = NuroModelProto.NuroInspectionOrderInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		if(item.getReserDay() != null){
        			info.setReserDay(String.format("%.0f",item.getReserDay()));
        		}
        		if(item.getSeq() != null){
        			info.setSeq(String.format("%.0f",item.getSeq()));
        		}
        		response.addInspectionOrderInfo(info);
            }
        }
		return response.build();
	}
}
