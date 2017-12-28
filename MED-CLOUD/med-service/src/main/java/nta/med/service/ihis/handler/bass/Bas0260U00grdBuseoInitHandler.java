package nta.med.service.ihis.handler.bass;

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
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.bass.BAS0260GrdBuseoListItemInfo;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.Bas0260U00grdBuseoInitRequest;
import nta.med.service.ihis.proto.BassServiceProto.Bas0260U00grdBuseoInitResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class Bas0260U00grdBuseoInitHandler extends ScreenHandler<BassServiceProto.Bas0260U00grdBuseoInitRequest, BassServiceProto.Bas0260U00grdBuseoInitResponse> {                             
	
	private static final Log LOGGER = LogFactory.getLog(Bas0260U00grdBuseoInitHandler.class);                                        
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository; 
	
	@Override
	@Transactional(readOnly = true)
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BassServiceProto.Bas0260U00grdBuseoInitRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override        
	@Transactional(readOnly = true)
	public Bas0260U00grdBuseoInitResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
		Bas0260U00grdBuseoInitRequest request) throws Exception {
		BassServiceProto.Bas0260U00grdBuseoInitResponse.Builder response=BassServiceProto.Bas0260U00grdBuseoInitResponse.newBuilder();
		List<BAS0260GrdBuseoListItemInfo> listResult = bas0260Repository.getBas0260U00grdBuseoInitListItem(request.getHospCode(), request.getStartDate(),getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(BAS0260GrdBuseoListItemInfo item : listResult){
				BassModelProto.BAS0260GrdBuseoListItemInfo.Builder info = BassModelProto.BAS0260GrdBuseoListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdInit(info);
			}
		}
		return response.build();
	}
	
	@Override
	public Bas0260U00grdBuseoInitResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			Bas0260U00grdBuseoInitRequest request, Bas0260U00grdBuseoInitResponse response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
		
		return response;
	}
}
