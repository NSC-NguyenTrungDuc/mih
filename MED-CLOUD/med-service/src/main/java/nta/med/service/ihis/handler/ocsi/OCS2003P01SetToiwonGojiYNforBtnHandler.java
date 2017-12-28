package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01SetToiwonGojiYNforBtnRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003P01SetToiwonGojiYNforBtnHandler extends ScreenHandler<OcsiServiceProto.OCS2003P01SetToiwonGojiYNforBtnRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Out0101Repository out0101Repository;
		
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01SetToiwonGojiYNforBtnRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = out0101Repository.OCSLibOrderBizGetIsToiwonGojiYNandEndOrder(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkinp1001()));
		response.setResult(StringUtils.isEmpty(result) ? "" : result);
		
		return response.build();
	}

}
