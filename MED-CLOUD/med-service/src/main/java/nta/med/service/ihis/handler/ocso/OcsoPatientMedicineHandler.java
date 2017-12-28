package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.ocso.PatientMedicineInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OcsoPatientMedicineRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OcsoPatientMedicineResponse;

@Service                                                                                                          
@Scope("prototype")
public class OcsoPatientMedicineHandler extends ScreenHandler<OcsoServiceProto.OcsoPatientMedicineRequest, OcsoServiceProto.OcsoPatientMedicineResponse>{

	private static final Log LOGGER = LogFactory.getLog(OcsoPatientMedicineHandler.class);
	
	@Resource
	private Bas0001Repository bas0001Repository;

	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Override
    @Transactional
    @Route(global = true)
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsoPatientMedicineRequest request) throws Exception {
        List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
        if(!CollectionUtils.isEmpty(bas0001List)){
            Bas0001 bas0001 = bas0001List.get(0);
            setSessionInfo(vertx, sessionId,
                    SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(), bas0001.getLanguage(), "", 1, ""));
        }
        else{
            LOGGER.info("OcsoPatientMedicineHandler preHandle not found hosp code");
        }
    }
	
	@Override
	public OcsoPatientMedicineResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OcsoPatientMedicineRequest request) throws Exception {
		
		OcsoServiceProto.OcsoPatientMedicineResponse.Builder response = OcsoServiceProto.OcsoPatientMedicineResponse.newBuilder();
		List<PatientMedicineInfo> medicineList = ocs1003Repository.getPatientMedicine(request.getPatientCode(), request.getHospCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(medicineList)){
			response.setHospName(medicineList.get(0).getHospName());
			for (PatientMedicineInfo info : medicineList) {
				OcsoModelProto.OcsoPatientMedicineInfo.Builder infoBuilder = OcsoModelProto.OcsoPatientMedicineInfo.newBuilder();
				infoBuilder.setId(info.getId() != null ? String.valueOf(info.getId()) : "");
				infoBuilder.setDatetimeRecord(info.getDatetimeRecord() != null ? info.getDatetimeRecord() : "");
				infoBuilder.setPrescriptionName(info.getPrescriptionName() != null ? info.getPrescriptionName() : "");
				infoBuilder.setMedicineName(info.getMedicineName() != null ? info.getMedicineName() : "");
				infoBuilder.setDose(info.getDose() != null ? info.getDose() : "");
				infoBuilder.setUnitCode(info.getUnitCode() != null ? info.getUnitCode() : "");
				infoBuilder.setUnit(info.getUnit() != null ? info.getUnit() : "");
				infoBuilder.setFrequency(info.getFrequency() != null ? info.getFrequency() : "");
				infoBuilder.setDays(info.getDays() != null ? info.getDays() : "");
				infoBuilder.setDosage(info.getDosage() != null ? info.getDosage() : "");
				infoBuilder.setMedicineMethod(info.getMedicineMethod() != null ? info.getMedicineMethod() : "");
				infoBuilder.setNeawonKey(CommonUtils.parseString(info.getNeawonKey()));
				infoBuilder.setHangmogCode(info.getHangmogCode() != null ? info.getHangmogCode() : "");
				
				response.addPatientMedicine(infoBuilder.build());
			}
		}
		
		return response.build();
	}
	
	
}
