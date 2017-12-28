package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.data.model.ihis.ocso.OCSACTGetFindWorkerInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSACTGetFindWorkerHandler extends ScreenHandler<OcsoServiceProto.OCSACTGetFindWorkerRequest, OcsoServiceProto.OCSACTGetFindWorkerResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTGetFindWorkerHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0108Repository ocs0108Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTGetFindWorkerResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTGetFindWorkerRequest request) throws Exception {
		OcsoServiceProto.OCSACTGetFindWorkerResponse.Builder response = OcsoServiceProto.OCSACTGetFindWorkerResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<OCSACTGetFindWorkerInfo> listFindWoker = null;
		if("ord_danui".equalsIgnoreCase(request.getColName())){
			listFindWoker = ocs0108Repository.getOCSACTGetFindWorkerInfoCaseOrdDanuiName(hospCode, language, request.getArg1());
		}else if("ord_danui_name".equalsIgnoreCase(request.getColName())){
			listFindWoker = ocs0108Repository.getOCSACTGetFindWorkerInfoCaseOrdDanuiName(hospCode, language, request.getArg1());
		}
		if(!CollectionUtils.isEmpty(listFindWoker)){
			for(OCSACTGetFindWorkerInfo item : listFindWoker){
				OcsoModelProto.OCSACTGetFindWorkerInfo.Builder info = OcsoModelProto.OCSACTGetFindWorkerInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addFwItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}