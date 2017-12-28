package nta.med.service.ihis.handler.invs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inv.Inv0101Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.CheckDuplicateDataINV0101Request;
import nta.med.service.ihis.proto.InvsServiceProto.CheckDuplicateDataINV0101Response;

@Service
@Scope("prototype")
public class CheckDuplicateDataINV0101Handler extends
		ScreenHandler<InvsServiceProto.CheckDuplicateDataINV0101Request, InvsServiceProto.CheckDuplicateDataINV0101Response> {

	@Resource
    private Inv0101Repository inv0101Repository;
	
	@Resource
    private Inv0102Repository inv0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CheckDuplicateDataINV0101Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CheckDuplicateDataINV0101Request request) throws Exception {
		
		InvsServiceProto.CheckDuplicateDataINV0101Response.Builder response = InvsServiceProto.CheckDuplicateDataINV0101Response.newBuilder();
		
		if("Y".equals(request.getIsMaster())){
			String strCheckMaster = inv0101Repository.checkDRG0102U00GrdMasterGridColumnChanged(request.getCodeType(), getLanguage(vertx, sessionId));
			if(!StringUtils.isEmpty(strCheckMaster)){
				response.setCheckMaster("Y");
			} else {
				response.setCheckMaster("N");
			}
		} else if("N".equals(request.getIsMaster())){
			String strCheckDetail = inv0102Repository.checkDrg0102U01GrdDetail(getHospitalCode(vertx, sessionId), request.getCodeType(), request.getCode(), getLanguage(vertx, sessionId));
			if(!StringUtils.isEmpty(strCheckDetail)){
				response.setCheckDetail("Y");
			} else {
				response.setCheckDetail("N");
			}
		}
		
		return response.build();
	}
	
}
