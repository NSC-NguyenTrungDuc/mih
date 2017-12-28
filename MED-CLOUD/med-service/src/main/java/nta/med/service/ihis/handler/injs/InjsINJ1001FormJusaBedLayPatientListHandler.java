package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.injs.InjsINJ1001FormJusaBedLayPatientItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class InjsINJ1001FormJusaBedLayPatientListHandler extends ScreenHandler<InjsServiceProto.INJ1001FormJusaBedLayPatientListRequest, InjsServiceProto.INJ1001FormJusaBedLayPatientListResponse>{
	private static final Log LOGGER = LogFactory.getLog(InjsINJ1001FormJusaBedLayPatientListHandler.class);
	@Resource
	private Out0101Repository out0101Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001FormJusaBedLayPatientListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001FormJusaBedLayPatientListRequest request) throws Exception {
		InjsServiceProto.INJ1001FormJusaBedLayPatientListResponse.Builder response = InjsServiceProto.INJ1001FormJusaBedLayPatientListResponse.newBuilder();
		List<InjsINJ1001FormJusaBedLayPatientItemInfo> getInjsINJ1001FormJusaBedLayPatientItemInfo= out0101Repository.getInjsINJ1001FormJusaBedLayPatientItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(getInjsINJ1001FormJusaBedLayPatientItemInfo)){
			for(InjsINJ1001FormJusaBedLayPatientItemInfo item : getInjsINJ1001FormJusaBedLayPatientItemInfo){
				InjsModelProto.INJ1001FormJusaBedLayPatientItemInfo.Builder info= InjsModelProto.INJ1001FormJusaBedLayPatientItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayPatientItem(info);
			}
		}
		return response.build();
	}
}
