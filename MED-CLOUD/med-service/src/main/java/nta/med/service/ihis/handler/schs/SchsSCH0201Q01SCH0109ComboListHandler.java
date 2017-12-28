package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboListByCodeTypeResponse;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q01SCH0109ComboListRequest;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201Q01SCH0109ComboListHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q01SCH0109ComboListRequest, SystemServiceProto.ComboListByCodeTypeResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	@Transactional(readOnly=true)
	public ComboListByCodeTypeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SchsSCH0201Q01SCH0109ComboListRequest request) throws Exception {
        List<ComboListItemInfo> list = sch0201Repository.getSchsSCH0201Q01SCH0109ComboList(getHospitalCode(vertx, sessionId),getLanguage(vertx, sessionId));
        SystemServiceProto.ComboListByCodeTypeResponse.Builder  response =  SystemServiceProto.ComboListByCodeTypeResponse.newBuilder();
        if(list != null && !list.isEmpty()){
        	for(ComboListItemInfo item : list){
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
