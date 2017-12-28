package nta.med.service.ihis.handler.ocsa;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.ocs.Ocs0133;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.ocs.Ocs0133Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0133U00ExecuteItemInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0133U00ExecuteRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class OCS0133U00ExecuteHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0133U00ExecuteRequest, SystemServiceProto.UpdateResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0133U00ExecuteHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0133Repository ocs0133Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0133U00ExecuteRequest request)
			throws Exception {                                                                
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();     
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		Integer result = null;
		for(OCS0133U00ExecuteItemInfo item : request.getItemInfoList()){	
	    	if(DataRowState.ADDED.getValue().equals(item.getRowState())){
	    		insertOCS0133U00Execute(item, hospCode, language);
	    		result=1;	
	    	} else if(DataRowState.MODIFIED.getValue().equals(item.getRowState())) {
	    		List<Ocs0133> listOcs0133 =ocs0133Repository.getListOcs0133CaseUpdateOCS0133U00Execute(hospCode,item.getInputControl(), language);
	    		if(!CollectionUtils.isEmpty(listOcs0133)) {
	    		for(Ocs0133 ocsa0133 : listOcs0133) {
	    			ocsa0133.setUpdId(item.getUserId());
	    			ocsa0133.setUpdDate(new Date());
	    			ocsa0133.setInputControlName(item.getInputControlName());
	    			ocsa0133.setSpecimenCrYn(item.getSpecimenCrYn() != null ? item.getSpecimenCrYn() : "N");
	    			ocsa0133.setSuryangCrYn(item.getSuryangCrYn() != null ? item.getSuryangCrYn() : "N");
	    			ocsa0133.setOrdDanuiCrYn(item.getOrdDanuiCrYn() != null ? item.getOrdDanuiCrYn() :  "N");
	    			ocsa0133.setDvCrYn(item.getDvCrYn() != null ? item.getDvCrYn() : "N");
	    			ocsa0133.setNalsuCrYn(item.getNalsuCrYn() !=null ? item.getNalsuCrYn() : "N");
	    			ocsa0133.setJusaCrYn(item.getJusaCrYn() != null ? item.getJusaCrYn() : "N");
	    			ocsa0133.setBogyongCodeCrYn(item.getBogyongCodeCrYn() != null ? item.getBogyongCodeCrYn() : "N");
	    			ocsa0133.setToiwonDrgCrYn(item.getToiwonDrgCrYn() != null ? item.getToiwonDrgCrYn() : "N");
	    			ocsa0133.setPortableCrYn(item.getPortableCrYn() != null ? item.getPortableCrYn() : "N");
	    			ocsa0133.setAmtCrYn(item.getAmtCrYn() != null ? item.getAmtCrYn() : "N");
	    			ocsa0133.setWonyoiOrderYnCrYn(item.getWonyoiOrderCrYn() != null ? item.getWonyoiOrderCrYn() : "N");
	    			ocsa0133.setPowderYnCrYn(item.getPowderCrYn() != null ? item.getPowderCrYn() : "N");
	    			}
	    		ocs0133Repository.save(listOcs0133);
	    		result =  listOcs0133.size();
	    		}
	    	} else if(DataRowState.DELETED.getValue().equals(item.getRowState())) {
	    		result = ocs0133Repository.deleteOCS0133U00Execute(hospCode,item.getInputControl(), language);
	    	}
		}
		response.setResult(result != null && result > 0);
		return response.build();
	}
	
	public void insertOCS0133U00Execute(OCS0133U00ExecuteItemInfo item, String hospCode, String language){	
		Ocs0133 ocsa0133 = new Ocs0133();
		ocsa0133.setSysDate(new Date());
		ocsa0133.setSysId(item.getUserId());
		ocsa0133.setInputControl(item.getInputControl());
		ocsa0133.setInputControlName(item.getInputControlName());
		ocsa0133.setSpecimenCrYn(item.getSpecimenCrYn() != null ? item.getSpecimenCrYn() : "N");
		ocsa0133.setSuryangCrYn(item.getSuryangCrYn() != null ? item.getSuryangCrYn() : "N");
		ocsa0133.setOrdDanuiCrYn(item.getOrdDanuiCrYn() != null ? item.getOrdDanuiCrYn() :  "N");
		ocsa0133.setDvCrYn(item.getDvCrYn() != null ? item.getDvCrYn() : "N");
		ocsa0133.setNalsuCrYn(item.getNalsuCrYn() != null ? item.getNalsuCrYn() : "N");
		ocsa0133.setJusaCrYn(item.getJusaCrYn() != null ? item.getJusaCrYn() : "N");
		ocsa0133.setBogyongCodeCrYn(item.getBogyongCodeCrYn() != null ? item.getBogyongCodeCrYn() : "N");
		ocsa0133.setToiwonDrgCrYn(item.getToiwonDrgCrYn() != null ? item.getToiwonDrgCrYn() : "N");
		ocsa0133.setPortableCrYn(item.getPortableCrYn() != null ? item.getPortableCrYn() : "N");
		ocsa0133.setAmtCrYn(item.getAmtCrYn() != null ? item.getAmtCrYn() : "N");
		ocsa0133.setWonyoiOrderYnCrYn(item.getWonyoiOrderCrYn() != null ? item.getWonyoiOrderCrYn() : "N");
		ocsa0133.setPowderYnCrYn(item.getPowderCrYn() != null ? item.getPowderCrYn() : "N");
		ocsa0133.setHospCode(hospCode);
		ocsa0133.setLanguage(language);
		ocs0133Repository.save(ocsa0133);		
	}

}