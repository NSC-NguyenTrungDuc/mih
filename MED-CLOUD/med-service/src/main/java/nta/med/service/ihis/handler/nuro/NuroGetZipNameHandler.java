package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroGetZipNameHandler extends ScreenHandler<NuroServiceProto.NuroGetZipNameRequest, NuroServiceProto.NuroGetZipNameResponse> {
	private static final Log LOG = LogFactory.getLog(NuroGetZipNameHandler.class);
	
	@Resource
	private Bas0123Repository bas0123Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroGetZipNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroGetZipNameRequest request) throws Exception {
		NuroServiceProto.NuroGetZipNameResponse.Builder response = NuroServiceProto.NuroGetZipNameResponse.newBuilder();
		List<String> listNuroCboZipCode = bas0123Repository.getNuroCboZipCodeInfo(request.getZipCode1(), request.getZipCode2());
    	if (listNuroCboZipCode != null && !listNuroCboZipCode.isEmpty()) {
             response.setRetValue(listNuroCboZipCode.get(0));
        }
		return response.build();
	}

}
