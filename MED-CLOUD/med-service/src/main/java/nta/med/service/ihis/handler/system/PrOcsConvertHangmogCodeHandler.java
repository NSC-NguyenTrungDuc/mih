package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0118Repository;
import nta.med.data.model.ihis.system.PrOcsConvertHangmogCodeInfo;
import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsConvertHangmogCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsConvertHangmogCodeResponse;

import org.apache.commons.lang3.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PrOcsConvertHangmogCodeHandler extends ScreenHandler<SystemServiceProto.PrOcsConvertHangmogCodeRequest , SystemServiceProto.PrOcsConvertHangmogCodeResponse > {                     
	@Resource                                                                                                       
	private Ocs0118Repository ocs0118Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public PrOcsConvertHangmogCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PrOcsConvertHangmogCodeRequest request) throws Exception {                                                                   
  	   	SystemServiceProto.PrOcsConvertHangmogCodeResponse.Builder response = SystemServiceProto.PrOcsConvertHangmogCodeResponse.newBuilder();                      
		Date gijunDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		PrOcsConvertHangmogCodeInfo info ;
			 info = ocs0118Repository.callPrOcsConvertHangmogCode(getHospitalCode(vertx, sessionId), request.getConvClass(),
					request.getGubun(), request.getHangmogCode(), request.getBunho(), gijunDate, 
					"", "", "");
		if(info != null){
			if(!StringUtils.isEmpty(info.getIoHangmogCode())) {
				response.setHangmogCode(info.getIoHangmogCode());
			}
			if(!StringUtils.isEmpty(info.getIoMsgYn())) {
				response.setMsgYn(info.getIoMsgYn());
			}
			if(!StringUtils.isEmpty(info.getIoRemark())) {
				response.setRemark(info.getIoRemark());
			}
		}
		return response.build();
	}
}