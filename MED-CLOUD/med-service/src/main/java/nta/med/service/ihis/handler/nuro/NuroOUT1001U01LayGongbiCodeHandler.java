package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1002Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01LayGongbiCodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroOUT1001U01LayGongbiCodeHandler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01LayGongbiCodeRequest, NuroServiceProto.NuroOUT1001U01LayGongbiCodeResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroOUT1001U01LayGongbiCodeHandler.class);

	@Resource
	private Out1002Repository out1002Repository;

	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01LayGongbiCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01LayGongbiCodeRequest request) throws Exception {
		Double pkou1001 = CommonUtils.parseDouble(request.getPkout1001());
		NuroServiceProto.NuroOUT1001U01LayGongbiCodeResponse.Builder response = NuroServiceProto.NuroOUT1001U01LayGongbiCodeResponse.newBuilder();
		List<NuroOUT1001U01LayGongbiCodeInfo> listNuroOUT1001U01LayGongbiCodeInfo = out1002Repository.getNuroOUT1001U01LayGongbiCode(getHospitalCode(vertx, sessionId), pkou1001);
		if (listNuroOUT1001U01LayGongbiCodeInfo != null && !listNuroOUT1001U01LayGongbiCodeInfo.isEmpty()) {
			for (NuroOUT1001U01LayGongbiCodeInfo item : listNuroOUT1001U01LayGongbiCodeInfo) {
				NuroModelProto.NuroOUT1001U01LayGongbiCodeInfo.Builder itemBuilder = NuroModelProto.NuroOUT1001U01LayGongbiCodeInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getGongbiCode1())) {
					itemBuilder.setGongbiCode1(item.getGongbiCode1());
				}
				if (!StringUtils.isEmpty(item.getGongbiCode2())) {
					itemBuilder.setGongbiCode2(item.getGongbiCode2());
				}
				if (!StringUtils.isEmpty(item.getGongbiCode3())) {
					itemBuilder.setGongbiCode3(item.getGongbiCode3());
				}
				if (!StringUtils.isEmpty(item.getGongbiCode4())) {
					itemBuilder.setGongbiCode4(item.getGongbiCode4());
				}
				response.addLayGongbiCodeItem(itemBuilder);
			}
		}
		return response.build();
	}

}
