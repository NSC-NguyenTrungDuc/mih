package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBIsJaewonRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBOutputResponse;

@Service
@Scope("prototype")
public class NURILIBIsJaewonHandler extends ScreenHandler<NuriServiceProto.NURILIBIsJaewonRequest, NuriServiceProto.NURILIBOutputResponse>{
	@Resource
	Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public NURILIBOutputResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NURILIBIsJaewonRequest request) throws Exception {
		NuriServiceProto.NURILIBOutputResponse.Builder response = NuriServiceProto.NURILIBOutputResponse.newBuilder();
		List<ComboListItemInfo> list = inp1001Repository.getPkinp1001JaewonFlag(getHospitalCode(vertx, sessionId), request.getBunho(), DateUtil.toDate(request.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
		if (!CollectionUtils.isEmpty(list))
			response.setOutput(list.get(0).getCodeName());
		return response.build();
	}

}
