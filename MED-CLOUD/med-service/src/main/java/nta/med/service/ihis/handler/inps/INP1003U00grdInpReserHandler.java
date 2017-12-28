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
import nta.med.data.model.ihis.inps.INP1003U00grdInpReserInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00grdInpReserHandler extends ScreenHandler<InpsServiceProto.INP1003U00grdInpReserRequest, InpsServiceProto.INP1003U00grdInpReserResponse> {

	@Resource
	private Inp1003Repository inp1003Repository;	

	@Override
	public INP1003U00grdInpReserResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00grdInpReserRequest request) throws Exception {
		InpsServiceProto.INP1003U00grdInpReserResponse.Builder response = InpsServiceProto.INP1003U00grdInpReserResponse.newBuilder();
		
		String hospCode = request.getHospCode();
		String reserDate = request.getReserDate();
		String hoDong = request.getHoDong();
		String language = getLanguage(vertx, sessionId);
		
		List<INP1003U00grdInpReserInfo> listInfo = inp1003Repository.getINP1003U00grdInpReser(hospCode, language, reserDate, hoDong);
		if (CollectionUtils.isEmpty(listInfo)) {
			return response.build();
		}
		
		for (INP1003U00grdInpReserInfo info : listInfo) {
			InpsModelProto.INP1003U00grdInpReserInfo.Builder infoProto = InpsModelProto.INP1003U00grdInpReserInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addGrdMasterItem(infoProto);
		}
		return response.build();
	}
	

}
