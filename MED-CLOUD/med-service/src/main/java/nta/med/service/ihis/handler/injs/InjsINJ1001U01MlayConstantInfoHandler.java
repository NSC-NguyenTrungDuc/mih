package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inj.Inj0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
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
public class InjsINJ1001U01MlayConstantInfoHandler extends ScreenHandler<InjsServiceProto.INJ1001U01MlayConstantInfoRequest, InjsServiceProto.INJ1001U01MlayConstantInfoResponse>{
	private static final Log LOGGER = LogFactory.getLog(InjsINJ1001U01MlayConstantInfoHandler.class);
	@Resource
	private Inj0102Repository inj0102Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001U01MlayConstantInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01MlayConstantInfoRequest request) throws Exception {
		InjsServiceProto.INJ1001U01MlayConstantInfoResponse.Builder response = InjsServiceProto.INJ1001U01MlayConstantInfoResponse.newBuilder();
		List<ComboListItemInfo> getMLayConstant = inj0102Repository.getINJ1001U01MlayConstantInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
        if(!CollectionUtils.isEmpty(getMLayConstant)){
        	for(ComboListItemInfo item : getMLayConstant){
        		CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addItem(info);
        	}
        }
		return response.build();
	}
}
