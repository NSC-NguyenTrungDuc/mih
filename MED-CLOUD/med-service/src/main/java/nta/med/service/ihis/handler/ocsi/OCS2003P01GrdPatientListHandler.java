package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.ocsi.OCS2003P01GrdPatientListInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01GrdPatientListRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01GrdPatientListResponse;

@Service
@Scope("prototype")
public class OCS2003P01GrdPatientListHandler extends
		ScreenHandler<OcsiServiceProto.OCS2003P01GrdPatientListRequest, OcsiServiceProto.OCS2003P01GrdPatientListResponse> {

	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS2003P01GrdPatientListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01GrdPatientListRequest request) throws Exception {
		OcsiServiceProto.OCS2003P01GrdPatientListResponse.Builder response = OcsiServiceProto.OCS2003P01GrdPatientListResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS2003P01GrdPatientListInfo> listInfo = ocs2003Repository.getOCS2003P01GrdPatientListInfo(hospCode
				, language
				, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD)
				, request.getInputGubun()
				, request.getApproveDoctor()
				, request.getBunho()
				, request.getDoctorYn()
				, request.getDoctor()
				, request.getHoDong());
		
		if(!CollectionUtils.isEmpty(listInfo)){
			for (OCS2003P01GrdPatientListInfo info : listInfo) {
				OcsiModelProto.OCS2003P01GrdPatientListInfo.Builder pInfo = OcsiModelProto.OCS2003P01GrdPatientListInfo.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addGrdList(pInfo);
			}
		}
		
		return response.build();
	}

}
