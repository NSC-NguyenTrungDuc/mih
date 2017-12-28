package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL0000Q00GetSigeyulDataSelect1ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00FrmGraphGetSigeyulRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00FrmGraphGetSigeyulResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0000Q00FrmGraphGetSigeyulHandler extends ScreenHandler<CplsServiceProto.CPL0000Q00FrmGraphGetSigeyulRequest, CplsServiceProto.CPL0000Q00FrmGraphGetSigeyulResponse> {
	private static final Log LOG = LogFactory.getLog(CPL0000Q00FrmGraphGetSigeyulHandler.class);
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	
	@Override
	@Transactional(readOnly = true)
	public CPL0000Q00FrmGraphGetSigeyulResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0000Q00FrmGraphGetSigeyulRequest request) throws Exception {
        CplsServiceProto.CPL0000Q00FrmGraphGetSigeyulResponse.Builder response = CplsServiceProto.CPL0000Q00FrmGraphGetSigeyulResponse.newBuilder();
        List<CPL0000Q00GetSigeyulDataSelect1ListItemInfo> listItem = cpl2010Repository.getCPL0000Q00FrmGraphGetSigeyul(getHospitalCode(vertx, sessionId), request.getBunho(),
        		request.getBaseDate(), request.getUserId(), request.getConditionValue());
        if(!CollectionUtils.isEmpty(listItem)) {
        	for(CPL0000Q00GetSigeyulDataSelect1ListItemInfo item : listItem) {
        		CplsModelProto.CPL0000Q00GetSigeyulDataSelect1ListItemInfo.Builder info = CplsModelProto.CPL0000Q00GetSigeyulDataSelect1ListItemInfo.newBuilder();
        		if (!StringUtils.isEmpty(item.getJubsuDate())) {
        			info.setJubsuDate(item.getJubsuDate());
        		}
        		if (!StringUtils.isEmpty(item.getJubsuTime())) {
        			info.setJubsuTime(item.getJubsuTime());
        		}
        		if (!StringUtils.isEmpty(item.getJubsuTime2())) {
        			info.setJubsuTime2(item.getJubsuTime2());
        		}

        		response.addResultList(info);
        	}
        }
		return response.build();
	}

}
