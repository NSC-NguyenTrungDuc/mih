package nta.med.service.ihis.handler.inps;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnTransRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSisJaewonPatientRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSisJaewonPatientResponse;

@Service
@Scope("prototype")
public class INPBATCHTRANSisJaewonPatientHandler extends ScreenHandler<InpsServiceProto.INPBATCHTRANSisJaewonPatientRequest, InpsServiceProto.INPBATCHTRANSisJaewonPatientResponse>{
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INPBATCHTRANSisJaewonPatientResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPBATCHTRANSisJaewonPatientRequest request) throws Exception {
		InpsServiceProto.INPBATCHTRANSisJaewonPatientResponse.Builder response = InpsServiceProto.INPBATCHTRANSisJaewonPatientResponse.newBuilder();
		String result = inp1001Repository.callFnInpJaewonHistoryCheck(request.getBunho(), DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD));
		if (!StringUtils.isEmpty(result)) {
			InpsModelProto.INPBATCHTRANSisJaewonPatientInfo.Builder info = InpsModelProto.INPBATCHTRANSisJaewonPatientInfo.newBuilder();
			info.setJaewonYn(result);
			response.addRtnValItem(info);
		}
		return response.build();
	}

}
