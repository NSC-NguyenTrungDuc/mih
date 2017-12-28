package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.data.model.ihis.cpls.CPL0000Q00GetSigeyulDataSelect2ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00GetSigeyulDataSelect2Request;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00GetSigeyulDataSelect2Response;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0000Q00GetSigeyulDataSelect2Handler extends ScreenHandler<CplsServiceProto.CPL0000Q00GetSigeyulDataSelect2Request, CplsServiceProto.CPL0000Q00GetSigeyulDataSelect2Response> {
	private static final Log LOG = LogFactory.getLog(CPL0000Q00GetSigeyulDataSelect2Handler.class);
	@Resource
	private Cpl3020Repository cpl3020Repository;
	
	
	@Override
	@Transactional(readOnly = true)
	public CPL0000Q00GetSigeyulDataSelect2Response handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0000Q00GetSigeyulDataSelect2Request request) throws Exception {
        CplsServiceProto.CPL0000Q00GetSigeyulDataSelect2Response.Builder response = CplsServiceProto.CPL0000Q00GetSigeyulDataSelect2Response.newBuilder();
        List<CPL0000Q00GetSigeyulDataSelect2ListItemInfo> listItem = cpl3020Repository.getCPL0000Q00GetSigeyulDataSelect2(getHospitalCode(vertx, sessionId), request.getBunho(),
        		request.getHangmogCode(), request.getJubsuDate(), request.getJubsuTime());
        if(!CollectionUtils.isEmpty(listItem)) {
        	for(CPL0000Q00GetSigeyulDataSelect2ListItemInfo item : listItem) {
        		CplsModelProto.CPL0000Q00GetSigeyulDataSelect2ListItemInfo.Builder info = CplsModelProto.CPL0000Q00GetSigeyulDataSelect2ListItemInfo.newBuilder();
        		if (!StringUtils.isEmpty(item.getCplResult())) {
        			info.setCplResult(item.getCplResult());
        		}
        		if (!StringUtils.isEmpty(item.getStandardYn())) {
        			info.setStandardYn(item.getStandardYn());
        		}
        		if (!StringUtils.isEmpty(item.getGumsaName())) {
        			info.setGumsaName(item.getGumsaName());
        		}
        		if (!StringUtils.isEmpty(item.getFromStandard())) {
        			info.setFromStandard(item.getFromStandard());
        		}
        		if (!StringUtils.isEmpty(item.getToStandard())) {
        			info.setToStandard(item.getToStandard());
        		}

        		response.addResultList(info);
        	}
        }
		return response.build();
	}
}
