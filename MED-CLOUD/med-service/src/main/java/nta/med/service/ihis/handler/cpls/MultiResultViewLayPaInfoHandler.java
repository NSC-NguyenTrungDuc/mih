package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.cpls.MultiResultViewLayPaInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.MultiResultViewLayPaInfoRequest;
import nta.med.service.ihis.proto.CplsServiceProto.MultiResultViewLayPaInfoResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class MultiResultViewLayPaInfoHandler extends ScreenHandler <CplsServiceProto.MultiResultViewLayPaInfoRequest, CplsServiceProto.MultiResultViewLayPaInfoResponse> {                     
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public MultiResultViewLayPaInfoResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			MultiResultViewLayPaInfoRequest request) throws Exception  {                                                                   
  	   	CplsServiceProto.MultiResultViewLayPaInfoResponse.Builder response = CplsServiceProto.MultiResultViewLayPaInfoResponse.newBuilder();                      
		List<MultiResultViewLayPaInfo> listLayPa   = out0101Repository.getMultiResultViewLayPaInfo(getHospitalCode(vertx, sessionId), request.getBunho(), getLanguage(vertx, sessionId));
        if(!CollectionUtils.isEmpty(listLayPa)) {
        	for(MultiResultViewLayPaInfo item : listLayPa) {
        		CplsModelProto.MultiResultViewLayPaInfo.Builder info = CplsModelProto.MultiResultViewLayPaInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addMultiResultViewLayPaInfo(info);
        	}
        }
        return response.build();
	}
}
