package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out2016Repository;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.NUR2016PublishEMRLinkRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

/**
 * @author DEV-NgocNV
 *
 */

@Transactional
@Service
@Scope("prototype")
public class NUR2016PublishEMRLinkHandler
		extends ScreenHandler<NuroServiceProto.NUR2016PublishEMRLinkRequest, SystemServiceProto.UpdateResponse> {
	private static final Log logger = LogFactory.getLog(NUR2016PublishEMRLinkHandler.class);

	@Resource
	private Out2016Repository out2016Repository;

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2016PublishEMRLinkRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();

		boolean result = publishEMRLink(request, request.getPatientId(), request.getIscheck());
		response.setResult(result);
		return response.build();
	}

	private boolean publishEMRLink(NuroServiceProto.NUR2016PublishEMRLinkRequest request, String patientId,
			boolean isCheck) {
		if (isCheck) {
			if (out2016Repository.activeEMRLink(CommonUtils.parseLong(request.getPatientId())) > 0) {
				return true;
			} else {
				return false;
			}

		} else {
			if (out2016Repository.deactiveEMRLink(CommonUtils.parseLong(request.getPatientId())) > 0) {
				return true;
			} else {
				return false;
			}
		}
	}
}
