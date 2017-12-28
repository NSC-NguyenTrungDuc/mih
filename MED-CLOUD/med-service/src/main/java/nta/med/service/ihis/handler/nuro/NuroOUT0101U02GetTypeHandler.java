package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0210Repository;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetType;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroOUT0101U02GetTypeHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GetTypeRequest, NuroServiceProto.NuroOUT0101U02GetTypeResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02GetTypeHandler.class);
	@Resource
	private Bas0210Repository bas0210Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02GetTypeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GetTypeRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02GetTypeResponse.Builder response = NuroServiceProto.NuroOUT0101U02GetTypeResponse.newBuilder();
		List<NuroOUT0101U02GetType> listNuroOUT0101U02GetType = bas0210Repository.getNuroOUT0101U02GetType(request.getJohapGubun(), request.getFind1(), getLanguage(vertx, sessionId));
		if(listNuroOUT0101U02GetType != null && !listNuroOUT0101U02GetType.isEmpty()){
			for(NuroOUT0101U02GetType item: listNuroOUT0101U02GetType){
				NuroModelProto.NuroOUT0101U02GetType.Builder nuroGetType = NuroModelProto.NuroOUT0101U02GetType.newBuilder();
				if(item.getType() != null){
					nuroGetType.setType(item.getType());
				}
				if(item.getTypeName() != null){
					nuroGetType.setTypeName(item.getTypeName());
				}
				response.addTypeItem(nuroGetType);
			}
		}
		return response.build();
	}

}
