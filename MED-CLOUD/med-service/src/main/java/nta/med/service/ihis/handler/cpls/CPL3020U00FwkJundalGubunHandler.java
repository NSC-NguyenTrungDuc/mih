package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00FwkJundalGubunRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U00FwkJundalGubunHandler extends ScreenHandler<CplsServiceProto.CPL3020U00FwkJundalGubunRequest, SystemServiceProto.ComboResponse >{
	
	@Resource
	private Cpl0109Repository cpl0109Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CPL3020U00FwkJundalGubunRequest request)
			throws Exception {
        SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
    	List<ComboListItemInfo> listFwkJundalGubunList = cpl0109Repository.getFwkJundalGubunListItem(getHospitalCode(vertx, sessionId), 
    			request.getCodeType(),request.getFind1(),getLanguage(vertx, sessionId));
    	if(listFwkJundalGubunList != null && !listFwkJundalGubunList.isEmpty()){
    		for(ComboListItemInfo item : listFwkJundalGubunList){
    			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
    			if (!StringUtils.isEmpty(item.getCode())) {
    				info.setCode(item.getCode());
    			}
    			if (!StringUtils.isEmpty(item.getCodeName())) {
    				info.setCodeName(item.getCodeName());
    			}
    			response.addComboItem(info);
    		}
    	}
    	return response.build();
	}
}
