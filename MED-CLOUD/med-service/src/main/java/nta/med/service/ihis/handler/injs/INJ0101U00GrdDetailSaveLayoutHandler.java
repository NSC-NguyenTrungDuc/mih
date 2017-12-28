package nta.med.service.ihis.handler.injs;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.inj.Inj0102;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.inj.Inj0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto.INJ0101U00GrdDetailInfo;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class INJ0101U00GrdDetailSaveLayoutHandler extends ScreenHandler<InjsServiceProto.INJ0101U00GrdDetailSaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(INJ0101U00GrdDetailSaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Inj0102Repository inj0102Repository;                                                                    
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ0101U00GrdDetailSaveLayoutRequest request) throws Exception {
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Integer result = null;
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder(); 
		for(INJ0101U00GrdDetailInfo  info : request.getGrdListList()){
			if(DataRowState.ADDED.getValue().equals(info.getRowState())) {
				insertInj0102(info, request.getUserId(), hospitalCode, language);
	    		result = 1;
	    	} else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
	    		result = inj0102Repository.updateINJ0101U00UpdateINJ0102(request.getUserId(), new Date(),
	    				info.getCodeName(), hospitalCode, info.getCodeType(), info.getCode(), language);
	    	} else if(DataRowState.DELETED.getValue().equals(info.getRowState())) {
	    		result=inj0102Repository.deleteINJ0101U00UpdateINJ0102(hospitalCode, info.getCodeType(), info.getCode(), language);
	    	}
		}
		response.setResult(result != null && result > 0);
		return response.build();
	}
	
	public void insertInj0102(INJ0101U00GrdDetailInfo  info ,String userId, String hospitalCode, String language){
		Inj0102 inj0102 = new Inj0102();
		inj0102.setSysDate(new Date());
		inj0102.setSysId(userId);
		inj0102.setUpdDate(new Date());
		inj0102.setUpdId(userId);
		inj0102.setHospCode(hospitalCode);
		inj0102.setCodeType(StringUtils.isEmpty(info.getCodeType()) ? null : info.getCodeType());
		inj0102.setCode(StringUtils.isEmpty(info.getCode()) ? null : info.getCode());
		inj0102.setCodeName(info.getCodeName());
		inj0102.setLanguage(language);
		inj0102Repository.save(inj0102);
	}
}