package nta.med.service.ihis.handler.schs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.Schs0201U99CheckInsertRequest;
import nta.med.service.ihis.proto.SchsServiceProto.Schs0201U99CheckInsertResponse;

@Service
@Scope("prototype")
public class Schs0201U99CheckInsertHandler extends ScreenHandler<SchsServiceProto.Schs0201U99CheckInsertRequest, SchsServiceProto.Schs0201U99CheckInsertResponse>{
	private static final Log logger = LogFactory.getLog(Schs0201U99CheckInsertHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public Schs0201U99CheckInsertResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			Schs0201U99CheckInsertRequest request) throws Exception {
		SchsServiceProto.Schs0201U99CheckInsertResponse.Builder response = SchsServiceProto.Schs0201U99CheckInsertResponse.newBuilder();
		String doctor = request.getDoctor();
        String gwa    = request.getGwa();
        String bunho  = request.getBunho();
        String hospCode   = request.getHospCode();
        Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
        List<Double> pkout1001 = out1001Repository.getSchs0201U99CheckInsert(hospCode, bunho, naewonDate, doctor, gwa);
        if(!CollectionUtils.isEmpty(pkout1001)){
        	response.setChkResult(String.format("%.0f", pkout1001.get(0)));
        }
		return response.build();
	}
	
}

