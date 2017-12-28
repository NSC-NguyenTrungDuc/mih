package nta.med.service.ihis.handler.bass;

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
import nta.med.service.ihis.proto.BassModelProto.Bas0260DepartmetnInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.Bas0260UpdateDepartmentRequest;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
@Transactional
public class Bas0260UpdateDepartmentHandler extends ScreenHandler<BassServiceProto.Bas0260UpdateDepartmentRequest, SystemServiceProto.UpdateResponse>{

	private static final Log LOGGER = LogFactory.getLog(Bas0260UpdateDepartmentHandler.class); 
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;  
	
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;
	
	@Override
	@Route(global = true)
	public void preHandle(Vertx vertx, String clientId,
											  String sessionId, long contextId, BassServiceProto.Bas0260UpdateDepartmentRequest request) throws Exception  {
		List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
		if (!CollectionUtils.isEmpty(bas0001List)) {
			Bas0001 bas0001 = bas0001List.get(0);
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(),
					bas0001.getLanguage(), "", 1, ""));
		} else {
			LOGGER.info("Bas0260UpdateDepartmentHandler preHandle not found hosp code");	
		}
	}
	
	@Override
	@Route(global = false)
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			Bas0260UpdateDepartmentRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<Bas0260DepartmetnInfo> deptList = request.getListDepartmentList();
		for(Bas0260DepartmetnInfo info : deptList) {
			bas0260Repository.updateBas0260U00FromMbs("MSS", Double.parseDouble(info.getAvgTime()), request.getHospCode(), info.getGwa(), request.getLocale());
		}
		response.setResult(true);
		response.setMsg("success");
		return response.build();
	}
	
}
