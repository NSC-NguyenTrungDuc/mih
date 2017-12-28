package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.service.ihis.proto.BassServiceProto;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.logging.log4j.util.Strings;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.dao.medi.out.Out0105Repository;
import nta.med.data.model.ihis.system.PatientByCodeInfo;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetPatientByCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetPatientByCodeResponse;

@Service
@Scope("prototype")
public class GetPatientByCodeHandler
	extends ScreenHandler<SystemServiceProto.GetPatientByCodeRequest, SystemServiceProto.GetPatientByCodeResponse>{
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private Out0102Repository out0102Repository;
	
	@Resource
	private Out0105Repository out0105Repository;
	@Resource
	private Bas0001Repository bas0001Repository;
	private static final Log LOGGER = LogFactory.getLog(GetPatientByCodeHandler.class);

	@Override
	@Transactional(readOnly = true)
	@Route(global = true)
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
						  SystemServiceProto.GetPatientByCodeRequest request) throws Exception {
		if(!Strings.isEmpty(request.getHospCode()))
		{
			List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
			if (!CollectionUtils.isEmpty(bas0001List)) {
				Bas0001 bas0001 = bas0001List.get(0);
				setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(),
						bas0001.getLanguage(), "", 1, ""));
			} else {
				LOGGER.info("kcck GetPatientByCodeRequest preHandle not found hosp code");
			}
		}

	}

	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public GetPatientByCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetPatientByCodeRequest request)throws Exception {
		
		String hospCode = request.getHospCode();
		if (StringUtils.isEmpty(hospCode)){
			hospCode = getHospitalCode(vertx, sessionId);
		}
		
        List<PatientByCodeInfo> listPatientByCodeInfo = out0101Repository.getGetPatientByCode(hospCode, request.getPatientCode(), getLanguage(vertx, sessionId));
        SystemServiceProto.GetPatientByCodeResponse.Builder response = SystemServiceProto.GetPatientByCodeResponse.newBuilder();
        if (listPatientByCodeInfo != null && !listPatientByCodeInfo.isEmpty()) {
            for (PatientByCodeInfo obj : listPatientByCodeInfo) {
            	SystemModelProto.PatientInfo.Builder builder = SystemModelProto.PatientInfo.newBuilder();
                BeanUtils.copyProperties(obj, builder, getLanguage(vertx, sessionId));
                response.addPatientInfo(builder);
            }
        }
        
        return response.build();
	}
}
