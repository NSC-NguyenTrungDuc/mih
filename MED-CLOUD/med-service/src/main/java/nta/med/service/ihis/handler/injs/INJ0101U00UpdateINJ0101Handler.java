package nta.med.service.ihis.handler.injs;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.inj.Inj0101;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.inj.Inj0101Repository;
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
public class INJ0101U00UpdateINJ0101Handler extends ScreenHandler<InjsServiceProto.INJ0101U00UpdateINJ0101Request, SystemServiceProto.UpdateResponse> {
private static final Log LOGGER = LogFactory.getLog(INJ0101U00UpdateINJ0101Handler.class);
	
    @Resource
    private  Inj0101Repository inj0101Repository;
    
	@Override
	@Route(global = true)
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ0101U00UpdateINJ0101Request request) throws Exception {
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer result = null;
		result = processInj0101(request, hospitalCode, language);
		response.setResult(result != null && result > 0);
		return response.build();
	}
    
    private Integer processInj0101(InjsServiceProto.INJ0101U00UpdateINJ0101Request request, String hospitalCode, String language) {
    	LOGGER.info("[START] processOcs0301");
    	Integer result = null;
    	if(DataRowState.ADDED.getValue().equals(request.getRowState())) {
    		insertInj0101(request, hospitalCode, language);
    		return 1;
    	} else if(DataRowState.MODIFIED.getValue().equals(request.getRowState())) {
    		result = inj0101Repository.updateINJ0101U00UpdateINJ0101(request.getUserId(), new Date(), request.getCodeTypeName(), request.getCodeType(), language);
    	} else if(DataRowState.DELETED.getValue().equals(request.getRowState())) {
    		result = inj0101Repository.deleteINJ0101U00UpdateINJ0101(request.getCodeType(), language);
    	}
    	LOGGER.info("processOcs0301 result=" + result);
    	return result;
    }
    
    private void insertInj0101(InjsServiceProto.INJ0101U00UpdateINJ0101Request request, String hospitalCode, String language) {
    	Inj0101 inj0101 = new Inj0101();
    	Date sysDate = new Date();
    	inj0101.setSysDate(sysDate);
    	inj0101.setSysId(request.getUserId());
    	inj0101.setUpdDate(sysDate);
    	inj0101.setUpdId(request.getUserId());
    	inj0101.setCodeType(request.getCodeType());
    	inj0101.setCodeTypeName(request.getCodeTypeName());
    	inj0101.setLanguage(language);
    	inj0101Repository.save(inj0101);
    }
}
