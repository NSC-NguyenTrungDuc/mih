package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GetCboGumsaRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GetCboGumsaResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH3001U00GetCboGumsaHandler
	extends ScreenHandler<SchsServiceProto.SCH3001U00GetCboGumsaRequest, SchsServiceProto.SCH3001U00GetCboGumsaResponse> {
	
	@Resource
	private Sch0109Repository sch0109Repository;
	
	@Override
	@Transactional(readOnly=true)
	public SCH3001U00GetCboGumsaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00GetCboGumsaRequest request) throws Exception {
        SchsServiceProto.SCH3001U00GetCboGumsaResponse.Builder response = SchsServiceProto.SCH3001U00GetCboGumsaResponse.newBuilder();
    	List<ComboListItemInfo> listComboListItemInfo = sch0109Repository.getSCH3001U00GetCboGumsa(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "GROUP");
    	if(listComboListItemInfo != null && !listComboListItemInfo.isEmpty()){
			for(ComboListItemInfo item : listComboListItemInfo){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				
				response.addListItem(info);
			}
		}
    	return response.build();
	}
}
