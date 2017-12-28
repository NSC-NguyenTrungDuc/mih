package nta.med.service.ihis.handler.ocsi;

import java.util.Date;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.adm.Adm0700;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0700Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99InsertAdm0700Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS2003U99InsertAdm0700Handler extends ScreenHandler<OcsiServiceProto.OCS2003U99InsertAdm0700Request, SystemServiceProto.UpdateResponse>{
	@Resource
	private Adm0700Repository adm0700Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U99InsertAdm0700Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if (insertAdm0700(request, hospCode) < 0){
			response.setResult(false);
		} else 
			response.setResult(true);
		return response.build();
	}
	
	private Integer insertAdm0700(OCS2003U99InsertAdm0700Request item, String hospCode) {
		Adm0700 adm0700 = new Adm0700();
		adm0700.setSendDt(new Date());
		adm0700.setSenderId(item.getSenderId());
		adm0700.setSendSeq(CommonUtils.parseDouble(item.getSendSeq()));
		adm0700.setSendSpot(item.getSenderBuseo());
		adm0700.setMsgTitle(item.getMsgTitle());
		adm0700.setMsgContents(item.getMsgContents());
		adm0700.setValidYn("Y");
		adm0700.setSendAllCnfmYn(item.getSendAllCnfmYn());
		adm0700.setRecvAllCnfmYn("N");
		adm0700.setFileAtchYn(item.getFileAtchYn());
		adm0700.setCrMemb(item.getUserId());
		adm0700.setCrTime(new Date());
		adm0700.setCrTrm(item.getUserTrm());
		adm0700.setHospCode(hospCode);
		Adm0700 adm0700Check = adm0700Repository.save(adm0700);
		if (adm0700Check != null  && adm0700.getId() != null)
			return 1;
		return -1;
	}
}
