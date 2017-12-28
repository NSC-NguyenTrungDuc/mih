package nta.med.service.emr.handler;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0501Repository;
import nta.med.service.emr.proto.EmrServiceProto;

/**
 * @author DEV-NgocNV
 *
 */
@Service
@Scope("prototype")
public class OCS2015U00GetHtmlContentHandler extends ScreenHandler<EmrServiceProto.OCS2015U00GetHtmlContentRequest, EmrServiceProto.OCS2015U00GetHtmlContentResponse>{
	private static final Log LOGGER = LogFactory.getLog(OCS2015U00GetHtmlContentHandler.class);
	
	@Resource
	private Bas0501Repository bas0501Repository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U00GetHtmlContentResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			EmrServiceProto.OCS2015U00GetHtmlContentRequest request) throws Exception {
		EmrServiceProto.OCS2015U00GetHtmlContentResponse.Builder response = EmrServiceProto.OCS2015U00GetHtmlContentResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String printContent = bas0501Repository.getOCS2015U00GetHtmlContent(hospCode, language);
		if(!StringUtils.isEmpty(printContent)){
			response.setPrintContent(printContent);
		}
		return response.build();
	}

}

