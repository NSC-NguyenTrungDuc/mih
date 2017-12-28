package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q02JundalComboListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q02JundalComboListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201Q02JundalComboListHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q02JundalComboListRequest, SchsServiceProto.SchsSCH0201Q02JundalComboListResponse>{
	@Resource
	private Bas0260Repository bas0260Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201Q02JundalComboListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201Q02JundalComboListRequest request) throws Exception {
		SchsServiceProto.SchsSCH0201Q02JundalComboListResponse.Builder response=SchsServiceProto.SchsSCH0201Q02JundalComboListResponse.newBuilder();
		List<ComboListItemInfo> comboList= bas0260Repository.getSchsSCH0201Q02JundalComboList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), false, true, false);
		if(comboList != null && !comboList.isEmpty()){
			for(ComboListItemInfo item : comboList){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
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
