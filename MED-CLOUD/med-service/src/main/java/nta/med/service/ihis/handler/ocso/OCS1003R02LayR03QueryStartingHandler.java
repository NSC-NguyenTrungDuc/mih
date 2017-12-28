package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.ocso.OCS1003R02LayR03ListInfo;
import nta.med.data.model.ihis.ocso.OCS1003R02LayR03ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS1003R02LayR03QueryStartingRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS1003R02LayR03QueryStartingResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003R02LayR03QueryStartingHandler extends ScreenHandler<OcsoServiceProto.OCS1003R02LayR03QueryStartingRequest, OcsoServiceProto.OCS1003R02LayR03QueryStartingResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003R02LayR03QueryStartingHandler.class);                                    
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS1003R02LayR03QueryStartingResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS1003R02LayR03QueryStartingRequest request) throws Exception {
		OcsoServiceProto.OCS1003R02LayR03QueryStartingResponse.Builder response = OcsoServiceProto.OCS1003R02LayR03QueryStartingResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
		String langauge = getLanguage(vertx, sessionId);
		List<OCS1003R02LayR03ListItemInfo> listLayOut;
		List<OCS1003R02LayR03ListInfo> listInfo = out0101Repository.getOCS1003R02LayR03ListInfo(hospCode, langauge, request.getGwa(), request.getNaewonDate(), request.getBunho());
		if(!CollectionUtils.isEmpty(listInfo)){
		  listLayOut = bas0260Repository.getOCS1003R03LayOutListItemInfo(hospCode, langauge, request.getGwa(),
					listInfo.get(0).getGwaName(), 
					listInfo.get(0).getBunho(), 
					listInfo.get(0).getSuname(), 
					listInfo.get(0).getBalheangDate(),
					listInfo.get(0).getBirth(), 
					listInfo.get(0).getNaewonDate(), 
					listInfo.get(0).getBunho1(),
				    request.getNaewonDate(), request.getBunho(), request.getNaewonType(), request.getDoctor(), "1");
		  	if(!CollectionUtils.isEmpty(listLayOut)){
		  		for(OCS1003R02LayR03ListItemInfo item : listLayOut){
		  		OcsoModelProto.OCS1003R02LayR03ListItemInfo.Builder info = OcsoModelProto.OCS1003R02LayR03ListItemInfo.newBuilder();
		  		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayr03List(info);
		  		}
		  	}
		}
		return response.build();
	}                                                                                                                 
}