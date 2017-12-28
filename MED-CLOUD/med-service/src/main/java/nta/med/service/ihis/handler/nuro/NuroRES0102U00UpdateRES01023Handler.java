package nta.med.service.ihis.handler.nuro;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import javax.annotation.Resource;

import nta.med.data.dao.medi.res.Res0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class NuroRES0102U00UpdateRES01023Handler extends ScreenHandler<NuroServiceProto.NuroRES0102U00UpdateRES0102Req3Request, SystemServiceProto.UpdateResponse>{
private static final Log logger = LogFactory.getLog(NuroRES0102U00UpdateRES01023Handler.class);
	
	@Resource
	private Res0102Repository res0102Repository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00UpdateRES0102Req3Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = updateRes0102(request, getHospitalCode(vertx, sessionId));
        response.setResult(result);
		return response.build();
	}
	
	private boolean updateRes0102(NuroServiceProto.NuroRES0102U00UpdateRES0102Req3Request request, String hospCode) throws ParseException {
		SimpleDateFormat dateFormat = new SimpleDateFormat( "yyyy/MM/dd" );
		Calendar cal = Calendar.getInstance();
		cal.setTime( dateFormat.parse( request.getStartDate()));
		cal.add(Calendar.DATE, -1);
		
		if(res0102Repository.updateRES0102Request3(hospCode, request.getDoctor(), cal.getTime()) > 0)
		return true;
		return false;
	}
}
