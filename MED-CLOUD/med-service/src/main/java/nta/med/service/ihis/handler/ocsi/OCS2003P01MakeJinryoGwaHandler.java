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
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayJinryoGwaInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01MakeJinryoGwaRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class OCS2003P01MakeJinryoGwaHandler extends ScreenHandler<OcsiServiceProto.OCS2003P01MakeJinryoGwaRequest, SystemServiceProto.ComboResponse>{
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly=true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01MakeJinryoGwaRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		List<OcsoOCS1003P01LayJinryoGwaInfo> list = bas0260Repository.getOcsoOCS1003P01LayJinryoGwaInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if (!CollectionUtils.isEmpty(list)) {
			for (OcsoOCS1003P01LayJinryoGwaInfo item : list) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				info.setCode(item.getGwa());
				info.setCodeName(item.getGwaName());
				response.addComboItem(info);
			}
		}
		return response.build();
	}

}
