package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.cpl.Cpl1000;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl1000Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto.CPL3010U00LayUrineInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00SaveLayUrineRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class CPL3010U00SaveLayUrineHandler extends ScreenHandler <CplsServiceProto.CPL3010U00SaveLayUrineRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Cpl1000Repository cpl1000Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U00SaveLayUrineRequest request) throws Exception  {                                                                   
      	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder(); 
      	String hospCode = getHospitalCode(vertx, sessionId);
		Boolean result = false;
		for(CPL3010U00LayUrineInfo info : request.getUrineInfoList()){
			result = processCase3(info, request.getUserId(), hospCode);
		}
		response.setResult(result);
		return response.build();
	}

	private boolean processCase3(CPL3010U00LayUrineInfo  info,String userId, String hospCode){
		if(cpl1000Repository.updateCPL3010U00Execute(userId, new Date(), info.getUrineRyang(), 
				info.getStabilityYn(), hospCode, info.getSpecimenSer()) > 0){
			return true;
		}else{
			Cpl1000 cpl1000 = new Cpl1000();
			cpl1000.setSysDate(new Date());
			cpl1000.setSysId(userId);
			cpl1000.setUpdDate(new Date());
			cpl1000.setUpdId(userId);
			cpl1000.setHospCode(hospCode);
			Double pkcpl1000 = CommonUtils.parseDouble(info.getPkcpl1000());
			cpl1000.setPkcpl1000(pkcpl1000);
			if (StringUtils.isEmpty(info.getUrineRyang())){
				cpl1000.setUrineRyang("0");
			}else{
				cpl1000.setUrineRyang(info.getUrineRyang());
			}
			cpl1000.setStabilityYn(info.getStabilityYn());
			cpl1000.setSpecimenSer(info.getSpecimenSer());
			cpl1000Repository.save(cpl1000);
			
			return true;
		}
	}
}