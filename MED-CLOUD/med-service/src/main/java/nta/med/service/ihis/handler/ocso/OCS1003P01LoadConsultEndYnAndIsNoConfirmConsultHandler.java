package nta.med.service.ihis.handler.ocso;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.LoadConsultEndYNInfo;
import nta.med.service.ihis.proto.CommonModelProto.NoConfirmConsultInfo;
import nta.med.service.ihis.proto.OcsoServiceProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultHandler extends ScreenHandler<OcsoServiceProto.OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultRequest, OcsoServiceProto.OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0503Repository ocs0503Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultRequest request) throws Exception {
		OcsoServiceProto.OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResponse.Builder response = OcsoServiceProto.OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResponse.newBuilder();                      
		String hospCode = getHospitalCode(vertx, sessionId);
		boolean colsultYn = false;
		LoadConsultEndYNInfo info = request.getItemInfo();
		Date maxReqDate = ocs0503Repository.getLoadConsultEndYN(hospCode, info.getBunho(), info.getReqDoctor());
		if(maxReqDate != null){
			response.setReqDate(DateUtil.toString(maxReqDate, DateUtil.PATTERN_YYMMDD));
		}
		
		NoConfirmConsultInfo cosultInfo = request.getConfirmConsultInfo();
		Date naewonDate = DateUtil.toDate(cosultInfo.getNaewondate(), DateUtil.PATTERN_YYMMDD);
		String result = ocs0503Repository.getNoConfirmConsult(hospCode, cosultInfo.getBunho(), naewonDate, cosultInfo.getGwa(),
				cosultInfo.getDoctor(), cosultInfo.getIoGubun());
		if("Y".equals(result)){
			colsultYn = true;
		}
		response.setIsNoReturnConsultYn(colsultYn);
		return response.build();
	}                                                                                                                 
}