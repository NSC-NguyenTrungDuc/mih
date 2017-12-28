package nta.med.service.ihis.handler.ocso;

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

import nta.med.core.glossary.CommonEnum;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.ocso.OCSACT2GetGrdPaListInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACT2GetGrdPaListRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACT2GetGrdPaListResponse;

@Service
@Scope("prototype")
public class OCSACT2GetGrdPaListHandler extends ScreenHandler<OcsoServiceProto.OCSACT2GetGrdPaListRequest, OcsoServiceProto.OCSACT2GetGrdPaListResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCSACT2GetGrdPaListHandler.class);                                    
	@Resource
    private Ocs1003Repository ocs1003Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCSACT2GetGrdPaListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSACT2GetGrdPaListRequest request) throws Exception {
		OcsoServiceProto.OCSACT2GetGrdPaListResponse.Builder response = OcsoServiceProto.OCSACT2GetGrdPaListResponse.newBuilder();
		Date orderDateFrom = DateUtil.toDate(request.getOrderDateFrom(), DateUtil.PATTERN_YYMMDD);
		Date orderDateTo = DateUtil.toDate(request.getOrderDateTo(), DateUtil.PATTERN_YYMMDD);
		String hospCode = getHospitalCode(vertx, sessionId);
		boolean isCPL = false;
		if(CommonEnum.PERCENTAGE.getValue().equals(request.getJundalTable())){
			isCPL = ocs1003Repository.isExistJundalTableIsCPL(hospCode, request.getGwa(), orderDateFrom, orderDateTo, request.getBunho(), request.getActingFlg());
		}
		List<OCSACT2GetGrdPaListInfo> grdPas = ocs1003Repository.getOCSACT2GetGrdPaListInfo(hospCode, getLanguage(vertx, sessionId), 
				request.getJundalTable(), request.getGwa(), orderDateFrom, orderDateTo, request.getBunho(), request.getActingFlg(), isCPL);
		if (!CollectionUtils.isEmpty(grdPas)) {
            for(OCSACT2GetGrdPaListInfo item : grdPas) {
            	OcsoModelProto.OCSACT2GetGrdPaListInfo.Builder info = OcsoModelProto.OCSACT2GetGrdPaListInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addPaItem(info);
            }
        }
		return response.build();
	}

}
