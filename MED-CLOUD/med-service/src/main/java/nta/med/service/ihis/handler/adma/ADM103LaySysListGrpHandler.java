package nta.med.service.ihis.handler.adma;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.data.model.ihis.adma.ADM103LaySysListGrpInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service                                                                                                          
@Scope("prototype")
public class ADM103LaySysListGrpHandler extends ScreenHandler<AdmaServiceProto.ADM103LaySysListGrpRequest, AdmaServiceProto.ADM103LaySysListGrpResponse> {
	private static final Log LOGGER = LogFactory.getLog(ADM103LaySysListGrpHandler.class);                                    
	@Resource                                                                                                       
	private Adm0200Repository adm0200Repository;

	@Override
	@Transactional(readOnly = true)
	public AdmaServiceProto.ADM103LaySysListGrpResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM103LaySysListGrpRequest request) throws Exception {
		AdmaServiceProto.ADM103LaySysListGrpResponse.Builder response = AdmaServiceProto.ADM103LaySysListGrpResponse.newBuilder();
		List<ADM103LaySysListGrpInfo> listItem = adm0200Repository.getADM103LaySysListGrpInfo(request.getHospCode(), getLanguage(vertx, sessionId));
		if (!CollectionUtils.isEmpty(listItem)) {
			for (ADM103LaySysListGrpInfo item : listItem) {
				AdmaModelProto.ADM103LaySysListGrpInfo.Builder builder = AdmaModelProto.ADM103LaySysListGrpInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addGrpItem(builder);
			}
		}
		return response.build();
	}
}
