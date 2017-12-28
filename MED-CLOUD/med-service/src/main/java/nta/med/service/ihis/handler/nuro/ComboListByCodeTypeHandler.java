package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

/**
 * @author dainguyen.
 */
@Service
@Scope("prototype")
public class ComboListByCodeTypeHandler extends ScreenHandler<NuroServiceProto.ComboListByCodeTypeRequest, SystemServiceProto.ComboListByCodeTypeResponse> {
	private static final Log logger = LogFactory.getLog(ComboListByCodeTypeHandler.class);
	
    @Resource
    private Bas0102Repository bas0102Repository;

	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public SystemServiceProto.ComboListByCodeTypeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ComboListByCodeTypeRequest request) throws Exception {
		 SystemServiceProto.ComboListByCodeTypeResponse.Builder response = SystemServiceProto.ComboListByCodeTypeResponse.newBuilder();
		 String hospCode = getHospitalCode(vertx, sessionId);
		 if(!StringUtils.isEmpty(request.getHospCodeLink())){
			 hospCode = request.getHospCodeLink();
		 }
		 List<ComboListItemInfo> listComboListItems = bas0102Repository.getNuroReceptionTypeList(getLanguage(vertx, sessionId), hospCode, request.getCodeType(), request.getIsAll());
         if (listComboListItems != null && !listComboListItems.isEmpty()) {
             for (ComboListItemInfo item : listComboListItems) {
             	CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                 info.setCode(item.getCode());
                 info.setCodeName(item.getCodeName());
                 response.addComboListItem(info);
             }

         }
		return response.build();
	}
}
