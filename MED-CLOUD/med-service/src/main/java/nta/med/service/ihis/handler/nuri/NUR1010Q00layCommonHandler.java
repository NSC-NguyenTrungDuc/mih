package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00layCommonHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00layCommonRequest, SystemServiceProto.ComboResponse> {   
	
	@Resource
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00layCommonRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		
		List<ComboListItemInfo> items = inp2004Repository.getNUR2004U01layCommon(getHospitalCode(vertx, sessionId),
				CommonUtils.parseDouble(request.getFkinp1001()));

		for (ComboListItemInfo item : items) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode() == null ? "" : item.getCode())
					.setCodeName(item.getCodeName() == null ? "" : item.getCodeName());
			response.addComboItem(info);
		}
		
		return response.build();
	}
}
