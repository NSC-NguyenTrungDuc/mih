package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ifs.Ifs1004Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANPRMakeIFS1004Request;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANPRMakeIFS1004Response;

@Service
@Scope("prototype")
@Transactional
public class ORDERTRANPRMakeIFS1004Handler extends ScreenHandler<NuroServiceProto.ORDERTRANPRMakeIFS1004Request, NuroServiceProto.ORDERTRANPRMakeIFS1004Response> {

	private static final Log LOGGER = LogFactory.getLog(ORDERTRANPRMakeIFS1004Handler.class);

	@Resource
	OutsangRepository outsangRepository;

	@Resource
	Ifs1004Repository ifs1004Repository;

	@Override
	public ORDERTRANPRMakeIFS1004Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			ORDERTRANPRMakeIFS1004Request request) throws Exception {
		String result = "0";
		String hospCode = getHospitalCode(vertx, sessionId);
		NuroServiceProto.ORDERTRANPRMakeIFS1004Response.Builder response = NuroServiceProto.ORDERTRANPRMakeIFS1004Response.newBuilder();
		
		List<NuroModelProto.ORDERTRANPRMakeIFS1004Info> listInfo = request.getInputInfoList();
		for (NuroModelProto.ORDERTRANPRMakeIFS1004Info info : listInfo) {
			if("SANG".equals(info.getTransGubun())){
				result = outsangRepository.callPrIfsOutsangTrans(hospCode, info.getIoGubun(), CommonUtils.parseInteger(info.getPkout1003()), info.getTransYn());
			} else if("ORDER".equals(info.getTransGubun())){
				result = ifs1004Repository.callPrIfsOrderProcMain(hospCode, info.getIoGubun(), CommonUtils.parseInteger(info.getPkout1003()), info.getTransYn());
			}
		}
		
		response.setRetVal(result);
		return response.build();
	}
	
}
