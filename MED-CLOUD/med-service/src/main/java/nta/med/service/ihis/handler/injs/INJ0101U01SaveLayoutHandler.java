package nta.med.service.ihis.handler.injs;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.inj.Inj0101;
import nta.med.core.domain.inj.Inj0102;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.inj.Inj0101Repository;
import nta.med.data.dao.medi.inj.Inj0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto.INJ0101U01GrdDetailItemInfo;
import nta.med.service.ihis.proto.InjsModelProto.INJ0101U01GrdMasterItemInfo;
import nta.med.service.ihis.proto.InjsServiceProto.INJ0101U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class INJ0101U01SaveLayoutHandler extends ScreenHandler<InjsServiceProto.INJ0101U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(INJ0101U01SaveLayoutHandler.class);                                    
	
	@Resource                                                                                                       
	private Inj0101Repository inj0101Repository;  
	
	@Resource                                                                                                       
	private Inj0102Repository inj0102Repository;  
	
	@Override
	@Route(global = true)
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ0101U01SaveLayoutRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();   
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Integer result = null;
		
		for(INJ0101U01GrdMasterItemInfo info : request.getGrdMasterItemInfoList()){
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				insertInj0101(info, request.getUserId(), hospitalCode, language);
				result = 1;
			}else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				result = inj0101Repository.updateINJ0101WhereHospCodeCodeType(request.getUserId(), new Date(),
						info.getCodeTypeName(), info.getAdminGubun(), info.getRemark(), info.getCodeType(), language);
			}else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				result = inj0101Repository.deleteINJ0101U00UpdateINJ0101(info.getCodeType(), language);
			}
		}
		
		response.setResult(result != null && result > 0);
		return response.build();
	}

	@Override
	@Route(global = false)
	public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			INJ0101U01SaveLayoutRequest request, UpdateResponse rs) throws Exception {
	
		SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Integer result = null;
		
		for(INJ0101U01GrdDetailItemInfo  info : request.getGrdDetailItemInfoList()){
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				insertInj0102(info, request.getUserId(), hospitalCode, language);
				result = 1;
			}else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				result = inj0102Repository.updateINJ0101WhereHospCodeCodeTypeCode(request.getUserId(), new Date(), info.getCodeName(), info.getRemark(), 
						hospitalCode, info.getCodeType(), info.getCode(), language);
			}else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				result = inj0102Repository.deleteINJ0101U00UpdateINJ0102(hospitalCode, info.getCodeType(), info.getCode(), language);
			}
		}
		
		response.setResult(result != null && result > 0);
		return response.build();
	}
	
	
	private void insertInj0101(INJ0101U01GrdMasterItemInfo info, String userId, String hospitalCode, String language){
		Inj0101 inj0101 = new Inj0101();
		inj0101.setSysDate(new Date());
		inj0101.setSysId(userId);
		inj0101.setUpdDate(new Date());
		inj0101.setUpdId(userId);
		inj0101.setCodeType(StringUtils.isEmpty(info.getCodeType()) ? null : info.getCodeType());
		inj0101.setCodeTypeName(info.getCodeTypeName());
		inj0101.setAdminGubun(info.getAdminGubun());
		inj0101.setRemark(info.getRemark());
		inj0101.setLanguage(language);
		inj0101Repository.save(inj0101);
	}
	private void insertInj0102(INJ0101U01GrdDetailItemInfo info, String userId, String hospitalCode, String language){
		Inj0102 inj0102 = new Inj0102();
		inj0102.setSysDate(new Date());
		inj0102.setSysId(userId);
		inj0102.setUpdDate(new Date());
		inj0102.setUpdId(userId);
		inj0102.setHospCode(hospitalCode);
		inj0102.setCodeType(StringUtils.isEmpty(info.getCodeType()) ? null : info.getCodeType());
		inj0102.setCode(StringUtils.isEmpty(info.getCode()) ? null : info.getCode());
		inj0102.setCodeName(info.getCodeName());
		inj0102.setRemark(info.getRemark());
		inj0102.setLanguage(language);
		inj0102Repository.save(inj0102);
		
	}
	
}