package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0102Repository;
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
public class InjsINJ1001U01CboTimeHandler extends ScreenHandler<InjsServiceProto.INJ1001U01CboTimeRequest, InjsServiceProto.INJ1001U01CboTimeResponse> {
	private static final Log LOGGER = LogFactory.getLog(InjsINJ1001U01CboTimeHandler.class);
	@Resource
	private Nur0102Repository nur0102Repositoy;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001U01CboTimeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01CboTimeRequest request) throws Exception {
		InjsServiceProto.INJ1001U01CboTimeResponse.Builder response = InjsServiceProto.INJ1001U01CboTimeResponse.newBuilder();
		List<ComboListItemInfo> getGrdOcs1003List = nur0102Repositoy.getCboTimeList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
        if(!CollectionUtils.isEmpty(getGrdOcs1003List)) {
        	for (ComboListItemInfo item : getGrdOcs1003List) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOcs1003Item(info);
			}
        }
		return response.build();
	}
}
