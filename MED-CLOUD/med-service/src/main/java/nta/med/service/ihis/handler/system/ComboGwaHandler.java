package nta.med.service.ihis.handler.system;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboGwaRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetDataForComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class ComboGwaHandler
	extends ScreenHandler<SystemServiceProto.ComboGwaRequest, SystemServiceProto.GetDataForComboResponse> {
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly = true)
	public GetDataForComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, ComboGwaRequest request)
			throws Exception {
        SystemServiceProto.GetDataForComboResponse.Builder response = SystemServiceProto.GetDataForComboResponse.newBuilder();
      Date comingDate = DateUtil.getDateTime(new Date(), DateUtil.PATTERN_YYMMDD);
      String hospitalCode = getHospitalCode(vertx, sessionId);
  	  String language = getLanguage(vertx, sessionId);
  	  List<ComboListItemInfo> listComboDepartment = bas0260Repository.getComboDepartmentItemInfo(language, hospitalCode, comingDate, true);
    	if (listComboDepartment != null && !listComboDepartment.isEmpty()) {
            for (ComboListItemInfo obj : listComboDepartment) {
                CommonModelProto.ComboListItemInfo.Builder comboInfo = CommonModelProto.ComboListItemInfo.newBuilder();
                if(!StringUtils.isEmpty(obj.getCode())){
                	comboInfo.setCode(obj.getCode());
                }
                if(!StringUtils.isEmpty(obj.getCodeName())){
                	comboInfo.setCodeName(obj.getCodeName());
                }
                response.addComboDepartmentItem(comboInfo);
            }
        }
    	return response.build();
	}
}
