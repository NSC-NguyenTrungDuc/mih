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
import nta.med.data.model.ihis.nuri.NUR1020Q00layIpwonInfoInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layIpwonInfoRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layIpwonInfoResponse;

@Service
@Scope("prototype")
public class NUR1020Q00layIpwonInfoHandler extends
		ScreenHandler<NuriServiceProto.NUR1020Q00layIpwonInfoRequest, NuriServiceProto.NUR1020Q00layIpwonInfoResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020Q00layIpwonInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020Q00layIpwonInfoRequest request) throws Exception {
		NuriServiceProto.NUR1020Q00layIpwonInfoResponse.Builder response = NuriServiceProto.NUR1020Q00layIpwonInfoResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1020Q00layIpwonInfoInfo> items = inp1001Repository.getNUR1020Q00layIpwonInfoInfo(hospCode, request.getBunho());
		for (NUR1020Q00layIpwonInfoInfo item : items) {
			NuriModelProto.NUR1020Q00layIpwonInfoInfo.Builder info = NuriModelProto.NUR1020Q00layIpwonInfoInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayItem(info);
		}
		
		return response.build();
	}

}
