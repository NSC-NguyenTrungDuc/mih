package nta.med.service.emr.handler;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U00GetInfoEPortViewerRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U00GetInfoEPortViewerResponse;

@Service
@Scope("prototype")
public class OCS2015U00GetInfoEPortViewerHandler extends ScreenHandler<EmrServiceProto.OCS2015U00GetInfoEPortViewerRequest, EmrServiceProto.OCS2015U00GetInfoEPortViewerResponse> {
	
	@Resource
	Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS2015U00GetInfoEPortViewerResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2015U00GetInfoEPortViewerRequest request) throws Exception {
		EmrServiceProto.OCS2015U00GetInfoEPortViewerResponse.Builder response = EmrServiceProto.OCS2015U00GetInfoEPortViewerResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String folderPath = bas0102Repository.getCodeNameByCodeTypeAndCode(hospCode, language, "EPORTVIEWER", "FOLDER_PATH");
		String exePath = bas0102Repository.getCodeNameByCodeTypeAndCode(hospCode, language, "EPORTVIEWER", "EXE_PATH");
		if(!StringUtils.isEmpty(folderPath)){
			response.setFolderPath(folderPath);
		}
		if(!StringUtils.isEmpty(exePath)){
			response.setExePath(exePath);
		}
		return response.build();
	}

}
