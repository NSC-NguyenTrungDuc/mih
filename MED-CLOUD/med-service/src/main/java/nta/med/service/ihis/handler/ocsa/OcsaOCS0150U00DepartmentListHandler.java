package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0150U00DepartmentListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0150U00DepartmentListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsaOCS0150U00DepartmentListHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0150U00DepartmentListRequest, OcsaServiceProto.OcsaOCS0150U00DepartmentListResponse> {
	
    @Resource
    private Bas0260Repository bas0260Repository;
    
    @Override
    @Transactional(readOnly = true)
    public OcsaOCS0150U00DepartmentListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0150U00DepartmentListRequest request) throws Exception {
        List<ComboListItemInfo> listItem = bas0260Repository.getOcsaOCS0150U00DepartmentList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getMemb());
        OcsaServiceProto.OcsaOCS0150U00DepartmentListResponse.Builder response = OcsaServiceProto.OcsaOCS0150U00DepartmentListResponse.newBuilder();
        if (listItem != null && !listItem.isEmpty()) {
        	for (ComboListItemInfo item : listItem) {
            	CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
            	if (!StringUtils.isEmpty(item.getCode())) {
            		info.setCode(item.getCode());
            	}
            	if (!StringUtils.isEmpty(item.getCodeName())) {
            		info.setCodeName(item.getCodeName());
            	}
                response.addDepartmentItem(info);
            }
        }
        return response.build();
    }

}
