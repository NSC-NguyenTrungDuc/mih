package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2017Q00grdNUR2017QueryEndRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2017Q00grdNUR2017QueryEndResponse;

@Service                                                                                                          
@Scope("prototype") 
public class NUR2017Q00grdNUR2017QueryEndHandler extends ScreenHandler<NuriServiceProto.NUR2017Q00grdNUR2017QueryEndRequest, NuriServiceProto.NUR2017Q00grdNUR2017QueryEndResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public NUR2017Q00grdNUR2017QueryEndResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2017Q00grdNUR2017QueryEndRequest request) throws Exception {
		NuriServiceProto.NUR2017Q00grdNUR2017QueryEndResponse.Builder response = NuriServiceProto.NUR2017Q00grdNUR2017QueryEndResponse.newBuilder();
		String result = ocs2003Repository.getNUR2017Q00grdNUR2017QueryEndInfo(getHospitalCode(vertx, sessionId), request.getBannabFkocs2003());
		if (!StringUtils.isEmpty(result)) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.setCmdItem(info);
		}
		return response.build();
	}

}
