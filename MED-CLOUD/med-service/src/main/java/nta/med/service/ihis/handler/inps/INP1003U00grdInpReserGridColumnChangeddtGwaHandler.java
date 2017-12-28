package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangeddtGwaInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtGwaRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtGwaResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00grdInpReserGridColumnChangeddtGwaHandler extends ScreenHandler<InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtGwaRequest, InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtGwaResponse> {

	@Resource
	private Bas0260Repository bas0260Repository;	
	
	@Override
	public INP1003U00grdInpReserGridColumnChangeddtGwaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00grdInpReserGridColumnChangeddtGwaRequest request) throws Exception {
		InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtGwaResponse.Builder response = InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtGwaResponse.newBuilder();
		
		String hospCode = request.getHospCode();
		String gwa = request.getGwa();
		String reserDate = request.getReserDate();
		String language = getLanguage(vertx, sessionId);

		List<INP1003U00grdInpReserGridColumnChangeddtGwaInfo> listInfo = bas0260Repository.getINP1003U00grdInpReserGridColumnChangeddtGwa(hospCode, gwa, reserDate);
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		if(!CollectionUtils.isEmpty(listInfo)){
			for (INP1003U00grdInpReserGridColumnChangeddtGwaInfo info : listInfo) {
				InpsModelProto.INP1003U00grdInpReserGridColumnChangeddtGwaInfo.Builder infoProto = InpsModelProto.INP1003U00grdInpReserGridColumnChangeddtGwaInfo.newBuilder();
				BeanUtils.copyProperties(info, infoProto, language);
				response.addGrdMasterItem(infoProto);
			}
		}
		
		return response.build();
	}

}