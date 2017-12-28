package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.system.GetORCAEnvInfo;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetORCAEnvRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetORCAEnvResponse;

@Service
@Scope("prototype")
public class GetORCAEnvHandler extends ScreenHandler<SystemServiceProto.GetORCAEnvRequest, SystemServiceProto.GetORCAEnvResponse>{
	private static final Log logger = LogFactory.getLog(GetORCAEnvHandler.class);
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public GetORCAEnvResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			GetORCAEnvRequest request) throws Exception {
		SystemServiceProto.GetORCAEnvResponse.Builder response = SystemServiceProto.GetORCAEnvResponse.newBuilder();
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
		//Check using ORCA
		String code = bas0102Repository.getCodeUsingORCA(hospCode, language);
		if(!StringUtils.isEmpty(code) && "00".equals(code)){
			List<GetORCAEnvInfo> listItem = bas0102Repository.getORCAEnvInfo(hospCode, language);
			if(!CollectionUtils.isEmpty(listItem)){
				for (GetORCAEnvInfo getORCAEnvInfo : listItem) {
					SystemModelProto.GetORCAEnvInfo.Builder info = SystemModelProto.GetORCAEnvInfo.newBuilder();
					BeanUtils.copyProperties(getORCAEnvInfo, info, language);
					response.setOrcaInfo(info);
				}
			}
		} else {
			response.setIsUsingOrca(false);
			return response.build();
		}
		response.setIsUsingOrca(true);
		return response.build();
	}
	
}

