package nta.med.service.ihis.handler.bass;

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
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0253Repository;
import nta.med.data.model.ihis.bass.BAS0250Q00layBedStatusInfo;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250Q00layBedStatusRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250Q00layBedStatusResponse;

@Service
@Scope("prototype")
public class BAS0250Q00layBedStatusHandler extends
		ScreenHandler<BassServiceProto.BAS0250Q00layBedStatusRequest, BassServiceProto.BAS0250Q00layBedStatusResponse> {
	private static final Log LOGGER = LogFactory.getLog(BAS0250Q00layBedStatusHandler.class); 
	@Resource
	private Bas0253Repository bas0253Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BAS0250Q00layBedStatusResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BAS0250Q00layBedStatusRequest request) throws Exception {
		
		BassServiceProto.BAS0250Q00layBedStatusResponse.Builder response = BassServiceProto.BAS0250Q00layBedStatusResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Date hoCodeYmd = DateUtil.toDate(request.getHoCodeYmd(), DateUtil.PATTERN_YYMMDD);
		
		List<BAS0250Q00layBedStatusInfo> lstInfo = bas0253Repository.getBAS0250Q00layBedStatusInfoList(hospCode, hoCodeYmd, request.getHoDong());

		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (BAS0250Q00layBedStatusInfo info : lstInfo) {
			BassModelProto.BAS0250Q00layBedStatusInfo.Builder protoInfo = BassModelProto.BAS0250Q00layBedStatusInfo.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, language);
			response.addLayItem(protoInfo);
		}
		
		return response.build();
	}

}
