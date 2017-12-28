package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.bass.Inp1003U00FwkGwaListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01FindBoxFindClickRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class INP1001U01FindBoxFindClickHandler
		extends ScreenHandler<InpsServiceProto.INP1001U01FindBoxFindClickRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01FindBoxFindClickRequest request) throws Exception {
		
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String controlName = request.getControlName();
		String buseoYmd = request.getBuseoYmd();
		String find1 = request.getFind1();
		String gwa = request.getGwa();
		String ipwonDate = request.getIpwonDate();
		String codeType = request.getCodeType();
		
		List<ComboListItemInfo> lstDoctor = null;
		
		switch (controlName) {
		case "fbxGwa":
			List<Inp1003U00FwkGwaListItemInfo> lstGwa = bas0260Repository.getInp1003U00FwkGwaListItemInfo(hospCode, buseoYmd, find1);
			if(!CollectionUtils.isEmpty(lstGwa)){
				for (Inp1003U00FwkGwaListItemInfo info : lstGwa) {
					CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder()
							.setCode(info.getGwa())
							.setCodeName(info.getGwaName());
					response.addComboItem(protoInfo);
				}
			}
			break;
		case "fbxDoctor":
			lstDoctor = bas0270Repository.findByHospCodeDoctorGwaFDate(hospCode, gwa, ipwonDate);
			break;
		case "fbxJisiDoctor":
			lstDoctor = bas0270Repository.findByHospCodeDoctorGwaFDate(hospCode, gwa, ipwonDate);
			break;
		case "fbxBoninGubun":
			List<ComboListItemInfo> lstItem = bas0102Repository.getBAS0001U00FbxDodobuHyeunFindClick(hospCode, language, codeType, find1);
			if(!CollectionUtils.isEmpty(lstItem)){
				for (ComboListItemInfo info : lstItem) {
					CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder()
							.setCode(info.getCode())
							.setCodeName(info.getCodeName());
					response.addComboItem(protoInfo);
				}
			}
			break;
		default:
			break;
		}
		
		if(!CollectionUtils.isEmpty(lstDoctor)){
			for (ComboListItemInfo bas0270 : lstDoctor) {
				CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(bas0270.getCode())
						.setCodeName(bas0270.getCodeName());
				response.addComboItem(protoInfo);
			}
		}
		
		return response.build();
	}

	
}
