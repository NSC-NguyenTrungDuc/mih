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
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.model.ihis.bass.BAS0250Q00grdHOBEDInfo;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250Q00grdHOBEDRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250Q00grdHOBEDResponse;

@Service
@Scope("prototype")
public class BAS0250Q00grdHOBEDHandler extends
		ScreenHandler<BassServiceProto.BAS0250Q00grdHOBEDRequest, BassServiceProto.BAS0250Q00grdHOBEDResponse> {
	private static final Log LOGGER = LogFactory.getLog(BAS0250Q00grdHOBEDHandler.class); 
	@Resource
	private Bas0250Repository bas0250Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BAS0250Q00grdHOBEDResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BAS0250Q00grdHOBEDRequest request) throws Exception {
		
		BassServiceProto.BAS0250Q00grdHOBEDResponse.Builder response = BassServiceProto.BAS0250Q00grdHOBEDResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Date hoCodeYmd = DateUtil.toDate(request.getHoCodeYmd(), DateUtil.PATTERN_YYMMDD);
		
		List<BAS0250Q00grdHOBEDInfo> lstInfo = bas0250Repository.getBAS0250Q00grdHOBEDInfoList(hospCode, request.getHoDong(), hoCodeYmd, request.getGumjinHodongYn());

		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (BAS0250Q00grdHOBEDInfo info : lstInfo) {
			BassModelProto.BAS0250Q00grdHOBEDInfo.Builder protoInfo = BassModelProto.BAS0250Q00grdHOBEDInfo.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, language);
			response.addGrdMasterItem(protoInfo);
		}
		
		return response.build();
	}

}
