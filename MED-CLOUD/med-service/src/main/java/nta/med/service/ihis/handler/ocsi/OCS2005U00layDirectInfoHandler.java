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
import nta.med.data.dao.medi.nur.Nur0110Repository;
import nta.med.data.model.ihis.ocsi.OCS2005U00layDirectInfoInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00layDirectInfoRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00layDirectInfoResponse;

@Service
@Scope("prototype")
public class OCS2005U00layDirectInfoHandler extends ScreenHandler<OcsiServiceProto.OCS2005U00layDirectInfoRequest, OcsiServiceProto.OCS2005U00layDirectInfoResponse>{
	@Resource
	private Nur0110Repository nur0110Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U00layDirectInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00layDirectInfoRequest request) throws Exception {
		OcsiServiceProto.OCS2005U00layDirectInfoResponse.Builder response = OcsiServiceProto.OCS2005U00layDirectInfoResponse.newBuilder();
		List<OCS2005U00layDirectInfoInfo> list = nur0110Repository.getOCS2005U00layDirectInfoInfo(getHospitalCode(vertx, sessionId));
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS2005U00layDirectInfoInfo item : list) {
				OcsiModelProto.OCS2005U00layDirectInfoInfo.Builder info = OcsiModelProto.OCS2005U00layDirectInfoInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayDirect(info);
			}
		}
		return response.build();
	}

}
