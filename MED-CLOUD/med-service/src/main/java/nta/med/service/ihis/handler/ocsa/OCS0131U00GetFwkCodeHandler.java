package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0131Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0131U00GetFwkCodeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0131U00GetFwkCodeResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OCS0131U00GetFwkCodeHandler
	extends ScreenHandler<OcsaServiceProto.OCS0131U00GetFwkCodeRequest, OcsaServiceProto.OCS0131U00GetFwkCodeResponse> {
	private static final Log LOG = LogFactory.getLog(OCS0131U00GetFwkCodeHandler.class);
	
	@Resource
	private Ocs0131Repository ocs0131Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS0131U00GetFwkCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0131U00GetFwkCodeRequest request) throws Exception {
        OcsaServiceProto.OCS0131U00GetFwkCodeResponse.Builder response = OcsaServiceProto.OCS0131U00GetFwkCodeResponse.newBuilder();
    	List<ComboListItemInfo> listItem = ocs0131Repository.getOCS0131U00FwkCode(request.getFind1(), getLanguage(vertx, sessionId));
    	if(listItem !=null && !listItem.isEmpty()){
			for(ComboListItemInfo item : listItem){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListItem(info);
			}
    	}
        return response.build();    	
	}
}
