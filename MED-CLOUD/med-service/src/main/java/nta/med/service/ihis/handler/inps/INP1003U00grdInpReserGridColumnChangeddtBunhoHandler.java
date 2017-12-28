package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangeddtBunhoInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtBunhoRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtBunhoResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00grdInpReserGridColumnChangeddtBunhoHandler extends ScreenHandler<InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtBunhoRequest, InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtBunhoResponse> {

	@Resource
	private Out0101Repository out0101Repository;	

	@Override
	public INP1003U00grdInpReserGridColumnChangeddtBunhoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00grdInpReserGridColumnChangeddtBunhoRequest request) throws Exception {
		InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtBunhoResponse.Builder response = InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtBunhoResponse.newBuilder();
		
		String hospCode = request.getHospCode();
		String bunho = request.getBunho();
		String language = getLanguage(vertx, sessionId);

		List<INP1003U00grdInpReserGridColumnChangeddtBunhoInfo> listInfo = out0101Repository.getINP1003U00grdInpReserGridColumnChangeddtBunho(hospCode, bunho);
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		if(!CollectionUtils.isEmpty(listInfo)){
			for (INP1003U00grdInpReserGridColumnChangeddtBunhoInfo info : listInfo) {
				InpsModelProto.INP1003U00grdInpReserGridColumnChangeddtBunhoInfo.Builder infoProto = InpsModelProto.INP1003U00grdInpReserGridColumnChangeddtBunhoInfo.newBuilder();
				BeanUtils.copyProperties(info, infoProto, language);
				response.addGrdMasterItem(infoProto);
			}
		}
		
		return response.build();
	}
	

}
