package nta.med.service.ihis.handler.ocso;

import java.math.BigDecimal;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs1003Repository;
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
public class OcsoOCS1003P01GetMaxOcs1003SeqHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01GetMaxOcs1003SeqRequest, OcsoServiceProto.OcsoOCS1003P01GetMaxOcs1003SeqResponse>{
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01GetMaxOcs1003SeqHandler.class);
	
	@Resource
	private Ocs1003Repository ocs1003Repository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01GetMaxOcs1003SeqResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01GetMaxOcs1003SeqRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01GetMaxOcs1003SeqResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01GetMaxOcs1003SeqResponse.newBuilder();
		String result = getOcsoOCS1003P01GetMaxOcs1003Seq(request, getHospitalCode(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setOcsKeyValue(result);
		}
		return response.build();
	}
	
	public String getOcsoOCS1003P01GetMaxOcs1003Seq(OcsoServiceProto.OcsoOCS1003P01GetMaxOcs1003SeqRequest request, String hospCode){
		try {
			BigDecimal fkout1001 = new BigDecimal(request.getFkout1001());
			String result = ocs1003Repository.getOcsoOCS1003P01GetMaxOcs1003Seq(fkout1001, hospCode);
			return result;
		}catch (Exception e) {
			LOGGER.error(e.getMessage(), e);
		}
		return null;
	}
	
}
