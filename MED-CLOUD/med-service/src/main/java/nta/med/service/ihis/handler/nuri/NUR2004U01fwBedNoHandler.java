package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0253Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01fwBedNoRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01fwBedNoResponse;

@Service
@Scope("prototype")
public class NUR2004U01fwBedNoHandler
		extends ScreenHandler<NuriServiceProto.NUR2004U01fwBedNoRequest, NuriServiceProto.NUR2004U01fwBedNoResponse> {

	@Resource
	private Bas0253Repository bas0253Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR2004U01fwBedNoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U01fwBedNoRequest request) throws Exception {
		NuriServiceProto.NUR2004U01fwBedNoResponse.Builder response = NuriServiceProto.NUR2004U01fwBedNoResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<String> lstBedNo = bas0253Repository.getBedNoNUR2004U01(hospCode, request.getHoDong(), request.getHoCode());
		for (String bedNo : lstBedNo) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(bedNo);
			response.addFwItem(info);
		}
		
		return response.build();
	}	
}
