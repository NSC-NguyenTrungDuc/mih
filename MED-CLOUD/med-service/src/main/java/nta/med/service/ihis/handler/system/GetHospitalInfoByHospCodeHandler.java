package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetHospitalInfoByHospCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetHospitalInfoByHospCodeResponse;

@Service                                                                                                          
@Scope("prototype") 
public class GetHospitalInfoByHospCodeHandler extends ScreenHandler<SystemServiceProto.GetHospitalInfoByHospCodeRequest, SystemServiceProto.GetHospitalInfoByHospCodeResponse> {
	private static final Log LOGGER = LogFactory.getLog(GetHospitalInfoByHospCodeHandler.class);
	@Resource                                                                                                       
	private Bas0001Repository  bas0001Repository;                                                                    
	
	@Override
    public boolean isAuthorized(Vertx vertx, String sessionId){
        return true;
    }
	
	@Override
	@Route(global = true)
	@Transactional(readOnly = true)
	public GetHospitalInfoByHospCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			GetHospitalInfoByHospCodeRequest request) throws Exception {
		SystemServiceProto.GetHospitalInfoByHospCodeResponse.Builder response = SystemServiceProto.GetHospitalInfoByHospCodeResponse.newBuilder();
		List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
		if(!CollectionUtils.isEmpty(bas0001List)){
			Bas0001 bas0001 = bas0001List.get(0);
			SystemModelProto.HospitalInfomation.Builder info = SystemModelProto.HospitalInfomation.newBuilder();
			if(!StringUtils.isEmpty(bas0001.getHospCode())){
				info.setHospCode(bas0001.getHospCode());
			}
			if(!StringUtils.isEmpty(bas0001.getYoyangName())){
				info.setHospName(bas0001.getYoyangName());
			}
			if(!StringUtils.isEmpty(bas0001.getAddress())){
				info.setAddress(bas0001.getAddress());
			}
			response.setHospInfo(info);
		}
		return response.build();
	}

}
