package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang3.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.out.Out0102;
import nta.med.core.domain.out.Out0105;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.core.utils.OrcaUtils;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.dao.medi.out.Out0105Repository;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetPatientInsRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetPatientInsResponse;

@Service
@Scope("prototype")
public class GetPatientInsHandler
		extends ScreenHandler<SystemServiceProto.GetPatientInsRequest, SystemServiceProto.GetPatientInsResponse> {

	@Resource
	private Out0102Repository out0102Repository;

	@Resource
	private Out0105Repository out0105Repository;

	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public GetPatientInsResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			GetPatientInsRequest request) throws Exception {

		SystemServiceProto.GetPatientInsResponse.Builder response = SystemServiceProto.GetPatientInsResponse
				.newBuilder();

		String hospCode = request.getHospCode();
		if (StringUtils.isEmpty(hospCode)) {
			hospCode = getHospitalCode(vertx, sessionId);
		}

		List<Out0102> privateInsList = out0102Repository.findByHospCodeBunho(hospCode, request.getPatientCode());
		if (!CollectionUtils.isEmpty(privateInsList)) {
			for (Out0102 item : privateInsList) {
				SystemModelProto.PrivateInsInfo.Builder builder = SystemModelProto.PrivateInsInfo.newBuilder();
				
				String bonGaGubun = item.getBonGaGubun() != null ? item.getBonGaGubun() : "";
				if("0".equals(bonGaGubun)){
					bonGaGubun = "1";
				} else if("1".equals(bonGaGubun)){
					bonGaGubun = "2";
				}
				
				builder.setGubun(item.getGubun() != null ? OrcaUtils.getClassCodeByInsurCode(item.getGubun()) : "");
				builder.setJohap(item.getJohap() != null ? item.getJohap() : "");
				builder.setPiname(item.getPiname() != null ? item.getPiname() : "");
				builder.setGaein(item.getGaein() != null ? item.getGaein() : "");
				builder.setGaeinNo(item.getGaeinNo() != null ? item.getGaeinNo() : "");
				builder.setBonGaGubun(bonGaGubun);
				if (item.getStartDate() != null) {
					builder.setStartDate(DateUtil.toString(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
				}

				if (item.getEndDate() != null) {
					builder.setEndDate(DateUtil.toString(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
				}

				if (item.getChuidukDate() != null) {
					builder.setChuiduckDate(DateUtil.toString(item.getChuidukDate(), DateUtil.PATTERN_YYMMDD));
				}

				response.addPriInfo(builder.build());
			}
		}

		List<Out0105> publicInsList = out0105Repository.findByHospCodeBunho(hospCode, request.getPatientCode());
		if (!CollectionUtils.isEmpty(publicInsList)) {
			for (Out0105 item : publicInsList) {
				SystemModelProto.PublicInsInfo.Builder builder = SystemModelProto.PublicInsInfo.newBuilder();
				builder.setGongbiCode(item.getGongbiCode() != null ? item.getGongbiCode() : "");
				builder.setBudamjaBunho(item.getBudamjaBunho() != null ? item.getBudamjaBunho() : "");
				builder.setSugubjaBunho(item.getSugubjaBunho() != null ? item.getSugubjaBunho() : "");
				if (item.getStartDate() != null) {
					builder.setStartDate(DateUtil.toString(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
				}

				if (item.getEndDate() != null) {
					builder.setEndDate(DateUtil.toString(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
				}

				response.addPubInfo(builder.build());
			}
		}

		return response.build();
	}

}
