package nta.med.service.ihis.handler.ocsa;

import java.math.BigDecimal;
import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs0221;
import nta.med.core.domain.ocs.Ocs0222;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs0221Repository;
import nta.med.data.dao.medi.ocs.Ocs0222Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OcsaOCS0221U00GrdOCS0221ListInfo;
import nta.med.service.ihis.proto.OcsaModelProto.OcsaOCS0221U00GrdOCS0222ListInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0221U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class OcsaOCS0221U00SaveLayoutHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0221U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {      
	
	@Resource
	private Ocs0221Repository ocs0221Repository;
	@Resource
	private CommonRepository commonRepository;
	@Resource
	private Ocs0222Repository ocs0222Repository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaOCS0221U00SaveLayoutRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsaOCS0221U00SaveLayoutRequest request) throws Exception {                                                                  
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer result = null; 
		String hospCode = request.getHospCode();
		//exOcs0221
		for(OcsaOCS0221U00GrdOCS0221ListInfo infoOcs0221 :request.getOcs0221SaveItemList()){
			if(DataRowState.ADDED.getValue().equals(infoOcs0221.getDataRowState())) {
				//Double seq = CommonUtils.parseDouble(commonRepository.getNextVal("OCS0221_SEQ"));
				insertOcs0221(infoOcs0221, request.getUserId(), hospCode);
	    		result = 1;
	    	} else if(DataRowState.MODIFIED.getValue().equals(infoOcs0221.getDataRowState())) {
	    		result =ocs0221Repository.updateOcsaOCS0221U00UpdateOCS0221(request.getUserId(), new Date(), infoOcs0221.getCategoryName(), infoOcs0221.getMemb(),
	    				CommonUtils.parseDouble(infoOcs0221.getFSeq()), hospCode);
	    		if(result <= 0){
					insertOcs0221(infoOcs0221, request.getUserId(), hospCode);
					result= 1;
	    		}
	    	} else if(DataRowState.DELETED.getValue().equals(infoOcs0221.getDataRowState())) {
	    	 result=ocs0221Repository.deleteOcsaOCS0221U00DeleteOCS0221(infoOcs0221.getMemb(), CommonUtils.parseDouble(infoOcs0221.getFSeq()), hospCode);
	    	}
		}
		//exOcs0222
		for(OcsaOCS0221U00GrdOCS0222ListInfo  infoOcs0222 :request.getOcs0222SaveItemList()){
			if(DataRowState.ADDED.getValue().equals(infoOcs0222.getDataRowState())) {
	    		insertOcs0222(infoOcs0222, request.getUserId(), hospCode);
	    		result= 1;
	    	} else if(DataRowState.MODIFIED.getValue().equals(infoOcs0222.getDataRowState())) {
	    		Double seq = CommonUtils.parseDouble(infoOcs0222.getSeq());
				Double serial = CommonUtils.parseDouble(infoOcs0222.getSerial());
	    		result=ocs0222Repository.updateOcsaOCS0221U00UpdateOCS0222(request.getUserId(), new Date(), infoOcs0222.getCommentTitle(),
	    				infoOcs0222.getCommentText(), infoOcs0222.getMemb(), seq, serial, hospCode);
	    	} else if(DataRowState.DELETED.getValue().equals(infoOcs0222.getDataRowState())) {
	    		Double seq = CommonUtils.parseDouble(infoOcs0222.getSeq());
				Double serial = CommonUtils.parseDouble(infoOcs0222.getSerial());
				result=ocs0222Repository.deleteOcsaOCS0221U00DeleteOCS0222(infoOcs0222.getMemb(), seq, serial, hospCode);
	    	}
		}
		response.setResult(result != null && result > 0);
		return response.build();
	}                                                                                                                                                   
	public void insertOcs0221(OcsaOCS0221U00GrdOCS0221ListInfo infoOcs0221, String userId, String hospCode){
		Ocs0221 ocs0221 = new Ocs0221();
		ocs0221.setSysDate(new Date());
		ocs0221.setSysId(userId);
		ocs0221.setUpdId(userId);
		ocs0221.setMemb(infoOcs0221.getMemb());
		ocs0221.setMembGubun("1");
		ocs0221.setSeq(CommonUtils.parseDouble(infoOcs0221.getFSeq()));
		ocs0221.setCategoryGubun(infoOcs0221.getCategoryGubun());
		ocs0221.setCategoryName(infoOcs0221.getCategoryName());
		ocs0221.setCommentLimit(new BigDecimal(0));
		ocs0221.setHospCode(hospCode);
		ocs0221.setUpdDate(new Date());
		
		ocs0221Repository.save(ocs0221);
	}
	public void insertOcs0222(OcsaOCS0221U00GrdOCS0222ListInfo infoOcs0222, String userId, String hospCode){
		Ocs0222 ocs0222 = new Ocs0222();
		ocs0222.setSysDate(new Date());
		ocs0222.setUpdDate(new Date());
		ocs0222.setSysId(userId);
		ocs0222.setUpdId(userId);
		ocs0222.setMemb(infoOcs0222.getMemb());
		ocs0222.setMembGubun("1");
		if(!StringUtils.isEmpty(infoOcs0222.getSeq())){
			ocs0222.setSeq(CommonUtils.parseDouble(infoOcs0222.getSeq()));
		}
		Double maxSerial = ocs0222Repository.getMaxSerialOcsaOCS0221U00InsertIntoOCS0222(infoOcs0222.getMemb(), CommonUtils.parseDouble(infoOcs0222.getSeq()), hospCode);
		if(maxSerial != null){
			ocs0222.setSerial(maxSerial);
		}
		ocs0222.setCommentTitle(infoOcs0222.getCommentTitle());
		ocs0222.setCommentText(infoOcs0222.getCommentText());
		ocs0222.setHospCode(hospCode);
		ocs0222Repository.save(ocs0222);
	}
}