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
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.ocsi.OCS2003U03getSysInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getSysRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getSysResponse;

@Service
@Scope("prototype")
public class OCS2003U03getSysHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03getSysRequest, OcsiServiceProto.OCS2003U03getSysResponse>{
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U03getSysResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03getSysRequest request) throws Exception {
		OcsiServiceProto.OCS2003U03getSysResponse.Builder response = OcsiServiceProto.OCS2003U03getSysResponse.newBuilder();
		List<OCS2003U03getSysInfo> list = drg3010Repository.getOCS2003U03getSysInfo(getHospitalCode(vertx, sessionId), request.getOBunho(), request.getOComments());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS2003U03getSysInfo item : list) {
				OcsiModelProto.OCS2003U03getSysInfo.Builder info = OcsiModelProto.OCS2003U03getSysInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(item.getCnt() != null){
					info.setCnt(String.valueOf(item.getCnt()));
				}
				
				response.addListSysdual(info);
			}
		}
		return response.build();
	}

}
