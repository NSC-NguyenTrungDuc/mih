package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q12UpdateKensaYnRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class SCH0201Q12UpdateKensaYnHandler 
	extends ScreenHandler<SchsServiceProto.SCH0201Q12UpdateKensaYnRequest, SystemServiceProto.UpdateResponse> {
	@Resource
	private Out1001Repository out1001Repository;
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH0201Q12UpdateKensaYnRequest request) throws Exception {
			SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		if (!StringUtils.isEmpty(request.getPkout1001())) {
			Double pkout1001 = CommonUtils.parseDouble(request.getPkout1001());
			if(out1001Repository.updateSchsSCH0201Q12UpdateKensaYn(getHospitalCode(vertx, sessionId),pkout1001)>0)
				response.setResult(true);
			else response.setResult(false);
		}
		else response.setResult(false);
		return response.build();
	}
}
