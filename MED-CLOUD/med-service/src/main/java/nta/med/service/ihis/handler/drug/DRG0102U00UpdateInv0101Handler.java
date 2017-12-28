package nta.med.service.ihis.handler.drug;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.inv.Inv0101;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.inv.Inv0101Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrugServiceProto;
import nta.med.service.ihis.proto.DrugServiceProto.DRG0102U00UpdateInv0101Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service
@Scope("prototype")
public class DRG0102U00UpdateInv0101Handler extends ScreenHandler<DrugServiceProto.DRG0102U00UpdateInv0101Request, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(DRG0102U00UpdateInv0101Handler.class);
	
	@Resource
	private Inv0102Repository inv0102Repository;
	
	@Resource
	private Inv0101Repository inv0101Repository;
	
	@Override
	@Route(global = true)
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRG0102U00UpdateInv0101Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String language = getLanguage(vertx, sessionId);
		boolean result = updateInv0101(request, language);
        response.setResult(result);
		return response.build();
	}
	
	@Override
	@Route(global = false)
	public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG0102U00UpdateInv0101Request request, UpdateResponse rs) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		if(DataRowState.DELETED.getValue().equals(request.getRowState())){
			String exits = inv0102Repository.checkDRG0102U00CheckExitToDelete(hospitalCode, request.getCodeType(), language);
			if(exits.equals("X")){
				if(inv0102Repository.deleteDRG0102U00UpdateInv0101(request.getCodeType(), hospitalCode, language)>0){
					response.setResult(true);
				}else{
					response.setResult(false);
				}
			}
		}
		
		return response.build();
	}
	
	public boolean updateInv0101(DrugServiceProto.DRG0102U00UpdateInv0101Request request, String language){
		try {
			if(DataRowState.ADDED.getValue().equals(request.getRowState())) {
				Inv0101 inv0101 = new Inv0101();
				inv0101.setSysDate(new Date());
				inv0101.setSysId(request.getUserId());
				inv0101.setUpdDate(new Date());
				inv0101.setUpdId(request.getUserId());
				inv0101.setCodeType(request.getCodeType());
				inv0101.setCodeTypeName(request.getCodeTypeName());
				inv0101.setLanguage(language);
				inv0101Repository.save(inv0101);
				return true;
			} else if(DataRowState.MODIFIED.getValue().equals(request.getRowState())){
				if (inv0101Repository.updateDRG0102U00UpdateInv0101(request.getUserId(), new Date(),request.getCodeType(), request.getCodeTypeName(), language) > 0){
					return true;
				}
			} else if(DataRowState.DELETED.getValue().equals(request.getRowState())){
				
				return (inv0101Repository.deleteDRG0102U00UpdateInv0101(request.getCodeType(), language)>0);
			}
		}catch (Exception e) {
			LOGGER.error(e.getMessage(), e);
			return false;
		}
		
		return false;
	}
	
}
