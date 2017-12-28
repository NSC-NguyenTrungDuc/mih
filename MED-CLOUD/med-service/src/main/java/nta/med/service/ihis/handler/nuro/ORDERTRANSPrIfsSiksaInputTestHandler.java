package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ifs.Ifs3021Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class ORDERTRANSPrIfsSiksaInputTestHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSPrIfsSiksaInputTestRequest, SystemServiceProto.UpdateResponse> {                   
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSPrIfsSiksaInputTestHandler.class);                                    
	@Resource                                                                                                       
	private Ifs3021Repository ifs3021Repository;                                                                    
	
	@Override
	public boolean isValid(NuroServiceProto.ORDERTRANSPrIfsSiksaInputTestRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getFromDate()) && DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD) == null
				&& !StringUtils.isEmpty(request.getToDate()) && DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSPrIfsSiksaInputTestRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Date fromDate = DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD);
		Date toDate = DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD);
		Integer fromSik = CommonUtils.parseInteger(request.getFromSik());
		Integer toSik = CommonUtils.parseInteger(request.getToSik());
		String result = ifs3021Repository.callPrIfsSikaInputTest(getHospitalCode(vertx, sessionId), request.getBunho(), fromDate, fromSik, toDate, toSik);
		if(!StringUtils.isEmpty(result)){
			response.setResult(true);
			response.setMsg(result);
		}
		return response.build();
	}                                                                                                                 
}