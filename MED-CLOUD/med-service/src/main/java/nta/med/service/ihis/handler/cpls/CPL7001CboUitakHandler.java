package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL7001CboUitakRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL7001CboUitakResponse;

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
public class CPL7001CboUitakHandler extends ScreenHandler<CplsServiceProto.CPL7001CboUitakRequest, CplsServiceProto.CPL7001CboUitakResponse> {
	private static final Log LOG = LogFactory.getLog(CPL7001CboUitakHandler.class);
	@Resource
	private Cpl0109Repository cpl0109Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL7001CboUitakResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL7001CboUitakRequest request)
					throws Exception {
        CplsServiceProto.CPL7001CboUitakResponse.Builder response = CplsServiceProto.CPL7001CboUitakResponse.newBuilder();
        List<ComboListItemInfo> listObject = cpl0109Repository.getCpl0109ComboListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),"IO_GUBUN", true);
        if(!CollectionUtils.isEmpty(listObject)) {
        	for(ComboListItemInfo item : listObject) {
        		CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
        		if (!StringUtils.isEmpty(item.getCode())) {
        			info.setCode(item.getCode());
        		}
        		if (!StringUtils.isEmpty(item.getCodeName())) {
        			info.setCodeName(item.getCodeName());
        		}

        		response.addListItem(info);
        	}
        }
		return response.build();
	}

}
