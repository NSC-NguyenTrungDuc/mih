package nta.med.service.orca.handler;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.oif.Oif1101Repository;
import nta.med.data.dao.medi.oif.Oif2101Repository;
import nta.med.data.dao.medi.oif.Oif4001Repository;
import nta.med.data.dao.medi.oif.Oif5101Repository;
import nta.med.data.model.ihis.orca.ORCALibAcquisitionInfo;
import nta.med.data.model.ihis.orca.ORCALibGetClaimDiagnosisInfo;
import nta.med.data.model.ihis.orca.ORCALibGetClaimInsuredInfo;
import nta.med.data.model.ihis.orca.ORCALibGetClaimOrderInfo;
import nta.med.data.model.ihis.orca.ORCALibGetClaimPatientInfo;
import nta.med.data.model.ihis.orca.ORCALibGetDocInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.orca.proto.OrcaModelProto;
import nta.med.service.orca.proto.OrcaServiceProto;
import nta.med.service.orca.proto.OrcaServiceProto.ORCALibGetClaimInfoRequest;
import nta.med.service.orca.proto.OrcaServiceProto.ORCALibGetClaimInfoResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class ORCALibGetClaimInfoHandler extends ScreenHandler<OrcaServiceProto.ORCALibGetClaimInfoRequest, OrcaServiceProto.ORCALibGetClaimInfoResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ORCALibGetClaimInfoHandler.class);                                    
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;                                                                    
	@Resource
	private Oif1101Repository oif1101Repository;
	@Resource
	private Oif2101Repository oif2101Repository;
	@Resource
	private Oif4001Repository oif4001Repository;
	@Resource
	private Oif5101Repository oif5101Repository;
	
	@Override
	public ORCALibGetClaimInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, ORCALibGetClaimInfoRequest request)
			throws Exception {
		OrcaServiceProto.ORCALibGetClaimInfoResponse.Builder response = OrcaServiceProto.ORCALibGetClaimInfoResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Integer result = null;
		Double fkoif1101 = CommonUtils.parseDouble(request.getFkoif1101());
		List<ORCALibGetDocInfo> listDoc = bas0001Repository.getORCALibGetDocInfo(hospCode, language);
		if(!CollectionUtils.isEmpty(listDoc)){
    		for(ORCALibGetDocInfo item : listDoc){
    			OrcaModelProto.ORCALibGetDocInfo.Builder info =OrcaModelProto.ORCALibGetDocInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDocItem(info);
    		}
    	}
		List<ORCALibGetClaimPatientInfo> listClaim = oif1101Repository.getORCALibGetClaimPatientInfo(hospCode, fkoif1101);
		if(!CollectionUtils.isEmpty(listClaim)){
			for(ORCALibGetClaimPatientInfo item : listClaim){
				OrcaModelProto.ORCALibGetClaimPatientInfo.Builder info = OrcaModelProto.ORCALibGetClaimPatientInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    			if (item.getPkoif1101() != null) {
    				info.setPkoif1101(String.format("%.0f",item.getPkoif1101()));
    			}
    			if (item.getPkoif1102() != null) {
    				info.setPkoif1102(String.format("%.0f",item.getPkoif1102()));
    			}
    			if (item.getPkoif1103() != null) {
    				info.setPkoif1103(String.format("%.0f",item.getPkoif1103()));
    			}
				response.addPatientItem(info);
    		}
		}
		List<ORCALibAcquisitionInfo > listAcquistion = oif1101Repository.getORCALibAcquisitionInfo(hospCode, fkoif1101);
		if(!CollectionUtils.isEmpty(listAcquistion)){
			for(ORCALibAcquisitionInfo  item : listAcquistion){
				OrcaModelProto.ORCALibAcquisitionInfo .Builder info = OrcaModelProto.ORCALibAcquisitionInfo .newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addAcquisItem(info);
    		}
		}
		List<ORCALibGetClaimInsuredInfo > listClaimInsured = oif2101Repository.getORCALibGetClaimInsuredInfo(hospCode, fkoif1101);
		if(!CollectionUtils.isEmpty(listClaimInsured)){
			for(ORCALibGetClaimInsuredInfo  item : listClaimInsured){
				OrcaModelProto.ORCALibGetClaimInsuredInfo .Builder info = OrcaModelProto.ORCALibGetClaimInsuredInfo .newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    			if (item.getPriority() != null) {
    				info.setPriority(String.format("%.0f",item.getPriority()));
    			}
				response.addInsuranceItem(info);
    		}
		}
		List<ORCALibGetClaimOrderInfo > listClaimOrder = oif4001Repository.getORCALibGetClaimOrderInfo(hospCode, fkoif1101);
		if(!CollectionUtils.isEmpty(listClaimOrder)){
			for(ORCALibGetClaimOrderInfo  item : listClaimOrder){
				OrcaModelProto.ORCALibGetClaimOrderInfo .Builder info = OrcaModelProto.ORCALibGetClaimOrderInfo .newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addClaimOrderItem(info);
    		}
		}
		
		List<ORCALibGetClaimDiagnosisInfo > listClaimDiag = oif5101Repository.getORCALibGetClaimDiagnosisInfo(hospCode, fkoif1101);
		if(!CollectionUtils.isEmpty(listClaim)){
			for(ORCALibGetClaimDiagnosisInfo  item : listClaimDiag){
				OrcaModelProto.ORCALibGetClaimDiagnosisInfo .Builder info = OrcaModelProto.ORCALibGetClaimDiagnosisInfo .newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDiagnosisItem(info);
    		}
			for(ORCALibGetClaimDiagnosisInfo  item : listClaimDiag){
				result = oif5101Repository.updateOIF5101ByFkoif1101AndPkoif5101(hospCode, item.getDocId(), fkoif1101, item.getPkoif5101());
				if(result <= 0){
					throw new ExecutionException(response.build());
				}
			}
		}
		return response.build();
	}                                                                                                                 
}