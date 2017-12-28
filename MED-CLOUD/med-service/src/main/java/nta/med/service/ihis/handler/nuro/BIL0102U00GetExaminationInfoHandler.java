package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.out.Out1001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.BIL0102U00GetExaminationInfoRequest;
import nta.med.service.ihis.proto.NuroServiceProto.BIL0102U00GetExaminationInfoResponse;

@Service
@Scope("prototype")
public class BIL0102U00GetExaminationInfoHandler extends ScreenHandler<NuroServiceProto.BIL0102U00GetExaminationInfoRequest, NuroServiceProto.BIL0102U00GetExaminationInfoResponse>{
	private static final Log LOGGER = LogFactory.getLog(BIL0102U00GetExaminationInfoHandler.class);

	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BIL0102U00GetExaminationInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BIL0102U00GetExaminationInfoRequest request) throws Exception {
		NuroServiceProto.BIL0102U00GetExaminationInfoResponse.Builder response = NuroServiceProto.BIL0102U00GetExaminationInfoResponse.newBuilder();
		String hospCode = request.getHospCode();
		if (StringUtils.isEmpty(hospCode)) {
			hospCode = getHospitalCode(vertx, sessionId);
		} 
		Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(hospCode, CommonUtils.parseDouble(request.getPkout1001()));
		if (out1001 != null) {
			if (out1001.getNaewonDate() != null ) {
				response.setNaewonDate(out1001.getNaewonDate().toString());
			}
			response.setJubsuTime(out1001.getJubsuTime());
		}
		return response.build();
	}

}
