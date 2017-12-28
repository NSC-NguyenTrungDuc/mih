package nta.med.service.ihis.handler.nuri;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.nur.Nur1017;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.nur.Nur1017Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriModelProto.NUR1017U00GrdNUR1017ListItemInfo;
import nta.med.service.ihis.proto.NuriServiceProto;

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
public class NUR1017U00SaveLayoutHandler extends ScreenHandler<NuriServiceProto.NUR1017U00SaveLayoutRequest, NuriServiceProto.NUR1017U00SaveLayoutResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(NUR1017U00SaveLayoutHandler.class);                                        
	@Resource                                                                                                       
	private CommonRepository commonRepository;     
	
	@Resource                                                                                                       
	private Nur1017Repository nur1017Repository;                                                                    
	                                                                                                                
	@Override
	public NuriServiceProto.NUR1017U00SaveLayoutResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NUR1017U00SaveLayoutRequest request) throws Exception {
		NuriServiceProto.NUR1017U00SaveLayoutResponse.Builder response = NuriServiceProto.NUR1017U00SaveLayoutResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		for(NUR1017U00GrdNUR1017ListItemInfo item : request.getGrdListList()){
			if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
				String listChk = nur1017Repository.getNuriNUR1017U00GetY(hospCode, item.getInfeCode(), item.getBunho(), item.getStartDate());
				if(!StringUtils.isEmpty(listChk)){
					response.setSaveLayoutResult(false);
				} else {
					response.setSaveLayoutResult(insertManageInfection(item, request.getUserId(), hospCode));
				}
			}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
				response.setSaveLayoutResult(updateManageInfection(item, request.getUserId(), hospCode));
			} else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
				response.setSaveLayoutResult(deleteNUR1017U00(item, request.getUserId(), hospCode));
			} else if (item.getRowState().equalsIgnoreCase(DataRowState.UNCHANGED.getValue())){
				response.setSaveLayoutResult(true);
			}
			
			String result = nur1017Repository.callNuriPrNurInfeMapping(hospCode, item.getBunho(), item.getInfeCode(),
            		"NUR1017", request.getUserId(), language, "");
		}
		return response.build();
	}
	
	private boolean insertManageInfection(NUR1017U00GrdNUR1017ListItemInfo item, String userId, String hospCode){
	     Nur1017 nur1017 = new Nur1017();
	     
	     Date date = new Date();
	     	
	     nur1017.setSysDate(date);
	     nur1017.setSysId(userId);
	     nur1017.setUpdDate(date);
	     nur1017.setUpdId(userId);
	     nur1017.setHospCode(hospCode);
	     nur1017.setInfeCode(item.getInfeCode());
	     nur1017.setBunho(item.getBunho());
	     if(!StringUtils.isEmpty(item.getStartDate()) && DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD) != null){
		     nur1017.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
	     }
	     if(!StringUtils.isEmpty(item.getStartDate()) && DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD) != null){
		     nur1017.setEndDate(DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
	     }
	     nur1017.setEndSayu(item.getEndSayu());
	     nur1017.setInputText(item.getInputText());
	     nur1017.setInfeJaeryo(item.getInfeJaeryo());
	     nur1017.setPknur1017(CommonUtils.parseDouble(commonRepository.getNextVal("NUR1017_SEQ")));
	     nur1017.setCancelYn("N");
	     
	     nur1017Repository.save(nur1017);
	     return true;
	}
	
	private boolean updateManageInfection(NUR1017U00GrdNUR1017ListItemInfo item, String userId, String hospCode){
		if(nur1017Repository.updateNuriNUR1017U00UpdateManageInfection(userId, DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD), 
			item.getEndSayu(), item.getInputText(), item.getInfeJaeryo(), hospCode, CommonUtils.parseDouble(item.getPknur1017()))>0){
			return true;
		}else{
			return false;
		}
	}
	
	private boolean deleteNUR1017U00(NUR1017U00GrdNUR1017ListItemInfo item, String userId, String hospCode){
	    if( nur1017Repository.deleteNuriNUR1017U00ManageInfection(userId, hospCode, CommonUtils.parseDouble(item.getPknur1017())) > 0){
				return true;
		}else{
			return false;
		}
	}

}                                                                                                                 
