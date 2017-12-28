package nta.med.service.ihis.handler.injs;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.inj.Inj0102;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.inj.Inj0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class INJ0101U00UpdateINJ0102Handler extends ScreenHandler<InjsServiceProto.INJ0101U00UpdateINJ0102Request, SystemServiceProto.UpdateResponse> {
private static final Log LOGGER = LogFactory.getLog(INJ0101U00UpdateINJ0102Handler.class);
	
    @Resource
    private  Inj0102Repository inj0102Repository;
    
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ0101U00UpdateINJ0102Request request) throws Exception {
		Integer result = null;
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		result = processInj0102(request, hospitalCode, language);
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(result != null && result > 0);
		return response.build();
	}
    
    private Integer processInj0102(InjsServiceProto.INJ0101U00UpdateINJ0102Request request, String hospitalCode, String language) {
    	LOGGER.info("[START] processOcs0301");
    	Integer result = null;
    	if(DataRowState.ADDED.getValue().equals(request.getRowState())) {
    		insertInj0102(request, hospitalCode, language);
    		return 1;
    	} else if(DataRowState.MODIFIED.getValue().equals(request.getRowState())) {
    		result = inj0102Repository.updateINJ0101U00UpdateINJ0102(request.getUserId(), new Date(), request.getCodeName(), hospitalCode, request.getCodeType(), request.getCode(), language);
    	} else if(DataRowState.DELETED.getValue().equals(request.getRowState())) {
    		result = inj0102Repository.deleteINJ0101U00UpdateINJ0102(hospitalCode, request.getCodeType(), request.getCode(), language);
    	}
    	LOGGER.info("processOcs0301 result=" + result);
    	return result;
    }
    
    private void insertInj0102(InjsServiceProto.INJ0101U00UpdateINJ0102Request request, String hospitalCode, String language) {
    	Inj0102 inj0102 = new Inj0102();
    	Date sysDate = new Date();
    	inj0102.setSysDate(sysDate);
    	inj0102.setSysId(request.getUserId());
    	inj0102.setUpdDate(sysDate);
    	inj0102.setUpdId(request.getUserId());
    	inj0102.setHospCode(hospitalCode);
    	inj0102.setCodeType(request.getCodeType());
    	inj0102.setCode(request.getCode());
    	inj0102.setCodeName(request.getCodeName());
    	inj0102.setLanguage(language);
    	inj0102Repository.save(inj0102);
    }
}
