package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur1017Repository;
import nta.med.data.model.ihis.nuri.NUR1017U00GrdNUR1017ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class NUR1017U00GrdNUR1017Handler extends ScreenHandler<NuriServiceProto.NUR1017U00GrdNUR1017Request, NuriServiceProto.NUR1017U00GrdNUR1017Response> {                             
	private static final Log LOGGER = LogFactory.getLog(NUR1017U00GrdNUR1017Handler.class);                                        
	@Resource                                                                                                       
	private Nur1017Repository nur1017Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1017U00GrdNUR1017Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NUR1017U00GrdNUR1017Request request) throws Exception {
		NuriServiceProto.NUR1017U00GrdNUR1017Response.Builder response = NuriServiceProto.NUR1017U00GrdNUR1017Response.newBuilder();
		List<NUR1017U00GrdNUR1017ListItemInfo> listResult = nur1017Repository.getNUR1017U00GrdNUR1017ListItem(getHospitalCode(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(listResult)){
			for(NUR1017U00GrdNUR1017ListItemInfo item : listResult){
				NuriModelProto.NUR1017U00GrdNUR1017ListItemInfo.Builder info = NuriModelProto.NUR1017U00GrdNUR1017ListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdNUR1017List(info);
			}
		}
		return response.build();
	}                                                                                                               
}                                                                                                                 
