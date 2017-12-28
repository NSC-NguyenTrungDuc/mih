package nta.med.orca.gw.socket;

import java.io.File;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;
import org.w3c.dom.Document;

import nta.med.common.glossary.Lifecyclet;
import nta.med.common.remoting.ServiceTimeoutException;
import nta.med.core.utils.CommonUtils;
import nta.med.orca.gw.api.command.AcceptancelstCommand;
import nta.med.orca.gw.api.command.AppointListCommand;
import nta.med.orca.gw.api.command.PatientInfoCommand;
import nta.med.orca.gw.api.contracts.message.AcceptlstInfo;
import nta.med.orca.gw.api.contracts.message.AppointlstInformationChild;
import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;
import nta.med.orca.gw.api.contracts.service.AppointListRequest;
import nta.med.orca.gw.api.contracts.service.AppointListResponse;
import nta.med.orca.gw.api.contracts.service.PatientInfoRequest;
import nta.med.orca.gw.api.contracts.service.PatientInfoResponse;
import nta.med.orca.gw.glossary.OrcaAcceptingRegPath;
import nta.med.orca.gw.glossary.OrcaPath;
import nta.med.orca.gw.model.patient.PrivateInsurance;
import nta.med.orca.gw.model.patient.PublicInsurance;
import nta.med.orca.gw.model.patient.Reception;
import nta.med.orca.gw.model.patient.SyncExamination;
import nta.med.orca.gw.model.patient.SyncPatient;
import nta.med.orca.gw.model.patient.impl.PrivateInsuranceImpl;
import nta.med.orca.gw.model.patient.impl.PublicInsuranceImpl;
import nta.med.orca.gw.model.patient.impl.ReceptionImpl;
import nta.med.orca.gw.model.patient.impl.SyncExaminationImpl;
import nta.med.orca.gw.model.patient.impl.SyncPatientImpl;
import nta.med.orca.gw.service.patient.PatientAdministrator;
import nta.med.orca.gw.service.system.SystemAdministrator;
import nta.med.orca.gw.xpath.XPathAPI;

/**
 * @author dainguyen.
 */
public class SyncHandler extends Lifecyclet {

    private static final Log LOGGER = LogFactory.getLog(SyncHandler.class);
    private final boolean deleteClaimFile;
    private final int decisionThreshold;

    @Resource
    private PatientInfoCommand patientInfoCommand;

    @Resource
    private AcceptancelstCommand acceptancelstCommand;

    @Resource
    private SystemAdministrator systemAdministrator;

    @Resource
    private PatientAdministrator patientAdministrator;

    @Resource
    private AppointListCommand appointListCommand;
    
    public SyncHandler(boolean deleteClaimFile, int decisionThreshold) {
        this.deleteClaimFile = deleteClaimFile;
        this.decisionThreshold = decisionThreshold;
    }

    public void handle(String fileName) {
        try {
            File file = new File(fileName);
            DocumentBuilderFactory documentBuilderFactory = DocumentBuilderFactory.newInstance();
            documentBuilderFactory.setNamespaceAware(true);
            DocumentBuilder documentBuilder = documentBuilderFactory.newDocumentBuilder();

            Document doc = documentBuilder.parse(fileName);
            if (doc == null) {
                LOGGER.info("Cannot parse MML file, file name = " + fileName);
                return;
            }

            boolean updateData = false;
            String claimStatus = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.CLAIM_STATUS.getPath());
            claimStatus = claimStatus == null ? "" : claimStatus;
            
            String gigwanCode = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.ORCA_GIGWAN_CODE.getPath());
            gigwanCode = gigwanCode == null ? "" : gigwanCode.trim();
            
            if (claimStatus.equals("info")) {
                PatientInfoResponse patientInfoResponse = null;
                String bunho = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.BUNHO_PATH.getPath());
                bunho = bunho == null ? "" : bunho.trim();
                
            	OrcaEnvInfo orcaEnvInfo = getOrcaInfo(gigwanCode);
                if (orcaEnvInfo == null) {
                    LOGGER.warn("Can not get ORCA Env from KCCK, gigwanCode = " + gigwanCode);
                } else {
                	PatientInfoRequest patientInfoRequest = new PatientInfoRequest(bunho, orcaEnvInfo);
                    patientInfoResponse = patientInfoCommand.execute(patientInfoRequest);
                }

                // sync patient
                updateData = synchronizePatient(doc, patientInfoResponse);
                LOGGER.info("Synchronize Patient " + bunho + ": " + updateData);
                
            } else if (claimStatus.equals("regist")) {
            	OrcaEnvInfo orcaEnvInfo = getOrcaInfo(gigwanCode);
            	List<AppointlstInformationChild> appointListToday = new ArrayList<>();
            	
            	if (orcaEnvInfo == null) {
                    LOGGER.warn("Can not get ORCA Env from KCCK, gigwanCode = " + gigwanCode);
                } else {
                	DateFormat df = new SimpleDateFormat("yyyy-MM-dd");
                    String currentDate = df.format(new Date());
                    String doctorCode = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.DOCTOR_CODE.getPath());
            		if(!StringUtils.isEmpty(doctorCode)){
            			doctorCode = doctorCode.trim();
            		}
                    
                    AppointListRequest rq = new AppointListRequest();
            		rq.setAppointmentDate(currentDate);
            		rq.setOrcaEnvInfo(orcaEnvInfo);
            		rq.setPhysicianCode(doctorCode);
            		
            		LOGGER.info("[START] Call ORCA Api to get appoint list, date = " + currentDate);
            		AppointListResponse rp = appointListCommand.execute(rq);
            		LOGGER.info("[END] Call ORCA Api to get appoint list, " + rp == null ? "response is null" : "Api_Result = " + rp.getApiResult().getValue() + " - " + rp.getApiResultMessage().getValue());
            		
            		appointListToday = (rp != null && rp.getAppointList() != null && "00".equals(rp.getApiResult().getValue())) ? rp.getAppointList() : appointListToday;
                }
            	
                updateData = acceptRegist(doc, appointListToday);
                LOGGER.info("Accept Regist is " + updateData);
            } else {
                LOGGER.info("Claim Status is invalid");
            }

            //Success
            if (file.exists() && updateData) {
                if (deleteClaimFile) {
                    file.delete();
                }
            }
        } catch (ServiceTimeoutException e) {
            LOGGER.error("Timeout Exception when sync data from ORCA to KCCK");
        } catch (Exception e) {
            LOGGER.error("Exception when sync data from ORCA to KCCK: " + e);
            StringBuffer strLog = new StringBuffer();
            for (StackTraceElement stackTrace : e.getStackTrace()) {
                strLog.append("\n" + stackTrace.getClassName() + " " + stackTrace.getMethodName() + " line " + stackTrace.getLineNumber());
            }

            if (!StringUtils.isEmpty(strLog.toString())) LOGGER.info("Stack Trace: " + strLog.toString());
        }
    }

    private boolean acceptRegist(Document doc, List<AppointlstInformationChild> appointListToday) throws Exception {
        SyncExamination updateJubsuDataInfo = new SyncExaminationImpl().toModel(doc, decisionThreshold);
        Reception reception = new ReceptionImpl().toModel(doc);
        updateJubsuDataInfo.setReception(reception);
        
        List<SyncExamination> updateJubsuDataInfos = new ArrayList<SyncExamination>();
        updateJubsuDataInfos.add(updateJubsuDataInfo);
        String patientCode = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.PATIENT_CODE.getPath());
        
        String departmentCode = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.DEPARTMENT_CODE.getPath());
		if(!StringUtils.isEmpty(departmentCode)){
			departmentCode = departmentCode.trim();
		}
        
        patientCode = patientCode == null ? "" : CommonUtils.formatMmlString(patientCode);
        String hasAppointment = "N";
        for (AppointlstInformationChild item : appointListToday) {
        	if(patientCode.equals(item.getPatientInformation().getPatientId()) && departmentCode.equals(item.getDepartmentCode().getValue())){
        		hasAppointment = "Y";
        		//TODO
        		updateJubsuDataInfo.setReceptionTime(item.getAppointmentTime().getValue().replace(":", "").substring(0, 4));
        		break;
        	}
		}
        
        updateJubsuDataInfo.setHasAppointment(hasAppointment);
        return patientAdministrator.acceptingSynchronization(updateJubsuDataInfos, "");	//TODO
    }

    private boolean acceptRegistFromOrcaApi(List<AcceptlstInfo> acceptlstInfo, String acceptanceDate, String gigwanCode) throws Exception {
        List<SyncExamination> updateJubsuDataInfos = new ArrayList<SyncExamination>();

        for (AcceptlstInfo info : acceptlstInfo) {
            SyncExaminationImpl updateJubsuDataInfo = new SyncExaminationImpl();
            updateJubsuDataInfo.toModel(info, acceptanceDate, gigwanCode);
            updateJubsuDataInfos.add(updateJubsuDataInfo);
        }

        return patientAdministrator.acceptingSynchronization(updateJubsuDataInfos, ""); //TODO
    }

    private boolean synchronizePatient(Document doc, PatientInfoResponse patientInfoResponse) throws Exception {
        SyncPatient syncPatient = new SyncPatientImpl().toModel(doc);
        List<PublicInsurance> publicInsuranceList = new PublicInsuranceImpl().toModelList(doc, patientInfoResponse);
        List<PrivateInsurance> privateInsurance = new PrivateInsuranceImpl().toModelList(doc);

        String userId = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.USER_ID.getPath());
        String orcaGigwanCode = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.ORCA_GIGWAN_CODE.getPath());
        String hospCode = CommonUtils.formatMmlString(orcaGigwanCode);
        String autoBunhoFlg = "";

        userId = CommonUtils.formatMmlString(userId);
        orcaGigwanCode = CommonUtils.formatMmlString(orcaGigwanCode);

        return patientAdministrator.patientSynchronization(syncPatient, publicInsuranceList,
        		privateInsurance, userId, hospCode, autoBunhoFlg, orcaGigwanCode);
    }

    private OrcaEnvInfo getOrcaInfo(String gigwanCode) throws Exception {
        return systemAdministrator.findOrcaInfoByGigwanCode(gigwanCode);
    }

    @Override
    protected void doStart() throws Exception {

    }

    @Override
    protected long doStop(long timeout, TimeUnit unit) throws Exception {
        return timeout;
    }
}
