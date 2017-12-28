package nta.med.service.ihis.handler.cpls;
import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL3020U00SelectInOutGubunListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00SelectInOutGubunRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00SelectInOutGubunResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U00SelectInOutGubunHandler extends ScreenHandler<CplsServiceProto.CPL3020U00SelectInOutGubunRequest, CplsServiceProto.CPL3020U00SelectInOutGubunResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U00SelectInOutGubunResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U00SelectInOutGubunRequest request) throws Exception {
        CplsServiceProto.CPL3020U00SelectInOutGubunResponse.Builder response = CplsServiceProto.CPL3020U00SelectInOutGubunResponse.newBuilder();
        	List<CPL3020U00SelectInOutGubunListItemInfo> listResult = cpl2010Repository.getCPL3020U00SelectInOutGubun(getHospitalCode(vertx, sessionId), request.getFkcpl2010());
    	if(listResult != null && !listResult.isEmpty()){
    		for(CPL3020U00SelectInOutGubunListItemInfo item : listResult){
    			CplsModelProto.CPL3020U00SelectInOutGubunListItemInfo.Builder info = CplsModelProto.CPL3020U00SelectInOutGubunListItemInfo.newBuilder();
    			if (!StringUtils.isEmpty(item.getInOutGubun())) {
    				info.setInOutGubun(item.getInOutGubun());
    			}
    			if (!StringUtils.isEmpty(item.getFkocs())) {
    				info.setFkocs(item.getFkocs().toString());
    			}
    			response.addResultList(info);
    		}
    	}
    	return response.build();
	}
}
