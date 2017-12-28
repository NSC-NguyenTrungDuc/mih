package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangedrtnresultInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtnresultRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtnresultResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00grdInpReserGridColumnChangedrtnresultHandler extends ScreenHandler<InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtnresultRequest, InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtnresultResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;	

	@Override
	public INP1003U00grdInpReserGridColumnChangedrtnresultResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00grdInpReserGridColumnChangedrtnresultRequest request) throws Exception {
		InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtnresultResponse.Builder response = InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtnresultResponse.newBuilder();
		
		String hospCode = request.getHospCode();
		String bunho = request.getBunho();
		String language = getLanguage(vertx, sessionId);

		List<INP1003U00grdInpReserGridColumnChangedrtnresultInfo> listInfo = inp1001Repository.getINP1003U00grdInpReserGridColumnChangedrtnresultInfo(hospCode, bunho);
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		if(!CollectionUtils.isEmpty(listInfo)){
			for (INP1003U00grdInpReserGridColumnChangedrtnresultInfo info : listInfo) {
				InpsModelProto.INP1003U00grdInpReserGridColumnChangedrtnresultInfo.Builder infoProto = InpsModelProto.INP1003U00grdInpReserGridColumnChangedrtnresultInfo.newBuilder();
				BeanUtils.copyProperties(info, infoProto, language);
				response.addGrdMasterItem(infoProto);
			}
		}
		
		return response.build();
	}
	

}
