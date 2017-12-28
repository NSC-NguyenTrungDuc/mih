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

import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.glossary.AccountingConfig;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U00MapingCodeRequest;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U00MapingCodeResponse;

@Service
@Scope("prototype")
public class RES1001U00MapingCodeHandler extends
		ScreenHandler<NuroServiceProto.RES1001U00MapingCodeRequest, NuroServiceProto.RES1001U00MapingCodeResponse> {

	private static final Log LOGGER = LogFactory.getLog(RES1001U00MapingCodeHandler.class);

	@Resource
	Ifs0003Repository ifs0003Repository;
	
	@Override
	@Transactional
	public RES1001U00MapingCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			RES1001U00MapingCodeRequest request) throws Exception {
		LOGGER.info("RES1001U00MapingCodeHandler: GWA = " + request.getGwa() + ", DOCTOR = " + request.getDoctor());
		
		NuroServiceProto.RES1001U00MapingCodeResponse.Builder response = NuroServiceProto.RES1001U00MapingCodeResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
		}
		
		List<Ifs0003> listIfs0003Gwa = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode
				, AccountingConfig.IF_ORCA_GWA.getValue(), request.getGwa());
		
		List<Ifs0003> listIfs0003Doctor = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode
				, AccountingConfig.IF_ORCA_DOCTOR.getValue(), request.getDoctor());
		
		String gwaResponse = "";
		String doctorResponse = "";
		
		if(!CollectionUtils.isEmpty(listIfs0003Gwa)){
			gwaResponse = listIfs0003Gwa.get(0).getIfCode();
		}
		
		if(!CollectionUtils.isEmpty(listIfs0003Doctor)){
			doctorResponse = listIfs0003Doctor.get(0).getIfCode();
		}
		
		NuroModelProto.RES1001U00MapingCodeInfo info = NuroModelProto.RES1001U00MapingCodeInfo.newBuilder()
				.setGwa(gwaResponse)
				.setDoctor(doctorResponse)
				.build();
		
		response.addListItem(info);
		return response.build();
	}

}
