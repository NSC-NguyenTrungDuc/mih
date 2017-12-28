package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs0801;
import nta.med.core.domain.ocs.Ocs0802;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0801Repository;
import nta.med.data.dao.medi.ocs.Ocs0802Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0801U00GrdOCS0801ListItemInfo;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0801U00GrdOCS0802ListItemInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0801U00TransactionalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0801U00TransactionalHandler
	extends ScreenHandler<OcsaServiceProto.OCS0801U00TransactionalRequest, SystemServiceProto.UpdateResponse> {                     
	
	@Resource                                                                                                       
	private Ocs0801Repository ocs0801Repository;                                                                    
	
	@Resource
	private Ocs0802Repository ocs0802Repository;
	
	@Override
	@Route(global = true)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0801U00TransactionalRequest request) throws Exception {                                                                
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();      
  	   	String language = getLanguage(vertx, sessionId);
		boolean ocs0801 = false;
		
		if(CollectionUtils.isEmpty(request.getListInfo1List())){
			ocs0801 = true;
		}else{
			for(OCS0801U00GrdOCS0801ListItemInfo  inputInfo : request.getListInfo1List()){
				if(!saveListInfo1(inputInfo, request, language)){
					response.setResult(false);
					response.setMsg(inputInfo.getRowSate());
					throw new ExecutionException(response.build());
				}else{
					ocs0801 = true;
				}
			}
		}
		
		if(ocs0801){
			response.setResult(true);
		}
		
		return response.build();
	}          
	
	@Override
	@Route(global = false)
	public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0801U00TransactionalRequest request, UpdateResponse rs) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
  	   	boolean ocs0802 = false;
  	  
		if(CollectionUtils.isEmpty(request.getListInfo2List())){
			ocs0802 = true;
		}else{
			for(OCS0801U00GrdOCS0802ListItemInfo  inputInfo : request.getListInfo2List()){
				if(!saveListInfo2(inputInfo, request, hospCode, language)){
					response.setResult(false);
					response.setMsg(inputInfo.getRowSate());
					throw new ExecutionException(response.build());
				}else{
					ocs0802 = true;
				}
			}
		}
		
		if(ocs0802){
			response.setResult(true);
		}
		
		return response.build();
	}
	
	public boolean saveListInfo1(OCS0801U00GrdOCS0801ListItemInfo  inputInfo,OcsaServiceProto.OCS0801U00TransactionalRequest request, String language){
		boolean save = false;
	    if(inputInfo.getRowSate().equalsIgnoreCase(DataRowState.ADDED.getValue())){
	    	String dupChk = ocs0801Repository.getOCS0801TransactionDupCheck(inputInfo.getPatStatus(), language);
	    	if(!StringUtils.isEmpty(dupChk) && dupChk.equalsIgnoreCase("Y")){
	    		save = false;
	    	}else{
	    		save = insertOCS0801(inputInfo, request.getUserId(), language);
	    	}
	    }else if(inputInfo.getRowSate().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
	    	save = updateOCS0801(inputInfo, request.getUserId(), language);
	    }else if(inputInfo.getRowSate().equalsIgnoreCase(DataRowState.DELETED.getValue())){
	    	save = deleteOCS0801(inputInfo, language);
		}
		return save;
	}
	
	public boolean saveListInfo2(OCS0801U00GrdOCS0802ListItemInfo  inputInfo,OcsaServiceProto.OCS0801U00TransactionalRequest request, String hospCode, String language){
		boolean save = false;
		if(inputInfo.getRowSate().equalsIgnoreCase(DataRowState.ADDED.getValue())){
			String dupChk = ocs0802Repository.getOCS0801TransactionDupCheck(hospCode, hospCode, inputInfo.getPatStatus(), inputInfo.getPatStatusCode());
			if(StringUtils.isEmpty(dupChk)){
				save = insertOCS0802(inputInfo, request.getUserId(), hospCode, language);
			}
		}else if(inputInfo.getRowSate().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
			save = updateOCS0802(inputInfo, request.getUserId(), hospCode, language);
		}else if(inputInfo.getRowSate().equalsIgnoreCase(DataRowState.DELETED.getValue())){
			save = deleteOCS0802(inputInfo, hospCode, language);
		}
		return save;
	}
	
	public boolean insertOCS0801(OCS0801U00GrdOCS0801ListItemInfo inputInfo, String userId, String language){
		Ocs0801 ocs0801 = new Ocs0801();
		ocs0801.setSysDate(new Date());
		ocs0801.setSysId(userId);
		ocs0801.setUpdDate(new Date());
		ocs0801.setPatStatus(inputInfo.getPatStatus());
		ocs0801.setPatStatusName(inputInfo.getPatStatusName());
		ocs0801.setMent(inputInfo.getMent());
		ocs0801.setSeq(CommonUtils.parseDouble(inputInfo.getSeq()));
		ocs0801.setLanguage(language);
		ocs0801Repository.save(ocs0801);
		return true;
	}
	
	public boolean updateOCS0801(OCS0801U00GrdOCS0801ListItemInfo inputInfo, String userId, String language){
		if(ocs0801Repository.updateOCS0801TransactionalModified(
				userId, 
				inputInfo.getPatStatusName(), 
				inputInfo.getMent(), 
				CommonUtils.parseDouble(inputInfo.getSeq()), 
				inputInfo.getPatStatus(), 
				language) > 0){
			return true;
		}else{
			return false;
		}
	}
	public boolean deleteOCS0801(OCS0801U00GrdOCS0801ListItemInfo inputInfo, String language){
		if(ocs0801Repository.deleteOCS0801TransactionalDeleted(
				inputInfo.getPatStatus(),
				language) > 0){
			return true;
		}else{
			return false;
		}
	}
	
	public boolean insertOCS0802(OCS0801U00GrdOCS0802ListItemInfo inputInfo, String userId, String hospCode, String language){
		Ocs0802 ocs0802 = new Ocs0802();
		ocs0802.setSysDate(new Date());
		ocs0802.setSysId(userId);
		ocs0802.setUpdDate(new Date());
		ocs0802.setPatStatus(inputInfo.getPatStatus());
		ocs0802.setPatStatusCode(inputInfo.getPatStatusCode());
		ocs0802.setPatStatusCodeName(inputInfo.getPatStatusName());
		ocs0802.setMent(inputInfo.getMent());
		ocs0802.setSeq(CommonUtils.parseDouble(inputInfo.getSeq()));
		ocs0802.setHospCode(hospCode);
		ocs0802.setLanguage(language);
		ocs0802Repository.save(ocs0802);
		return true;
	}
	
	public boolean updateOCS0802(OCS0801U00GrdOCS0802ListItemInfo inputInfo, String userId, String hospCode, String language){
		if(ocs0802Repository.updateOCS0801TransactionalOcs0802Modified(
				userId, 
				inputInfo.getPatStatusName(), 
				inputInfo.getMent(), 
				CommonUtils.parseDouble(inputInfo.getSeq()), 
				inputInfo.getPatStatusCode(),
				inputInfo.getPatStatus(), 
				hospCode,
				language)>0){
		return true;
		}else{
			return false;
		}
	}
	public boolean deleteOCS0802(OCS0801U00GrdOCS0802ListItemInfo inputInfo, String hospCode, String language){
		if(ocs0802Repository.deleteOCS0801TransactionalOcs0802Deleted(
				inputInfo.getPatStatus(), 
				inputInfo.getPatStatusCode(), 
				hospCode,
				language)>0){
		return true;
		}else{
			return false;
		}
	}
}