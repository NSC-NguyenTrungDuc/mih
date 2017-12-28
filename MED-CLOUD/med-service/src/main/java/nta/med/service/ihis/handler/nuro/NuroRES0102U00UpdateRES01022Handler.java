package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.res.Res0102Repository;
import nta.med.data.model.ihis.nuro.NuroRES0102U00UpdateRES0102Info;
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
public class NuroRES0102U00UpdateRES01022Handler extends ScreenHandler<NuroServiceProto.NuroRES0102U00UpdateRES0102Req2Request, SystemServiceProto.UpdateResponse>{
	private static final Log logger = LogFactory.getLog(NuroRES0102U00UpdateRES01022Handler.class);
	private NuroRES0102U00UpdateRES0102Info nuroRES0102U00UpdateRES0102Info;
	
	@Resource
	private Res0102Repository res0102Repository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00UpdateRES0102Req2Request request) throws Exception {
		nuroRES0102U00UpdateRES0102Info = new NuroRES0102U00UpdateRES0102Info();
        BeanUtils.copyProperties(request, nuroRES0102U00UpdateRES0102Info, getLanguage(vertx, sessionId));
    	boolean result = res0102Repository.updateNuroRES0102U00UpdateRES0102Info(getHospitalCode(vertx, sessionId), nuroRES0102U00UpdateRES0102Info);
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        response.setResult(result);
		return response.build();
	}

}
