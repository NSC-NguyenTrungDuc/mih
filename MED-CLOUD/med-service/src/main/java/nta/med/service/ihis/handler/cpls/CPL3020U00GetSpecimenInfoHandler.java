package nta.med.service.ihis.handler.cpls;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.cpls.CPL3020U00GetSpecimenInfoListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00GetSpecimenInfoRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00GetSpecimenInfoResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U00GetSpecimenInfoHandler extends ScreenHandler<CplsServiceProto.CPL3020U00GetSpecimenInfoRequest, CplsServiceProto.CPL3020U00GetSpecimenInfoResponse> {
	@Resource
	private Bas0260Repository bas0260Repository;
	@Override
    public boolean isValid(CPL3020U00GetSpecimenInfoRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        }
        return true;
    }
	
	@Override
	@Transactional
	public CPL3020U00GetSpecimenInfoResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U00GetSpecimenInfoRequest request) throws Exception  {
            CplsServiceProto.CPL3020U00GetSpecimenInfoResponse.Builder response = CplsServiceProto.CPL3020U00GetSpecimenInfoResponse.newBuilder();
        	List<CPL3020U00GetSpecimenInfoListItemInfo> listResult = bas0260Repository.getCPL3020U00GetSpecimenInfo(request.getGwa(), request.getOrderDate(),
        			request.getHoDong(), getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
        	if(listResult != null && !listResult.isEmpty()){
        		for(CPL3020U00GetSpecimenInfoListItemInfo item : listResult){
        			CplsModelProto.CPL3020U00GetSpecimenInfoListItemInfo.Builder info = CplsModelProto.CPL3020U00GetSpecimenInfoListItemInfo.newBuilder();
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
