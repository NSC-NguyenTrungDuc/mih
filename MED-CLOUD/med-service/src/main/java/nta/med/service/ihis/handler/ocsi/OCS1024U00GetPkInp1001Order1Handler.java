package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00GetPkInp1001Order1Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00GetPkInp1001Order1Response;

@Service
@Scope("prototype")
public class OCS1024U00GetPkInp1001Order1Handler extends ScreenHandler<OcsiServiceProto.OCS1024U00GetPkInp1001Order1Request , OcsiServiceProto.OCS1024U00GetPkInp1001Order1Response>{
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS1024U00GetPkInp1001Order1Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS1024U00GetPkInp1001Order1Request request) throws Exception {
		OcsiServiceProto.OCS1024U00GetPkInp1001Order1Response.Builder response = OcsiServiceProto.OCS1024U00GetPkInp1001Order1Response.newBuilder();
		List<Double> pkinp1001s = inp1001Repository.getPkinp1001ByBunhoAndJaewonFlag(getHospitalCode(vertx, sessionId), request.getBunho(), "Y");
		if(!CollectionUtils.isEmpty(pkinp1001s)){
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(pkinp1001s.get(0) != null ? CommonUtils.parseString(pkinp1001s.get(0)) : "");
			response.setPkItem(info);
		}
		return response.build();
	}

}
