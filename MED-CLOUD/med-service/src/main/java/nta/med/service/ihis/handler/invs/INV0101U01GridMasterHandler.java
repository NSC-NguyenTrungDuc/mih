package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv0101Repository;
import nta.med.data.model.ihis.invs.INV0101U01GridMasterInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;

@Service
@Scope("prototype")
public class INV0101U01GridMasterHandler extends ScreenHandler<InvsServiceProto.INV0101U01GridMasterRequest, InvsServiceProto.INV0101U01GridMasterResponse>{
	private static final Log LOGGER = LogFactory.getLog(INV0101U01GridMasterHandler.class);

	@Resource
	private Inv0101Repository inv0101Repository;

	@Override
	@Transactional(readOnly = true)
	public InvsServiceProto.INV0101U01GridMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InvsServiceProto.INV0101U01GridMasterRequest request) throws Exception {
		InvsServiceProto.INV0101U01GridMasterResponse.Builder response = InvsServiceProto.INV0101U01GridMasterResponse.newBuilder();
		List<INV0101U01GridMasterInfo> inv0101U01GridMasterInfos = inv0101Repository.getGridMasterInfo(request.getCodeType(), getLanguage(vertx, sessionId));
		if (!CollectionUtils.isEmpty(inv0101U01GridMasterInfos)) {	
			for (INV0101U01GridMasterInfo item : inv0101U01GridMasterInfos) {
				InvsModelProto.INV0101U01GridMasterInfo.Builder itemBuilder = InvsModelProto.INV0101U01GridMasterInfo.newBuilder();
				BeanUtils.copyProperties(item, itemBuilder, getLanguage(vertx, sessionId));
				response.addGrdMasterInfo(itemBuilder);
			}
		}else{
			LOGGER.info("INV0101U01GridMasterHandler handler not found list of INV0101U01GridMasterInfo");
		}
		return response.build();
	}
}
