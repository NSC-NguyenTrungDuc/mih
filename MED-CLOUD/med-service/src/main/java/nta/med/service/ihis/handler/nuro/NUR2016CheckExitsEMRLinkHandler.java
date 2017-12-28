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

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out2016Repository;
import nta.med.data.model.ihis.nuro.LinkEMRPatientInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

/**
 * @author DEV-NgocNV
 *
 */

@Service
@Scope("prototype")
public class NUR2016CheckExitsEMRLinkHandler extends
		ScreenHandler<NuroServiceProto.NUR2016CheckExitsEMRLinkRequest, NuroServiceProto.NUR2016CheckExitsEMRLinkResponse> {
	
	private static final Log logger = LogFactory.getLog(NUR2016CheckExitsEMRLinkHandler.class);
	
	@Resource
	private Out2016Repository out2016Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NUR2016CheckExitsEMRLinkResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, NuroServiceProto.NUR2016CheckExitsEMRLinkRequest request) throws Exception {
		NuroServiceProto.NUR2016CheckExitsEMRLinkResponse.Builder response = NuroServiceProto.NUR2016CheckExitsEMRLinkResponse
				.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);

		List<LinkEMRPatientInfo> linkEMRPatientInfo = out2016Repository.getLinkEMRPatientInfo(hospCode,
				request.getBunho(), request.getHospCodeLink(), request.getBunhoLink());

		if (!CollectionUtils.isEmpty(linkEMRPatientInfo)) {
			String result = CommonUtils.parseString(Integer.valueOf(linkEMRPatientInfo.size()));

			for (LinkEMRPatientInfo item : linkEMRPatientInfo) {
				NuroModelProto.LinkEMRPatientInfo.Builder info = NuroModelProto.LinkEMRPatientInfo.newBuilder();
				// BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setBunho(item.getBunhoLink());
				info.setPatientId(String.valueOf(item.getPatientId()));
				response.addLinkEmrPatientItem(info);
				response.setResult(result);
			}
		} else {
			response.setResult("0");
		}
		return response.build();
	}
}
