package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl9000Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto.CPL3010U01PrCplInsertCpl9000Info;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01PrCplInsertCpl9000Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class CPL3010U01PrCplInsertCpl9000Handler extends ScreenHandler<CplsServiceProto.CPL3010U01PrCplInsertCpl9000Request, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Cpl9000Repository cpl9000Repository;                                                                    
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U01PrCplInsertCpl9000Request request) throws Exception {                                                                   
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
  	    String result = null;
		for(CPL3010U01PrCplInsertCpl9000Info info : request.getPrCplLstList()){
        	Date createDate = DateUtil.getDateTime(new Date(),DateUtil.PATTERN_YYMMDD);
        	String createTime = DateUtil.getCurrentHH24MI();
        	result = cpl9000Repository.callCPL3010U01PrCplInsertCpl9000(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),request.getUserId(),createDate,createTime,
        			 info.getIraiKey() ,info.getBunho() ,DateUtil.toDate(info.getPartJubsuDate(), DateUtil.PATTERN_YYMMDD) ,
        			 info.getPartJubsuTime(),info.getGubun() ,info.getCenterCode());
        	 if("-1".equals(result)){
				 throw new ExecutionException(response.build());
        	 }
		}
		if(!StringUtils.isEmpty(result) && !"-1".equals(result)){
			response.setResult(true);
		}else{
			response.setResult(false);
		}
		return response.build();
	}
}