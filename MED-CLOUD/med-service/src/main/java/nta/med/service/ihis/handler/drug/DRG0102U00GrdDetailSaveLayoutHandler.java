package nta.med.service.ihis.handler.drug;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.inv.Inv0102;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrugModelProto.DRG0102U00GrdDetailInfo;
import nta.med.service.ihis.proto.DrugServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class DRG0102U00GrdDetailSaveLayoutHandler extends ScreenHandler<DrugServiceProto.DRG0102U00GrdDetailSaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(DRG0102U00GrdDetailSaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Inv0102Repository inv0102Repository;                                                                    
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRG0102U00GrdDetailSaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder(); 
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		if(CollectionUtils.isEmpty(request.getInputListList())){
			response.setResult(false);
		}else{
			for(DRG0102U00GrdDetailInfo item : request.getInputListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					response.setResult(insertInv0102(item, request.getUserId(), hospitalCode, language));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					response.setResult(updateInv0102(item, request.getUserId(), hospitalCode, language));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					response.setResult(deleteInv0102(item, hospitalCode, language));
				}
			}
		}
		return response.build();
	}
	
	public boolean insertInv0102(DRG0102U00GrdDetailInfo item, String userId, String hospitalCode, String language){
		Inv0102 inv0102 = new Inv0102();
		inv0102.setSysDate(new Date());
		inv0102.setSysId(userId);
		inv0102.setUpdDate(new Date());
		inv0102.setUpdId(userId);
		inv0102.setCodeType(item.getCodeType());
		inv0102.setCode(item.getCode());
		inv0102.setCodeName(item.getCodeName());
		inv0102.setHospCode(hospitalCode);
		inv0102.setCodeValue(item.getCodeValue());
		inv0102.setLanguage(language);
		inv0102Repository.save(inv0102);
		return true;
	}
	
	public boolean updateInv0102(DRG0102U00GrdDetailInfo item, String userId, String hospitalCode, String language){
		if(inv0102Repository.updateDRG0102U00UpdateInv0102(userId, new Date(), item.getCodeName(), item.getCodeValue(),
				item.getCodeType(), item.getCode(), hospitalCode, language) > 0){
			return true;	
		}else{
			return false;
		}
	}
	
	public boolean deleteInv0102(DRG0102U00GrdDetailInfo item, String hospitalCode, String language){
		if(inv0102Repository.deleteDRG0102U00UpdateInv0102(item.getCodeType(), item.getCode(), hospitalCode, language) > 0){
			return true;
		}else{
			return false;
		}
	}
}