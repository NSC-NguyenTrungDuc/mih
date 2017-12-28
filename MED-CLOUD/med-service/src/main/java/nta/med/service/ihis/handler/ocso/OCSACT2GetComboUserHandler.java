package nta.med.service.ihis.handler.ocso;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.adm.Adm3200;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACT2GetComboUserRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service                                                                                                          
@Scope("prototype")
public class OCSACT2GetComboUserHandler extends ScreenHandler<OcsoServiceProto.OCSACT2GetComboUserRequest, SystemServiceProto.ComboResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCSACT2GetComboUserHandler.class);                                    
	@Resource
    private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSACT2GetComboUserRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<ComboListItemInfo> list = new ArrayList<ComboListItemInfo>();
		switch (request.getJundalTable()) {
			case "CPL":
				list = adm3200Repository.getUserIdUserNameInfo("CPL", "3", hospCode, false, "");
				break;
			case "PFE":
				list = adm3200Repository.getOcsactCboSystemSelectedIndexPfesCaseListItem(
						hospCode, "OCS", "SUBPART_DOCTOR", language);
				break;
			case "TST":
				list = adm3200Repository.getOcsactCboSystemSelectedIndexOprsCaseListItem(hospCode,"NUR", "2", "30010", false);
				list.addAll(adm3200Repository.getOcsactCboSystemSelectedIndexNuriCaseListItem(hospCode,
						"NUR", "2", "", language));
				break;
			case "INJ":
				List<Adm3200> listAdm3200 = adm3200Repository.getInjsINJ1001U01ActorListItemInfo(getHospitalCode(vertx, sessionId));
				if(!CollectionUtils.isEmpty(listAdm3200)){
					for(Adm3200 item : listAdm3200) {
						ComboListItemInfo info = new ComboListItemInfo(item.getUserId(), item.getUserNm());
						list.add(info);
		        	}
				}
				break;
			default:
				break;
		}
        if (!CollectionUtils.isEmpty(list)) {
            for (ComboListItemInfo item : list) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addComboItem(info);
            }
        }
		return response.build();
	}

}
