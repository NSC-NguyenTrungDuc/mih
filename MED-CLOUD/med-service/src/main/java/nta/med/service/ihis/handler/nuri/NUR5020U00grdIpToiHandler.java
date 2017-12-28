package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.nuri.NUR5020U00grdIpToiInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdIpToiRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdIpToiResponse;

@Service
@Scope("prototype")
public class NUR5020U00grdIpToiHandler
		extends ScreenHandler<NuriServiceProto.NUR5020U00grdIpToiRequest, NuriServiceProto.NUR5020U00grdIpToiResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR5020U00grdIpToiResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00grdIpToiRequest request) throws Exception {
		NuriServiceProto.NUR5020U00grdIpToiResponse.Builder response = NuriServiceProto.NUR5020U00grdIpToiResponse
				.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String queryNumber = request.getQueryNumber();

		if ("1".equals(queryNumber)) {
			List<NUR5020U00grdIpToiInfo> items = inp1001Repository.getNUR5020U00grdIpToiInfoCase1(hospCode, language,
					DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD), request.getHoDong());
			for (NUR5020U00grdIpToiInfo item : items) {
				NuriModelProto.NUR5020U00grdIpToiInfo.Builder info = NuriModelProto.NUR5020U00grdIpToiInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				info.setBigo("");
				response.addGrdMasterItem(info);
			}
		} else if("2".equals(queryNumber)){
			List<NUR5020U00grdIpToiInfo> items = inp1001Repository.getNUR5020U00grdIpToiInfoCase2(hospCode, language,
					DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD), request.getHoDong());
			for (NUR5020U00grdIpToiInfo item : items) {
				NuriModelProto.NUR5020U00grdIpToiInfo.Builder info = NuriModelProto.NUR5020U00grdIpToiInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdMasterItem(info);
			}
		}

		return response.build();
	}

}
