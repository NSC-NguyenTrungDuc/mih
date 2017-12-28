package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0101;
import nta.med.core.domain.nur.Nur0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0101Repository;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0811U00CboRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0811U00CboResponse;

@Service
@Scope("prototype")
public class NUR0811U00CboHandler
		extends ScreenHandler<NuriServiceProto.NUR0811U00CboRequest, NuriServiceProto.NUR0811U00CboResponse> {

	@Resource
	private Nur0101Repository nur0101Repository;

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0811U00CboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0811U00CboRequest request) throws Exception {

		NuriServiceProto.NUR0811U00CboResponse.Builder response = NuriServiceProto.NUR0811U00CboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<Nur0101> listNur0101 = nur0101Repository.findByAdminGubun(language, "USER");
		if(!CollectionUtils.isEmpty(listNur0101)){
			for (Nur0101 nur0101 : listNur0101) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(nur0101.getCodeType() == null ? "" : nur0101.getCodeType())
						.setCodeName(nur0101.getCodeTypeName() == null ? "" : nur0101.getCodeTypeName());
				response.addLayComboItems(info);
			}
		}
		
		List<Nur0102> listNur0102ByNeedType = nur0102Repository.findByCodeTypeLanguage(hospCode, "NEED_TYPE", language);
		if(!CollectionUtils.isEmpty(listNur0102ByNeedType)){
			for (Nur0102 nur0102 : listNur0102ByNeedType) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(nur0102.getCode())
						.setCodeName(nur0102.getCodeName());
				response.addXeditGridCell(info);
			}
		}
		
		List<Nur0102> listNur0102ByNeedHType = nur0102Repository.findByCodeTypeLanguage(hospCode, "NEED_H_TYPE", language);
		if(!CollectionUtils.isEmpty(listNur0102ByNeedHType)){
			for (Nur0102 nur0102 : listNur0102ByNeedHType) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(nur0102.getCode())
						.setCodeName(nur0102.getCodeName());
				response.addMasterGrd(info);
			}
		}
		
		return response.build();
	}

}
