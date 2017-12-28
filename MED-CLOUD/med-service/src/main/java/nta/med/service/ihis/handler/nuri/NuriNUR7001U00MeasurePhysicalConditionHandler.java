package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur7001Repository;
import nta.med.data.model.ihis.nuri.NuriMeasurePhysicalConditionListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuriNUR7001U00MeasurePhysicalConditionHandler extends ScreenHandler<NuriServiceProto.NuriNUR7001U00MeasurePhysicalConditionRequest, NuriServiceProto.NuriNUR7001U00MeasurePhysicalConditionResponse> {
	private static final Log LOG = LogFactory.getLog(NuriNUR7001U00MeasurePhysicalConditionHandler.class);
	@Resource
	private Nur7001Repository nur7001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NuriNUR7001U00MeasurePhysicalConditionResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR7001U00MeasurePhysicalConditionRequest request) throws Exception {
		NuriServiceProto.NuriNUR7001U00MeasurePhysicalConditionResponse.Builder response = NuriServiceProto.NuriNUR7001U00MeasurePhysicalConditionResponse.newBuilder();
		List<NuriMeasurePhysicalConditionListItemInfo> listObject = nur7001Repository.getNuriMeasurePhysicalConditionListItemInfo(getHospitalCode(vertx, sessionId), request.getBunho());
        if (listObject != null && !listObject.isEmpty()) {
         	for(NuriMeasurePhysicalConditionListItemInfo item : listObject) {
         		NuriModelProto.NuriMeasurePhysicalConditionListItemInfo.Builder info = NuriModelProto.NuriMeasurePhysicalConditionListItemInfo.newBuilder();
         		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
         		response.addMeasurePhysicalConditionListItem(info);
         	}
         }
		return response.build();
	}
}
