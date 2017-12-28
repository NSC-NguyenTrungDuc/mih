package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL3020U02ExecuteSelectInOutGubunListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02ExecuteSelectInOutGubunRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02ExecuteSelectInOutGubunResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U02ExecuteSelectInOutGubunHandler extends ScreenHandler <CplsServiceProto.CPL3020U02ExecuteSelectInOutGubunRequest, CplsServiceProto.CPL3020U02ExecuteSelectInOutGubunResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U02ExecuteSelectInOutGubunResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U02ExecuteSelectInOutGubunRequest request) throws Exception {
        CplsServiceProto.CPL3020U02ExecuteSelectInOutGubunResponse.Builder response = CplsServiceProto.CPL3020U02ExecuteSelectInOutGubunResponse .newBuilder();
    	Double pkcpl2010 = CommonUtils.parseDouble(request.getFkcpl2010());
    	List<CPL3020U02ExecuteSelectInOutGubunListItemInfo> listItem = cpl2010Repository.getCPL3020U02ExecuteSelectInOutGubunListItemInfo(getHospitalCode(vertx, sessionId),"I", pkcpl2010);
        if(!CollectionUtils.isEmpty(listItem)) {
        	for(CPL3020U02ExecuteSelectInOutGubunListItemInfo item : listItem) {
        		CplsModelProto.CPL3020U02ExecuteSelectInOutGubunListItemInfo.Builder info = CplsModelProto.CPL3020U02ExecuteSelectInOutGubunListItemInfo.newBuilder();
        		if (!StringUtils.isEmpty(item.getInOutGubun())) {
        			info.setInOutGubun(item.getInOutGubun());
        		}
        		if (item.getFkocs()!=null) {
        			info.setFkocs(String.format("%.0f",item.getFkocs()));
        		}

        		response.addResultList(info);
        	}
        }
        return response.build();
	}
}
