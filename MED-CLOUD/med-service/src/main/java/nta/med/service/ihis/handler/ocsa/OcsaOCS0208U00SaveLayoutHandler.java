package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs0208;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs0208Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OcsaOCS0208U00GrdOCS0208U00ListInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0208U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class OcsaOCS0208U00SaveLayoutHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0208U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	 
	@Resource
	private Ocs0208Repository ocs0208Repository;                                                                   
	 
	@Resource
	private CommonRepository commonRepository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaOCS0208U00SaveLayoutRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsaOCS0208U00SaveLayoutRequest request) throws Exception {                                                                 
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();     
		Integer result = null;
		String hospCode = request.getHospCode();
		for(OcsaOCS0208U00GrdOCS0208U00ListInfo info : request.getGrdSaveItemList()){
	    	if(DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
	    		//check seq name ???
	    		insertOcs0208(info,CommonUtils.parseDouble(info.getSeq()), request.getUserId(), hospCode);
	    		result = 1;
	    	} else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
	    		result=ocs0208Repository.updateOcsaOCS0208U00UpdateOCS0208(CommonUtils.parseDouble(info.getSeq()), hospCode, info.getBogyongCode());
	    	} else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
	    		result=ocs0208Repository.deleteOcsaOCS0208U00DeleteOCS0208(info.getDoctor(), hospCode, info.getBogyongCode());
	    	}
		}
		response.setResult(result != null && result > 0);
		return response.build();
	}  
	
	public void insertOcs0208(OcsaOCS0208U00GrdOCS0208U00ListInfo info,Double seq,String userId, String hospCode){
		Ocs0208 ocs0208 = new Ocs0208();
		ocs0208.setSysDate(new Date());
		ocs0208.setSysId(userId);
		ocs0208.setDoctor(info.getDoctor());
		ocs0208.setUserId(userId);
		ocs0208.setSeq(seq);
		ocs0208.setBogyongCode(info.getBogyongCode());
		ocs0208.setHospCode(hospCode);
		ocs0208Repository.save(ocs0208);
	}
}