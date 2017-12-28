package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv6002Repository;
import nta.med.data.model.ihis.invs.INV6002U00GrdINV6002LoadcbxActorInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV6002U00GrdINV6002LoadcbxActorRequest;
import nta.med.service.ihis.proto.InvsServiceProto.INV6002U00GrdINV6002LoadcbxActorResponse;

@Service
@Scope("prototype")
public class INV6002U00GrdINV6002LoadcbxActorHandler extends ScreenHandler<InvsServiceProto.INV6002U00GrdINV6002LoadcbxActorRequest, InvsServiceProto.INV6002U00GrdINV6002LoadcbxActorResponse>{
	private static final Log LOGGER = LogFactory.getLog(INV6002U00GrdINV6002LoadcbxActorHandler.class);
	@Resource
    private Inv6002Repository inv6002Repository;

	@Override
	@Transactional(readOnly = true)
	public INV6002U00GrdINV6002LoadcbxActorResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, INV6002U00GrdINV6002LoadcbxActorRequest request) throws Exception {
		InvsServiceProto.INV6002U00GrdINV6002LoadcbxActorResponse.Builder response = InvsServiceProto.INV6002U00GrdINV6002LoadcbxActorResponse.newBuilder();
		List<INV6002U00GrdINV6002LoadcbxActorInfo> INV6002LoadcbxActorInfos = inv6002Repository.getINV6002LoadcbxActorInfos(getHospitalCode(vertx, sessionId));
		if(!CollectionUtils.isEmpty(INV6002LoadcbxActorInfos))
		{
			for(INV6002U00GrdINV6002LoadcbxActorInfo item : INV6002LoadcbxActorInfos){
				InvsModelProto.INV6002U00GrdINV6002LoadcbxActorInfo.Builder info = InvsModelProto.INV6002U00GrdINV6002LoadcbxActorInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
   			 	
   			 	response.addItem(info);           
			}
		}else{
			LOGGER.info("INV6002U00GrdINV6002cbxActorHandler handler not found list of INV6002U00GrdINV6002LoadcbxActorInfo");
		}
		return response.build();
	}

	
}
