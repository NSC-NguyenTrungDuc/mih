package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL7001Q01LayDailyReportInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL7001Q01LayDailyReportRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL7001Q01LayDailyReportResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL7001Q01LayDailyReportHandler extends ScreenHandler <CplsServiceProto.CPL7001Q01LayDailyReportRequest, CplsServiceProto.CPL7001Q01LayDailyReportResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	@Override
	public boolean isValid(CPL7001Q01LayDailyReportRequest request,
			Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getKensaDate()) && DateUtil.toDate(request.getKensaDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	@Transactional(readOnly = true)
	public CPL7001Q01LayDailyReportResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL7001Q01LayDailyReportRequest request) throws Exception {
        CplsServiceProto.CPL7001Q01LayDailyReportResponse.Builder response = CplsServiceProto.CPL7001Q01LayDailyReportResponse.newBuilder();
        List<CPL7001Q01LayDailyReportInfo> listObject = cpl2010Repository.getCPL7001Q01LayDailyReportInfo(getHospitalCode(vertx, sessionId),
        		getLanguage(vertx, sessionId), request.getKensaDate(), request.getIoGubun(), request.getUitakCode());
        if(!CollectionUtils.isEmpty(listObject)) {
        	for(CPL7001Q01LayDailyReportInfo item : listObject) {
        		CplsModelProto.CPL7001Q01LayDailyReportInfo.Builder info = CplsModelProto.CPL7001Q01LayDailyReportInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addListIem(info);
        	}
        }
        return response.build();
	}
}
