package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto.CPL3010U00GrdGumListItemInfo;
import nta.med.service.ihis.proto.CplsModelProto.CPL3010U00GrdPartListItemInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class CPL3010U00SaveLayoutHandler extends ScreenHandler <CplsServiceProto.CPL3010U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Cpl2010Repository cpl2010Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U00SaveLayoutRequest request) throws Exception {                                                                   
	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		String tFlag = "";
		String hospCode = getHospitalCode(vertx, sessionId);
		//callerId = 1
		for(CPL3010U00GrdPartListItemInfo  info : request.getGrdPartInfoList()){
			 if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				 String retVal = cpl2010Repository.checkSpecimenSerCPL3010U00Execute(hospCode, info.getSpecimenSer());
					if(!StringUtils.isEmpty(retVal)){
						tFlag = retVal;
					}
				 cpl2010Repository.updateCPL3010U00Execute(hospCode, info.getSpecimenSer());
				 tFlag = cpl2010Repository.callPrCplPartJubsuCancel(request.getUserId(), info.getSpecimenSer(), null, "1", hospCode,info.getPartJubsuja());
			 }
		}
		//callerId = 2
		for(CPL3010U00GrdGumListItemInfo  info : request.getGrdGumInfoList()){
			 if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				 if("N".equalsIgnoreCase(info.getSubJubsuYn())){
					 Double fkcpl2010 = CommonUtils.parseDouble(info.getFkcpl2010());
					 tFlag =  cpl2010Repository.callPrCplPartJubsuCancel(request.getUserId(), info.getSpecimenSer(), fkcpl2010, "2", hospCode,info.getPartJubsuja());
				 }
			 }
		}
		response.setResult(true);
		return response.build();
	}
}