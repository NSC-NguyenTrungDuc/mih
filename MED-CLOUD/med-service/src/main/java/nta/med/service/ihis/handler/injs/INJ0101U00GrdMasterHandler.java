package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inj.Inj0101Repository;
import nta.med.data.model.ihis.injs.InjsComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

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
public class INJ0101U00GrdMasterHandler extends ScreenHandler<InjsServiceProto.INJ0101U00GrdMasterRequest, InjsServiceProto.INJ0101U00GrdMasterResponse> {
	private static final Log LOG = LogFactory.getLog(INJ0101U00GrdMasterHandler.class);
	@Resource
	private Inj0101Repository inj0101Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ0101U00GrdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ0101U00GrdMasterRequest request) throws Exception {
		InjsServiceProto.INJ0101U00GrdMasterResponse.Builder response = InjsServiceProto.INJ0101U00GrdMasterResponse.newBuilder();
		List<InjsComboListItemInfo> listResult = inj0101Repository.getINJ0101U00GrdMasterInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listResult)) {
        	CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
        	for (InjsComboListItemInfo item : listResult) {
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
