package nta.med.service.ihis.handler.ocsa;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs0212;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0212Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0203U00GrdOcs0203P1Info;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class OCS0203U00SaveLayoutHandler extends ScreenHandler<OcsaServiceProto.OCS0203U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0203U00SaveLayoutHandler.class);        
	
	@Resource                                                                                                       
	private Ocs0212Repository ocs0212Repository;   
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0203U00SaveLayoutRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0203U00SaveLayoutRequest request) throws Exception {
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		response = saveLayout(request);
		if(!response.getResult()){
			throw new ExecutionException(response.build());
		}
		return response.build();
	}
	
	public SystemServiceProto.UpdateResponse.Builder saveLayout(OcsaServiceProto.OCS0203U00SaveLayoutRequest request){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<OCS0203U00GrdOcs0203P1Info> listGrd = request.getInfoListList();
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0203U00GrdOcs0203P1Info item : listGrd){
				String retVal = ocs0212Repository.getRetValOCS0203U00SaveLayout(item.getMemb(), item.getHangmogCode(), request.getHospCode());
				if(!StringUtils.isEmpty(retVal)){
					ocs0212Repository.updateOCS0203U00SaveLayout(request.getUserId(), new Date(), CommonUtils.parseDouble(item.getSeq()), item.getOftenUsed(), item.getMemb(), item.getHangmogCode(), request.getHospCode());
				} else {
					Ocs0212 ocs0212 = new Ocs0212();
					ocs0212.setSysDate(new Date());
					ocs0212.setSysId(request.getUserId());
					ocs0212.setUpdDate(new Date());
					ocs0212.setUpdId(request.getUserId());
					ocs0212.setMembGubun("1");
					ocs0212.setMemb(item.getMemb());
					ocs0212.setHangmogCode(item.getHangmogCode());
					ocs0212.setSeq(CommonUtils.parseDouble(item.getSeq()));
					ocs0212.setOftenUse(item.getOftenUsed());
					ocs0212.setHospCode(request.getHospCode());
					ocs0212Repository.save(ocs0212);
				}
			}
		}
		
		response.setResult(true);
		return response;
	}
}
