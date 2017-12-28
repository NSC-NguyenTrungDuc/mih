package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0250;
import nta.med.core.domain.bas.Bas0251;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.dao.medi.bas.Bas0251Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01MultiComboRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01MultiComboResponse;

@Service
@Scope("prototype")
public class INP1001U01MultiComboHandler extends ScreenHandler<InpsServiceProto.INP1001U01MultiComboRequest, InpsServiceProto.INP1001U01MultiComboResponse>{

	@Resource
	private Bas0250Repository bas0250Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
	private Bas0251Repository bas0251Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INP1001U01MultiComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01MultiComboRequest request) throws Exception {
		
		InpsServiceProto.INP1001U01MultiComboResponse.Builder response = InpsServiceProto.INP1001U01MultiComboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		if(!StringUtils.isEmpty(request.getKaikeiHodong())){
			List<Bas0250> lstHocode = bas0250Repository.findByHospCodeHoDong(hospCode, request.getKaikeiHodong());
			
			// cbo_kaikei_hocode
			if(!CollectionUtils.isEmpty(lstHocode)){
				for (Bas0250 info : lstHocode) {
					CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder()
							.setCode(info.getHoCode())
							.setCodeName(info.getHoCode());
					
					response.addCboKaikeiHocode(protoInfo);
				}
			}
		} else {
			List<ComboListItemInfo> lstEmergencyGubun = bas0102Repository.getCodeNameListItem(hospCode, "EMERGENCY_GUBUN", "1", language);
			List<ComboListItemInfo> lstChojae = bas0102Repository.getCodeNameListItem(hospCode, "CHOJAE", "1", language);
			List<ComboListItemInfo> lstBabyStatus = bas0102Repository.getCodeNameListItem(hospCode, "BABY_STATUS", "1", language);
			List<ComboListItemInfo> lstIpwonRtn2 = bas0102Repository.getCodeNameListItem(hospCode, "IPWON_RTN2", "1", language);
			List<Bas0251> lstHoGrade = bas0251Repository.findByHospCode(hospCode);
			List<ComboListItemInfo> lstIpwonType = bas0102Repository.getCodeNameListItem(hospCode, "IPWON_TYPE", "1", language);
			
			// cbo_emergency_gubun
			if(!CollectionUtils.isEmpty(lstEmergencyGubun)){
				for (ComboListItemInfo info : lstEmergencyGubun) {
					CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder()
							.setCode(info.getCode())
							.setCodeName(info.getCodeName());
					
					response.addCboEmergencyGubun(protoInfo);
				}
			}
			
			// cbo_chojae
			if(!CollectionUtils.isEmpty(lstChojae)){
				for (ComboListItemInfo info : lstChojae) {
					CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder()
							.setCode(info.getCode())
							.setCodeName(info.getCodeName());
					
					response.addCboChojae(protoInfo);
				}
			}
			
			// cbo_baby_status
			if(!CollectionUtils.isEmpty(lstBabyStatus)){
				for (ComboListItemInfo info : lstBabyStatus) {
					CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder()
							.setCode(info.getCode())
							.setCodeName(info.getCodeName());
					
					response.addCboBabyStatus(protoInfo);
				}
			}
			
			// cbo_ipwon_rtn_2
			if(!CollectionUtils.isEmpty(lstIpwonRtn2)){
				for (ComboListItemInfo info : lstIpwonRtn2) {
					CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder()
							.setCode(info.getCode())
							.setCodeName(info.getCodeName());
					
					response.addCboIpwonRtn2(protoInfo);
				}
			}
			
			// cbo_ho_grade_1
			if(!CollectionUtils.isEmpty(lstHoGrade)){
				for (Bas0251 info : lstHoGrade) {
					CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder()
							.setCode(info.getHoGrade())
							.setCodeName(info.getHoGradeName() == null ? "" : info.getHoGradeName());
					
					response.addCboHoGrade1(protoInfo);
				}
			}
			
			// cbo_ipwon_type
			if(!CollectionUtils.isEmpty(lstIpwonType)){
				for (ComboListItemInfo info : lstIpwonType) {
					CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder()
							.setCode(info.getCode())
							.setCodeName(info.getCodeName());
					
					response.addCboIpwonType(protoInfo);
				}
			}
		}
		
		return response.build();
	}
	
}
