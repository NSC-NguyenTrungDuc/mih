package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.model.ihis.cpls.MultiResultViewGrdSigeyulInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.MultiResultViewGrdSigeyul2Request;
import nta.med.service.ihis.proto.CplsServiceProto.MultiResultViewGrdSigeyulResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class MultiResultViewGrdSigeyul2Handler extends ScreenHandler<CplsServiceProto.MultiResultViewGrdSigeyul2Request, CplsServiceProto.MultiResultViewGrdSigeyulResponse>{                     
	@Resource                                                                                                       
	private Cpl0101Repository cpl0101Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly = true)
	public MultiResultViewGrdSigeyulResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			MultiResultViewGrdSigeyul2Request request) throws Exception {                                                                   
  	   	CplsServiceProto.MultiResultViewGrdSigeyulResponse.Builder response = CplsServiceProto.MultiResultViewGrdSigeyulResponse.newBuilder();                      
		List<MultiResultViewGrdSigeyulInfo> listSigeyu = cpl0101Repository.getMultiResultViewGrdSigeyul2(getHospitalCode(vertx, sessionId), request.getBunho(), 
				request.getGroupHangmog());
        if(!CollectionUtils.isEmpty(listSigeyu)) {
        	for(MultiResultViewGrdSigeyulInfo item : listSigeyu) {
        		CplsModelProto.MultiResultViewGrdSigeyulInfo.Builder info = CplsModelProto.MultiResultViewGrdSigeyulInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addGrdSigeyulInfo(info);
        	}
        }
        return response.build();
	}
}
