package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.ocs.Ocs0204;
import nta.med.core.domain.ocs.Ocs0205;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0204Repository;
import nta.med.data.dao.medi.ocs.Ocs0205Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OcsaOCS0204U00GrdOCS0204ListInfo;
import nta.med.service.ihis.proto.OcsaModelProto.OcsaOCS0204U00GrdOCS0205ListInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class OcsaOCS0204U00SaveLayoutHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0204U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Ocs0204Repository ocs0204Repository; 
	@Resource
	private Ocs0205Repository ocs0205Repository;
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsaOCS0204U00SaveLayoutRequest request) throws Exception {                                                                  
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		Integer result = null;
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		//exOCS0204
		for(OcsaOCS0204U00GrdOCS0204ListInfo infoOcs0204 :request.getGrd0204SaveItemList()){
			if(DataRowState.ADDED.getValue().equals(infoOcs0204.getDataRowState())) {
				insertOcs0204(infoOcs0204,request.getUserId(), hospCode, language);
	    		result= 1;
	    	} else if(DataRowState.MODIFIED.getValue().equals(infoOcs0204.getDataRowState())) {
	    		Double seq = CommonUtils.parseDouble(infoOcs0204.getFSeq());
				result= ocs0204Repository.updateOcsaOCS0204U00UpdateOCS0204(request.getUserId(), new Date(), seq, infoOcs0204.getSangGubunName(),
						infoOcs0204.getMemb(), infoOcs0204.getSangGubun(), hospCode, language);
	    	} else if(DataRowState.DELETED.getValue().equals(infoOcs0204.getDataRowState())) {
	    		result=ocs0204Repository.deleteOcsaOCS0204U00DeleteOCS0204(infoOcs0204.getMemb(), infoOcs0204.getSangGubun(), hospCode, language);
	    	}
		}
		//exOCS0205
		for(OcsaOCS0204U00GrdOCS0205ListInfo  infoOcs0205 :request.getGrd0205SaveItemList()){
			if(DataRowState.ADDED.getValue().equals(infoOcs0205.getDataRowState())) {
	    		insertOcs0205(infoOcs0205,request.getUserId(), hospCode);
	    		result= 1;
	    	} else if(DataRowState.MODIFIED.getValue().equals(infoOcs0205.getDataRowState())) {
	    		Double ser = CommonUtils.parseDouble(infoOcs0205.getSer());
				Double pkSeq = CommonUtils.parseDouble(infoOcs0205.getPkSeq());
	    		result=ocs0205Repository.updateOcsaOCS0204U00UpdateOCS0205Request(request.getUserId(), new Date(), ser, infoOcs0205.getSangName(),
	    				infoOcs0205.getPreModifier1(), infoOcs0205.getPreModifier2(), infoOcs0205.getPreModifier3(), infoOcs0205.getPreModifier4(),
	    				infoOcs0205.getPreModifier5(), infoOcs0205.getPreModifier6(), infoOcs0205.getPreModifier7(), infoOcs0205.getPreModifier8(),
	    				infoOcs0205.getPreModifier9(), infoOcs0205.getPreModifier10(), infoOcs0205.getPreModifierName(), infoOcs0205.getPostModifier1(),
	    				infoOcs0205.getPostModifier2(), infoOcs0205.getPostModifier3(), infoOcs0205.getPostModifier4(), infoOcs0205.getPostModifier5(),
	    				infoOcs0205.getPostModifier6(), infoOcs0205.getPostModifier7(), infoOcs0205.getPostModifier8(), infoOcs0205.getPostModifier9(),
	    				infoOcs0205.getPostModifier10(), infoOcs0205.getPostModifierName(), infoOcs0205.getMemb(), infoOcs0205.getSangGubun(), pkSeq, hospCode);
	    	} else if(DataRowState.DELETED.getValue().equals(infoOcs0205.getDataRowState())) {
	    		Double pkSeq = CommonUtils.parseDouble(infoOcs0205.getPkSeq());
	    		result=ocs0205Repository.deleteOcsaOCS0204U00DeleteOCS0205(infoOcs0205.getMemb(), infoOcs0205.getSangGubun(), pkSeq, hospCode);
	    	}
		}
		response.setResult(result != null && result > 0);
		return response.build();
	}
	public void insertOcs0204(OcsaOCS0204U00GrdOCS0204ListInfo infoOcs0204,String userId, String hospCode, String language){
		Ocs0204 ocs0204 = new Ocs0204();
		ocs0204.setSysDate(new Date());
		if(!StringUtils.isEmpty(userId)){
			ocs0204.setSysId(userId);
		}
		if(!StringUtils.isEmpty(infoOcs0204.getMemb())){
			ocs0204.setMemb(infoOcs0204.getMemb());
		}
		ocs0204.setMembGubun("1");
		if(!StringUtils.isEmpty(infoOcs0204.getFSeq())){
			Double seq = CommonUtils.parseDouble(infoOcs0204.getFSeq());
			ocs0204.setSeq(seq);
		}
		if(!StringUtils.isEmpty(infoOcs0204.getSangGubun())){
			ocs0204.setSangGubun(infoOcs0204.getSangGubun());
		}
		if(!StringUtils.isEmpty(infoOcs0204.getSangGubunName())){
			ocs0204.setSangGubunName(infoOcs0204.getSangGubunName());
		}
		ocs0204.setHospCode(hospCode);
		ocs0204.setLanguage(language);
		ocs0204Repository.save(ocs0204);
	}
	public void insertOcs0205(OcsaOCS0204U00GrdOCS0205ListInfo  infoOcs0205,String userId, String hospCode){
		Ocs0205 ocs0205 = new Ocs0205();
		ocs0205.setSysDate(new Date());
		if(!StringUtils.isEmpty(userId)){
			ocs0205.setSysId(userId);
		}
		Double pkSeq = ocs0205Repository.getPkSeqOcsaOCS0204U00InsertIntoOCS0205(infoOcs0205.getMemb(),infoOcs0205.getSangGubun(), hospCode);
		if(pkSeq != null){
			ocs0205.setPkSeq(pkSeq);
		}
		if(!StringUtils.isEmpty(infoOcs0205.getMemb())){
			ocs0205.setMemb(infoOcs0205.getMemb());
		}
		ocs0205.setMembGubun("1");
		if(!StringUtils.isEmpty(infoOcs0205.getSangGubun())){
			ocs0205.setSangGubun(infoOcs0205.getSangGubun());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getSangCode())){
			ocs0205.setSangCode(infoOcs0205.getSangCode());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getSer())){
			Double ser = CommonUtils.parseDouble(infoOcs0205.getSer());
			ocs0205.setSer(ser);
		}
		if(!StringUtils.isEmpty(infoOcs0205.getSangName())){
			ocs0205.setSangName(infoOcs0205.getSangName());
		}
		//
		if(!StringUtils.isEmpty(infoOcs0205.getPreModifier1())){
			ocs0205.setPreModifier1(infoOcs0205.getPreModifier1());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPreModifier2())){
			ocs0205.setPreModifier2(infoOcs0205.getPreModifier2());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPreModifier3())){
			ocs0205.setPreModifier3(infoOcs0205.getPreModifier3());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPreModifier4())){
			ocs0205.setPreModifier4(infoOcs0205.getPreModifier4());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPreModifier5())){
			ocs0205.setPreModifier5(infoOcs0205.getPreModifier5());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPreModifier6())){
			ocs0205.setPreModifier6(infoOcs0205.getPreModifier6());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPreModifier7())){
			ocs0205.setPreModifier7(infoOcs0205.getPreModifier7());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPreModifier8())){
			ocs0205.setPreModifier8(infoOcs0205.getPreModifier8());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPreModifier9())){
			ocs0205.setPreModifier9(infoOcs0205.getPreModifier9());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPreModifier10())){
			ocs0205.setPreModifier10(infoOcs0205.getPreModifier10());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPreModifierName())){
			ocs0205.setPreModifierName(infoOcs0205.getPreModifierName());
		}
		//
		if(!StringUtils.isEmpty(infoOcs0205.getPostModifier1())){
			ocs0205.setPostModifier1(infoOcs0205.getPostModifier1());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPostModifier2())){
			ocs0205.setPostModifier2(infoOcs0205.getPostModifier2());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPostModifier3())){
			ocs0205.setPostModifier3(infoOcs0205.getPostModifier3());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPostModifier4())){
			ocs0205.setPostModifier4(infoOcs0205.getPostModifier4());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPostModifier5())){
			ocs0205.setPostModifier5(infoOcs0205.getPostModifier5());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPostModifier6())){
			ocs0205.setPostModifier6(infoOcs0205.getPostModifier6());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPostModifier7())){
			ocs0205.setPostModifier7(infoOcs0205.getPostModifier7());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPostModifier8())){
			ocs0205.setPostModifier8(infoOcs0205.getPostModifier8());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPostModifier9())){
			ocs0205.setPostModifier9(infoOcs0205.getPostModifier9());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPostModifier10())){
			ocs0205.setPostModifier10(infoOcs0205.getPostModifier10());
		}
		if(!StringUtils.isEmpty(infoOcs0205.getPostModifierName())){
			ocs0205.setPostModifierName(infoOcs0205.getPostModifierName());
		}
		ocs0205.setHospCode(hospCode);
		ocs0205Repository.save(ocs0205);
	}
}