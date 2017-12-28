package nta.med.service.ihis.handler.bass;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0251Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.bass.HoGradeInfo;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetDepartmentInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00FindboxFindClickRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00FindboxFindClickResponse;

@Service
@Scope("prototype")
public class BAS0250U00FindboxFindClickHandler extends
		ScreenHandler<BassServiceProto.BAS0250U00FindboxFindClickRequest, BassServiceProto.BAS0250U00FindboxFindClickResponse> {

	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Resource
	private Bas0251Repository bas0251Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BAS0250U00FindboxFindClickResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BAS0250U00FindboxFindClickRequest request) throws Exception {
		
		BassServiceProto.BAS0250U00FindboxFindClickResponse.Builder response = BassServiceProto.BAS0250U00FindboxFindClickResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String ctrlName = request.getControlName();
		String jukyongDate = request.getJukyongDate();
		String find1 = request.getFind1();
		
		List<NuroOUT1001U01GetDepartmentInfo> deptList = new ArrayList<>();
		List<HoGradeInfo> hoGradeList = new ArrayList<>();
		
		switch (ctrlName) {
		case "fbxHoDong":
			deptList = bas0260Repository.getNuroOUT1001U01GetDepartmentInfo(language, hospCode, jukyongDate, "2", find1);
			break;
		case "fbxHoGrade":	
			hoGradeList = bas0251Repository.getHoGradeInfo(hospCode, find1, jukyongDate);
			break;
		case "fbxHoMainGwa":
			deptList = bas0260Repository.getNuroOUT1001U01GetDepartmentInfo(language, hospCode, jukyongDate, "1", find1);
			break;
		case "fbxGwa":
			deptList = bas0260Repository.getNuroOUT1001U01GetDepartmentInfo(language, hospCode, jukyongDate, "1", find1);
			break;
		default:
			break;
		}
		
		if(!CollectionUtils.isEmpty(deptList)){
			for (NuroOUT1001U01GetDepartmentInfo dept : deptList) {
				CommonModelProto.ComboListItemInfo.Builder infoBuilder = CommonModelProto.ComboListItemInfo.newBuilder();
				infoBuilder.setCode(dept.getGwa());
				infoBuilder.setCodeName(dept.getGwaName());
				response.addFbList(infoBuilder);
			}
		}
		
		if(!CollectionUtils.isEmpty(hoGradeList)){
			for (HoGradeInfo hoGrade : hoGradeList) {
				CommonModelProto.ComboListItemInfo.Builder infoBuilder = CommonModelProto.ComboListItemInfo.newBuilder();
				infoBuilder.setCode(hoGrade.getHoGrade());
				infoBuilder.setCodeName(hoGrade.getHoGradeName());
				response.addFbList(infoBuilder);
			}
		}
		
		return response.build();
	}

}
