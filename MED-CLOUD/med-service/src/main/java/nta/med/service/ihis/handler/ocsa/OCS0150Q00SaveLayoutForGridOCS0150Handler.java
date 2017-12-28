package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.ocs.Ocs0150;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0150Q00GridOCS0150Info;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0150Q00SaveLayoutForGridOCS0150Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class OCS0150Q00SaveLayoutForGridOCS0150Handler
	extends ScreenHandler<OcsaServiceProto.OCS0150Q00SaveLayoutForGridOCS0150Request, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0150Q00SaveLayoutForGridOCS0150Handler.class);                                    
	@Resource                                                                                                       
	private Ocs0150Repository ocs0150Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0150Q00SaveLayoutForGridOCS0150Request request) throws Exception {                                     
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		Integer result = null;
		String hospCode = getHospitalCode(vertx, sessionId);
		for(OCS0150Q00GridOCS0150Info info : request.getGridOcs0150InfoList()){
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				insertOcs0150(info,request.getUserId(), hospCode);
				result = 1;
			} else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				result = ocs0150Repository.updateOcsaOCS0150U00UpdateOCS0150New(info.getAllergyPopYn(), info.getDoOrderPopYn(), info.getDrgPrtYn(), info.getEmrPopYn(),
						info.getReserPrtYn(), info.getSpecialwritePopYn(), info.getVitalsignsPopYn(), info.getXrtPrtYn() ,info.getSentouSearchYn(), 
						info.getOrderLabelPrtYn(), info.getGeneralDispYn(), info.getSameNameCheckYn(), info.getDoctor(),
						info.getGwa(), info.getIoGubun(), hospCode, info.getCheckingDrugYn(), info.getPotionDrugOrder(), info.getDiseaseNameUnregistered(), info.getInfection());
			} else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				result = ocs0150Repository.deleteOcsaOCS0150U00DeleteOCS0150(info.getDoctor(), info.getGwa(), info.getIoGubun(),hospCode);
			}
		}
		response.setResult(result != null && result > 0);
		return response.build();
	}
	
	 public void insertOcs0150(OCS0150Q00GridOCS0150Info  info,String userId, String hospCode){
     	Ocs0150 ocs0150 = new Ocs0150();
     	ocs0150.setSysDate(new Date());
     	ocs0150.setSysId(userId);
     	ocs0150.setUpdDate(new Date());
     	ocs0150.setUpdId(userId);
     	ocs0150.setDoctor(info.getDoctor());
     	ocs0150.setGwa(info.getGwa());
     	ocs0150.setHospCode(hospCode);
     	ocs0150.setIoGubun(info.getIoGubun());
     	ocs0150.setAllergyPopYn(info.getAllergyPopYn());
     	ocs0150.setDoOrderPopYn(info.getDoOrderPopYn());
     	ocs0150.setDrgPrtYn(info.getDrgPrtYn());
     	ocs0150.setEmrPopYn(info.getEmrPopYn());
     	ocs0150.setReserPrtYn(info.getReserPrtYn());
     	ocs0150.setSpecialwritePopYn(info.getSpecialwritePopYn());
     	ocs0150.setVitalsignsPopYn(info.getVitalsignsPopYn());
     	ocs0150.setXrtPrtYn(info.getXrtPrtYn());
     	ocs0150.setSentouSearchYn(info.getSentouSearchYn());
     	ocs0150.setOrderLabelPrtYn(info.getOrderLabelPrtYn());
     	ocs0150.setGeneralDispYn(info.getGeneralDispYn());
     	ocs0150.setSameNameCheckYn(info.getSameNameCheckYn());
     	ocs0150.setCheckingDrgYn(info.getCheckingDrugYn());
     	ocs0150.setPotionDrugYn(info.getPotionDrugOrder());
     	ocs0150.setDiseaseUnregisteredYn(info.getDiseaseNameUnregistered());
     	ocs0150.setInfectionPopYn(info.getInfection());;
     	ocs0150Repository.save(ocs0150);
	 }
}