package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.App1001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsCHTAPPROVEgrdPatientRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsCHTAPPROVEgrdPatientResponse;

@Service
@Scope("prototype")
public class OcsCHTAPPROVEgrdPatientHandler extends
		ScreenHandler<OcsaServiceProto.OcsCHTAPPROVEgrdPatientRequest, OcsaServiceProto.OcsCHTAPPROVEgrdPatientResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsCHTAPPROVEgrdPatientHandler.class);
	@Resource
	private App1001Repository app1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsCHTAPPROVEgrdPatientResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OcsCHTAPPROVEgrdPatientRequest request) throws Exception {
		OcsaServiceProto.OcsCHTAPPROVEgrdPatientResponse.Builder response = OcsaServiceProto.OcsCHTAPPROVEgrdPatientResponse.newBuilder();
		List<ComboListItemInfo> list = app1001Repository.getOcsCHTAPPROVEgrdPatientInfo(getHospitalCode(vertx, sessionId), request.getIoGubun(), request.getUserId(), request.getApproveYn());
		if (!CollectionUtils.isEmpty(list)) {
			for (ComboListItemInfo item : list) {
				OcsaModelProto.OcsCHTAPPROVEgrdPatientInfo.Builder info = OcsaModelProto.OcsCHTAPPROVEgrdPatientInfo.newBuilder();
				info.setBunho(item.getCode());
				info.setSuname(item.getCodeName());
				response.addGrdPa(info);
			}
		}
		return response.build();
	}
	
}
