package nta.med.service.ihis.handler.drug;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.inv.Inv0110;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.ModifyFlg;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.service.ihis.proto.DrugServiceProto;
import nta.med.service.ihis.proto.DrugServiceProto.DRGOCSCHKSaveGrdOcsChkRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.DrugModelProto.DRGOCSCHKGrdOcsChkFullInfo;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service                                                                                                          
@Scope("prototype")
public class DRGOCSCHKSaveGrdOcsChkHandler extends ScreenHandler<DrugServiceProto.DRGOCSCHKSaveGrdOcsChkRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(DRGOCSCHKSaveGrdOcsChkHandler.class);                                    
	@Resource                                                                                                       
	private Inv0110Repository inv0110Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRGOCSCHKSaveGrdOcsChkRequest request) throws Exception {
		String hospitalCode = getHospitalCode(vertx, sessionId);
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		if(CollectionUtils.isEmpty(request.getListInfoList())){
			response.setResult(false);
		}else{
			for(DRGOCSCHKGrdOcsChkFullInfo item : request.getListInfoList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					String getY = inv0110Repository.checkInvenByJaeryCode(item.getJaeryoCode(), hospitalCode);
					if ("Y".equalsIgnoreCase(getY)) {
	                    response.setMsg("2");
	                    response.setResult(false);
	                    throw new ExecutionException(response.build());
	                }
					response.setResult(insertInv0110(item, getUserId(vertx, sessionId), hospitalCode));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					response.setResult(updateInv0110(item, getUserId(vertx, sessionId), hospitalCode));
				}else if (DataRowState.DELETED.getValue().equals(item.getRowState())) {
					response.setResult((inv0110Repository.deleteInv0110ByJaeryoCode(item.getJaeryoCode(), hospitalCode) > 0) ?  true : false);
	            }
			}
		}
		return response.build();
	}
	
	public boolean insertInv0110(DRGOCSCHKGrdOcsChkFullInfo item, String userId, String hospitalCode){
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
	
	public boolean updateInv0110(DRGOCSCHKGrdOcsChkFullInfo item, String userId, String hospitalCode){
		Date startDate = DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD);
		Double subulDanga = null ;
		if (!StringUtils.isEmpty(item.getSubulDanga())){
			subulDanga = CommonUtils.parseDouble(item.getSubulDanga());
		}
		String jaeryoNameInx = item.getJaeryoName() + " " + item.getJaeryoCode();
		if(inv0110Repository.updateInv0110ByJaeryoCode2(item.getJaeryoName(), jaeryoNameInx, item.getSmallCode(), 
    			item.getSubulDanui(), item.getStockYn(), subulDanga, startDate, ModifyFlg.UPDATE.getValue(), item.getJaeryoCode(), item.getSubulQcodeOut(), item.getSubulQcodeInp(), hospitalCode) > 0){
			return true;
		}else{
			return false;
		}
	}
}
