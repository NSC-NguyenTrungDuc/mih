package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0812U00CboRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0812U00CboResponse;

@Service
@Scope("prototype")
public class NUR0812U00CboHandler
		extends ScreenHandler<NuriServiceProto.NUR0812U00CboRequest, NuriServiceProto.NUR0812U00CboResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0812U00CboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0812U00CboRequest request) throws Exception {
		NuriServiceProto.NUR0812U00CboResponse.Builder response = NuriServiceProto.NUR0812U00CboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<Nur0102> listNur0102 = nur0102Repository.findByCodeTypeLanguage(hospCode, "NEED_H_TYPE", language);
		if(!CollectionUtils.isEmpty(listNur0102)){
			for (Nur0102 nur0102 : listNur0102) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(nur0102.getCode())
						.setCodeName(nur0102.getCodeName());
				response.addMasterGrd(info);
			}
		}
		
		List<ComboListItemInfo> listXeditGridCell1 = nur0102Repository.getNUR0812U00XeditGridCell1(hospCode, "NEED_GUBUN", language); 
		if(!CollectionUtils.isEmpty(listXeditGridCell1)){
			for (ComboListItemInfo item : listXeditGridCell1) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(item.getCode())
						.setCodeName(item.getCodeName());
				response.addXeditGridCell1(info);
			}
		}
		
		List<ComboListItemInfo> listXeditGridCell3 = nur0102Repository.getNUR0812U00XeditGridCell3(hospCode, "NEED_TYPE", language); 
		if(!CollectionUtils.isEmpty(listXeditGridCell3)){
			for (ComboListItemInfo item : listXeditGridCell3) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(item.getCode())
						.setCodeName(item.getCodeName());
				response.addXeditGridCell3(info);
			}
		}
		
		return response.build();
	}

}
