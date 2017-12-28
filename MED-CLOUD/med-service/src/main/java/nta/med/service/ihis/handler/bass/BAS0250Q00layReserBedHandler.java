package nta.med.service.ihis.handler.bass;

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
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.model.ihis.bass.BAS0250Q00layReserBedInfo;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250Q00layReserBedRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250Q00layReserBedResponse;

@Service
@Scope("prototype")
public class BAS0250Q00layReserBedHandler extends
		ScreenHandler<BassServiceProto.BAS0250Q00layReserBedRequest, BassServiceProto.BAS0250Q00layReserBedResponse> {
	private static final Log LOGGER = LogFactory.getLog(BAS0250Q00layReserBedHandler.class); 
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BAS0250Q00layReserBedResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BAS0250Q00layReserBedRequest request) throws Exception {
		
		BassServiceProto.BAS0250Q00layReserBedResponse.Builder response = BassServiceProto.BAS0250Q00layReserBedResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<BAS0250Q00layReserBedInfo> lstInfo = inp1003Repository.getBAS0250Q00layReserBedInfoList(hospCode, request.getHoDong());

		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (BAS0250Q00layReserBedInfo info : lstInfo) {
			BassModelProto.BAS0250Q00layReserBedInfo.Builder protoInfo = BassModelProto.BAS0250Q00layReserBedInfo.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, language);
			response.addLayItem(protoInfo);
		}
		
		return response.build();
	}

}
