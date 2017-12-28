package nta.med.service.ihis.handler.bass;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0101Repository;
import nta.med.data.model.ihis.bass.BAS0101U00PrBasGridColumnChangedItemInfo;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0101U00PrBasGridColumnChangedRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0101U00PrBasGridColumnChangedResponse;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service
@Scope("prototype")
public class BAS0101U00PrBasGridColumnChangedHandler extends ScreenHandler<BassServiceProto.BAS0101U00PrBasGridColumnChangedRequest, BassServiceProto.BAS0101U00PrBasGridColumnChangedResponse>{
	private static final Log LOGGER = LogFactory.getLog(BAS0101U00PrBasGridColumnChangedHandler.class);
	@Resource
	private Bas0101Repository bas0101Repository;
	@Override
	@Transactional
	public BAS0101U00PrBasGridColumnChangedResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0101U00PrBasGridColumnChangedRequest request) throws Exception {
		LOGGER.info("[START] BAS0101U00PrBasGridColumnChangedHandler");
        Rpc.RpcMessage rpcMessage;
			 BassServiceProto.BAS0101U00PrBasGridColumnChangedResponse.Builder response=BassServiceProto.BAS0101U00PrBasGridColumnChangedResponse.newBuilder();
			BAS0101U00PrBasGridColumnChangedItemInfo prGrd = bas0101Repository.callPrBasGridColumnChanged(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),request.getMasterCheck(),request.getCodeType(),request.getColId());
			if(prGrd != null){
				BassModelProto.BAS0101U00PrBasGridColumnChangedItemInfo.Builder info= BassModelProto.BAS0101U00PrBasGridColumnChangedItemInfo.newBuilder();
				if (!StringUtils.isEmpty(prGrd.getDupYn())) {
					info.setDupYn(prGrd.getDupYn());
				}
				if (!StringUtils.isEmpty(prGrd.getError())) {
					info.setError(prGrd.getError());
				}
				response.setGrdMaster(info);
			}
		return response.build();
	}
}
