package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0123Repository;
import nta.med.data.model.ihis.system.BasManageZipCodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.BasManageZipCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto.BasManageZipCodeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class BasManageZipCodeHandler
	extends ScreenHandler<SystemServiceProto.BasManageZipCodeRequest, SystemServiceProto.BasManageZipCodeResponse>{
	
	@Resource
	private Bas0123Repository bas0123Repository;

	@Override
	@Transactional(readOnly = true)
	public BasManageZipCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BasManageZipCodeRequest request)
			throws Exception {
        List<BasManageZipCodeInfo> listBasManageZipCodeInfo = bas0123Repository.getBasManageZipCodeInfo(request.getCondition(), request.getAddress(), request.getZip1(), request.getZip2());
        SystemServiceProto.BasManageZipCodeResponse.Builder response = SystemServiceProto.BasManageZipCodeResponse.newBuilder();
        if (listBasManageZipCodeInfo != null && !listBasManageZipCodeInfo.isEmpty()) {
            for (BasManageZipCodeInfo obj : listBasManageZipCodeInfo) {
            	SystemModelProto.BasManageZipCodeInfo.Builder builder = SystemModelProto.BasManageZipCodeInfo.newBuilder();
                BeanUtils.copyProperties(obj, builder, getLanguage(vertx, sessionId));
                response.addManageZipCodeItem(builder);
            }
        }
        return response.build();
	}
}
