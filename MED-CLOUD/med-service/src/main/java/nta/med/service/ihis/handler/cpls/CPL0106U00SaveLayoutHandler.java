package nta.med.service.ihis.handler.cpls;

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
import nta.med.core.domain.cpl.Cpl0106;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.ModifyFlg;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.cpl.Cpl0106Repository;
import nta.med.service.ihis.proto.CplsModelProto.CPL0106U00GrdListItemInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0106U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")                 
@Transactional
public class CPL0106U00SaveLayoutHandler extends ScreenHandler<CplsServiceProto.CPL0106U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(CPL0106U00SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Cpl0106Repository cpl0106Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL0106U00SaveLayoutRequest request) throws Exception {
		String hospitalCode = getHospitalCode(vertx, sessionId);
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		if(CollectionUtils.isEmpty(request.getInputListList())){
			response.setResult(false);
		}else{
			boolean result = false;			
			for(CPL0106U00GrdListItemInfo item : request.getInputListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					boolean isDupplicateKey = cpl0106Repository.isExistedCpl0106(hospitalCode, item.getHangmogCode(), item.getSpecimenCode(), item.getEmergency(),item.getSubHangmogCode());
					if(isDupplicateKey){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}else {
							result = insertCpl0106(item, request.getUserId(), hospitalCode);
						}
					
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(cpl0106Repository.updateCpl0106(request.getUserId(), new Date(), 
            				item.getSubSpecimenCode(), item.getSubEmergency(), item.getContinueYn(), ModifyFlg.UPDATE.getValue(), hospitalCode, 
            				item.getGroupGubunA(), item.getHangmogCode(), item.getSpecimenCode(), item.getEmergency(), item.getSubHangmogCode()) >0){
						result = true;
					}
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					LOGGER.info("OBJECT " +hospitalCode+ " "+
            				item.getGroupGubunA()+ " "+ item.getHangmogCode()+ " "+ item.getSpecimenCode()+ " "+ item.getEmergency()+ " "+ item.getSubHangmogCode());
					if(cpl0106Repository.deleteCpl0106(hospitalCode, 
            				item.getGroupGubunA(), item.getHangmogCode(), item.getSpecimenCode(), item.getEmergency(), item.getSubHangmogCode()) >0){
						result = true;
					}
				}
				
				if(result){
						response.setResult(true);
				}else {
					response.setResult(false);
					throw new ExecutionException(response.build());
				} 
			}
			response.setResult(result);
		}
		return response.build();
	}         
	private boolean insertCpl0106(CPL0106U00GrdListItemInfo item, String userId, String hospitalCode){
		Cpl0106 cpl0106 = new Cpl0106();
		cpl0106.setSysDate(new Date());
		cpl0106.setSysId(userId);
		cpl0106.setUpdDate(new Date());
		cpl0106.setUpdId(userId);
		cpl0106.setGroupGubun(item.getGroupGubunA());
		cpl0106.setHangmogCode(item.getHangmogCode());
		cpl0106.setSpecimenCode(item.getSpecimenCode());
		cpl0106.setEmergency(StringUtils.isEmpty(item.getEmergency()) ? "N" : item.getEmergency());
		cpl0106.setSubHangmogCode(item.getSubHangmogCode());
		cpl0106.setSubSpecimenCode(item.getSubSpecimenCode());
		cpl0106.setSubEmergency(StringUtils.isEmpty(item.getSubEmergency()) ? "N" : item.getSubEmergency());
		cpl0106.setContinueYn(item.getContinueYn());
		cpl0106.setHospCode(hospitalCode);
		cpl0106.setModifyFlg(ModifyFlg.INSERT.getValue());
		cpl0106Repository.save(cpl0106);
		return true;
	}
		
}