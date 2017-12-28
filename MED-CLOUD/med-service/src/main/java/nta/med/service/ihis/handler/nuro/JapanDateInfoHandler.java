package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class JapanDateInfoHandler  extends ScreenHandler<NuroServiceProto.JapanDateInfoRequest, NuroServiceProto.JapanDateInfoResponse>{
	private static final Log logger = LogFactory.getLog(JapanDateInfoHandler.class);
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.JapanDateInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.JapanDateInfoRequest request) throws Exception {
		NuroServiceProto.JapanDateInfoResponse.Builder response = NuroServiceProto.JapanDateInfoResponse.newBuilder();
		String result = bas0102Repository.getJapanDateInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getNaewonDate());
        if(!StringUtils.isEmpty(result)) {
        	NuroModelProto.JapanDateInfo.Builder builder = NuroModelProto.JapanDateInfo.newBuilder();
        	builder.setNaewonDateJp(result);
            response.addJpDateInfo(builder);
        }
		return response.build();
	}
}
