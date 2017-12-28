package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.cpl.Cpl0104;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.ModifyFlg;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl0104Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto.CPL0104U00GrdDetailListItemInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0104U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL0104U00SaveLayoutHandler extends ScreenHandler<CplsServiceProto.CPL0104U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(CPL0104U00SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Cpl0104Repository cpl0104Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CPL0104U00SaveLayoutRequest request) throws Exception {                                                                   
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();    
		String hospitalCode = getHospitalCode(vertx, sessionId);
		if(CollectionUtils.isEmpty(request.getInputListList())){
			response.setResult(false);
		}else{
			boolean result = false;
			for(CPL0104U00GrdDetailListItemInfo item : request.getInputListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					result = insertCpl0104(item, request.getUserId(), hospitalCode);
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(cpl0104Repository.updateCpl0104(hospitalCode, request.getUserId(), item.getFromStandard(),
							item.getToStandard(), ModifyFlg.UPDATE.getValue(), item.getHangmogCode(), item.getSpecimenCode(),item.getEmergency(), item.getSex(),
							CommonUtils.parseDouble(item.getFromAge()),CommonUtils.parseDouble(item.getToAge()), item.getNaiFrom(), item.getNaiTo()) >0){
						result = true;
					}
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(cpl0104Repository.deleteCpl0104(hospitalCode, item.getHangmogCode(),  item.getSpecimenCode(), 
							item.getEmergency(), item.getSex(), CommonUtils.parseDouble(item.getFromAge()), CommonUtils.parseDouble(item.getToAge()),
							item.getNaiFrom(), item.getNaiTo()) >0){
						result = true;
					}
				}
				if(!result){
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}
		}
		response.setResult(true);
		return response.build();
	}     
	
	public boolean insertCpl0104(CPL0104U00GrdDetailListItemInfo item, String userId, String hospitalCode){
		Cpl0104 cpl0104= new Cpl0104();
		cpl0104.setSysDate(new Date());
		cpl0104.setSysId(userId);
		cpl0104.setUpdDate(new Date());
		cpl0104.setUpdId(userId);
		cpl0104.setHangmogCode(item.getHangmogCode());
		cpl0104.setSpecimenCode(item.getSpecimenCode());
		cpl0104.setEmergency(item.getEmergency());
		cpl0104.setSex(item.getSex());
		cpl0104.setFromAge(CommonUtils.parseDouble(item.getFromAge()));
		cpl0104.setToAge(CommonUtils.parseDouble(item.getToAge()));
		cpl0104.setFromStandard(item.getFromStandard());
		cpl0104.setToStandard(item.getToStandard());
		cpl0104.setNaiFrom(item.getNaiFrom());
		cpl0104.setNaiTo(item.getNaiTo());
		cpl0104.setHospCode(hospitalCode);
		cpl0104.setModifyFlg(ModifyFlg.INSERT.getValue());
		cpl0104Repository.save(cpl0104);
		
		return true;
	}

}