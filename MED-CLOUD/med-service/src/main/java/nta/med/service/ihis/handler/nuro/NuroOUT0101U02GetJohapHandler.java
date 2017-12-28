package nta.med.service.ihis.handler.nuro;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0110Repository;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetJohapInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class NuroOUT0101U02GetJohapHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GetJohapRequest, NuroServiceProto.NuroOUT0101U02GetJohapResponse> {
	@Resource
	private Bas0110Repository bas0110Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02GetJohapResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GetJohapRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02GetJohapResponse.Builder response = NuroServiceProto.NuroOUT0101U02GetJohapResponse.newBuilder();
		List<NuroOUT0101U02GetJohapInfo> listNuroOUT0101U02GetJohapInfo = bas0110Repository.getNuroOUT0101U02GetJohapInfo(request.getJohap(), new Date(), getLanguage(vertx, sessionId));
		if(listNuroOUT0101U02GetJohapInfo != null && !listNuroOUT0101U02GetJohapInfo.isEmpty()){
			for(NuroOUT0101U02GetJohapInfo item : listNuroOUT0101U02GetJohapInfo){
				NuroModelProto.NuroOUT0101U02GetJohapInfo.Builder nuroGetJohapInfo = NuroModelProto.NuroOUT0101U02GetJohapInfo.newBuilder();
				if(item.getJohapName() != null){
					nuroGetJohapInfo.setJohapName(item.getJohapName());
				}
				if(item.getJohapGubun() != null){
					nuroGetJohapInfo.setJohapGubun(item.getJohapGubun());
				}
				
				response.addJohapItem(nuroGetJohapInfo);
			}
		}
		return response.build();
	}

}
