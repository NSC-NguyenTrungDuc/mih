package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL2010U01grdPaInfo;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01grdPaRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01grdPaResponse;

@Service
@Scope("prototype")
public class CPL2010U01grdPaHandler
		extends ScreenHandler<CplsServiceProto.CPL2010U01grdPaRequest, CplsServiceProto.CPL2010U01grdPaResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;

	@Override
	@Transactional(readOnly = true)
	public CPL2010U01grdPaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U01grdPaRequest request) throws Exception {
		CplsServiceProto.CPL2010U01grdPaResponse.Builder response = CplsServiceProto.CPL2010U01grdPaResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);  
        List<CPL2010U01grdPaInfo> list = cpl2010Repository.getCPL2010U01grdPaInfo(hospCode, language, 
        								request.getBunho(), 
        								request.getReserYn(), 
        								request.getFromDate(), 
        								request.getToDate(), 
        								request.getDoctor(), 
        								request.getEmergencyYn(), 
        								startNum, 
        								CommonUtils.parseInteger(offset), 
        								request.getRbxmijubsu());
        if (!CollectionUtils.isEmpty(list)) {
        	for (CPL2010U01grdPaInfo item : list) {
				CplsModelProto.CPL2010U01grdPaInfo.Builder info = CplsModelProto.CPL2010U01grdPaInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdMasterItem(info);
			}
        }
		
		return response.build();
	}

}
