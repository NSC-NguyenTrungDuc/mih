package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.nuri.NUR8003R02grdPayloadDataInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003R02grdPayloadDataRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003R02grdPayloadDataResponse;

@Service
@Scope("prototype")
public class NUR8003R02grdPayloadDataHandler extends
		ScreenHandler<NuriServiceProto.NUR8003R02grdPayloadDataRequest, NuriServiceProto.NUR8003R02grdPayloadDataResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR8003R02grdPayloadDataResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003R02grdPayloadDataRequest request) throws Exception {
		NuriServiceProto.NUR8003R02grdPayloadDataResponse.Builder response = NuriServiceProto.NUR8003R02grdPayloadDataResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR8003R02grdPayloadDataInfo> items = inp1001Repository.getNUR8003R02grdPayloadDataInfo(hospCode, language,
				request.getNeedHType(), request.getFromDate(), request.getToDate(), request.getHodong(), request.getBunho());
		
		for (NUR8003R02grdPayloadDataInfo item : items) {
			NuriModelProto.NUR8003R02grdPayloadDataInfo.Builder info = NuriModelProto.NUR8003R02grdPayloadDataInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}
