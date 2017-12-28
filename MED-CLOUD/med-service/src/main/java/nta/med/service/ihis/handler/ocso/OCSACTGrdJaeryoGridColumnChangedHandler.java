package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0313Repository;
import nta.med.data.model.ihis.ocso.OCSACTGrdJaeryoGridColumnChangedInfo;
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
public class OCSACTGrdJaeryoGridColumnChangedHandler extends ScreenHandler<OcsoServiceProto.OCSACTGrdJaeryoGridColumnChangedRequest, OcsoServiceProto.OCSACTGrdJaeryoGridColumnChangedResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTGrdJaeryoGridColumnChangedHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0313Repository ocs0313Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTGrdJaeryoGridColumnChangedResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTGrdJaeryoGridColumnChangedRequest request) throws Exception {
		OcsoServiceProto.OCSACTGrdJaeryoGridColumnChangedResponse.Builder response = OcsoServiceProto.OCSACTGrdJaeryoGridColumnChangedResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
		String languae = getLanguage(vertx, sessionId);
		List<OCSACTGrdJaeryoGridColumnChangedInfo> listGrd1 = ocs0313Repository.getOCSACTGrdJaeryoGridColumnChangedInfo(hospCode, languae,request.getHangmogCode1(), request.getSetHangmogCode(), false);
		if(!CollectionUtils.isEmpty(listGrd1)){
			for(OCSACTGrdJaeryoGridColumnChangedInfo item : listGrd1){
				OcsoModelProto.OCSACTGrdJaeryoGridColumnChangedInfo.Builder info = OcsoModelProto.OCSACTGrdJaeryoGridColumnChangedInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addDt1Item(info);
			}
		}else{
			List<OCSACTGrdJaeryoGridColumnChangedInfo> listGrd2 = ocs0313Repository.getOCSACTGrdJaeryoGridColumnChangedInfoCaseElse(hospCode, languae, request.getHangmogCode2(), false);
			if(!CollectionUtils.isEmpty(listGrd2)){
				for(OCSACTGrdJaeryoGridColumnChangedInfo item : listGrd2){
					OcsoModelProto.OCSACTGrdJaeryoGridColumnChangedInfo.Builder info = OcsoModelProto.OCSACTGrdJaeryoGridColumnChangedInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            		response.addDt2Item(info);
				}
			}
		}
		return response.build();
	}                                                                                                                 
}