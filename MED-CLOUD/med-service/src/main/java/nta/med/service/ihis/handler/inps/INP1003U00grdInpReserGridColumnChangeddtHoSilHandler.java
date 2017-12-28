package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtHoSilRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtHoSilResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00grdInpReserGridColumnChangeddtHoSilHandler extends ScreenHandler<InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtHoSilRequest, InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtHoSilResponse> {

	@Resource
	private Bas0250Repository bas0250Repository;	

	@Override
	public INP1003U00grdInpReserGridColumnChangeddtHoSilResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00grdInpReserGridColumnChangeddtHoSilRequest request) throws Exception {
		InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtHoSilResponse.Builder response = InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtHoSilResponse.newBuilder();
		
		String hospCode = request.getHospCode();
		String hoCodeYmd = request.getHoCodeYmd();
		String hoDong = request.getHoDong();
		String hoCode = request.getHoCode();
		String language = getLanguage(vertx, sessionId);

		List<ComboListItemInfo> listInfo = bas0250Repository.getINP1003U00grdInpReserGridColumnChangeddtHoSil(hospCode, hoCodeYmd, hoDong, hoCode);
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		if(!CollectionUtils.isEmpty(listInfo)){
			for (ComboListItemInfo info : listInfo) {
				CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, infoProto, language);
				response.addGrdMasterItem(infoProto);
			}
		}
		
		return response.build();
	}

}
