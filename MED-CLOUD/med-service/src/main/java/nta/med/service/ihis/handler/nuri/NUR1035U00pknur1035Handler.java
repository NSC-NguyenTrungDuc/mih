package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1035U00pknur1035Handler extends ScreenHandler<NuriServiceProto.NUR1035U00pknur1035Request, NuriServiceProto.NUR1035U00pknur1035Response> {   
	
	@Resource
	private CommonRepository commonRepository;

	@Override
	@Transactional
	public NuriServiceProto.NUR1035U00pknur1035Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1035U00pknur1035Request request) throws Exception {
				
		NuriServiceProto.NUR1035U00pknur1035Response.Builder response = NuriServiceProto.NUR1035U00pknur1035Response.newBuilder();
		
		String result = commonRepository.getNextVal("NUR1035_SEQ");
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
		info.setDataValue(result);
		response.setPkitem(info);
		
		return response.build();
	}
}
