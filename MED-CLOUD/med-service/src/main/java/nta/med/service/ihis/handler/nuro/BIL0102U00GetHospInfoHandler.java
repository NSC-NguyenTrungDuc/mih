package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.BIL0102U00GetHospInfoRequest;
import nta.med.service.ihis.proto.NuroServiceProto.BIL0102U00GetHospInfoResponse;

@Service
@Scope("prototype")
public class BIL0102U00GetHospInfoHandler extends ScreenHandler<NuroServiceProto.BIL0102U00GetHospInfoRequest, NuroServiceProto.BIL0102U00GetHospInfoResponse>{
	private static final Log LOGGER = LogFactory.getLog(BIL0102U00GetHospInfoHandler.class);
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BIL0102U00GetHospInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BIL0102U00GetHospInfoRequest request) throws Exception {
		NuroServiceProto.BIL0102U00GetHospInfoResponse.Builder response = NuroServiceProto.BIL0102U00GetHospInfoResponse.newBuilder();
		List<Bas0001> listBas = bas0001Repository.findLatestByHospCode(request.getHospCode());
		if (!CollectionUtils.isEmpty(listBas)) {
			Bas0001 bas0001 = listBas.get(0);
			response.setYoyangName(bas0001.getYoyangName());
			response.setAddress(StringUtils.isEmpty(bas0001.getAddress()) ? "" : bas0001.getAddress());
			response.setTel(StringUtils.isEmpty(bas0001.getTel()) ? "" : bas0001.getTel());
			response.setEmail(StringUtils.isEmpty(bas0001.getEmail()) ? "" : bas0001.getEmail());
			response.setLocale(StringUtils.isEmpty(bas0001.getLanguage()) ? "" : bas0001.getLanguage());
		}
		return response.build();
	}

}
