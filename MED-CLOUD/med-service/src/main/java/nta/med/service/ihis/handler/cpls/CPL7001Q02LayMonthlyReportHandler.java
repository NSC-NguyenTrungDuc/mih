package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL7001Q02LayMonthlyReportInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL7001Q02LayMonthlyReportRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL7001Q02LayMonthlyReportResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL7001Q02LayMonthlyReportHandler  extends ScreenHandler <CplsServiceProto.CPL7001Q02LayMonthlyReportRequest, CplsServiceProto.CPL7001Q02LayMonthlyReportResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	public boolean isValid(CPL7001Q02LayMonthlyReportRequest request, Vertx vertx, String clientId, String sessionId) {
	   if(!StringUtils.isEmpty(request.getFromDate()) && DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD_BLANK) == null){
	       return false;
	   }
	   if(!StringUtils.isEmpty(request.getToDate()) && DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD_BLANK) == null){
	       return false;
	   }
	   return true;
	}

	@Override
	@Transactional(readOnly = true)
	public CPL7001Q02LayMonthlyReportResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL7001Q02LayMonthlyReportRequest request) throws Exception {
        CplsServiceProto.CPL7001Q02LayMonthlyReportResponse.Builder response = CplsServiceProto.CPL7001Q02LayMonthlyReportResponse.newBuilder();
        List<CPL7001Q02LayMonthlyReportInfo> listObject = cpl2010Repository.getCPL7001Q02LayMonthlyReportInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId)
        		, request.getFromDate(), request.getToDate(), request.getIoGubun(), request.getUitakCode());
        if(!CollectionUtils.isEmpty(listObject)) {
        	for(CPL7001Q02LayMonthlyReportInfo item : listObject) {
        		CplsModelProto.CPL7001Q02LayMonthlyReportInfo.Builder info = CplsModelProto.CPL7001Q02LayMonthlyReportInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addListItem(info);
        	}
        }
        return response.build();
	}
}
