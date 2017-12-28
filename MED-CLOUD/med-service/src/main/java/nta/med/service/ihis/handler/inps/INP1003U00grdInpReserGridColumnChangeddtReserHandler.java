package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangeddtReserInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtReserRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtReserResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00grdInpReserGridColumnChangeddtReserHandler extends ScreenHandler<InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtReserRequest, InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtReserResponse> {

	@Resource
	private Inp1003Repository inp1003Repository;	

	@Override
	public INP1003U00grdInpReserGridColumnChangeddtReserResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00grdInpReserGridColumnChangeddtReserRequest request) throws Exception {
		InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtReserResponse.Builder response = InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtReserResponse.newBuilder();
		
		String hospCode = request.getHospCode();
		String bunho = request.getBunho();
		String language = getLanguage(vertx, sessionId);

		List<INP1003U00grdInpReserGridColumnChangeddtReserInfo> listInfo = inp1003Repository.getINP1003U00grdInpReserGridColumnChangeddtReserInfo(hospCode, bunho);
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		if(!CollectionUtils.isEmpty(listInfo)){
			for (INP1003U00grdInpReserGridColumnChangeddtReserInfo info : listInfo) {
				InpsModelProto.INP1003U00grdInpReserGridColumnChangeddtReserInfo.Builder infoProto = InpsModelProto.INP1003U00grdInpReserGridColumnChangeddtReserInfo.newBuilder();
				BeanUtils.copyProperties(info, infoProto, language);
				response.addGrdMasterItem(infoProto);
			}
		}
		
		return response.build();
	}
	

}
