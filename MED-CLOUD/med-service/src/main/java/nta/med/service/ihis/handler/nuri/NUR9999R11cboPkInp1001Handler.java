package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.inp.Inp1001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR9999R11cboPkInp1001Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class NUR9999R11cboPkInp1001Handler
		extends ScreenHandler<NuriServiceProto.NUR9999R11cboPkInp1001Request, SystemServiceProto.ComboResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR9999R11cboPkInp1001Request request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();

		List<Inp1001> inps = inp1001Repository.findByHospCodeBunho(getHospitalCode(vertx, sessionId),
				request.getBunho());

		for (Inp1001 item : inps) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(String.format("%.0f", item.getPkinp1001()))
					.setCodeName(DateUtil.toString(item.getIpwonDate(), DateUtil.PATTERN_YYMMDD) + "'～"
							+ DateUtil.toString(item.getToiwonDate(), DateUtil.PATTERN_YYMMDD));
			response.addComboItem(info);
		}

		return response.build();
	}

}
