package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG5100P01CheckActRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG5100P01CheckActResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class DRG5100P01CheckActHandler extends ScreenHandler<DRG5100P01CheckActRequest, DRG5100P01CheckActResponse>{
	@Resource
	private Inv0102Repository inv0102Repository;
	@Override
	@Transactional(readOnly = true)
	public DRG5100P01CheckActResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, DRG5100P01CheckActRequest request)
			throws Exception {
		DRG5100P01CheckActResponse.Builder response = DRG5100P01CheckActResponse.newBuilder();
		String result = inv0102Repository.getDRG5100P01CheckActInfo(getHospitalCode(vertx, sessionId), "DRG_CONSTANT", "07", "btn_useACT_yn", getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setCode(result);
		}
		return response.build();
	}

}
