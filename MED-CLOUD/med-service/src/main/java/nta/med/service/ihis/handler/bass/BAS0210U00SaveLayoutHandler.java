package nta.med.service.ihis.handler.bass;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0210;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0210Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.BAS0210U00grdBAS0210ItemInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class BAS0210U00SaveLayoutHandler extends ScreenHandler<BassServiceProto.BAS0210U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                             
	@Resource                                                                                                       
	private Bas0210Repository bas0210Repository;                                                                    
	                                                                                                                
	@Override         
	@Route(global = true)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0210U00SaveLayoutRequest request) throws Exception {         
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		response = executeHandler(request, hospitalCode, language);
		if(!response.getResult()){
			throw new ExecutionException(response.build());
		}
		return response.build();                                                                                  
	}
	
	public SystemServiceProto.UpdateResponse.Builder executeHandler(BassServiceProto.BAS0210U00SaveLayoutRequest request, String hospitalCode, String language){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		for(BAS0210U00grdBAS0210ItemInfo item : request.getItemInfoList()){
			if(DataRowState.ADDED.getValue().equalsIgnoreCase(item.getDataRowState())){
				String getTDupCheck=bas0210Repository.getBAS0210U00DupCheck(item.getGubun(),DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD), language);
				if(getTDupCheck !=null && getTDupCheck.equals("Y")){ 
					response.setResult(false);
					return response;
				}
				//
				bas0210Repository.updateBAS0210U00ExecuteCaseInsert(request.getUserId(),DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD),item.getGubun(), language);
				//
				Bas0210 bas0210= new Bas0210();
				bas0210.setStartDate(new Date());
				bas0210.setSysId(request.getUserId());
				bas0210.setUpdDate(new Date());
				bas0210.setUpdId(request.getUserId());
				bas0210.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
				bas0210.setEndDate(DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
				bas0210.setGubun(item.getGubun());
				bas0210.setGubunName(item.getGubunName());
				bas0210.setJohapGubun(item.getJohapGubun());
				bas0210.setGongbiYn(item.getGonbiYn());
				bas0210.setLanguage(language);
				bas0210Repository.save(bas0210);
			}else if(DataRowState.MODIFIED.getValue().equalsIgnoreCase(item.getDataRowState())){
				if(bas0210Repository.updateBAS0210Execute(request.getUserId(),DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD),
						 item.getGubunName(),item.getJohapGubun(),item.getGonbiYn(),item.getGubun(),DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD), language) <= 0) {
					response.setResult(false);
					return response;
				}
			}else if(DataRowState.DELETED.getValue().equalsIgnoreCase(item.getDataRowState())){
				 if(bas0210Repository.deleteBAS0210U00Execute(item.getGubun(), DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD), language) <= 0){
					 response.setResult(false);
					 return response;
				 }
			}
		}
		response.setResult(true);
		return response;
	}
}