package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.out.Out0106;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layConmentRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layConmentResponse;

@Service
@Scope("prototype")
public class NUR1020Q00layConmentHandler extends
		ScreenHandler<NuriServiceProto.NUR1020Q00layConmentRequest, NuriServiceProto.NUR1020Q00layConmentResponse> {

	@Resource
	private Out0106Repository out0106Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020Q00layConmentResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020Q00layConmentRequest request) throws Exception {
		NuriServiceProto.NUR1020Q00layConmentResponse.Builder response = NuriServiceProto.NUR1020Q00layConmentResponse.newBuilder();
		
		List<Out0106> items = out0106Repository.findByHospCodeBunho(getHospitalCode(vertx, sessionId), request.getBunho());
		for (Out0106 item : items) {
			NuriModelProto.NUR1020Q00layConmentInfo.Builder info = NuriModelProto.NUR1020Q00layConmentInfo.newBuilder()
					.setBunho(item.getBunho())
					.setSer(item.getSer() == null ? "" : String.format("%.0f", item.getSer()))
					.setComment(item.getComments() == null ? "" : item.getComments())
					.setDisplayYn(item.getDisplayYn() == null ? "" : item.getDisplayYn())
					.setHospCode(item.getHospCode());
			response.addLayItem(info);
		}
		
		return response.build();
	}
}
