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
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.model.ihis.invs.INV0101U01GridDetailInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;

@Service
@Scope("prototype")
public class INV0101U01GridDetailHandler extends ScreenHandler<InvsServiceProto.INV0101U01GridDetailRequest, InvsServiceProto.INV0101U01GridDetailResponse>{
	private static final Log LOGGER = LogFactory.getLog(INV0101U01GridDetailHandler.class);

	@Resource
	private Inv0102Repository inv0102Repository;

	@Override
	@Transactional(readOnly = true)
	public InvsServiceProto.INV0101U01GridDetailResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InvsServiceProto.INV0101U01GridDetailRequest request) throws Exception {
		InvsServiceProto.INV0101U01GridDetailResponse.Builder response = InvsServiceProto.INV0101U01GridDetailResponse.newBuilder();
		List<INV0101U01GridDetailInfo> gridDetailList = inv0102Repository.getGridDetailInfo(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
		if (!CollectionUtils.isEmpty(gridDetailList)) {
			for (INV0101U01GridDetailInfo item : gridDetailList) {
				InvsModelProto.INV0101U01GridDetailInfo.Builder info = InvsModelProto.INV0101U01GridDetailInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdDetailInfo(info);
			}
		}else{
			LOGGER.info("INV0101U01GridDetailHandler handler not found list of INV0101U01GridDetailInfo");
		}
		return response.build();
	}
}
