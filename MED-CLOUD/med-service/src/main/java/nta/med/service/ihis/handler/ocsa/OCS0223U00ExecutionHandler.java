package nta.med.service.ihis.handler.ocsa;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs0223;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs0223Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0223U00ExecutionRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class OCS0223U00ExecutionHandler	extends ScreenHandler<OcsaServiceProto.OCS0223U00ExecutionRequest, SystemServiceProto.UpdateResponse> {                     
	
	@Resource                                                                                                       
	private Ocs0223Repository ocs0223Repository;                                                                    
	
	@Resource                                                                                                       
	private CommonRepository commonRepository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0223U00ExecutionRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0223U00ExecutionRequest request)
			throws Exception {                                                                  
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		List<OcsaModelProto.OCS0223U00GrdOCS0223Info> listItem = request.getInfoList();
		String userId = request.getUserId();
		if (!CollectionUtils.isEmpty(listItem)) {
			List<Ocs0223> listInsert = new ArrayList<Ocs0223>();
			for (OcsaModelProto.OCS0223U00GrdOCS0223Info item : listItem) {
				if(DataRowState.ADDED.getValue().equalsIgnoreCase(item.getRowState())) {
					listInsert.add(setOcs0223(item, userId, request.getHospCode()));
				} else if(DataRowState.MODIFIED.getValue().equalsIgnoreCase(item.getRowState())) {
					ocs0223Repository.updateOcs0223(new Date(), userId, CommonUtils.parseDouble(item.getSerial()), item.getCommentTitle(), item.getCommentText(), item.getJundalPart(), CommonUtils.parseDouble(item.getSeq()));
				} else if(DataRowState.DELETED.getValue().equalsIgnoreCase(item.getRowState())) {
					ocs0223Repository.deleteOcs0223(item.getJundalPart(), CommonUtils.parseDouble(item.getSeq()));
				}
			}
			ocs0223Repository.save(listInsert);
		}
		response.setResult(true);
		return response.build();
	} 
	
	private Ocs0223 setOcs0223(OcsaModelProto.OCS0223U00GrdOCS0223Info item, String userId, String hospCode) {
		Ocs0223 ocs0223 = new Ocs0223();
		ocs0223.setSysDate(new Date());
		ocs0223.setSysId(userId);
		ocs0223.setUpdDate(new Date());
		ocs0223.setUpdId(userId);
		ocs0223.setHospCode(hospCode);
		ocs0223.setJundalPart(item.getJundalPartName());
		ocs0223.setSeq(CommonUtils.parseDouble(commonRepository.getNextVal("OCS0223_SEQ")));
		ocs0223.setSerial(CommonUtils.parseDouble(item.getSerial()));
		ocs0223.setCommentText(item.getCommentText());
		ocs0223.setCommentTitle(item.getCommentTitle());
		return ocs0223;
	}
}