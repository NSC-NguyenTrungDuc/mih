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
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.drgs.CPL2010U01grdTubeInfo;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01grdTubeRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01grdTubeResponse;

@Service
@Scope("prototype")
public class CPL2010U01grdTubeHandler
		extends ScreenHandler<CplsServiceProto.CPL2010U01grdTubeRequest, CplsServiceProto.CPL2010U01grdTubeResponse> {

	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL2010U01grdTubeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U01grdTubeRequest request) throws Exception {
		CplsServiceProto.CPL2010U01grdTubeResponse.Builder response = CplsServiceProto.CPL2010U01grdTubeResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<CPL2010U01grdTubeInfo> items = cpl2010Repository.getCPL2010U01grdTubeInfo(hospCode
				, language
				, request.getQuerySqlIndex()
				, request.getJubsuDate()
				, request.getJubsuTime()
				, request.getBunho()
				, DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD)
				, request.getReserYn());
		
		if(!CollectionUtils.isEmpty(items)){
			for (CPL2010U01grdTubeInfo item : items) {
				CplsModelProto.CPL2010U01grdTubeInfo.Builder info = CplsModelProto.CPL2010U01grdTubeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdMasterItem(info);
			}
		}
		
		return response.build();
	}

}
