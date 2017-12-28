package nta.med.service.ihis.handler.drug;

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

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.UserGroup;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.model.ihis.drug.DRG0120U00Grd0120Item2Info;
import nta.med.service.ihis.proto.DrugModelProto;
import nta.med.service.ihis.proto.DrugServiceProto;
import nta.med.service.ihis.proto.DrugServiceProto.DRG0120U00GrdNaebogResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class DRG0120U00GrdNaebogHandler extends ScreenHandler<DrugServiceProto.DRG0120U00GrdNaebogRequest, DrugServiceProto.DRG0120U00GrdNaebogResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(DRG0120U00GrdNaebogHandler.class);                                    
	@Resource                                                                                                       
	private Drg0120Repository drg0120Repository; 
	@Resource
    private Bas0001Repository bas0001Repository;

	@Override
    @Transactional
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, DrugServiceProto.DRG0120U00GrdNaebogRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }

	@Override
	@Transactional(readOnly = true)
	public DrugServiceProto.DRG0120U00GrdNaebogResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRG0120U00GrdNaebogRequest request) throws Exception {
		DrugServiceProto.DRG0120U00GrdNaebogResponse.Builder response = DrugServiceProto.DRG0120U00GrdNaebogResponse.newBuilder();
		List<DRG0120U00Grd0120Item2Info> listGrdNaebog = drg0120Repository.getDRG0120U00Grd0120Item2Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
        if(!CollectionUtils.isEmpty(listGrdNaebog)) {
        	for(DRG0120U00Grd0120Item2Info item : listGrdNaebog) {
        		DrugModelProto.DRG0120U00Grd0120Item2Info.Builder itemGrdNaebog = DrugModelProto.DRG0120U00Grd0120Item2Info.newBuilder();
        		BeanUtils.copyProperties(item, itemGrdNaebog, getLanguage(vertx, sessionId));
        		response.addGrdNaebogList(itemGrdNaebog);
        	}
        }
		return response.build();
	} 
	
	@Override
	public DRG0120U00GrdNaebogResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrugServiceProto.DRG0120U00GrdNaebogRequest request, DRG0120U00GrdNaebogResponse response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
		
		return response;
	}
}