package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.UserRole;
import nta.med.data.dao.medi.adm.AdmsGroupSystemRepository;
import nta.med.data.model.ihis.adma.ADMS2015U00GetSystemHospitalInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U00GetSystemHospitalRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U00GetSystemHospitalResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ADMS2015U00GetSystemHospitalHandler extends ScreenHandler<AdmaServiceProto.ADMS2015U00GetSystemHospitalRequest, AdmaServiceProto.ADMS2015U00GetSystemHospitalResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ADMS2015U00GetSystemHospitalHandler.class);                                    
	@Resource
	private AdmsGroupSystemRepository admsGroupSystemRepository;
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	@Override
	@Transactional(readOnly = true)
	public ADMS2015U00GetSystemHospitalResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			ADMS2015U00GetSystemHospitalRequest request) throws Exception {
  	   	AdmaServiceProto.ADMS2015U00GetSystemHospitalResponse.Builder response = AdmaServiceProto.ADMS2015U00GetSystemHospitalResponse.newBuilder();                      
  	   	List<ADMS2015U00GetSystemHospitalInfo> listSystem = admsGroupSystemRepository.getADMS2015U00GetSystemHospitalInfo(request.getHospCode(), request.getGroupId(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listSystem)) {
			for (ADMS2015U00GetSystemHospitalInfo itemSystem : listSystem) {
				AdmaModelProto.ADMS2015U00SystemHospitalInfo.Builder infoSystem = AdmaModelProto.ADMS2015U00SystemHospitalInfo.newBuilder();
				if (itemSystem.getAdmsGroupSystemId() != null) {
					infoSystem.setAdmsGroupSystemId(itemSystem.getAdmsGroupSystemId().toString());
				}
				if (!StringUtils.isEmpty(itemSystem.getSysId())) {
					infoSystem.setSystemId(itemSystem.getSysId());
				}
				if (itemSystem.getSysSeq() != null) {
					infoSystem.setSystemSeq(itemSystem.getSysSeq().toString());
				}
				if (!StringUtils.isEmpty(itemSystem.getHospCode())) {
					infoSystem.setHospCode(itemSystem.getHospCode());
				}
				infoSystem.setSelectFlg("1".equals(itemSystem.getSelectFlg()) ? "Y" : "N");
				if (!StringUtils.isEmpty(itemSystem.getSysNm())) {
					infoSystem.setSysNm(itemSystem.getSysNm());
				}

				response.addSystemInfo(infoSystem);
			}
		}
								
 		return response.build();
	}
																																					
}