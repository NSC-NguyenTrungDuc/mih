package nta.med.service.emr.handler;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang3.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.emr.OCS2015U03OrderGubunInfo;
import nta.med.data.model.ihis.nuro.NuroPatientReceptionHistoryInfo;
import nta.med.data.model.ihis.system.PatientByCodeInfo;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.EMRSetDataForTvExamHistRequest;
import nta.med.service.emr.proto.EmrServiceProto.EMRSetDataForTvExamHistResponse;
import nta.med.service.ihis.proto.SystemModelProto;
@Service
@Scope("prototype")
public class EMRSetDataForTvExamHistHandler extends ScreenHandler<EmrServiceProto.EMRSetDataForTvExamHistRequest, EmrServiceProto.EMRSetDataForTvExamHistResponse>{
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;
	
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;   
	
	@Override
	@Transactional(readOnly = true)
	public EMRSetDataForTvExamHistResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, EMRSetDataForTvExamHistRequest request)
			throws Exception {
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCode())){
			hospCode = request.getHospCode();
		}
        List<PatientByCodeInfo> listPatientByCodeInfo = out0101Repository.getGetPatientByCode(hospCode, request.getBunho(), language);
        EmrServiceProto.EMRSetDataForTvExamHistResponse.Builder response = EmrServiceProto.EMRSetDataForTvExamHistResponse.newBuilder();
        if (listPatientByCodeInfo != null && !listPatientByCodeInfo.isEmpty()) {
            for (PatientByCodeInfo obj : listPatientByCodeInfo) {
            	SystemModelProto.PatientInfo.Builder builder = SystemModelProto.PatientInfo.newBuilder();
                BeanUtils.copyProperties(obj, builder, language);
                response.addPatientListItem(builder);
            }
            
            List<NuroPatientReceptionHistoryInfo> listNuroPatientReceptionHistoryInfo = out1001Repository.getNuroPatientReceptionHistoryInfo(getLanguage(vertx, sessionId), hospCode, request.getBunho());
    		if(listNuroPatientReceptionHistoryInfo != null && !listNuroPatientReceptionHistoryInfo.isEmpty()){
    			for(NuroPatientReceptionHistoryInfo item : listNuroPatientReceptionHistoryInfo){
    				EmrModelProto.OcsEmrPatientReceptionHistoryListItemInfo.Builder info = EmrModelProto.OcsEmrPatientReceptionHistoryListItemInfo.newBuilder();
    				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    				
    				List<OCS2015U03OrderGubunInfo> listGubun = ocs1003Repository.getOCS2015U03OrderGubunInfo(hospCode, request.getBunho(), item.getPkout1001());
    				for (OCS2015U03OrderGubunInfo orderItem : listGubun) {
    					EmrModelProto.OCS2015U03OrderGubunInfo.Builder orderInfo = EmrModelProto.OCS2015U03OrderGubunInfo.newBuilder();
    					BeanUtils.copyProperties(orderItem, orderInfo, language);
    					info.addOrderGubun(orderInfo);
    				}
    				
    				response.addEmrHistoryListItem(info);
    			}
    		}
        }
        return response.build();
	}

}
