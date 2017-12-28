package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003P01CheckDataSendYnHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01CheckDataSendYnRequest, OcsoServiceProto.OcsoOCS1003P01CheckDataSendYnResponse>{
	
	private static final Log logger = LogFactory.getLog(OcsoOCS1003P01CheckDataSendYnHandler.class);
	
	@Resource
	private OutsangRepository outsangRepository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01CheckDataSendYnResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01CheckDataSendYnRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01CheckDataSendYnResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01CheckDataSendYnResponse.newBuilder();
		String result = getOcsoOCS1003P01CheckDataSendYn(request, getHospitalCode(vertx, sessionId));
        if(!StringUtils.isEmpty(result)) {
        	response.setResultCheck(result);
        }
		return response.build();
	}
	
	private String getOcsoOCS1003P01CheckDataSendYn(OcsoServiceProto.OcsoOCS1003P01CheckDataSendYnRequest request, String hospCode) {
		Double pkSeq = CommonUtils.parseDouble(request.getPkSeq());
		String result = outsangRepository.getOcsoOCS1003P01CheckDataSendYn(hospCode, request.getBunho(), request.getGw(), 
				request.getIoGubun(), pkSeq);
		return result;
}
}
