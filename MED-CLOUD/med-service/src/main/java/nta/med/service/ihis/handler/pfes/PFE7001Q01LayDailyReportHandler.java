package nta.med.service.ihis.handler.pfes;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.pfes.PFE7001Q01LayDailyReportInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PfesModelProto;
import nta.med.service.ihis.proto.PfesServiceProto;
import nta.med.service.ihis.proto.PfesServiceProto.PFE7001Q01LayDailyReportRequest;
import nta.med.service.ihis.proto.PfesServiceProto.PFE7001Q01LayDailyReportResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PFE7001Q01LayDailyReportHandler
	extends ScreenHandler <PfesServiceProto.PFE7001Q01LayDailyReportRequest, PfesServiceProto.PFE7001Q01LayDailyReportResponse> {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public PFE7001Q01LayDailyReportResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PFE7001Q01LayDailyReportRequest request) throws Exception {                                                                 
  	   	PfesServiceProto.PFE7001Q01LayDailyReportResponse.Builder response = PfesServiceProto.PFE7001Q01LayDailyReportResponse.newBuilder();                      
    	List<PFE7001Q01LayDailyReportInfo> listObject = ocs0103Repository.getPFE7001Q01LayDailyReportInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId)
        		, request.getKensaDate(), request.getIoGubun(), request.getPartCode());
        if(!CollectionUtils.isEmpty(listObject)) {
        	for(PFE7001Q01LayDailyReportInfo item : listObject) {
        		PfesModelProto.PFE7001Q01LayDailyReportInfo.Builder info = PfesModelProto.PFE7001Q01LayDailyReportInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addDailyReportItem(info);
        	}
        }
        return response.build();
	}
}