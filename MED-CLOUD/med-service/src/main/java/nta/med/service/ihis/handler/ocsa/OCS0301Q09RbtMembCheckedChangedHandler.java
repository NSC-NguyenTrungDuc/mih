package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.ocs.Ocs0300Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301Q09RbtMembCheckedChangedRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301Q09RbtMembCheckedChangedResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0301Q09RbtMembCheckedChangedHandler
	extends ScreenHandler<OcsaServiceProto.OCS0301Q09RbtMembCheckedChangedRequest, OcsaServiceProto.OCS0301Q09RbtMembCheckedChangedResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;   
	@Resource
	private Ocs0300Repository ocs0300Repository;
	                                                                                                                
	@Override          
	@Transactional(readOnly = true)
	public OCS0301Q09RbtMembCheckedChangedResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0301Q09RbtMembCheckedChangedRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0301Q09RbtMembCheckedChangedResponse.Builder response = OcsaServiceProto.OCS0301Q09RbtMembCheckedChangedResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getDirectPath()) && request.getRbtName().equalsIgnoreCase("rbt"+request.getId())){
			List<String> resultOcs0132=ocs0132Repository.getCodeNameByCodeAndCodeType(hospCode, language, "INPUT_TAB",request.getCode());
			List<String> resultOcs0300=ocs0300Repository.getOCS0301Q09RbtMembCheckedChangedTableOCS0300(hospCode,request.getId(),CommonUtils.parseDouble(request.getM0300()));
			String 		resultOcs0300AndOcs0301=ocs0300Repository.getOCS0301Q09RbtMembCheckedChangedTableOCS0300And0301(hospCode,request.getId(),
					CommonUtils.parseDouble(request.getM0300()),request.getM0301());
			if(!CollectionUtils.isEmpty(resultOcs0132)){
				if(!StringUtils.isEmpty(resultOcs0132.get(0))){
					response.setResult1(resultOcs0132.get(0));
				}
			}
			if(!CollectionUtils.isEmpty(resultOcs0300)){
				if(!StringUtils.isEmpty(resultOcs0300.get(0))){
					response.setResult2(resultOcs0300.get(0));
				}
			}
			if(!StringUtils.isEmpty(resultOcs0300AndOcs0301)){
				response.setResult3(resultOcs0300AndOcs0301);
			}
		}
		return response.build();
	}

}