package nta.med.service.ihis.handler.ocso;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.ocso.OCSACT2GetPatientListCPLInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACT2GetPatientListCPLRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACT2GetPatientListCPLResponse;

@Service                                                                                                          
@Scope("prototype")
public class OCSACT2GetPatientListCPLHandler extends ScreenHandler<OcsoServiceProto.OCSACT2GetPatientListCPLRequest, OcsoServiceProto.OCSACT2GetPatientListCPLResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCSACT2GetPatientListCPLHandler.class);                                    
	@Resource                                                                                                       
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCSACT2GetPatientListCPLResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSACT2GetPatientListCPLRequest request) throws Exception {
		OcsoServiceProto.OCSACT2GetPatientListCPLResponse.Builder response = OcsoServiceProto.OCSACT2GetPatientListCPLResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<OCSACT2GetPatientListCPLInfo> listGrdPa = new ArrayList<OCSACT2GetPatientListCPLInfo>();
		 if(request.getRbxJubsuChecked()){
			 listGrdPa= cpl2010Repository.getOCSACT2GetPatientListCPLInfo(hospCode,language,
					 request.getFromDate(),request.getToDate(),request.getBunho());
		 }else{
			listGrdPa = cpl2010Repository.getOCSACT2GetPatientListCPLInfo2(hospCode,language,
					 request.getFromDate(),request.getToDate(),request.getBunho());
		 }
		 if(!CollectionUtils.isEmpty(listGrdPa)){
			 for(OCSACT2GetPatientListCPLInfo item :listGrdPa){
				 OcsoModelProto.OCSACT2GetPatientListCPLInfo.Builder info = OcsoModelProto.OCSACT2GetPatientListCPLInfo.newBuilder();
				 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				 if (new BigInteger("1").compareTo(item.getNumProtocol()) <= 0) {
        			info.setTrialYn(YesNo.YES.getValue());
        		 } else {
        			info.setTrialYn(YesNo.NO.getValue());
        		 }
				 if (item.getPkocs1003() != null) {
						info.setPkocs1003(String.format("%.0f",item.getPkocs1003()));
				 }
				 if (item.getPkout1001() != null) {
						info.setPkout1001(String.format("%.0f",item.getPkout1001()));
				 }
				 response.addPatCplItem(info);
			 }
		 }
		return response.build();
	}

}
