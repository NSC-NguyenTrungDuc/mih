package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs2017Repository;
import nta.med.data.model.ihis.ocsi.NUR2017Q00grdNUR2017Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2017Q00grdNUR2017Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2017Q00grdNUR2017Response;

@Service                                                                                                          
@Scope("prototype") 
public class NUR2017Q00grdNUR2017Handler extends ScreenHandler<NuriServiceProto.NUR2017Q00grdNUR2017Request, NuriServiceProto.NUR2017Q00grdNUR2017Response>{
	@Resource                                                                                                       
	private Ocs2017Repository ocs2017Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public NUR2017Q00grdNUR2017Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2017Q00grdNUR2017Request request) throws Exception {
		NuriServiceProto.NUR2017Q00grdNUR2017Response.Builder response = NuriServiceProto.NUR2017Q00grdNUR2017Response.newBuilder();
		List<NUR2017Q00grdNUR2017Info> list = ocs2017Repository.getNUR2017Q00grdNUR2017Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), request.getOrderDate(), request.getPkocs2003());
		if (!CollectionUtils.isEmpty(list)) {
			for (NUR2017Q00grdNUR2017Info item : list) {
				NuriModelProto.NUR2017Q00grdNUR2017Info.Builder info = NuriModelProto.NUR2017Q00grdNUR2017Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}
