package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.FindDepartmentByHospCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto.FindDepartmentByHospCodeResponse;

@Service
@Scope("prototype")
public class FindDepartmentByHospCodeHandler extends ScreenHandler<SystemServiceProto.FindDepartmentByHospCodeRequest, SystemServiceProto.FindDepartmentByHospCodeResponse>{

	private static final Log LOGGER = LogFactory.getLog(FindDepartmentByHospCodeHandler.class);
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Bas0260Repository bas0260Repository;

	@Override
    @Transactional
    @Route(global = true)
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, FindDepartmentByHospCodeRequest request) throws Exception {
        List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
        if(!CollectionUtils.isEmpty(bas0001List)){
            Bas0001 bas0001 = bas0001List.get(0);
            setSessionInfo(vertx, sessionId,
                    SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(), bas0001.getLanguage(), "", 1, ""));
        }
        else{
            LOGGER.info("FindDepartmentByHospCodeHandler preHandle not found hosp code");
        }
    }
	
	@Override
	@Transactional(readOnly = true)
	public FindDepartmentByHospCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			FindDepartmentByHospCodeRequest request) throws Exception {
		SystemServiceProto.FindDepartmentByHospCodeResponse.Builder response = SystemServiceProto.FindDepartmentByHospCodeResponse.newBuilder();
		List<ComboListItemInfo> listComboDepartment = bas0260Repository.findDepartmentByHospCode(request.getHospCode(), getLanguage(vertx, sessionId));
		
		if (listComboDepartment != null && !listComboDepartment.isEmpty()) {
            for (ComboListItemInfo obj : listComboDepartment) {
                CommonModelProto.ComboListItemInfo.Builder comboInfo = CommonModelProto.ComboListItemInfo.newBuilder();
                comboInfo.setCode(obj.getCode());
                comboInfo.setCodeName(obj.getCodeName());
                response.addDepartment(comboInfo);
            }
        }
		
		return response.build();
	}
	
}
