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
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10LoadDetailDataInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10LoadDetailDataRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10LoadDetailDataResponse;

@Service
@Scope("prototype")
public class OCS6010U10LoadDetailDataHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10LoadDetailDataRequest, OcsiServiceProto.OCS6010U10LoadDetailDataResponse> {

	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Override
	@Transactional
	public OCS6010U10LoadDetailDataResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10LoadDetailDataRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10LoadDetailDataResponse.Builder response = OcsiServiceProto.OCS6010U10LoadDetailDataResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS6010U10LoadDetailDataInfo> listInfo = ocs6010Repository.getOCS6010U10LoadDetailDataInfo(hospCode
				, language
				, request.getBunho()
				, CommonUtils.parseDouble(request.getFkinp1001())
				, DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD)
				, DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD)
				, request.getAllSiji()
				, request.getEmerTreat()
				, request.getInsteadOrdDisp()
				, request.getBVal()
				, request.getCVal()
				, request.getDVal()
				, request.getHVal()
				, request.getGVal()
				, request.getMVal()
				, request.getFVal()
				, request.getOVal()
				, request.getNVal()
				, request.getEVal()
				, request.getLVal()
				, request.getKVal()
				, request.getIVal()
				, request.getZVal()
				, request.getCommentYn()
				, request.getRemarkYn());
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (OCS6010U10LoadDetailDataInfo info : listInfo) {
			OcsiModelProto.OCS6010U10LoadDetailDataInfo.Builder pInfo = OcsiModelProto.OCS6010U10LoadDetailDataInfo.newBuilder();
			BeanUtils.copyProperties(info, pInfo, language);
			
			if (info.getFkinp1001() != null) {
				pInfo.setFkinp1001(String.format("%.0f",info.getFkinp1001()));
			}
			
			if (info.getFkocs6010() != null) {
				pInfo.setFkocs6010(String.format("%.0f",info.getFkocs6010()));
			}
			
			if (info.getSuryang() != null) {
				pInfo.setSuryang(String.format("%.0f",info.getSuryang()));
			}
			
			if (info.getNalsu() != null) {
				pInfo.setNalsu(String.format("%.0f",info.getNalsu()));
			}
			
			if (info.getJaewonil() != null) {
				pInfo.setJaewonil(String.format("%.0f",info.getJaewonil()));
			}
			
			if (info.getPk() != null) {
				pInfo.setPk(String.format("%.0f",info.getPk()));
			}
			
			if (info.getInputSeq() != null) {
				pInfo.setInputSeq(String.format("%.0f",info.getInputSeq()));
			}
			
			if (info.getPkocs2005() != null) {
				pInfo.setPkocs2005(String.format("%.0f",info.getPkocs2005()));
			}
			
			if (info.getPkocs6015() != null) {
				pInfo.setPkocs6015(String.format("%.0f",info.getPkocs6015()));
			}
			
			if (info.getDv() != null) {
				pInfo.setDv(String.format("%.0f",info.getDv()));
			}
			
			if (info.getFkocs1003() != null) {
				pInfo.setFkocs1003(String.format("%.0f",info.getFkocs1003()));
			}
			
			response.addDetailLst(pInfo);
		}
		
		return response.build();
	}

}
