package nta.med.service.emr.handler;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.emr.OCS2015U31GetADM3200UserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31GetADM3200UserRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31GetADM3200UserResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

/**
 * @author DEV_HieuTT
 *
 */
@Service
@Scope("prototype")
public class OCS2015U31GetADM3200UserHandler extends ScreenHandler<OCS2015U31GetADM3200UserRequest, OCS2015U31GetADM3200UserResponse>{
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS2015U31GetADM3200UserResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS2015U31GetADM3200UserRequest request) throws Exception {
		
		List<OCS2015U31GetADM3200UserInfo> listResult = new ArrayList<OCS2015U31GetADM3200UserInfo>();
		
		if(getUserRole(vertx, sessionId).equals(UserRole.NORMAL_ADMIN)){
			listResult = adm3200Repository.getAdminListOCS2015U31GetADM3200UserInfo(getHospitalCode(vertx, sessionId));
		}else{
			listResult = adm3200Repository.getNursOrDoctorListOCS2015U31GetADM3200UserInfo(getHospitalCode(vertx, sessionId), request.getUserId());
		}
		
		EmrServiceProto.OCS2015U31GetADM3200UserResponse.Builder response = EmrServiceProto.OCS2015U31GetADM3200UserResponse.newBuilder();
		String language  = getLanguage(vertx, sessionId);
		if(!StringUtils.isEmpty(listResult)){
			for (OCS2015U31GetADM3200UserInfo item : listResult){
				EmrModelProto.OCS2015U31GetADM3200UserInfo.Builder info = EmrModelProto.OCS2015U31GetADM3200UserInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addAdm3200UserInfo(info);
			}
		}
		return response.build();
	}

}
