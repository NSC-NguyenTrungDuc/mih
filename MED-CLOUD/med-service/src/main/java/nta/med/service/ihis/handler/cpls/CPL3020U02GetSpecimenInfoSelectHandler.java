package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.model.ihis.cpls.CPL3020U02GetSpecimenInfoSelectListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02GetSpecimenInfoSelectRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02GetSpecimenInfoSelectResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U02GetSpecimenInfoSelectHandler extends ScreenHandler<CplsServiceProto.CPL3020U02GetSpecimenInfoSelectRequest, CplsServiceProto.CPL3020U02GetSpecimenInfoSelectResponse> {
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U02GetSpecimenInfoSelectResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U02GetSpecimenInfoSelectRequest request) throws Exception {
        CplsServiceProto.CPL3020U02GetSpecimenInfoSelectResponse.Builder response = CplsServiceProto.CPL3020U02GetSpecimenInfoSelectResponse.newBuilder();
        List<CPL3020U02GetSpecimenInfoSelectListItemInfo> listItem = commonRepository.getCPL3020U02GetSpecimenInfoSelectListItemInfo(
        		getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getGwa(), request.getHoDong(), request.getOrderDate());
        if(!CollectionUtils.isEmpty(listItem)) {
        	for(CPL3020U02GetSpecimenInfoSelectListItemInfo item : listItem) {
        		CplsModelProto.CPL3020U02GetSpecimenInfoSelectListItemInfo.Builder info = CplsModelProto.CPL3020U02GetSpecimenInfoSelectListItemInfo.newBuilder();
        		if (!StringUtils.isEmpty(item.getGwaName())) {
        			info.setGwaName(item.getGwaName());
        		}
        		if (!StringUtils.isEmpty(item.getHoDongName())) {
        			info.setHoDongName(item.getHoDongName());
        		}
        		response.addResultList(info);
        	}
        }
        return response.build();           
	}
}
