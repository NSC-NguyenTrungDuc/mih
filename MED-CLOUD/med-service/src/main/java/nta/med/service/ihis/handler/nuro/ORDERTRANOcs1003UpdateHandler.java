package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANOcs1003UpdateRequest;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANOcs1003UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class ORDERTRANOcs1003UpdateHandler extends ScreenHandler<NuroServiceProto.ORDERTRANOcs1003UpdateRequest, NuroServiceProto.ORDERTRANOcs1003UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(ORDERTRANOcs1003UpdateHandler.class);
	
	@Resource
	Ocs1003Repository ocs1003Repository;
	
	@Resource
	Out1003Repository out1003Repository;

	@Override
	public ORDERTRANOcs1003UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			ORDERTRANOcs1003UpdateRequest request) throws Exception {
		
		
		NuroServiceProto.ORDERTRANOcs1003UpdateResponse.Builder response = NuroServiceProto.ORDERTRANOcs1003UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		NuroModelProto.ORDERTRANOcs1003UpdateInfo firstInfo = null;
		List<NuroModelProto.ORDERTRANOcs1003UpdateInfo> listInfo = request.getSaveLayoutItemList();
		if(!CollectionUtils.isEmpty(listInfo)){
			firstInfo = listInfo.get(0);
		}
		
		Integer pkOut1003 = out1003Repository.callPrIfsOutOrderMasterInsert(hospCode, firstInfo.getBunho(),
				DateUtil.toDate(firstInfo.getActingDate(), DateUtil.PATTERN_YYMMDD), firstInfo.getGubun(), firstInfo.getGwa(), firstInfo.getDoctor(), firstInfo.getChojae());
		
		if(pkOut1003 == null || pkOut1003 <= 0){
			return response.build();
		}
		
		for (NuroModelProto.ORDERTRANOcs1003UpdateInfo info : listInfo) {
			ocs1003Repository.updateORDERTRANOcs1003Update(DateUtil.toDate(info.getSunabDate(), 
					DateUtil.PATTERN_YYMMDD), CommonUtils.parseDouble(String.valueOf(pkOut1003)), CommonUtils.parseDouble(info.getPkocs1003()), hospCode);
		}
		
		response.setPkout1003(String.valueOf(pkOut1003));
		return response.build();
		
	}
	
}
