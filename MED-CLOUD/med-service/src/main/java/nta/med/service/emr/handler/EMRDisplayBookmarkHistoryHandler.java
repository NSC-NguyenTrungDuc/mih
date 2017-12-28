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
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroPatientReceptionHistoryInfo;
import nta.med.data.model.ihis.system.PatientByCodeInfo;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.EMRDisplayBookmarkHistoryRequest;
import nta.med.service.emr.proto.EmrServiceProto.EMRDisplayBookmarkHistoryResponse;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.SystemModelProto;

@Service
@Scope("prototype")
public class EMRDisplayBookmarkHistoryHandler extends ScreenHandler<EmrServiceProto.EMRDisplayBookmarkHistoryRequest, EmrServiceProto.EMRDisplayBookmarkHistoryResponse>{
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public EMRDisplayBookmarkHistoryResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, EMRDisplayBookmarkHistoryRequest request)
			throws Exception {
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCode())){
			hospCode = request.getHospCode();
		}
        List<PatientByCodeInfo> listPatientByCodeInfo = out0101Repository.getGetPatientByCode(hospCode, request.getBunho(), language);
        EmrServiceProto.EMRDisplayBookmarkHistoryResponse.Builder response = EmrServiceProto.EMRDisplayBookmarkHistoryResponse.newBuilder();
        if (listPatientByCodeInfo != null && !listPatientByCodeInfo.isEmpty()) {
            for (PatientByCodeInfo obj : listPatientByCodeInfo) {
            	SystemModelProto.PatientInfo.Builder builder = SystemModelProto.PatientInfo.newBuilder();
                BeanUtils.copyProperties(obj, builder, language);
                response.addPatientListItem(builder);
            }
            
            List<NuroPatientReceptionHistoryInfo> listNuroPatientReceptionHistoryInfo = out1001Repository.getNuroPatientReceptionHistoryInfo(getLanguage(vertx, sessionId), hospCode, request.getBunho());
    		if(listNuroPatientReceptionHistoryInfo != null && !listNuroPatientReceptionHistoryInfo.isEmpty()){
    			for(NuroPatientReceptionHistoryInfo item : listNuroPatientReceptionHistoryInfo){
    				NuroModelProto.NuroPatientReceptionHistoryListItemInfo.Builder nuroPatientReceptionHistoryInfo = NuroModelProto.NuroPatientReceptionHistoryListItemInfo.newBuilder();
    				BeanUtils.copyProperties(item, nuroPatientReceptionHistoryInfo, language);
    				response.addHistoryListItem(nuroPatientReceptionHistoryInfo);
    			}
    		}
        }
        return response.build();
	}

}
