package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.system.PatientAccountInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.VerifyPatientAccountRequest;
import nta.med.service.ihis.proto.SystemServiceProto.VerifyPatientAccountResponse;

@Service                                                                                                          
@Scope("prototype")
public class VerifyPatientAccountHandler extends ScreenHandler<SystemServiceProto.VerifyPatientAccountRequest, SystemServiceProto.VerifyPatientAccountResponse>{

	private static final Log LOGGER = LogFactory.getLog(VerifyPatientAccountHandler.class);
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
    @Transactional
    @Route(global = true)
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, VerifyPatientAccountRequest request) throws Exception {
        List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
        if(!CollectionUtils.isEmpty(bas0001List)){
            Bas0001 bas0001 = bas0001List.get(0);
            setSessionInfo(vertx, sessionId,
                    SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(), bas0001.getLanguage(), "", 1, ""));
        }
        else{
            LOGGER.info("VerifyPatientAccountHandler preHandle not found hosp code");
        }
    }
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public VerifyPatientAccountResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			VerifyPatientAccountRequest request) throws Exception {
		
		SystemServiceProto.VerifyPatientAccountResponse.Builder response = SystemServiceProto.VerifyPatientAccountResponse.newBuilder();
		PatientAccountInfo accInfo = out0101Repository.verifyPatientAccount(request.getUsername(), request.getPassword(), request.getHospCode());
		
		if(accInfo != null){
			response.setHospCode(accInfo.getHospCode());
			response.setHospName(accInfo.getHospName());
			response.setPatientCode(accInfo.getPatientCode());
			response.setVerifyResult(true);
		}else{
			response.setVerifyResult(false);
		}
		
		return response.build();
	}
	
}
