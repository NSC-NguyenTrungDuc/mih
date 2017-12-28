package nta.med.service.ihis.handler.nuro;

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

import nta.med.data.dao.medi.out.Out2016Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U00FbxHospCodeLinkDataValidatingRequest;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U00FbxHospCodeLinkDataValidatingResponse;

@Service
@Scope("prototype")
public class RES1001U00FbxHospCodeLinkDataValidatingHandler extends ScreenHandler<NuroServiceProto.RES1001U00FbxHospCodeLinkDataValidatingRequest, NuroServiceProto.RES1001U00FbxHospCodeLinkDataValidatingResponse>{
	private static final Log logger = LogFactory.getLog(RES1001U00FbxHospCodeLinkDataValidatingHandler.class);
	
	@Resource
	private Out2016Repository out2016Repository;
	
	@Override
	@Transactional(readOnly = true)
	public RES1001U00FbxHospCodeLinkDataValidatingResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, RES1001U00FbxHospCodeLinkDataValidatingRequest request) throws Exception {
		NuroServiceProto.RES1001U00FbxHospCodeLinkDataValidatingResponse.Builder response = NuroServiceProto.RES1001U00FbxHospCodeLinkDataValidatingResponse.newBuilder();
		List<ComboListItemInfo> listInfo = out2016Repository.getRES1001U00FbxHospCodeLinkDataValidating(request.getHospCode(), getLanguage(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(listInfo)){
			if(!StringUtils.isEmpty(listInfo.get(0).getCode())){
				response.setHospName(listInfo.get(0).getCode());
			}
			if(!StringUtils.isEmpty(listInfo.get(0).getCodeName())){
				response.setBunhoLink(listInfo.get(0).getCodeName());
			}
		}
		return response.build();
	}

}
