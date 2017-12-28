package nta.med.service.ihis.handler.nuts;

import java.util.Date;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp5001Repository;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00btnFinalCClickRequest;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00btnFinalCClickResponse;

@Service
@Scope("prototype")
public class NUT9001U00btnFinalCClickHandler extends
		ScreenHandler<NutsServiceProto.NUT9001U00btnFinalCClickRequest, NutsServiceProto.NUT9001U00btnFinalCClickResponse> {

	@Resource
	private Inp5001Repository inp5001Repository;
	
	@Override
	@Transactional
	public NUT9001U00btnFinalCClickResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUT9001U00btnFinalCClickRequest request) throws Exception {
		NutsServiceProto.NUT9001U00btnFinalCClickResponse.Builder response = NutsServiceProto.NUT9001U00btnFinalCClickResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String ctlTag = request.getCtlTag();
		String yn = request.getYn();
		Date magamDate = DateUtil.toDate(request.getMagamDate(), DateUtil.PATTERN_YYMMDD); 
		
		switch (ctlTag) {
		case "1C":
			inp5001Repository.updateNutJoMagamYnInNUT9001U00(hospCode, yn, magamDate);
			break;
		case "2C":
			inp5001Repository.updateNutJuMagamYnInNUT9001U00(hospCode, yn, magamDate);
			break;
		case "3C":
			inp5001Repository.updateNutSeokMagamYnInNUT9001U00(hospCode, yn, magamDate);
			break;
		default:
			break;
		}
		
		return response.build();
	}

}
