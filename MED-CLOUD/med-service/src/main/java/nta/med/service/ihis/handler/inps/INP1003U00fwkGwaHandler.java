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
import nta.med.data.model.ihis.inps.INP1003U00fwkGwaInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00fwkGwaRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00fwkGwaResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00fwkGwaHandler extends ScreenHandler<InpsServiceProto.INP1003U00fwkGwaRequest, InpsServiceProto.INP1003U00fwkGwaResponse> {

	@Resource
	private Bas0260Repository bas0260Repository;

	@Override
	public INP1003U00fwkGwaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00fwkGwaRequest request) throws Exception {
		InpsServiceProto.INP1003U00fwkGwaResponse.Builder response = InpsServiceProto.INP1003U00fwkGwaResponse.newBuilder();
		
		String hospCode = request.getHospCode();
		String buseoYmd = request.getBuseoYmd();
		String find1 = request.getFind1();
		
		List<INP1003U00fwkGwaInfo> listInfo = bas0260Repository.getINP1003U00fwkGwaInfo(hospCode, buseoYmd, find1);
		if (CollectionUtils.isEmpty(listInfo)) {
			return response.build();
		}
		
		for (INP1003U00fwkGwaInfo info : listInfo) {
			InpsModelProto.INP1003U00fwkGwaInfo.Builder infoProto = InpsModelProto.INP1003U00fwkGwaInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, getLanguage(vertx, sessionId));
			response.addFwkItem(infoProto);
		}
		
		return response.build();
	}

}
