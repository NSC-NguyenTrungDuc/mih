package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inj.Inj0101Repository;
import nta.med.data.model.ihis.injs.InjsINJ1001U01FormJusaBedLayHosilItemInfo;
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
public class InjsINJ1001U01FormJusaBedLayHosilListHandler extends ScreenHandler<InjsServiceProto.INJ1001U01FormJusaBedLayHosilListRequest, InjsServiceProto.INJ1001U01FormJusaBedLayHosilListResponse> {
	private static final Log LOGGER = LogFactory.getLog(InjsINJ1001U01FormJusaBedLayHosilListHandler.class);
	@Resource
	private Inj0101Repository inj0101Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001U01FormJusaBedLayHosilListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01FormJusaBedLayHosilListRequest request) throws Exception {
		InjsServiceProto.INJ1001U01FormJusaBedLayHosilListResponse.Builder response = InjsServiceProto.INJ1001U01FormJusaBedLayHosilListResponse.newBuilder();
		List<InjsINJ1001U01FormJusaBedLayHosilItemInfo> getLayPatientList = inj0101Repository.getInjsINJ1001U01FormJusaBedLayHosilItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(getLayPatientList)){
			for(InjsINJ1001U01FormJusaBedLayHosilItemInfo item : getLayPatientList){
				InjsModelProto.INJ1001U01FormJusaBedLayHosilItemInfo .Builder info = InjsModelProto.INJ1001U01FormJusaBedLayHosilItemInfo .newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayPatientItem(info);
			}
		}
		return response.build();
	}
}
