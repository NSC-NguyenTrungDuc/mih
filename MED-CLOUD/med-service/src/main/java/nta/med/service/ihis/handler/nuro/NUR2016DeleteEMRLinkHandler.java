package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.out.Out2016;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out2016Repository;
import nta.med.data.model.ihis.nuro.LinkEMRPatientInfo;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.NUR2016DeleteEMRLinkRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

/**
 * @author DEV-NgocNV
 *
 */

@Transactional
@Service
@Scope("prototype")
public class NUR2016DeleteEMRLinkHandler
		extends ScreenHandler<NuroServiceProto.NUR2016DeleteEMRLinkRequest, SystemServiceProto.UpdateResponse> {
	private static final Log logger = LogFactory.getLog(NUR2016DeleteEMRLinkHandler.class);

	@Resource
	private Out2016Repository out2016Repository;

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2016DeleteEMRLinkRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Long patientId = CommonUtils.parseLong(request.getPatientId()); // patientId from hospital A to hospital B
		Long patientId2 = null;                                         // patientId2 from hospital B to hospital A
		Out2016 out2016 = out2016Repository.getOut2016ById(patientId);
		if(out2016 != null){
			List<LinkEMRPatientInfo> linkEMRPatientInfo = out2016Repository.getLinkEMRPatientInfo(out2016.getHospCodeLink(),
					out2016.getBunhoLink(), out2016.getHospCode(), out2016.getBunho());
			if(!CollectionUtils.isEmpty(linkEMRPatientInfo)){
				patientId2 =  CommonUtils.parseLong(String.valueOf(linkEMRPatientInfo.get(0).getPatientId()));
			}
		}
		
		boolean result = deleteEMRLink(patientId, patientId2);
		response.setResult(result);
		return response.build();
	}

	private boolean deleteEMRLink(Long patientId, Long patientId2) {
		if (out2016Repository.deleteEMRLink(patientId) > 0 && out2016Repository.deleteEMRLink(patientId2) > 0)
			return true;
		return false;

		/*
		 * Integer rs = out2016Repository.deleteEMRLink(CommonUtils.parseLong(request.getPatientId()));
		 * if(rs > 0)
		 *     return true;
		 *     return false;
		 */
	}
}
