package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99BannabOrderCountRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003U99BannabOrderCountHandler extends ScreenHandler<OcsiServiceProto.OCS2003U99BannabOrderCountRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U99BannabOrderCountRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		List<ComboListItemInfo> list = bas0260Repository.getOCSCHKDISCHARGEgrdStatus1(getHospitalCode(vertx, sessionId), "", request.getKijunDate(), request.getBunho());
		if (!CollectionUtils.isEmpty(list)) {
			for (ComboListItemInfo item : list) {
				if ("SYO".equals(item.getCode())) {
					response.setResult(item.getCodeName());
					break;
				}					
			}
		}
		return response.build();
	}

}
