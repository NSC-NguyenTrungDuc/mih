package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBGetBuseoNameBAS0260Request;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBGetCodeNameBAS0102Request;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBOutputResponse;

@Service
@Scope("prototype")
public class NURILIBGetCodeNameBAS0102Handler extends ScreenHandler<NuriServiceProto.NURILIBGetCodeNameBAS0102Request, NuriServiceProto.NURILIBOutputResponse>{
	@Resource
	Bas0102Repository bas0102Reposity;
	
	@Override
	@Transactional(readOnly=true)
	public NURILIBOutputResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NURILIBGetCodeNameBAS0102Request request) throws Exception {
		NuriServiceProto.NURILIBOutputResponse.Builder response = NuriServiceProto.NURILIBOutputResponse.newBuilder();
		List<ComboListItemInfo> list = bas0102Reposity.getCodeNameSortKeyListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType(), request.getCode());
		if (!CollectionUtils.isEmpty(list)) 
			response.setOutput(list.get(0).getCode());
		return response.build();
	}

}
