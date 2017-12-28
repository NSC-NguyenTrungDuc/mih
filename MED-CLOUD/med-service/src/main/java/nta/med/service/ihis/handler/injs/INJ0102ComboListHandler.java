package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.inj.Inj0102;
import nta.med.data.dao.medi.inj.Inj0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

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
public class INJ0102ComboListHandler extends ScreenHandler<InjsServiceProto.INJ0102ComboListRequest, SystemServiceProto.ComboListByCodeTypeResponse> {
	private static final Log LOG = LogFactory.getLog(INJ0102ComboListHandler.class);
	@Resource
	private Inj0102Repository inj0102Repository;

	@Override
	@Transactional(readOnly=true)
	public SystemServiceProto.ComboListByCodeTypeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ0102ComboListRequest request) throws Exception {
		 SystemServiceProto.ComboListByCodeTypeResponse.Builder response = SystemServiceProto.ComboListByCodeTypeResponse.newBuilder();
		 List<Inj0102> listResult = inj0102Repository.findByCodeType(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
         if (!CollectionUtils.isEmpty(listResult)) {
         	CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
         	for (Inj0102 item : listResult) {
		            if (!StringUtils.isEmpty(item.getCode())) {
	            		info.setCode(item.getCode());
	            	}
		            if (!StringUtils.isEmpty(item.getCodeName())) {
		            	info.setCodeName(item.getCodeName());
		            }
		            response.addComboListItem(info);
         	}
         }
		return response.build();
	}
}
