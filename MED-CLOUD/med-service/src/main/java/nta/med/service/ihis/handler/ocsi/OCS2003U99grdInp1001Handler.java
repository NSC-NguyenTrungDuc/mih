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
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.ocsi.OCS2003U99grdInp1001Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99grdInp1001Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99grdInp1001Response;

@Service
@Scope("prototype")
public class OCS2003U99grdInp1001Handler extends ScreenHandler<OcsiServiceProto.OCS2003U99grdInp1001Request, OcsiServiceProto.OCS2003U99grdInp1001Response>{
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U99grdInp1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U99grdInp1001Request request) throws Exception {
		OcsiServiceProto.OCS2003U99grdInp1001Response.Builder response = OcsiServiceProto.OCS2003U99grdInp1001Response.newBuilder();
		List<OCS2003U99grdInp1001Info> list = inp1001Repository.getOCS2003U99grdInp1001Info(getHospitalCode(vertx, sessionId), request.getFkinp1001());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS2003U99grdInp1001Info item : list) {
				OcsiModelProto.OCS2003U99grdInp1001Info.Builder info = OcsiModelProto.OCS2003U99grdInp1001Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdInp(info);
			}
		}
		return response.build();
	}

}
