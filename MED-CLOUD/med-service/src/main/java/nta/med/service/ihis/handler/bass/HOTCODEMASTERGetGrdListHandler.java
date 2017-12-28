package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.AdmHotCodeRepository;
import nta.med.data.model.ihis.bass.HOTCODEMASTERGetGrdListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.HOTCODEMASTERGetGrdListRequest;
import nta.med.service.ihis.proto.BassServiceProto.HOTCODEMASTERGetGrdListResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class HOTCODEMASTERGetGrdListHandler extends
		ScreenHandler<BassServiceProto.HOTCODEMASTERGetGrdListRequest, BassServiceProto.HOTCODEMASTERGetGrdListResponse> {
	private static final Log LOGGER = LogFactory.getLog(HOTCODEMASTERSaveLayoutHandler.class);

	@Resource
	private AdmHotCodeRepository admHotCodeRepository;

	@Override
	@Transactional(readOnly = true)
	public HOTCODEMASTERGetGrdListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, HOTCODEMASTERGetGrdListRequest request) throws Exception {
		BassServiceProto.HOTCODEMASTERGetGrdListResponse.Builder response = BassServiceProto.HOTCODEMASTERGetGrdListResponse.newBuilder();
		
		String offset = request.getOffset();
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		List<HOTCODEMASTERGetGrdListInfo> listItem = admHotCodeRepository.getHOTCODEMASTERGetGrdListInfo(request.getHotCode(), request.getHangmogName(), 
				startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(listItem)){
			for(HOTCODEMASTERGetGrdListInfo item : listItem){				
				BassModelProto.HOTCODEMASTERGetGrdListInfo.Builder info = BassModelProto.HOTCODEMASTERGetGrdListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdListItem(info);
			}
		}
		
		return response.build();
	}

}
