package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00MlayConstantCPL2010ListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01PostLoadRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01PostLoadResponse;

@Service
@Scope("prototype")
public class CPL2010U01PostLoadHandler
		extends ScreenHandler<CplsServiceProto.CPL2010U01PostLoadRequest, CplsServiceProto.CPL2010U01PostLoadResponse> {
	@Resource
	private Cpl0109Repository cpl0109Repository;

	@Override
	@Transactional(readOnly = true)
	public CPL2010U01PostLoadResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U01PostLoadRequest request) throws Exception {
		CplsServiceProto.CPL2010U01PostLoadResponse.Builder response = CplsServiceProto.CPL2010U01PostLoadResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String autoQueryYn = "";
		String autoAlarmYn = "";
		String alarmFilePathCPL = "";
		String alarmFilePathCPLEM = "";
		List<CplsCPL2010U00MlayConstantCPL2010ListItemInfo> list = cpl0109Repository.getCPL2010U00MlayConstantInfo(hospCode, language, "CPL_CONSTANT");
		if (!CollectionUtils.isEmpty(list)) {
			for (CplsCPL2010U00MlayConstantCPL2010ListItemInfo item : list) {
				if ("btn_autoQuery_yn".equals(item.getCodeName()))
					autoQueryYn = item.getCodeValue();
			}
			
			for (CplsCPL2010U00MlayConstantCPL2010ListItemInfo item : list) {
				if ("btn_autoAlarm_yn".equals(item.getCodeName())) {
					autoAlarmYn = item.getCodeValue();
					List<CplsCPL2010U00MlayConstantCPL2010ListItemInfo> list2 = cpl0109Repository.getCPL2010U00MlayConstantInfo(hospCode, language, "CPL_ALARM");
					if (!CollectionUtils.isEmpty(list2)) {
						for (CplsCPL2010U00MlayConstantCPL2010ListItemInfo item2 : list2) {
							if ("CPL".equals(item2.getCode()))
								alarmFilePathCPL = item2.getCodeValue();
							if ("CPL_EM".equals(item2.getCode()))
								alarmFilePathCPLEM = item2.getCodeValue();
						}
					}
				}
			}
		}
		
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
		info.setDataValue(autoQueryYn);
		response.addLayoutItem(info);
		info.setDataValue(autoAlarmYn);
		response.addLayoutItem(info);
		info.setDataValue(alarmFilePathCPL);
		response.addLayoutItem(info);
		info.setDataValue(alarmFilePathCPLEM);
		response.addLayoutItem(info);
		
		return response.build();
	}

}
