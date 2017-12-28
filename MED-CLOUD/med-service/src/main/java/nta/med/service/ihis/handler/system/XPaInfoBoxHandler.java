package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.system.XPaInfoBoxInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.XPaInfoBoxRequest;
import nta.med.service.ihis.proto.SystemServiceProto.XPaInfoBoxResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class XPaInfoBoxHandler extends ScreenHandler<SystemServiceProto.XPaInfoBoxRequest, SystemServiceProto.XPaInfoBoxResponse>{
	@Resource
    private Out0101Repository out0101Repository;
	
	
	@Override
	@Transactional(readOnly = true)
	public XPaInfoBoxResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, XPaInfoBoxRequest request)
			throws Exception  {
        SystemServiceProto.XPaInfoBoxResponse.Builder response = SystemServiceProto.XPaInfoBoxResponse.newBuilder();
		List<XPaInfoBoxInfo> listXPaInfoBoxInfo = out0101Repository.getXPaInfoBoxInfo(getHospitalCode(vertx, sessionId), request.getDepartmentCode(), getLanguage(vertx, sessionId));
        if (listXPaInfoBoxInfo != null && !listXPaInfoBoxInfo.isEmpty()) {
            for (XPaInfoBoxInfo obj : listXPaInfoBoxInfo) {
            	SystemModelProto.XPaInfoBoxInfo.Builder builder = SystemModelProto.XPaInfoBoxInfo.newBuilder();
                BeanUtils.copyProperties(obj, builder, getLanguage(vertx, sessionId));
                response.addPatientInfoItem(builder);
            }
        }
        return response.build();
	}
}
