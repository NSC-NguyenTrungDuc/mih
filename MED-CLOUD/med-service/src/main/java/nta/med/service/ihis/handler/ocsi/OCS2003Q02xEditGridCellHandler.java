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
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02xEditGridCellRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02xEditGridCellResponse;

@Service
@Scope("prototype")
public class OCS2003Q02xEditGridCellHandler extends
		ScreenHandler<OcsiServiceProto.OCS2003Q02xEditGridCellRequest, OcsiServiceProto.OCS2003Q02xEditGridCellResponse> {

	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS2003Q02xEditGridCellResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003Q02xEditGridCellRequest request) throws Exception {

		OcsiServiceProto.OCS2003Q02xEditGridCellResponse.Builder response = OcsiServiceProto.OCS2003Q02xEditGridCellResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		// cbxordergubun 
		List<ComboListItemInfo> listCbxOrderGubun = ocs0132Repository.getCodeCodeNameWhereNURItemInfo(hospCode, language, "INPUT_TAB", "1", true);
		if(!CollectionUtils.isEmpty(listCbxOrderGubun)){
			for (ComboListItemInfo info : listCbxOrderGubun) {
				CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, protoInfo, language);
				response.addCbxordergubun(protoInfo);
			}
		}
		
		// xeditgridcell20 and xeditgridcell77
		List<ComboListItemInfo> cboGwaList = bas0260Repository.findBasGwaByHospCodeIpwonYnBuseoGubun(hospCode, language, "Y", "1", false);
		if(!CollectionUtils.isEmpty(cboGwaList)){
			for (ComboListItemInfo info : cboGwaList) {
				CommonModelProto.ComboListItemInfo.Builder pInfo = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addXeditgridcell20(pInfo);
				response.addXeditgridcell77(pInfo);
			}
		}
		
		// xeditgridcell78 and xeditgridcell21
		List<ComboListItemInfo> cboDoctorList = bas0270Repository.findDoctorByHospCodeSysDateDoctorGwa(hospCode, language, "", false);
		if(!CollectionUtils.isEmpty(cboDoctorList)){
			for (ComboListItemInfo info : cboDoctorList) {
				CommonModelProto.ComboListItemInfo.Builder pInfo = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addXeditgridcell78(pInfo);
				response.addXeditgridcell21(pInfo);
			}
		}
		
		return response.build();
	}

}
