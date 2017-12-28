package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.adm.Adm3300;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3300Repository;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DrgsDRG5100P01PrintNameRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DrgsDRG5100P01PrintNameResponse;

@Service                                                                                                          
@Scope("prototype")
public class DrgsDRG5100P01PrintNameHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01PrintNameRequest, DrgsServiceProto.DrgsDRG5100P01PrintNameResponse>{

	@Resource                                                                                                       
	private Adm3300Repository adm3300Repository;

	@Override
	@Transactional(readOnly = true)
	public DrgsDRG5100P01PrintNameResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsDRG5100P01PrintNameRequest request) throws Exception {
		
		DrgsServiceProto.DrgsDRG5100P01PrintNameResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01PrintNameResponse.newBuilder();
		List<Adm3300> listResult = adm3300Repository.findByIpAddr(getHospitalCode(vertx, sessionId), request.getIpAddr());
		if(!CollectionUtils.isEmpty(listResult)){
			for (Adm3300 item : listResult) {
				DrgsModelProto.DrgsDRG5100P01PrintNameInfo info = DrgsModelProto.DrgsDRG5100P01PrintNameInfo
						.newBuilder().setBPrintName(item.getBPrintName()).build();
				response.addPrintNameList(info);
			}
		}
		
		return response.build();
	}
	
}
