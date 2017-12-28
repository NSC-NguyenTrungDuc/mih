package nta.med.service.ihis.handler.drug;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.inv.Inv0110;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrugModelProto.DRGOCSCHKGrdOcsChkInfo;
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
public class DRGOCSCHKSaveLayoutHandler extends ScreenHandler<DrugServiceProto.DRGOCSCHKSaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(DRGOCSCHKSaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Inv0110Repository inv0110Repository;                                                                    

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRGOCSCHKSaveLayoutRequest request) throws Exception {
		String hospitalCode = getHospitalCode(vertx, sessionId);
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();  
		if(CollectionUtils.isEmpty(request.getInputListList())){
			response.setResult(false);
		}else{
			for(DRGOCSCHKGrdOcsChkInfo item :request.getInputListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					response.setResult(insertInv0110(item, request.getUserId(), hospitalCode));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					response.setResult(updateInv0110(item, request.getUserId(), hospitalCode));
				}
			}
		}
		return response.build();
	}
	
	public boolean insertInv0110(DRGOCSCHKGrdOcsChkInfo item, String userId, String hospitalCode){
		Inv0110 inv0110 = new Inv0110();
		inv0110.setJukyongDate(new Date());
		inv0110.setJaeryoCode(item.getJaeryoCode());
		inv0110.setJaeryoName(item.getJaeryoName());
		inv0110.setChk3(item.getDrgPackYn());
		inv0110.setChk2(item.getPhamarcyYn());
		inv0110.setChk1(item.getPowerYn());
		inv0110.setToijangYn(item.getHubalChangeYn());
		inv0110.setBunryu2(item.getMayakYn());
		inv0110.setSmallCode(item.getSmallCode());
		inv0110.setCautionCode(item.getCautionCode());
		inv0110.setSysDate(new Date());
		inv0110.setSysId(userId);
		inv0110.setHospCode(hospitalCode);
		inv0110Repository.save(inv0110);
		return true;
	}
	public boolean updateInv0110(DRGOCSCHKGrdOcsChkInfo item, String userId, String hospitalCode){
		if(inv0110Repository.updateInv0110(item.getDrgPackYn(), item.getPhamarcyYn(), item.getPowerYn(), 
				item.getHubalChangeYn(), item.getMayakYn(), item.getSmallCode(), item.getCautionCode(), userId, new Date(),
				item.getJaeryoCode(), hospitalCode) > 0){
			return true;
		}else{
			return false;
		}
	}
}