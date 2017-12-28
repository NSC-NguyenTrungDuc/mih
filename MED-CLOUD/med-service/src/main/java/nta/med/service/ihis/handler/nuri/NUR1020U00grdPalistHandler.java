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
import nta.med.data.model.ihis.nuri.NUR1020U00grdPalistInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00grdPalistRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00grdPalistResponse;

@Service
@Scope("prototype")
public class NUR1020U00grdPalistHandler extends
		ScreenHandler<NuriServiceProto.NUR1020U00grdPalistRequest, NuriServiceProto.NUR1020U00grdPalistResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020U00grdPalistResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00grdPalistRequest request) throws Exception {
		NuriServiceProto.NUR1020U00grdPalistResponse.Builder response = NuriServiceProto.NUR1020U00grdPalistResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1020U00grdPalistInfo> listData = inp1001Repository.getNUR1020U00grdPalistInfo(hospCode
				, request.getHoDong()
				, request.getDate()
				, request.getA()
				, request.getB()
				, request.getC()
				, request.getD());
		
		for (NUR1020U00grdPalistInfo item : listData) {
			NuriModelProto.NUR1020U00grdPalistInfo.Builder info = NuriModelProto.NUR1020U00grdPalistInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}
	
}
