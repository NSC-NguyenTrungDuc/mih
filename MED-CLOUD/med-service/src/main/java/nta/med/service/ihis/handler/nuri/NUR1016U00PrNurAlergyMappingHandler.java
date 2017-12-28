package nta.med.service.ihis.handler.nuri;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.nur.Nur1016;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriModelProto.NUR1016U00GrdNUR1016ListItemInfo;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class NUR1016U00PrNurAlergyMappingHandler extends ScreenHandler<NuriServiceProto.NUR1016U00PrNurAlergyMappingRequest, NuriServiceProto.NUR1016U00PrNurAlergyMappingResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(NUR1016U00PrNurAlergyMappingHandler.class);                                        
	@Resource                                                                                                       
	private Nur1016Repository nur1016Repository;  
	
	@Override
	public boolean isValid(NuriServiceProto.NUR1016U00PrNurAlergyMappingRequest request, Vertx vertx, String clientId, String sessionId) {
		for(NUR1016U00GrdNUR1016ListItemInfo info : request.getGrdNUR1016ListList()){
			if (!StringUtils.isEmpty(info.getStartDate()) && DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
				return false;
			}else if(!StringUtils.isEmpty(info.getEndDate())&& DateUtil.toDate(info.getEndDate(),DateUtil.PATTERN_YYMMDD) == null){
				return false;
			}
		}
		return true;
	}
	                                                                                                                
	@Override
	public NuriServiceProto.NUR1016U00PrNurAlergyMappingResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NUR1016U00PrNurAlergyMappingRequest request) throws Exception {
		NuriServiceProto.NUR1016U00PrNurAlergyMappingResponse.Builder response=NuriServiceProto.NUR1016U00PrNurAlergyMappingResponse.newBuilder();
		boolean save = false;
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!CollectionUtils.isEmpty(request.getGrdNUR1016ListList())){
			for(NUR1016U00GrdNUR1016ListItemInfo item : request.getGrdNUR1016ListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.toString())){
					if(StringUtils.isEmpty(item.getPknur1016())){
//						rpcBuilder.setResult(Rpc.RpcMessage.Result.SERVICE_REJECTED);
						save = false;
					}else{
						save = insertNur10106(item, request.getUserId(), hospCode);
					}
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.toString())){
					save = updateNur1016(item, request.getUserId(), hospCode);
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.toString())){
					save = updateCancelStatusNur1016(item, request.getUserId(), hospCode);
				}
				if(!save){
					response.setSaveLayoutResult(false);
					throw new ExecutionException(response.build());
				}
			}
		}
		response.setSaveLayoutResult(save);
		String result = nur1016Repository.callNuriNUR1016U00NurAlegyMapping(hospCode, request.getBunho(), request.getTableId(), request.getUserId());
		if(!StringUtils.isEmpty(result)){
			response.setPrResult(result);
		}
		return response.build();
	}
	
	public boolean insertNur10106(NUR1016U00GrdNUR1016ListItemInfo info, String userId, String hospCode){
			Nur1016 nur1016 = new Nur1016();
			nur1016.setSysDate(new Date());
			nur1016.setSysId(userId);           
			nur1016.setUpdDate(new Date());         
			nur1016.setUpdId(userId);           
			nur1016.setHospCode(hospCode);
			nur1016.setPknur1016(CommonUtils.parseDouble(info.getPknur1016()));
			nur1016.setBunho(info.getBunho());
			nur1016.setAllergyGubun(info.getAllergyGubun());
			nur1016.setAllergyInfo(info.getAllergyInfo());
			nur1016.setStartDate(DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
			nur1016.setEndDate(DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD));
			nur1016.setEndSayu(info.getEndSayu());
			nur1016.setInputText(info.getInputText());
			nur1016.setCancelYn("N");
			nur1016Repository.save(nur1016);
			return true;
		}
	
	private boolean updateNur1016(NUR1016U00GrdNUR1016ListItemInfo info, String userId, String hospCode){
			if(nur1016Repository.updateNur1016(
					userId, 
					new Date(), 
					info.getAllergyInfo(), 
					DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD), 
					info.getEndSayu(),
					info.getInputText(),
					hospCode, 
					CommonUtils.parseDouble(info.getPknur1016()), 
					info.getBunho(), 
					info.getAllergyGubun(),
					info.getStartDate()) > 0){
				return true;
			}else{
				return false;
			}
	}
	private boolean updateCancelStatusNur1016(NUR1016U00GrdNUR1016ListItemInfo info, String userId, String hospCode){
			if(nur1016Repository.updateCancelStatusNur1016(
					userId, 
					new Date(), 
					hospCode, 
					CommonUtils.parseDouble(info.getPknur1016()), 
					info.getBunho(),
					info.getAllergyGubun(), 
					info.getStartDate()) > 0){
				return true;
			}else{
				return false;
			}
	}
}                                                                                                                 
