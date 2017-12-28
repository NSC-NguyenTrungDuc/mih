package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0101U00PrCplCopyCPL0101Request;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0101U00PrCplCopyCPL0101Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;
@Transactional
@Service
@Scope("prototype")
public class CPL0101U00PrCplCopyCPL0101Handler extends ScreenHandler<CplsServiceProto.CPL0101U00PrCplCopyCPL0101Request, CplsServiceProto.CPL0101U00PrCplCopyCPL0101Response> {
	private static final Log LOGGER = LogFactory.getLog(CPL0101U00PrCplCopyCPL0101Handler.class);
	@Resource
	private Cpl0101Repository cpl0101Repository;
	
	@Override
	public CPL0101U00PrCplCopyCPL0101Response handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0101U00PrCplCopyCPL0101Request request) throws Exception {
		CplsServiceProto.CPL0101U00PrCplCopyCPL0101Response.Builder response = CplsServiceProto.CPL0101U00PrCplCopyCPL0101Response.newBuilder();
		String result = cpl0101Repository.callPrCplCopyCpl0101(getHospitalCode(vertx, sessionId), request.getHangmogCode(), request.getSpecimenCode(), request.getEmergency(), 
				request.getNewSpecimenCode(), request.getNewEmergency(),"");
		if(result != null && !result.isEmpty()){
			response.setResult(true);
		} else{
			response.setResult(false);
		}

		return response.build();
	}
}
