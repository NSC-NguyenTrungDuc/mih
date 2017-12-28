package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0123Repository;
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
public class NuroCboZipCodeHandler extends ScreenHandler<NuroServiceProto.NuroCboZipCodeRequest, NuroServiceProto.NuroCboZipCodeResponse>{
	private static final Log logger = LogFactory.getLog(NuroCboZipCodeHandler.class);
	
	@Resource
	private Bas0123Repository bas0123Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroCboZipCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroCboZipCodeRequest request) throws Exception {
		NuroServiceProto.NuroCboZipCodeResponse.Builder response = NuroServiceProto.NuroCboZipCodeResponse.newBuilder();
		List<String> listNuroCboZipCode = bas0123Repository.getNuroCboZipCodeInfo(request.getZipCode1(), request.getZipCode2());
         if (listNuroCboZipCode != null && !listNuroCboZipCode.isEmpty()) {
             for (String nuroCboZipCode : listNuroCboZipCode) {
                 NuroModelProto.NuroCboZipCodeInfo.Builder builder = NuroModelProto.NuroCboZipCodeInfo.newBuilder();
                 if(!StringUtils.isEmpty(nuroCboZipCode)) {
                 	builder.setZipName(nuroCboZipCode);
                 }
                 response.addZipCodeInfo(builder);
             }
         }
		return response.build();
	}
}
