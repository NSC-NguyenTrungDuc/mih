package nta.med.service.ihis.handler.ocsi;

import java.util.Date;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.adm.Adm0710;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0710Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99InsertAdm0710Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS2003U99InsertAdm0710Handler extends ScreenHandler<OcsiServiceProto.OCS2003U99InsertAdm0710Request, SystemServiceProto.UpdateResponse>{
	@Resource
	private Adm0710Repository adm0710Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U99InsertAdm0710Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String result = adm0710Repository.getOCS2003U99InsertAdm0710Request(hospCode, request.getSenderId(), request.getSendSeq(), request.getRecvSpot(), request.getRecieverId());
		response.setResult(false);
		if (!StringUtils.isEmpty(result)) {
			if (insertAdm0710(hospCode, request) > 0)
				response.setResult(true);
		}
		return response.build();
	}
	
	private Integer insertAdm0710(String hospCode, OCS2003U99InsertAdm0710Request item) {
		Adm0710 adm0710 = new Adm0710();
		adm0710.setSendDt(new Date());
		adm0710.setSenderId(item.getSenderId());
		adm0710.setSendSeq(CommonUtils.parseDouble(item.getSendSeq()));
		adm0710.setRecvSpot(item.getRecvSpot());
		adm0710.setRecverId(item.getRecieverId());
		adm0710.setRecvSpotYn("Y");
		adm0710.setCnfmYn("N");
		adm0710.setRecvAllCnfmYn("N");
		adm0710.setFileAtchYn("N");
		adm0710.setValidYn("Y");
		adm0710.setUpMemb(item.getUserId());
		adm0710.setUpTime(new Date());
		adm0710.setUpTrm("");
		adm0710.setCrMemb(item.getUserId());
		adm0710.setCrTime(new Date());
		adm0710.setCrTrm("");
		adm0710.setHospCode(hospCode);
		Adm0710 adm0710Check = adm0710Repository.save(adm0710);
		if (adm0710Check != null && adm0710Check.getId() != null)
			return 1;
		return -1;
	}
}
