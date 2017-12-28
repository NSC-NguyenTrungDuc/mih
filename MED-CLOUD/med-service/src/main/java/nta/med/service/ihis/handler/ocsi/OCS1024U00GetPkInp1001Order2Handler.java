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
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00GetPkInp1001Order2Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00GetPkInp1001Order2Response;

@Service
@Scope("prototype")
public class OCS1024U00GetPkInp1001Order2Handler extends ScreenHandler<OcsiServiceProto.OCS1024U00GetPkInp1001Order2Request , OcsiServiceProto.OCS1024U00GetPkInp1001Order2Response>{
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS1024U00GetPkInp1001Order2Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS1024U00GetPkInp1001Order2Request request) throws Exception {
		OcsiServiceProto.OCS1024U00GetPkInp1001Order2Response.Builder response = OcsiServiceProto.OCS1024U00GetPkInp1001Order2Response.newBuilder();
		List<Double> reserFkinp1001 = inp1003Repository.getReserFkinp1001ByBunho(getHospitalCode(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(reserFkinp1001)){
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(reserFkinp1001.get(0) != null ? CommonUtils.parseString(reserFkinp1001.get(0)) : "");
			response.setPkItem(info);
		}
		return response.build();
	}

}
