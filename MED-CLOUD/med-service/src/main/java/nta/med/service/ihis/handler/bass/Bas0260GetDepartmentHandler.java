package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.bass.BAS0260DepartmentInfo;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.Bas0260GetDepartmentRequest;
import nta.med.service.ihis.proto.BassServiceProto.Bas0260GetDepartmentResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class Bas0260GetDepartmentHandler extends ScreenHandler<BassServiceProto.Bas0260GetDepartmentRequest, BassServiceProto.Bas0260GetDepartmentResponse> {                             
	
	private static final Log LOGGER = LogFactory.getLog(Bas0260GetDepartmentHandler.class);                                        
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;                                                                   
	
	@Override
	@Transactional(readOnly = true)
    @Route(global = true)
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			BassServiceProto.Bas0260GetDepartmentRequest request) throws Exception {
		List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
		if (!CollectionUtils.isEmpty(bas0001List)) {
			Bas0001 bas0001 = bas0001List.get(0);
//			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(),
//					StringUtils.isEmpty(request.getLocale()) ? bas0001.getLanguage() : request.getLocale(), "", 1, ""));

			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(),
					bas0001.getLanguage(), "", 1, ""));
		} else {
			LOGGER.info("kcck Bas0260GetDepartmentRequest preHandle not found hosp code");
		}
	}
	
	@Override        
	@Transactional(readOnly = true)
	public Bas0260GetDepartmentResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
		Bas0260GetDepartmentRequest request) throws Exception {
		LOGGER.info("Bas0260GetDepartmentRequest: hospCode: " + request.getHospCode() + ", locale: " + request.getLocale());
		BassServiceProto.Bas0260GetDepartmentResponse.Builder response=BassServiceProto.Bas0260GetDepartmentResponse.newBuilder();
		List<BAS0260DepartmentInfo> listResult = bas0260Repository.getBas0260ListGetDepartment(request.getHospCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(BAS0260DepartmentInfo item : listResult){
				BassModelProto.Bas0260DepartmetnInfo.Builder info = BassModelProto.Bas0260DepartmetnInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setId(item.getId().toString());
				info.setAvgTime(String.valueOf(item.getAvgTime() == null ? (double)30 : item.getAvgTime()));
				response.addListDepartment(info);
			}
		}
		return response.build();
	}
}
