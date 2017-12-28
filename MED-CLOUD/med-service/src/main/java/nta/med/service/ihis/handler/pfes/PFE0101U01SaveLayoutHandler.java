package nta.med.service.ihis.handler.pfes;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.pfe.Pfe0101;
import nta.med.core.domain.pfe.Pfe0102;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.pfe.Pfe0101Repository;
import nta.med.data.dao.medi.pfe.Pfe0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PfesModelProto.PFE0101U01GrdDCodeInfo;
import nta.med.service.ihis.proto.PfesModelProto.PFE0101U01GrdMCodeInfo;
import nta.med.service.ihis.proto.PfesServiceProto;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class PFE0101U01SaveLayoutHandler
	extends ScreenHandler<PfesServiceProto.PFE0101U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Pfe0101Repository pfe0101Repository;
	@Resource
	private Pfe0102Repository pfe0102Repository;
	                                                                                                                
	@Override     
	@Route(global = true)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PFE0101U01SaveLayoutRequest request) throws Exception {                                                                 
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();            
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		Integer result = 0;
		//callerId = 1
		for(PFE0101U01GrdMCodeInfo  info : request.getGrdMcodeItemList()){
			if(DataRowState.ADDED.getValue().equals(info.getRowState())){
				insertPfe0101(info, request.getUserId(), hospCode, language);
				result = 1;
			}else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())){
				result = pfe0101Repository.getUpdatePFE0101U01SaveLayout(request.getUserId(), new Date(), info.getCodeTypeName(), info.getAdminGubun(),info.getCodeType(), language);
			}else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
				result = pfe0101Repository.getDeletePFE0101U01SaveLayout(info.getCodeType(), language);
			}
		}  
		if(result>0){
  			response.setResult(true);
  		}else{
  			response.setResult(false);
  		}
		return response.build();
	}
	private void insertPfe0101(PFE0101U01GrdMCodeInfo info, String userId, String hospCode, String language){
		Pfe0101 pfes0101 = new Pfe0101();
		pfes0101.setSysDate(new Date());
		pfes0101.setSysId(userId);
		pfes0101.setUpdDate(new Date());
		pfes0101.setUpdId(userId);
		//pfes0101.setHospCode(hospCode);
		pfes0101.setCodeType(StringUtils.isEmpty(info.getCodeType()) ? null : info.getCodeType());
		pfes0101.setCodeTypeName(info.getCodeTypeName());
		pfes0101.setAdminGubun(info.getAdminGubun());
		pfes0101.setLanguage(language);
		pfe0101Repository.save(pfes0101);
	}
	private void insertPfe0102(PFE0101U01GrdDCodeInfo info, String userId, String hospCode, String language){
		Pfe0102 pfe0102 = new Pfe0102();
		pfe0102.setSysDate(new Date());
		pfe0102.setSysId(userId);
		pfe0102.setUpdDate(new Date());
		pfe0102.setUpdId(userId);
		pfe0102.setHospCode(hospCode);
		pfe0102.setCodeType(StringUtils.isEmpty(info.getCodeType()) ? null : info.getCodeType());
		pfe0102.setCode(StringUtils.isEmpty(info.getCode()) ? null : info.getCode()); 
		pfe0102.setCodeName(StringUtils.isEmpty(info.getCodeName()) ? null : info.getCodeName()); 
		pfe0102.setCodeNameRe(info.getCodeNameRe());
		pfe0102.setCodeValue(info.getCodeValue());
		pfe0102.setLanguage(language);
		pfe0102Repository.save(pfe0102);
	}
	
	
	@Override
    @Route(global = false)
    public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		PFE0101U01SaveLayoutRequest request, UpdateResponse rs) throws Exception {
    	SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
    	Integer result = 0;
    	String hospCode = getHospitalCode(vertx, sessionId);
    	String language = getLanguage(vertx, sessionId);
    	//callerId = 1
    	for(PFE0101U01GrdMCodeInfo  info : request.getGrdMcodeItemList()){
			if(DataRowState.DELETED.getValue().equals(info.getRowState())){
				result = pfe0102Repository.getDeletePFE0101U01SaveLayout(hospCode, info.getCodeType(), getLanguage(vertx, sessionId));
			}
		}  
    	//callerId = 2
		for(PFE0101U01GrdDCodeInfo  info : request.getGrdDcodeItemList()){
			if(DataRowState.ADDED.getValue().equals(info.getRowState())){
				insertPfe0102(info, request.getUserId(), hospCode, language);
				result = 1;
			}else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())){
				result = pfe0102Repository.getUpdatePFE0101U00SaveLayout(hospCode, request.getUserId(), new Date(),
					 info.getCodeName(), info.getCodeNameRe(), info.getCodeValue(), info.getCodeType(), info.getCode(), language);
			}else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
				result = pfe0102Repository.getDeletePFE0101U00SaveLayout(hospCode, info.getCodeType(), info.getCode(), language);
			}
		}            
  		if(result>0){
  			response.setResult(true);
  		}else{
  			response.setResult(false);
  		}	
    	return response.build();
    }
}