package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1001U00LayFkinp1001Handler extends ScreenHandler<NuriServiceProto.NUR1001U00LayFkinp1001Request, NuriServiceProto.NUR1001U00LayFkinp1001Response> {
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1001U00LayFkinp1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001U00LayFkinp1001Request request) throws Exception {
				
		NuriServiceProto.NUR1001U00LayFkinp1001Response.Builder response = NuriServiceProto.NUR1001U00LayFkinp1001Response.newBuilder();
		
		List<ComboListItemInfo> result = inp1001Repository.getNUR1001U00LayFkinp1001Info(getHospitalCode(vertx, sessionId), request.getBunho());
		
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				NuriModelProto.NUR1001U00LayFkinp1001Info.Builder info = NuriModelProto.NUR1001U00LayFkinp1001Info.newBuilder();
				info.setPkinp1001(item.getCode());
				info.setFkinp1001(item.getCodeName());
				response.addLayList(info);
			}
		}
		
		return response.build();
	}
}
