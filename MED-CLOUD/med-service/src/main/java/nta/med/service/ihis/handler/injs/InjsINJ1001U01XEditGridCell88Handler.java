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
public class InjsINJ1001U01XEditGridCell88Handler extends ScreenHandler<InjsServiceProto.INJ1001U01XEditGridCell88Request, InjsServiceProto.INJ1001U01XEditGridCell88Response>{
	private static final Log LOGGER = LogFactory.getLog(InjsINJ1001U01XEditGridCell88Handler.class);
	@Resource
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001U01XEditGridCell88Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01XEditGridCell88Request request) throws Exception {
		InjsServiceProto.INJ1001U01XEditGridCell88Response.Builder response = InjsServiceProto.INJ1001U01XEditGridCell88Response.newBuilder();
		List<ComboListItemInfo> xeditGridCell88List = nur0102Repository.getINJ1001U01XEditGridCell88(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(xeditGridCell88List)){
			for (ComboListItemInfo item : xeditGridCell88List) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addXeditGridCell88Item(info);
			}
		}
		return response.build();
	}
}
