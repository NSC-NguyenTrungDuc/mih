package nta.med.service.ihis.handler.system;

import java.util.List;

import nta.med.core.utils.BeanUtils;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.LoadComboDataSourceRequest;
import nta.med.service.ihis.proto.SystemServiceProto.LoadComboDataSourceResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class LoadComboDataSourceHandler
		extends
		ScreenHandler<SystemServiceProto.LoadComboDataSourceRequest, SystemServiceProto.LoadComboDataSourceResponse> {
	@Override
	@Transactional(readOnly = true)
	public LoadComboDataSourceResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, LoadComboDataSourceRequest request)
			throws Exception {
		SystemServiceProto.LoadComboDataSourceResponse.Builder response = SystemServiceProto.LoadComboDataSourceResponse.newBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<ComboListItemInfo> listInfo = OrderBizHelper.getLoadComboDataSource(hospitalCode, language, request.getDataInfo());
		if (!CollectionUtils.isEmpty(listInfo)) {
			for (ComboListItemInfo info : listInfo) {
				CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addDataInfo(builder);
			}
		}
		return response.build();
	}
}
