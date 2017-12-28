package nta.med.service.ihis.handler.pfes;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.pfe.Pfe0102;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.pfe.Pfe0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PfesModelProto.PFE0101U00SaveLayoutInfo;
import nta.med.service.ihis.proto.PfesServiceProto;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class PFE0101U00SaveLayoutHandler
	extends ScreenHandler<PfesServiceProto.PFE0101U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Pfe0102Repository pfe0102Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PFE0101U00SaveLayoutRequest request) throws Exception {                                                                  
      	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();    
      	   	String hospCode = getHospitalCode(vertx, sessionId);
      	   	String language = getLanguage(vertx, sessionId);
			Integer result = null;
			for(PFE0101U00SaveLayoutInfo info : request.getSaveLayoutItemList()){
		    	if(DataRowState.ADDED.getValue().equals(info.getRowState())) {
		    		insertPfe0102(info,request.getUserId(), hospCode, language);
		    		result = 1;
		    	} else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
		    		result=pfe0102Repository.getUpdatePFE0101U00SaveLayout(hospCode,request.getUserId(), new Date(),
		    			info.getCodeName(),info.getCodeNameRe(),info.getCodeValue(),info.getCodeType(),info.getCode(), language);
		    	} else if(DataRowState.DELETED.getValue().equals(info.getRowState())) {
		    		result=pfe0102Repository.getDeletePFE0101U00SaveLayout(hospCode,info.getCodeType(),info.getCode(), language);
		    	}
			}
			response.setResult(result != null && result > 0);
			return response.build();
	}
	public void insertPfe0102(PFE0101U00SaveLayoutInfo info,String userId, String hospCode, String language){
		Pfe0102 pfe0102 = new Pfe0102();
		pfe0102.setSysDate(new Date());
		pfe0102.setSysId(userId);
		pfe0102.setUpdDate(new Date());
		pfe0102.setUpdId(userId);
		pfe0102.setHospCode(hospCode);
		pfe0102.setCodeType(info.getCodeType());
		pfe0102.setCode(info.getCode());
		pfe0102.setCodeName(info.getCodeName());
		pfe0102.setCodeNameRe(info.getCodeNameRe());
		pfe0102.setCodeValue(info.getCodeValue());
		pfe0102.setLanguage(language);
		pfe0102Repository.save(pfe0102);
	}
}