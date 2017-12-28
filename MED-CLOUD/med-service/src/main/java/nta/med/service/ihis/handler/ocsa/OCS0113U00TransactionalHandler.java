package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.ocs.Ocs0113;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0113Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0113U00GrdOCS0113ListItemInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0113U00TransactionalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0113U00TransactionalHandler
	extends ScreenHandler<OcsaServiceProto.OCS0113U00TransactionalRequest, SystemServiceProto.UpdateResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0113U00TransactionalHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0113Repository ocs0113Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0113U00TransactionalRequest request) throws Exception {                                                                   
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();  
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		for(OCS0113U00GrdOCS0113ListItemInfo item : request.getListItemList()){
			if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
				response.setResult(insertOCS0113(item, request.getUserId(), hospCode));
			}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
				response.setResult(updateOCS0113(item, request.getUserId(), hospCode));
			}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
				response.setResult(deleteOCS0113(item, request.getUserId(), hospCode));
			}
		}
		return response.build();	                                                                                
	}          
	
	public boolean insertOCS0113(OCS0113U00GrdOCS0113ListItemInfo item, String userId, String hospCode){
		Ocs0113 ocs0113 = new Ocs0113();
		ocs0113.setSysDate(new Date());
		ocs0113.setSysId(userId);
		ocs0113.setHangmogCode(item.getHangmogCode());
		ocs0113.setSpecimenCode(item.getSpecimenCode());
		ocs0113.setSeq(CommonUtils.parseDouble(item.getSeq()));
		ocs0113.setDefaultYn(item.getDefaultYn());
		ocs0113.setHospCode(hospCode);
		if(!StringUtils.isEmpty(item.getHangmogStatDate())){
		ocs0113.setHangmogStartDate(DateUtil.toDate(item.getHangmogStatDate(), DateUtil.PATTERN_YYMMDD));
		}
		ocs0113Repository.save(ocs0113);
		return true;
	}
	
	public boolean updateOCS0113(OCS0113U00GrdOCS0113ListItemInfo item, String userId, String hospCode){
		if(ocs0113Repository.updateOcs0113TransactionModified(
				userId, 
				CommonUtils.parseDouble(item.getSeq()), 
				item.getDefaultYn(), 
				item.getHangmogCode(), 
				item.getSpecimenCode(),
				hospCode)>0){
			return true;
		}else{
			return false;
		}
	}
	
	public boolean deleteOCS0113(OCS0113U00GrdOCS0113ListItemInfo item, String userId, String hospCode){
		if(ocs0113Repository.deleteOcs0113TransactionDeleted(
				item.getHangmogCode(), item.getSpecimenCode(), hospCode)>0){
			return true;
		}else{
			return false;
		}
	}

}