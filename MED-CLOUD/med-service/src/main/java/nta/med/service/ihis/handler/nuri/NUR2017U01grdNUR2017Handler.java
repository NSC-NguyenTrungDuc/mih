package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs2017Repository;
import nta.med.data.model.ihis.nuri.NUR2017U01grdNUR2017Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2017U01grdNUR2017Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2017U01grdNUR2017Response;

@Service
@Scope("prototype")
public class NUR2017U01grdNUR2017Handler extends
		ScreenHandler<NuriServiceProto.NUR2017U01grdNUR2017Request, NuriServiceProto.NUR2017U01grdNUR2017Response> {

	@Resource
	private Ocs2017Repository ocs2017Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR2017U01grdNUR2017Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2017U01grdNUR2017Request request) throws Exception {
		NuriServiceProto.NUR2017U01grdNUR2017Response.Builder response = NuriServiceProto.NUR2017U01grdNUR2017Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR2017U01grdNUR2017Info> items = ocs2017Repository.getNUR2017U01grdNUR2017Info(hospCode, language,
				request.getOrderGubun(), request.getActResDate(), request.getBunho(), request.getBannabDel());
		
		for (NUR2017U01grdNUR2017Info item : items) {
			NuriModelProto.NUR2017U01grdNUR2017Info.Builder info = NuriModelProto.NUR2017U01grdNUR2017Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addItems(info);
		}
		
		return response.build();
	}

	
}
