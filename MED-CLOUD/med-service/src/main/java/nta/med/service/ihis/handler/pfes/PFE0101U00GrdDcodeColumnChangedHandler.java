package nta.med.service.ihis.handler.pfes;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.pfe.Pfe0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PfesServiceProto;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00GrdDcodeColumnChangedRequest;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00GrdDcodeColumnChangedResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PFE0101U00GrdDcodeColumnChangedHandler
	extends ScreenHandler<PfesServiceProto.PFE0101U00GrdDcodeColumnChangedRequest, PfesServiceProto.PFE0101U00GrdDcodeColumnChangedResponse> {                     
	@Resource                                                                                                       
	private Pfe0102Repository pfe0102Repository;
	@Resource
	private Adm3200Repository adm3200Repository;
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public PFE0101U00GrdDcodeColumnChangedResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PFE0101U00GrdDcodeColumnChangedRequest request) throws Exception {                                                                 
  	   	PfesServiceProto.PFE0101U00GrdDcodeColumnChangedResponse.Builder response = PfesServiceProto.PFE0101U00GrdDcodeColumnChangedResponse.newBuilder();                      
		String hospCode = getHospitalCode(vertx, sessionId);
		if(DataRowState.ADDED.getValue().equals(request.getRowState())) {
			if("code".equalsIgnoreCase(request.getColName())){
				String layDupD=pfe0102Repository.getPFE0101U00LayDupDRequest(hospCode,request.getCodeType(),request.getCode(), getLanguage(vertx, sessionId));
				if(!StringUtils.isEmpty(layDupD)){
					response.setDupYn(layDupD);
				}
			}
		}
		
		if(request.getMCodeType() && "code".equalsIgnoreCase(request.getColName())){
			List<String> layUser = adm3200Repository.getUserNameList(hospCode, request.getCode());
			if(!CollectionUtils.isEmpty(layUser) && !StringUtils.isEmpty(layUser.get(0))){
				response.setUserName(layUser.get(0));
			}
		}
		return response.build();
	}
}