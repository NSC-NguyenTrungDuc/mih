package nta.med.service.ihis.handler.cpls;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00ChangeTimeUpdateCPL2010Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL2010U00ChangeTimeUpdateCPL2010Handler extends ScreenHandler<CplsServiceProto.CPL2010U00ChangeTimeUpdateCPL2010Request, SystemServiceProto.UpdateResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL2010U00ChangeTimeUpdateCPL2010Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<CplsModelProto.CPL2010U00ChangeTimeGrdSpecimenListItemInfo> listInfo = request.getInputListList();
		if(listInfo != null && !listInfo.isEmpty()){
			for(CplsModelProto.CPL2010U00ChangeTimeGrdSpecimenListItemInfo info: listInfo){
				cpl2010Repository.updateCPL2010U00ChangeTimeUpdateCPL2010(request.getUserId(), new Date(),info.getOrderTime(), 
					 getHospitalCode(vertx, sessionId),CommonUtils.parseDouble(info.getPkcpl2010()));
			}
		}    			
		response.setResult(true);
		return response.build();
	}
}
