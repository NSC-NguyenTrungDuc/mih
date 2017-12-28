package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.nuro.RES1001U00FbxHospCodeLinkListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U00FbxHospCodeLinkRequest;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U00FbxHospCodeLinkResponse;

@Service
@Scope("prototype")
public class RES1001U00FbxHospCodeLinkHandler extends ScreenHandler<NuroServiceProto.RES1001U00FbxHospCodeLinkRequest, NuroServiceProto.RES1001U00FbxHospCodeLinkResponse>{
	private static final Log logger = LogFactory.getLog(RES1001U00FbxHospCodeLinkHandler.class);
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public RES1001U00FbxHospCodeLinkResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			RES1001U00FbxHospCodeLinkRequest request) throws Exception {
		NuroServiceProto.RES1001U00FbxHospCodeLinkResponse.Builder response = NuroServiceProto.RES1001U00FbxHospCodeLinkResponse.newBuilder();
		List<RES1001U00FbxHospCodeLinkListItemInfo> hospCodeLinks = bas0001Repository.getRES1001U00FbxHospCodeLinkInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(hospCodeLinks)){
			for (RES1001U00FbxHospCodeLinkListItemInfo item : hospCodeLinks) {
				NuroModelProto.RES1001U00FbxHospCodeLinkListItemInfo.Builder info = NuroModelProto.RES1001U00FbxHospCodeLinkListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addFbxHospCodeList(info);
			}
		}
		return response.build();
	}

}
