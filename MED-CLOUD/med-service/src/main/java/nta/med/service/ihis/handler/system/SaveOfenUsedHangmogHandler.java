package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs0212;
import nta.med.data.dao.medi.ocs.Ocs0212Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.SaveOfenUsedHangmogInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.SaveOfenUsedHangmogRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class SaveOfenUsedHangmogHandler extends ScreenHandler<SystemServiceProto.SaveOfenUsedHangmogRequest, SystemServiceProto.UpdateResponse>{                     
	@Resource                                                                                                       
	private Ocs0212Repository ocs0212Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, SaveOfenUsedHangmogRequest request)
			throws Exception {                                                                   
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();        
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		Double pSeq = new Double(0);
		Integer result = null;
		SaveOfenUsedHangmogInfo info = request.getInfo1();
		Integer checkUpdate = ocs0212Repository.updateSaveOfenUsedHangmogInfo(hospCode, info.getOftenUse(), info.getMembGubun(), info.getMemb(), info.getHangmogCode());
		if(checkUpdate > 0){
			pSeq = ocs0212Repository.getMaxSeqOfenUsedHangmogInfo(hospCode, info.getMembGubun(), info.getMemb(), info.getHangmogCode());
			if(pSeq == 0){
				pSeq = new Double(1);
			}
			insertSaveOfenUsedHangmog(info, pSeq, hospCode);
			result = 1;	
		}
		if(result != null && result > 0){
			response.setResult(true);
		}else{
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		return response.build();
	}    
	

	public void insertSaveOfenUsedHangmog(SaveOfenUsedHangmogInfo info, Double seq, String hospCode){
		Ocs0212 ocs0212 = new Ocs0212();
		ocs0212.setSysDate(new Date());
		ocs0212.setSysId(info.getUserInfo());
		ocs0212.setUpdDate(new Date());
		ocs0212.setUpdId(info.getUserInfo());
		ocs0212.setHospCode(hospCode);
		ocs0212.setMembGubun(info.getMembGubun());
		ocs0212.setMemb(info.getMemb());
		ocs0212.setHangmogCode(info.getHangmogCode());
		ocs0212.setSeq(seq);
		ocs0212.setOftenUse(info.getOftenUse());
		ocs0212Repository.save(ocs0212);	
	}
}