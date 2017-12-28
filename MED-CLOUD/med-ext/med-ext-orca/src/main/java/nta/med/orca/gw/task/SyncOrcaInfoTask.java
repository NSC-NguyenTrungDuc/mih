package nta.med.orca.gw.task;

import nta.med.common.util.concurrent.executor.XExecutors;
import nta.med.core.glossary.OrcaApiConfig;
import nta.med.orca.gw.api.command.AcceptancelstCommand;
import nta.med.orca.gw.api.command.AppointListCommand;
import nta.med.orca.gw.api.command.PatientInfoCommand;
import nta.med.orca.gw.api.command.PatientListCommand;
import nta.med.orca.gw.api.contracts.message.*;
import nta.med.orca.gw.api.contracts.service.*;
import nta.med.orca.gw.cache.OrcaInfoCache;
import nta.med.orca.gw.model.patient.*;
import nta.med.orca.gw.model.patient.impl.*;
import nta.med.orca.gw.service.order.OrderAdministrator;
import nta.med.orca.gw.service.patient.PatientAdministrator;
import nta.med.orca.gw.service.system.SystemAdministrator;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.batch.core.StepContribution;
import org.springframework.batch.core.scope.context.ChunkContext;
import org.springframework.batch.core.step.tasklet.Tasklet;
import org.springframework.batch.repeat.RepeatStatus;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import io.netty.handler.codec.http.HttpContentEncoder.Result;

import javax.annotation.Resource;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;
import java.util.concurrent.*;
import java.util.concurrent.atomic.AtomicReference;

public class SyncOrcaInfoTask implements Tasklet {
	
	private static final Logger LOGGER = LogManager.getLogger(SyncOrcaInfoTask.class);
	
    @Resource
    private SystemAdministrator systemAdministrator;
	
    @Resource
    private OrderAdministrator orderAdministrator;
    
    @Resource
    private PatientListCommand patientListCommand;
    
    @Resource
    private PatientInfoCommand patientInfoCommand;
    
    @Resource
    private PatientAdministrator patientAdministrator;
    
    @Resource
    private AppointListCommand appointListCommand;
    
    @Resource
    private AcceptancelstCommand acceptancelstCommand;

	private static final AtomicReference<Status> status = new AtomicReference(Status.STOPPED);

	private final Map<String, ExecutorService> executors = new ConcurrentHashMap<>();
    
	public SyncOrcaInfoTask() {
		
	}

	@Override
	public RepeatStatus execute(StepContribution contribution, ChunkContext chunkContext) throws Exception {
		LOGGER.info("[START] SYNC DATA FROM ORCA TO KCCK...");
		if(this.status.compareAndSet(Status.STOPPED, Status.STARTED)) {
			try {
				List<OrcaEnvInfo> orcas = systemAdministrator.getOrcaEnvInfo();
				DateFormat df = new SimpleDateFormat("yyyy-MM-dd");
				String currentDate = df.format(new Date());
				final CountDownLatch latch = new CountDownLatch(orcas.size());
				for (OrcaEnvInfo orcaEnvInfo : orcas) {
					ExecutorService exec;
					if(!executors.containsKey(orcaEnvInfo.getHospCode())) 
						executors.putIfAbsent(orcaEnvInfo.getHospCode(), XExecutors.create("batch." + orcaEnvInfo.getHospCode(), 1));
					exec = executors.get(orcaEnvInfo.getHospCode());
					exec.execute(() -> {
						try {
							LOGGER.info("[BEGIN] SYNC DADA HOSP_CODE = " + orcaEnvInfo.getHospCode());
							boolean syncPatientResult = syncPatient(orcaEnvInfo, currentDate);

							if(syncPatientResult){
								boolean syncReceptionResult = syncReception(orcaEnvInfo, currentDate);
								if(syncReceptionResult){
									syncPaidOrder(orcaEnvInfo, currentDate);
								}
							}

							LOGGER.info("[FINISH] SYNC DADA HOSP_CODE = " + orcaEnvInfo.getHospCode());
						} finally {
							latch.countDown();
						}
					});
				}
				boolean successful = latch.await(10, TimeUnit.MINUTES);
				if(!successful) {
					executors.clear();
				}
			}finally {
				this.status.set(Status.STOPPED);
			}
		} else {
			LOGGER.warn("There is another task is being run.");
		}
		
		LOGGER.info("[END] SYNC DATA FROM ORCA TO KCCK...");
		return RepeatStatus.FINISHED;
	}
	
	// sync patient and insurance to KCCK
	private boolean syncPatient(OrcaEnvInfo orcaEnvInfo, String currentDate){
		try {
			OrcaInfoCache.patientListCache.putIfAbsent(orcaEnvInfo.getHospCode(), new ConcurrentHashMap<>());
			List<PatientInformation> patients = getPatientListToday(orcaEnvInfo, currentDate);
			List<PatientInfo> patientDetailList = getPatientDetailListToday(orcaEnvInfo, patients);
			List<PatientInfo> patientDetailListUpdate = new ArrayList<>();
			
			ConcurrentMap<String, Integer> mapPts = OrcaInfoCache.patientListCache.get(orcaEnvInfo.getHospCode());
			for (PatientInfo patientInfo : patientDetailList) {
				if(mapPts.containsKey(patientInfo.getPatientId())){
					if(mapPts.get(patientInfo.getPatientId()) != patientInfo.hashCode()){
						OrcaInfoCache.patientListCache.get(orcaEnvInfo.getHospCode()).remove(patientInfo.getPatientId());
						OrcaInfoCache.patientListCache.get(orcaEnvInfo.getHospCode()).putIfAbsent(patientInfo.getPatientId(), patientInfo.hashCode());
						patientDetailListUpdate.add(patientInfo);
					}
				} else {
					OrcaInfoCache.patientListCache.get(orcaEnvInfo.getHospCode()).putIfAbsent(patientInfo.getPatientId(), patientInfo.hashCode());
					patientDetailListUpdate.add(patientInfo);
				}
			}
			
			if(!CollectionUtils.isEmpty(patientDetailListUpdate)){
				boolean syncResult = syncPatien(orcaEnvInfo.getHospCode(), patientDetailListUpdate);
				LOGGER.info("SYNC PATIENT RESULT: hosp_code = " + orcaEnvInfo.getHospCode() + ", result = " + syncResult);
//				if(!syncResult){
//					for (PatientInfo patientInfo : patientDetailListUpdate) {
//						OrcaInfoCache.patientListCache.get(orcaEnvInfo.getHospCode()).remove(patientInfo.getPatientId());						
//					}
//				}
			}
		} catch (Exception e) {
			LOGGER.error("Sync patient and insurance fail, hosp_code = " + orcaEnvInfo.getHospCode(), e);
			return false;
		}
		
		return true;
	}
	
	// sync reception to KCCK
	private boolean syncReception(OrcaEnvInfo orcaEnvInfo, String currentDate){
		try {
			List<AcceptlstInfo> receptionList = getReceptionListToday(orcaEnvInfo, currentDate, "03");
			if(CollectionUtils.isEmpty(receptionList)){
				return true;
			}
			
			List<AppointlstInformationChild> appointList = getAppointListToday(orcaEnvInfo, currentDate);
			List<AppointlstInformationChild> appointListVisit = new ArrayList<>();
			
			for (AppointlstInformationChild item : appointList) {
				if(item.getVisitInformation() != null || "1".equals(item.getVisitInformation())){
					appointListVisit.add(item);
				}
			}
			
			if(!CollectionUtils.isEmpty(appointListVisit)){
				for (AcceptlstInfo info : receptionList) {
					for (AppointlstInformationChild item : appointListVisit) {
						if(info.getPatientInformation().getPatientId().equals(item.getPatientInformation().getPatientId())
								&& info.getPhysicianCode().equals(item.getPhysicianCode().getValue())
								&& info.getDepartmentCode().equals(item.getDepartmentCode().getValue())
								/*&& info.getMedicalInformation().equals(item.getMedicalInformation().getValue())*/){
							
							info.setAppointmentYn("Y");
							info.setAppointTime(item.getAppointmentTime().getValue().replace(":", "").substring(0, 4));
						}
					}
					
					if(info.getAppointmentYn() == null){
						info.setAppointmentYn("N");
					}
				}
			}
			
			OrcaInfoCache.acceptListCache.putIfAbsent(orcaEnvInfo.getHospCode(), new ConcurrentHashMap<>());
			ConcurrentMap<String, Integer> mapAccept = OrcaInfoCache.acceptListCache.get(orcaEnvInfo.getHospCode());
			List<AcceptlstInfo> receptionListUpdate = new ArrayList<>();
			for (AcceptlstInfo info : receptionList) {
				if(mapAccept.containsKey(info.getAcceptanceId())){
					if(mapAccept.get(info.getAcceptanceId()) != info.hashCode()){
						OrcaInfoCache.acceptListCache.get(orcaEnvInfo.getHospCode()).remove(info.getAcceptanceId());
						mapAccept.remove(info.getAcceptanceId());
						OrcaInfoCache.acceptListCache.get(orcaEnvInfo.getHospCode()).putIfAbsent(info.getAcceptanceId(), info.hashCode());
						receptionListUpdate.add(info);
					}
				} else {
					OrcaInfoCache.acceptListCache.get(orcaEnvInfo.getHospCode()).putIfAbsent(info.getAcceptanceId(), info.hashCode());
					receptionListUpdate.add(info);
				}
			}
			
			if(!CollectionUtils.isEmpty(receptionListUpdate)){
				List<SyncExamination> examList = new ArrayList<>();
				for (AcceptlstInfo info : receptionListUpdate) {
					if(StringUtils.isEmpty(info.getAcceptanceId())){
						LOGGER.warn("Sync reception: AcceptanceId is null, patient_id = " + info.getPatientInformation().getPatientId());
					} else {
						SyncExamination exam = new SyncExaminationImpl().copyFromAcceptlstInfo(info, currentDate.replace("-", "/"));
						examList.add(exam);
					}
				}
				
				boolean syncResult = patientAdministrator.acceptingSynchronization(examList, orcaEnvInfo.getHospCode());
				LOGGER.info("SYNC RECEPTION RESULT: hosp_code = " + orcaEnvInfo.getHospCode() + ", result = " + syncResult);
				
//				if(!syncResult){
//					for (SyncExamination exam : examList) {
//						OrcaInfoCache.acceptListCache.get(orcaEnvInfo.getHospCode()).remove(exam.getReceptRefId());						
//					}
//				}
			}
		} catch (Exception e) {
			LOGGER.error("Sync reception fail, hosp_code = " + orcaEnvInfo.getHospCode(), e);
			return false;
		}
		
		return true;
	}
	
	// Sync paid order to KCCK
	private boolean syncPaidOrder(OrcaEnvInfo orcaEnvInfo, String currentDate){
		try {
			List<AcceptlstInfo> receptionList = getReceptionListToday(orcaEnvInfo, currentDate, "02");
			if(CollectionUtils.isEmpty(receptionList)){
				return true;
			}
			
			List<String> refIdListUpd = new ArrayList<>();
			OrcaInfoCache.paidOrderCache.putIfAbsent(orcaEnvInfo.getHospCode(), new ConcurrentHashMap<>());
			ConcurrentMap<String, Integer> mapRefId = OrcaInfoCache.paidOrderCache.get(orcaEnvInfo.getHospCode());
			
			for (AcceptlstInfo info : receptionList) {
				if(mapRefId.containsKey(info.getAcceptanceId())){
					if(mapRefId.get(info.getAcceptanceId()) != info.hashCode()){
						OrcaInfoCache.paidOrderCache.get(orcaEnvInfo.getHospCode()).remove(info.getAcceptanceId());
						mapRefId.remove(info.getAcceptanceId());
						OrcaInfoCache.paidOrderCache.get(orcaEnvInfo.getHospCode()).putIfAbsent(info.getAcceptanceId(), info.hashCode());
						refIdListUpd.add(info.getAcceptanceId());
					}
				} else {
					OrcaInfoCache.paidOrderCache.get(orcaEnvInfo.getHospCode()).putIfAbsent(info.getAcceptanceId(), info.hashCode());
					refIdListUpd.add(info.getAcceptanceId());
				}
			}
			
			if(!CollectionUtils.isEmpty(refIdListUpd)){
				orderAdministrator.updatePaidOrder(orcaEnvInfo.getHospCode(), currentDate, refIdListUpd);
			}
		} catch (Exception e) {
			LOGGER.error("Sync paid order fail, hosp_code = " + orcaEnvInfo.getHospCode(), e);
			return false;
		}
		
		return true;
	}
	
	// sync reservation to KCCK
	private boolean syncReservation(OrcaEnvInfo orcaEnvInfo, String currentDate){
		try {
			List<SyncReservation> reserList = new ArrayList<>();
			
			List<AppointlstInformationChild> appList = getAppointListToday(orcaEnvInfo, currentDate);
			if(!CollectionUtils.isEmpty(appList)){
				for (AppointlstInformationChild info : appList) {
					SyncReservation reser = new SyncReservationImpl().copyFromAppointment(info, currentDate);
					reserList.add(reser);
				}
				
				patientAdministrator.reservationListSynchronization(reserList, orcaEnvInfo.getHospCode());
			}
			
		} catch (Exception e) {
			LOGGER.error("Sync reservation fail, hosp_code = " + orcaEnvInfo.getHospCode(), e);
			return false;
		}
		
		return true;
	}
	
	// get patient list from ORCA by hospital
	private List<PatientInformation> getPatientListToday(OrcaEnvInfo orcaEnvInfo, String currentDate) throws Exception{
		List<PatientInformation> patients = new ArrayList<PatientInformation>();
		PatientListRequest request = new PatientListRequest();
		
		request.setBaseStartDate(currentDate);
		request.setBaseEndDate(currentDate);
		request.setContainTestPatientFlag("");
		request.setOrcaEnvInfo(orcaEnvInfo);
		
		PatientListResponse rp = patientListCommand.execute(request);
		if(rp != null && OrcaApiConfig.API_RESULT_SUCCESS.getValue().equals(rp.getApiResult())){
			if(!CollectionUtils.isEmpty(rp.getPatientInfoList())){
				patients = rp.getPatientInfoList();
			}
		}
		
		return patients;
	}
	
	// get patient detail list (include insurance) from ORCA
	private List<PatientInfo> getPatientDetailListToday(OrcaEnvInfo orcaEnvInfo, List<PatientInformation> patients) throws Exception{
		List<PatientInfo> patientDetailList = new ArrayList<PatientInfo>();
		for (PatientInformation pt : patients) {
			PatientInfoRequest patientInfoRequest = new PatientInfoRequest(pt.getPatientId(), orcaEnvInfo);
			PatientInfoResponse rp = patientInfoCommand.execute(patientInfoRequest);
			if(rp != null && rp.getPatientInformation() != null){
				PatientInfo p = rp.getPatientInformation();
				p.setPatientType(pt.getTestPatientFlag());
				patientDetailList.add(p);
			}
		}
		
		return patientDetailList;
	}
	
	// request to MED-APP to create/update patient
	private boolean syncPatien(String hospCode, List<PatientInfo> patientList) throws Exception{
		List<SyncPatient> totalPatientList = new ArrayList<>();
		List<PublicInsurance> totalPublicInsurance = new ArrayList<>();
		List<PrivateInsurance> totalPrivateInsurance = new ArrayList<>();
		
		for (PatientInfo patient : patientList) {
			SyncPatient syncPatient = new SyncPatientImpl().copyFromPatientInfo(patient);
			totalPatientList.add(syncPatient);
			
	        List<PublicInsurance> publicInsuranceList = new PublicInsuranceImpl().copyFromPatientInfo(patient);
	        totalPublicInsurance.addAll(publicInsuranceList);
	        
	        List<PrivateInsurance> privateInsurance = new PrivateInsuranceImpl().copyFromPatientInfo(patient);
	        totalPrivateInsurance.addAll(privateInsurance);
		}
		
		return patientAdministrator.patientListSynchronization(totalPatientList, totalPublicInsurance, totalPrivateInsurance, "", hospCode, "N", "");
	}
	
	// get reception list
	private List<AcceptlstInfo> getReceptionListToday(OrcaEnvInfo orcaEnvInfo, String currentDate, String reqClass) throws Exception{
		AcceptancelstRequest acceptancelstRequest = new AcceptancelstRequest(currentDate, orcaEnvInfo);
		acceptancelstRequest.setReqClass(reqClass);
		
		AcceptlstResponse rp = acceptancelstCommand.execute(acceptancelstRequest);
		if(rp != null && !CollectionUtils.isEmpty(rp.getAcceptlstInformation())){
			return rp.getAcceptlstInformation();
		}
		
		return new ArrayList<>();
	}
	
	// get appointment list
	private List<AppointlstInformationChild> getAppointListToday(OrcaEnvInfo orcaEnvInfo, String currentDate) throws Exception{
		AppointListRequest rq = new AppointListRequest();
		rq.setAppointmentDate(currentDate);
		rq.setOrcaEnvInfo(orcaEnvInfo);
		AppointListResponse rp = appointListCommand.execute(rq);
		
		if(rp != null && !CollectionUtils.isEmpty(rp.getAppointList())){
			return rp.getAppointList();
		}
		
		return new ArrayList<>();
	}

	private static enum Status {
		STARTED,
		STOPPED;

		private Status() {
		}
	}
}
