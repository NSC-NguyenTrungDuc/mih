package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.cpl.Cpl0109;
import nta.med.core.domain.ocs.Ocs0116;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.ModifyFlg;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.dao.medi.ocs.Ocs0116Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto.CPL0108U00InitGrdDetailListItemInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL0108U00SaveLayoutHandler extends ScreenHandler<CplsServiceProto.CPL0108U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Cpl0109Repository cpl0109Repository;                                                                    
	@Resource                                                                                                       
	private Ocs0116Repository ocs0116Repository;  
	
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL0108U00SaveLayoutRequest request) throws Exception {                                                                   
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		if(CollectionUtils.isEmpty(request.getInputListList())){
			response.setResult(false);
		}else{
			String hospCode = getHospitalCode(vertx, sessionId);
			String language = getLanguage(vertx, sessionId);
			boolean result0109 = false;
			for(CPL0108U00InitGrdDetailListItemInfo item : request.getInputListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					if(item.getCodeType().equalsIgnoreCase("04")){
						if(insertCpl0109(item, request.getUserId(), hospCode, language) && ocs0116Transaction(item, request.getUserId(), hospCode)){
							result0109 = true;
						}
					}else{
						result0109 = insertCpl0109(item, request.getUserId(), hospCode, language);
					}
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(item.getCodeType().equalsIgnoreCase("04")){
						if(updateCpl0109(item, request.getUserId(), hospCode, language) && ocs0116Transaction(item, request.getUserId(), hospCode)){
							result0109 = true;
						}
					}else{
						result0109 = updateCpl0109(item, request.getUserId(), hospCode, language);
					}
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(cpl0109Repository.deleteCPL010108U00Cpl0109(item.getCodeType(), hospCode,item.getCode(), language) >0){
						result0109 = true;
					}
				}
				if(!result0109){
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}
			response.setResult(result0109);
		}
		return response.build();		
	}
	public boolean insertCpl0109(CPL0108U00InitGrdDetailListItemInfo item, String userId, String hospCode, String language){
		Cpl0109 cpl0109 = new Cpl0109();
		cpl0109.setSysDate(new Date());
		cpl0109.setSysId(userId);
		cpl0109.setUpdDate(new Date());
		cpl0109.setUpdId(userId);
		cpl0109.setCodeType(item.getCodeType());
		cpl0109.setCode(item.getCode());
		cpl0109.setCodeName(item.getCodeName());
		cpl0109.setCodeNameRe(item.getCodeNameRe());
		cpl0109.setSystemGubun("CPL");
		cpl0109.setHospCode(hospCode);
		cpl0109.setCodeValue(item.getCodeValue());
		cpl0109.setLanguage(language);
		cpl0109.setModifyFlg(ModifyFlg.INSERT.getValue());
		
		cpl0109Repository.save(cpl0109);
		return true;
	}
	
	public boolean ocs0116Transaction(CPL0108U00InitGrdDetailListItemInfo item, String userId, String hospCode){
		boolean result = false;
		result = insertCpl0116(item, userId, hospCode);
		String dupYn = ocs0116Repository.getCpl0108U00DupYn(hospCode, item.getCode(), "CPL");
		if(!StringUtils.isEmpty(dupYn)){
			if(ocs0116Repository.UpdateCpl0108U00Ocs0116(userId, item.getCodeName(), hospCode, item.getCode(), "CPL")>0){
				result = true;
			}
		}
		return result;
	}
	
	public boolean insertCpl0116(CPL0108U00InitGrdDetailListItemInfo item, String userId, String hospCode){
		Ocs0116 ocs0116 =  new Ocs0116();
		ocs0116.setSysDate(new Date());
		ocs0116.setSysId(userId);
		ocs0116.setUpdDate(new Date());
		ocs0116.setUpdId(userId);
		ocs0116.setHospCode(hospCode);
		ocs0116.setSpecimenGubun("CPL");
		ocs0116.setSpecimenCode(item.getCode());
		ocs0116.setSpecimenName(item.getCodeName());
		//ocs0116.setModifyFlg(ModifyFlg.INSERT.getValue());
		
		ocs0116Repository.save(ocs0116);
		return true;
	}
	
	public boolean updateCpl0109(CPL0108U00InitGrdDetailListItemInfo item, String userId, String hospCode, String language){
		boolean save = false;
		if(cpl0109Repository.updateCPL010108U00Cpl0109(userId, item.getCodeName(), item.getCodeNameRe(),
				item.getCodeValue(), ModifyFlg.UPDATE.getValue(), item.getCodeType(),item.getCode(),hospCode, language) >0){
			save = true;
		}
		return save;
	}
}