package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroPatientInsuranceInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroPatientInsuranceListHandler extends ScreenHandler<NuroServiceProto.NuroPatientInsuranceListRequest, NuroServiceProto.NuroPatientInsuranceListResponse> {
	private static final Log logger = LogFactory.getLog(NuroPatientInsuranceListHandler.class);
	
    @Resource
    private Out1001Repository out1001Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroPatientInsuranceListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getComingDate()) && DateUtil.toDate(request.getComingDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
    @Route(global = false)
	public NuroServiceProto.NuroPatientInsuranceListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroPatientInsuranceListRequest request) throws Exception {
		NuroServiceProto.NuroPatientInsuranceListResponse.Builder response = NuroServiceProto.NuroPatientInsuranceListResponse.newBuilder();
		List<NuroPatientInsuranceInfo> listNuroPatientInsuranceInfo = out1001Repository.getNuroPatientInsuranceListItemInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), 
        		request.getPatientCode(), request.getComingDate());
        if (listNuroPatientInsuranceInfo != null && !listNuroPatientInsuranceInfo.isEmpty()) {
            for (NuroPatientInsuranceInfo item : listNuroPatientInsuranceInfo) {
                NuroModelProto.NuroPatientInsuranceListItemInfo.Builder patientInsuranceInfo = NuroModelProto.NuroPatientInsuranceListItemInfo.newBuilder();
                
                if (item.getStatus() != null) {
                    patientInsuranceInfo.setStatus(item.getStatus());
                }

                if (item.getInsurCode() != null) {
                    patientInsuranceInfo.setInsurCode(item.getInsurCode());
                }

                if (item.getStatus() != null) {
                    patientInsuranceInfo.setInsurName(item.getInsurName());
                }

                if (item.getLastCheckDate() != null) {
                    patientInsuranceInfo.setLastCheckDate(item.getLastCheckDate().toString());
                }

                if (item.getStartDate() != null) {
                    patientInsuranceInfo.setStartDate(item.getStartDate().toString());
                }

                if (item.getPatientCode() != null) {
                    patientInsuranceInfo.setPatientCode(item.getPatientCode());
                }

                if (item.getBudamjaPatientCode() != null) {
                    patientInsuranceInfo.setBudamjaPatientCode(item.getBudamjaPatientCode());
                }

                if (item.getInsurJiyeok() != null) {
                    patientInsuranceInfo.setInsurJiyeok(item.getInsurJiyeok());
                }

                response.addPatientInsurListItem(patientInsuranceInfo);
            }
        }
		return response.build();
	}

}
