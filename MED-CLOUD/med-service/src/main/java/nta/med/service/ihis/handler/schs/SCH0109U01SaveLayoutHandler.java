package nta.med.service.ihis.handler.schs;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.sch.Sch0108;
import nta.med.core.domain.sch.Sch0109;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.sch.Sch0108Repository;
import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.service.ihis.proto.SchsModelProto.SCH0109U01GrdDetailInfo;
import nta.med.service.ihis.proto.SchsModelProto.SCH0109U01GrdMasterInfo;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")    
@Transactional
public class SCH0109U01SaveLayoutHandler
	extends ScreenHandler<SchsServiceProto.SCH0109U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {  
	
	private static final Log LOGGER = LogFactory.getLog(SCH0109U01SaveLayoutHandler.class);
	
	@Resource                                                                                                       
	private Sch0108Repository sch0108Repository;  
	@Resource                                                                                                       
	private Sch0109Repository sch0109Repository;  
	                                                                                                                
	@Override                                         
	@Route(global = false)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH0109U01SaveLayoutRequest request) throws Exception {                                                                  
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		Integer result = 0;
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
   		//callerId = 1
		for(SCH0109U01GrdMasterInfo info : request.getGrdMstItemList()){
			if(DataRowState.DELETED.getValue().equals(info.getRowState())){
				String getY = sch0109Repository.getSCH0109XSavePerformer(hospCode, language, info.getCodeType());
				if("Y".equalsIgnoreCase(getY)){
					result = sch0109Repository.deleteSCH0109XSavePerformer1(hospCode, language, info.getCodeType());
				}
				response.setMsg(getY);
			}
		}
		//callerId = 2
		for(SCH0109U01GrdDetailInfo info : request.getGrdDetailItemList()){
			if(DataRowState.ADDED.getValue().equals(info.getRowState())){
				boolean isDupplicateKey = sch0109Repository.isExistedSCH0109(hospCode, info.getCodeType(), info.getCode(), language);
            	if(isDupplicateKey){
            		LOGGER.info("Duplicate entry for key " +"HospCode: "+hospCode+"codeType:" +info.getCodeType()+"Code: "+info.getCode()+"Language:"+language);
					response.setResult(false);
					throw new ExecutionException(response.build());
				}else {				
					insertSch0109(info, request.getUserId(), hospCode, language);
					result = 1;
				}
			}else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())){
				Double seq = CommonUtils.parseDouble(info.getSeq());
				result = sch0109Repository.updateSCH0109WithSeq(request.getUserId(), new Date(), info.getCodeName(), info.getCodeName2(),
						info.getCode2(), seq, hospCode, language, info.getCodeType(), info.getCode());
			}else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
				result = sch0109Repository.deleteSCH0109XSavePerformer(hospCode, language, info.getCodeType(), info.getCode());
			}
		}
		if(result>0){
  			response.setResult(true);
  		}else{
  			response.setResult(false);
  		}	
		return response.build();
	}
	private void insertSch0108(SCH0109U01GrdMasterInfo info, String userId, String hospCode, String language){
		Sch0108 sch0108 = new Sch0108();
		sch0108.setSysDate(new Date());
		sch0108.setSysId(userId);
		sch0108.setUpdDate(new Date());
		sch0108.setUpdId(userId);
		sch0108.setCodeType(info.getCodeType());
		sch0108.setCodeTypeName(info.getCodeTypeName());
		sch0108.setAdminGubun(info.getAdminGubun());
		sch0108.setRemark(info.getRemark());
		sch0108.setLanguage(language);
		sch0108Repository.save(sch0108);
	}
	private void insertSch0109(SCH0109U01GrdDetailInfo info, String userId, String hospCode, String language){
		Sch0109 sch0109 = new Sch0109();
		Double seq = CommonUtils.parseDouble(info.getSeq());
		sch0109.setSysDate(new Date());
		sch0109.setSysId(userId);
		sch0109.setUpdDate(new Date());
		sch0109.setUpdId(userId);
		sch0109.setHospCode(hospCode);
		sch0109.setLanguage(language);
		sch0109.setCodeType(info.getCodeType());
		sch0109.setCode(info.getCode());
		sch0109.setCodeName(info.getCodeName());
		sch0109.setCodeName2(info.getCodeName2());
		sch0109.setCode2(info.getCode2());
		sch0109.setSeq(seq);
		sch0109Repository.save(sch0109);
	}
	
	@Override
    @Route(global = true)
    public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		SCH0109U01SaveLayoutRequest request, UpdateResponse rs) throws Exception {
    	SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
    	Integer result = 0;
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
   		//callerId = 1
		for(SCH0109U01GrdMasterInfo info : request.getGrdMstItemList()){
			if(DataRowState.ADDED.getValue().equals(info.getRowState())){
				insertSch0108(info, request.getUserId(), hospCode, language);
				result = 1;
			}else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())){
				result = sch0108Repository.updateSCH0109U01Execute(request.getUserId(), new Date(), info.getCodeTypeName(), info.getAdminGubun(), info.getRemark(),
						hospCode, info.getCodeType(), language);
			}else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
				if(!"Y".equalsIgnoreCase(response.getMsg())){
					result = sch0108Repository.deleteSCH0108XSavePerformer(hospCode, info.getCodeType(), language);
				}
			}
		}

		if(result>0){
  			response.setResult(true);
  		}else{
  			response.setResult(false);
  		}	
    	return response.build();
    }
}