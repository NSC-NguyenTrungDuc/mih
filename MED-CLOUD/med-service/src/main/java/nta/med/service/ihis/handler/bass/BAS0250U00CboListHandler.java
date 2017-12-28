package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00CboListRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00CboListResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service
@Scope("prototype")
public class BAS0250U00CboListHandler
		extends ScreenHandler<BassServiceProto.BAS0250U00CboListRequest, BassServiceProto.BAS0250U00CboListResponse> {

	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BAS0250U00CboListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BAS0250U00CboListRequest request) throws Exception {
		
		BassServiceProto.BAS0250U00CboListResponse.Builder response = BassServiceProto.BAS0250U00CboListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<Bas0102> lstHoStt = bas0102Repository.getByCodeType(hospCode, "HO_STATUS", language);
		List<ComboListItemInfo> lstSexGubun = bas0102Repository.getByCodeTypeContainNull(hospCode, "SEX_GUBUN", language);
		List<Bas0102> lstHoGubun = bas0102Repository.getByCodeType(hospCode, "HO_GUBUN", language);
		List<Bas0102> lstBedStt = bas0102Repository.getByCodeType(hospCode, "BED_STATUS", language);
		
		if(!CollectionUtils.isEmpty(lstHoStt)){
			for (Bas0102 bas0102 : lstHoStt) {
				CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder();
				protoInfo.setCode(bas0102.getCode() == null ? "" : bas0102.getCode());
				protoInfo.setCodeName(bas0102.getCodeName() == null ? "" : bas0102.getCodeName());
				response.addCboHoStatus(protoInfo);
			}
			
			CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder();
			protoInfo.setCode("");
			protoInfo.setCodeName("");
			response.addCboHoStatus(protoInfo);
		} else {
			CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder();
			protoInfo.setCode("");
			protoInfo.setCodeName("");
			response.addCboHoStatus(protoInfo);
		}
		
		if(!CollectionUtils.isEmpty(lstSexGubun)){
			for (ComboListItemInfo item : lstSexGubun) {
				CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder();
				protoInfo.setCode(item.getCode() == null ? "" : item.getCode());
				protoInfo.setCodeName(item.getCodeName() == null ? "" : item.getCodeName());
				response.addCboHoSex(protoInfo);
			}
		}
		
		if(!CollectionUtils.isEmpty(lstHoGubun)){
			for (Bas0102 bas0102 : lstHoGubun) {
				CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder();
				protoInfo.setCode(bas0102.getCode() == null ? "" : bas0102.getCode());
				protoInfo.setCodeName(bas0102.getCodeName() == null ? "" : bas0102.getCodeName());
				response.addCboHoGubun(protoInfo);
			}
		}
		
		if(!CollectionUtils.isEmpty(lstBedStt)){
			for (Bas0102 bas0102 : lstBedStt) {
				CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder();
				protoInfo.setCode(bas0102.getCode() == null ? "" : bas0102.getCode());
				protoInfo.setCodeName(bas0102.getCodeName() == null ? "" : bas0102.getCodeName());
				response.addXeditGridCell(protoInfo);
			}
		}

		return response.build();
	}

}
