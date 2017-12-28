package nta.med.service.ihis.handler.ocso;

import java.math.BigInteger;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1001Repository;
import nta.med.data.model.ihis.ocso.OCSACT2GetPatientListINJInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACT2GetPatientListINJRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACT2GetPatientListINJResponse;

@Service                                                                                                          
@Scope("prototype") 
public class OCSACT2GetPatientListINJHandler extends ScreenHandler<OcsoServiceProto.OCSACT2GetPatientListINJRequest, OcsoServiceProto.OCSACT2GetPatientListINJResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCSACT2GetPatientListINJHandler.class);                                    
	
	@Resource
	private Inj1001Repository inj1001Repository;
	
	@Override
	public boolean isValid(OcsoServiceProto.OCSACT2GetPatientListINJRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getReserDate()) && DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public OCSACT2GetPatientListINJResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSACT2GetPatientListINJRequest request) throws Exception {
		OcsoServiceProto.OCSACT2GetPatientListINJResponse.Builder response = OcsoServiceProto.OCSACT2GetPatientListINJResponse.newBuilder();
		 List<OCSACT2GetPatientListINJInfo> patients = inj1001Repository.getOCSACT2GetPatientListINJInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				 request.getGwa(), request.getReserDate(), request.getActingFlag());
		 if (!CollectionUtils.isEmpty(patients)) {
	        	for (OCSACT2GetPatientListINJInfo item : patients) {
	        		OcsoModelProto.OCSACT2GetPatientListINJInfo.Builder info = OcsoModelProto.OCSACT2GetPatientListINJInfo.newBuilder();
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
	        		response.addPatInjItem(info);
	        	}
	        }
		return response.build();
	} 

}
