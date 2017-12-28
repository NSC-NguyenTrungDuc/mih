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
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.ocsi.OCS2003P01LayQueryLayoutInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01LayQueryLayoutRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01LayQueryLayoutResponse;

@Service
@Scope("prototype")
public class OCS2003P01LayQueryLayoutHandler extends ScreenHandler<OcsiServiceProto.OCS2003P01LayQueryLayoutRequest , OcsiServiceProto.OCS2003P01LayQueryLayoutResponse>{
	
	@Resource
	private Ocs2003Repository ocs2003Repository;

	@Override
	@Transactional(readOnly=true)
	public OCS2003P01LayQueryLayoutResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01LayQueryLayoutRequest request) throws Exception {
		
		OcsiServiceProto.OCS2003P01LayQueryLayoutResponse.Builder response = OcsiServiceProto.OCS2003P01LayQueryLayoutResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String bunho = request.getBunho();
		String fkinp1001 = request.getFkinp1001();
		String orderDate = request.getOrderDate();
		
		String queryGubun = request.getQueryGubun();
		String inputDoctor = request.getInputDoctor();
		String inputGubun = request.getInputGubun();
		
		List<OCS2003P01LayQueryLayoutInfo> listInfo = ocs2003Repository.getOCS2003P01LayQueryLayout(hospCode, language, bunho, fkinp1001, orderDate, queryGubun, inputDoctor, inputGubun);
		if(!CollectionUtils.isEmpty(listInfo)){
			for(OCS2003P01LayQueryLayoutInfo item : listInfo){
				OcsiModelProto.OCS2003P01LayQueryLayoutInfo.Builder info = OcsiModelProto.OCS2003P01LayQueryLayoutInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				
				if (item.getInOutKey() != null) {
					info.setInOutKey(String.format("%.0f",item.getInOutKey()));
				}
				if (item.getPkocskey() != null) {
					info.setPkocskey(String.format("%.0f",item.getPkocskey()));
				}
				if (item.getSeq() != null) {
					info.setSeq(String.format("%.0f",item.getSeq()));
				}
				if (item.getSuryang() != null) {
					info.setSuryang(String.format("%.0f",item.getSuryang()));
				}
				if (item.getSunabSuryang() != null) {
					info.setSunabSuryang(String.format("%.0f",item.getSunabSuryang()));
				}
				if (item.getSubulSuryang() != null) {
					info.setSubulSuryang(String.format("%.0f",item.getSubulSuryang()));
				}
				if (item.getDv() != null) {
					info.setDv(String.format("%.0f",item.getDv()));
				}
				if (item.getDv1() != null) {
					info.setDv1(String.format("%.0f",item.getDv1()));
				}
				if (item.getDv2() != null) {
					info.setDv2(String.format("%.0f",item.getDv2()));
				}
				if (item.getDv3() != null) {
					info.setDv3(String.format("%.0f",item.getDv3()));
				}
				if (item.getDv4() != null) {
					info.setDv4(String.format("%.0f",item.getDv4()));
				}
				if (item.getAmt() != null) {
					info.setAmt(String.format("%.0f",item.getAmt()));
				}
				if (item.getActingDay() != null) {
					info.setActingDay(String.format("%.0f",item.getActingDay()));
				}
				if (item.getSourceOrdKey() != null) {
					info.setSourceOrdKey(String.format("%.0f",item.getSourceOrdKey()));
				}
				if (item.getOrgKey() != null) {
					info.setOrgKey(String.format("%.0f",item.getOrgKey()));
				}
				if (item.getParentKey() != null) {
					info.setParentKey(String.format("%.0f",item.getParentKey()));
				}
				if (item.getDv5() != null) {
					info.setDv5(String.format("%.0f",item.getDv5()));
				}
				if (item.getDv6() != null) {
					info.setDv6(String.format("%.0f",item.getDv6()));
				}
				if (item.getDv7() != null) {
					info.setDv7(String.format("%.0f",item.getDv7()));
				}
				if (item.getDv8() != null) {
					info.setDv8(String.format("%.0f",item.getDv8()));
				}
				if (item.getLimitNalsu() != null) {
					info.setLimitNalsu(String.format("%.0f",item.getLimitNalsu()));
				}
				if (item.getLimitSuryang() != null) {
					info.setLimitSuryang(String.format("%.0f",item.getLimitSuryang()));
				}
				
				response.addGrdList(info);
			}
		}
		
		return response.build();
	}
}
