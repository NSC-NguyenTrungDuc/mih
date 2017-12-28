package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.data.model.ihis.nuri.NUR1016U00GrdNUR1016ListItemInfo;
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
public class NUR1016U00GrdNUR1016Handler extends ScreenHandler<NuriServiceProto.NUR1016U00GrdNUR1016Request, NuriServiceProto.NUR1016U00GrdNUR1016Response> {                             
	private static final Log LOGGER = LogFactory.getLog(NUR1016U00GrdNUR1016Handler.class);                                        
	@Resource                                                                                                       
	private Nur1016Repository nur1016Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1016U00GrdNUR1016Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NUR1016U00GrdNUR1016Request request) throws Exception {
		NuriServiceProto.NUR1016U00GrdNUR1016Response.Builder response = NuriServiceProto.NUR1016U00GrdNUR1016Response.newBuilder();
		List<NUR1016U00GrdNUR1016ListItemInfo> listResult = nur1016Repository.NUR1016U00GrdNUR1016ListItem(getHospitalCode(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(listResult)){
			for(NUR1016U00GrdNUR1016ListItemInfo item : listResult){
				NuriModelProto.NUR1016U00GrdNUR1016ListItemInfo.Builder info = NuriModelProto.NUR1016U00GrdNUR1016ListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setPknur1016(CommonUtils.parseString(item.getPknur1016()));
				response.addGrdNUR1016List(info);
			}
		}
		return response.build();
	}                                                                                                               
}                                                                                                                 
