package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.model.ihis.cpls.CPL0106U00FwkGumsaListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0106U00GridColumnChangeRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0106U00GridColumnChangeResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class CPL0106U00GridColumnChangeHandler extends ScreenHandler<CplsServiceProto.CPL0106U00GridColumnChangeRequest, CplsServiceProto.CPL0106U00GridColumnChangeResponse> {
	private static final Log LOG = LogFactory.getLog(CPL0106U00GridColumnChangeHandler.class);
	@Resource
	private Cpl0101Repository cpl0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL0106U00GridColumnChangeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0106U00GridColumnChangeRequest request) throws Exception {
        CplsServiceProto.CPL0106U00GridColumnChangeResponse.Builder response = CplsServiceProto.CPL0106U00GridColumnChangeResponse.newBuilder();
    	List<CPL0106U00FwkGumsaListItemInfo> listFwkGumsa = cpl0101Repository.getCPL0106U00FwkGumsaListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCode(), false);
        if(!CollectionUtils.isEmpty(listFwkGumsa)) {
        	for(CPL0106U00FwkGumsaListItemInfo item : listFwkGumsa) {
        		CplsModelProto.CPL0106U00FwkGumsaListItemInfo.Builder info = CplsModelProto.CPL0106U00FwkGumsaListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addResultList(info);
        	}
        }
		return response.build();
	}

}
