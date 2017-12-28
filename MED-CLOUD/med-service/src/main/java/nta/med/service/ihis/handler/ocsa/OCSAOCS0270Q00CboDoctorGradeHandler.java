package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCSAOCS0270Q00CboDoctorGradeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCSAOCS0270Q00CboDoctorGradeResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OCSAOCS0270Q00CboDoctorGradeHandler
	extends ScreenHandler<OcsaServiceProto.OCSAOCS0270Q00CboDoctorGradeRequest, OcsaServiceProto.OCSAOCS0270Q00CboDoctorGradeResponse> {
	
    @Resource
    private Bas0102Repository bas0102Repository;

    @Override
    @Transactional(readOnly = true)
    public OCSAOCS0270Q00CboDoctorGradeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCSAOCS0270Q00CboDoctorGradeRequest request) throws Exception {
    		String hospCode = getHospitalCode(vertx, sessionId);
    		if(!StringUtils.isEmpty(request.getHospCode())){
    			hospCode = request.getHospCode();
    		}
            List<ComboListItemInfo> listItem = bas0102Repository.getOcsaComboListItemInfo(hospCode, getLanguage(vertx, sessionId));
            
            OcsaServiceProto.OCSAOCS0270Q00CboDoctorGradeResponse.Builder response = OcsaServiceProto.OCSAOCS0270Q00CboDoctorGradeResponse.newBuilder();
            if (listItem != null && !listItem.isEmpty()) {
                for (ComboListItemInfo item : listItem) {
                	CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                	if(!StringUtils.isEmpty(item.getCode())){
                		 info.setCode(item.getCode());
                	}
                	if(!StringUtils.isEmpty(item.getCodeName())){
                		info.setCodeName(item.getCodeName());
                	}
                    response.addComboListItems(info);
                }
            }
            return response.build();
    }

}
