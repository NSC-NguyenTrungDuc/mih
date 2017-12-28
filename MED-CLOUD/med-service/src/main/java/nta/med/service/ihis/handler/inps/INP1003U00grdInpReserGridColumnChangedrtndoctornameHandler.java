package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserGridColumnChangedrtndoctornameInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtndoctornameRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtndoctornameResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00grdInpReserGridColumnChangedrtndoctornameHandler extends ScreenHandler<InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtndoctornameRequest, InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtndoctornameResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;	
	
	@Override
	public INP1003U00grdInpReserGridColumnChangedrtndoctornameResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00grdInpReserGridColumnChangedrtndoctornameRequest request) throws Exception {
		InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtndoctornameResponse.Builder response = InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtndoctornameResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String jisiDoctor = request.getJisiDoctor();
		String reserDate = request.getReserDate();
		String language = getLanguage(vertx, sessionId);

		List<INP1003U00grdInpReserGridColumnChangedrtndoctornameInfo> listInfo = inp1001Repository.getINP1003U00grdInpReserGridColumnChangedrtndoctornameInfo(hospCode, jisiDoctor, reserDate);
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		if(!CollectionUtils.isEmpty(listInfo)){
			for (INP1003U00grdInpReserGridColumnChangedrtndoctornameInfo info : listInfo) {
				InpsModelProto.INP1003U00grdInpReserGridColumnChangedrtndoctornameInfo.Builder infoProto = InpsModelProto.INP1003U00grdInpReserGridColumnChangedrtndoctornameInfo.newBuilder();
				BeanUtils.copyProperties(info, infoProto, language);
				response.addGrdMasterItem(infoProto);
			}
		}
		
		return response.build();
	}

}
