package nta.med.service.ihis.handler.nuro;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp2001Repository;
import nta.med.data.dao.medi.out.Out2001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto.ORDERTRANInsertOcsTempInfo;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANInsertOcsTempResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class ORDERTRANInsertOcsTempHandler extends ScreenHandler<NuroServiceProto.ORDERTRANInsertOcsTempRequest, NuroServiceProto.ORDERTRANInsertOcsTempResponse> {
	private static final Log LOG = LogFactory.getLog(ORDERTRANInsertOcsTempHandler.class);
	private static String RESULT_TRUE = "0";
	@Resource
	private Out2001Repository out2001Repository;
	@Resource
	private Inp2001Repository inp2001Repository;

	@Override
	public ORDERTRANInsertOcsTempResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANInsertOcsTempRequest request) throws Exception {
		NuroServiceProto.ORDERTRANInsertOcsTempResponse.Builder response = NuroServiceProto.ORDERTRANInsertOcsTempResponse.newBuilder();
		List<String> listResult = new ArrayList<String>();
		String err = "";
		String pkOif1101 = "";
		List<ORDERTRANInsertOcsTempInfo> listRequest = request.getInputInfoList();
		for (ORDERTRANInsertOcsTempInfo item : listRequest) {
			err = out2001Repository.callPrOutCreateOut2001Temp(getHospitalCode(vertx, sessionId), Integer.parseInt(item.getPkOcs()), item.getUserId());
			if(err != null && RESULT_TRUE.equals(err)){
				listResult = out2001Repository.callPrOutMakeOrderDataOut(
						getHospitalCode(vertx, sessionId), 
						getLanguage(vertx, sessionId), 
						item.getBunho(), 
						DateUtil.toDate(item.getJunsongDate(), DateUtil.PATTERN_YYMMDD), 
						Integer.parseInt(item.getPkOcs()), 
						UUID.randomUUID().toString(),
						UUID.randomUUID().toString(),
						UUID.randomUUID().toString(),
						UUID.randomUUID().toString(),
						item.getDoctor(), item.getUserId());
				if(listResult != null && listResult.size() > 0){
					err = listResult.get(0);
					pkOif1101 = listResult.get(1);
				}
			}
		}
         
        response.setOutputList0(err);
        response.setOutputList1(pkOif1101);
		return response.build();
	}
}
