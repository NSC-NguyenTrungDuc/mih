package nta.med.orca.gw.model.patient.impl;

import nta.med.common.util.DateTimes;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.OrcaUtils;
import nta.med.ext.support.proto.PatientModelProto;
import nta.med.orca.gw.api.contracts.message.AcceptlstInfo;
import nta.med.orca.gw.api.contracts.message.PublicInsuranceInfo;
import nta.med.orca.gw.glossary.CommonEnum;
import nta.med.orca.gw.glossary.OrcaAcceptingRegPath;
import nta.med.orca.gw.glossary.OrcaPath;
import nta.med.orca.gw.model.patient.Reception;
import nta.med.orca.gw.model.patient.SyncExamination;
import nta.med.orca.gw.xpath.XPathAPI;
import org.apache.logging.log4j.util.Strings;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.w3c.dom.Document;
import org.w3c.dom.Node;

import java.util.HashMap;
import java.util.List;

public class SyncExaminationImpl implements SyncExamination {

	private String departmentCode ;
    private String departmentName ;
    private String doctorCode ;
    private String doctorName ;
    private String examStatus ;
    private String receptionNo ;
    private String insurCode ;
    private String insurName ;
    private String patientCode ;
    private String comingDate ;
    private String pkout1001 ;
    private String receptionTime ;
    private String comingStatus ;
    private String comingType ;
    private String sunnabStatus ;
    private String fkinp1001 ;
    private String receptionType ;
    private String inpTransStatus ;
    private String bigo ;
    private String insurCode1 ;
    private String insurCode2 ;
    private String insurCode3 ;
    private String insurCode4 ;
    private String priority1 ;
    private String priority2 ;
    private String priority3 ;
    private String priority4 ;
    private String sujinNo ;
    private String wonyoiOrderStatus ;
    private String reserStatus ;
    private String button ;
    private String checkComing ;
    private String arriveTime ;
    private String groupKey ;
    private String contKey ;
    private String dataRowState ;
    private String deletedRowTable ;
    private String sysId ;
	private String updId;
	private String orcaGigwanCode;
	private Reception reception;
	private String modifyFlg;
	private String hasAppointment;
	private String receptRefId;
	
	@Override
	public PatientModelProto.SyncExamination toProto() {
		PatientModelProto.SyncExamination.Builder builder = PatientModelProto.SyncExamination.newBuilder()
				.setDepartmentCode(departmentCode)
				.setDepartmentName(departmentName)
				.setDoctorCode(doctorCode)
				.setDoctorName(doctorName)
				.setExamStatus(examStatus)
				.setReceptionNo(receptionNo)
				.setInsurCode(insurCode)
				.setInsurName(insurName)
				.setPatientCode(org.apache.commons.lang3.StringUtils.leftPad(patientCode, 9, "0"))
				.setComingDate(comingDate)
				.setPkout1001(pkout1001)
				.setReceptionTime(receptionTime)
				.setComingStatus(comingStatus)
				.setComingType(comingType)
				.setSunnabStatus(sunnabStatus)
				.setFkinp1001(fkinp1001)
				.setReceptionType(receptionType)
				.setInpTransStatus(inpTransStatus)
				.setBigo(bigo)
				.setInsurCode1(insurCode1)
				.setInsurCode2(insurCode2)
				.setInsurCode3(insurCode3)
				.setInsurCode4(insurCode4)
				.setPriority1(priority1)
				.setPriority2(priority2)
				.setPriority3(priority3)
				.setPriority4(priority4)
				.setSujinNo(sujinNo)
				.setWonyoiOrderStatus(wonyoiOrderStatus)
				.setReserStatus(reserStatus)
				.setButton(button)
				.setCheckComing(checkComing)
				.setArriveTime(arriveTime)
				.setGroupKey(groupKey)
				.setContKey(contKey)
				.setDataRowState(dataRowState)
				.setDeletedRowTable(deletedRowTable)
				.setSysId(sysId)
				.setUpdId(updId);
		
		if(!Strings.isEmpty(modifyFlg)) builder.setModifyFlg(modifyFlg);
		if(!Strings.isEmpty(hasAppointment)) builder.setHasAppointment(hasAppointment);
		if(!Strings.isEmpty(receptRefId)) builder.setReceptRefId(receptRefId);
		
        return builder.build();
	}
	
	@Override
	public SyncExamination copyFromAcceptlstInfo(AcceptlstInfo info, String acceptanceDate){
		
		String tmpReceptionTime = info.getAcceptanceTime() == null ? "" : info.getAcceptanceTime().replace(":", "").substring(0, 4);
		String tmpInsurCode = "";
		
		String tmpGongbiName1 = "";
		String tmpGongbiName2 = "";
		String tmpGongbiName3 = "";
		String tmpGongbiName4 = "";
		
		String tmpPriority1 = "1";
		String tmpPriority2 = "2";
		String tmpPriority3 = "3";
		String tmpPriority4 = "4";
		
		if(info.getHealthInsuranceInformation() != null){
			tmpInsurCode = OrcaUtils.getInsurCodeByClassCode(info.getHealthInsuranceInformation().getInsuranceProviderClass());
			List<PublicInsuranceInfo> publicInsList = info.getHealthInsuranceInformation().getPublicInsuranceInformation();
			if(!CollectionUtils.isEmpty(publicInsList)){
				if(publicInsList.size() > 0){
					tmpGongbiName1 = publicInsList.get(0).getPublicInsuranceClass();
				}
				
				if(publicInsList.size() > 1){
					tmpGongbiName2 = publicInsList.get(1).getPublicInsuranceClass();
				}
				
				if(publicInsList.size() > 2){
					tmpGongbiName3 = publicInsList.get(2).getPublicInsuranceClass();
				}
				
				if(publicInsList.size() > 3){
					tmpGongbiName4 = publicInsList.get(3).getPublicInsuranceClass();
				}
			}
		}
		
		this.setDepartmentCode(info.getDepartmentCode() == null ? "" : info.getDepartmentCode());
		this.setDepartmentName(info.getDepartmentWholeName() == null ? "" : info.getDepartmentWholeName());
		this.setDoctorCode(info.getPhysicianCode() == null ? "" : info.getPhysicianCode());
		this.setDoctorName(info.getPhysicianWholeName() == null ? "" : info.getPhysicianWholeName());
		this.setExamStatus("");			// Check on KCCK
		this.setReceptionNo("");
		this.setInsurCode(tmpInsurCode);	
		this.setInsurName("");
		this.setPatientCode(info.getPatientInformation().getPatientId());
		this.setComingDate(acceptanceDate);
		this.setPkout1001("");
		
		if(info.getAppointmentYn() != null && "Y".equals(info.getAppointmentYn())){
			this.setReceptionTime(info.getAppointTime().replace(":", "").substring(0, 4));
		}else {
			this.setReceptionTime(tmpReceptionTime);
		}
		
		this.setComingStatus("Y");
		this.setComingType("0");
		this.setSunnabStatus("N");
		this.setFkinp1001("");
		this.setReceptionType(info.getMedicalInformation() == null ? "" : info.getMedicalInformation());
		this.setInpTransStatus("N");
		this.setBigo("");
		this.setInsurCode1(tmpGongbiName1);
		this.setInsurCode2(tmpGongbiName2);
		this.setInsurCode3(tmpGongbiName3);
		this.setInsurCode4(tmpGongbiName4);
		this.setPriority1(tmpPriority1);
		this.setPriority2(tmpPriority2);
		this.setPriority3(tmpPriority3);
		this.setPriority4(tmpPriority4);
		this.setSujinNo("");
		this.setWonyoiOrderStatus("");
		this.setReserStatus("");
		this.setButton("");
		this.setCheckComing("Y");
		this.setArriveTime(tmpReceptionTime);
		this.setGroupKey("");
		this.setContKey("");
		this.setDataRowState("");
		this.setDeletedRowTable("");
		this.setSysId("ORCA");
		this.setUpdId("ORCA"); 
		this.setOrcaGigwanCode("");
		this.setModifyFlg("");
		this.setReceptRefId(info.getAcceptanceId());
		this.setHasAppointment(info.getAppointmentYn() == null ? "" : info.getAppointmentYn());
		
		return this;
	}
	
	@Override
	public SyncExamination toModel(Document doc, int decisionThreshold) throws Exception {
		String modifyFlg = "I";
		String createDate = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.CREATE_DATE_PATH.getPath());
		String registTime = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.REGIST_TIME_PATH.getPath());
		if(!StringUtils.isEmpty(createDate) && !StringUtils.isEmpty(registTime) && createDate.length() > 0 && registTime.length() > 0){
			long diff = Math.abs(DateTimes.parse("yyyy-MM-dd HH:mm:ss", createDate.replace("T", " ")) - DateTimes.parse("yyyy-MM-dd HH:mm:ss", registTime.replace("T", " ")));
			if(diff > decisionThreshold) modifyFlg = "U";
		}
		
		// [START] Get private insurance info
		String departmentCode = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.DEPARTMENT_CODE.getPath());
		if(!StringUtils.isEmpty(departmentCode)){
			departmentCode = departmentCode.trim();
		}
		
		String doctorCode = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.DOCTOR_CODE.getPath());
		if(!StringUtils.isEmpty(doctorCode)){
			doctorCode = doctorCode.trim();
		}
		
		String insurCode = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.INSUR_CODE.getPath());
		if(insurCode != null && OrcaPath.GUBUN_DEFAULT.getPath().equals(insurCode.trim())){
			insurCode = "";
		}
		insurCode = insurCode == null ? "" : insurCode;
		
		String patientCode = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.PATIENT_CODE.getPath());
		String commingDate = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.COMING_DATE.getPath());
		String splitValue = CommonEnum.T.getValue();
		if(!StringUtils.isEmpty(commingDate) && commingDate.contains(splitValue)){
			commingDate = commingDate.split(splitValue)[0];
			commingDate = commingDate.replace("-", "/");
		}
		String receptionTime = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.RECEPTION_TIME.getPath());
		if(!StringUtils.isEmpty(receptionTime) && receptionTime.contains(splitValue)){
			receptionTime = receptionTime.split(splitValue)[1];
			receptionTime = receptionTime.replace(":", "");
			if(receptionTime.length() >= 4 ){
				receptionTime = receptionTime.substring(0, 4);
			}
		}
		String sysId = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.SYS_ID.getPath());
		String updId = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.UPD_ID.getPath());
		String orcaGigwanCode = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.ORCA_GIGWAN_CODE.getPath());
		String codeName = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.CODE_NAME.getPath());
		String examStatus = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.EXAM_STATUS.getPath());
		
		// [END] Get private insurance info
		
		// [START] Get list public insurance info
		
		// get the first HealthInsuranceModule
		List<Node> listHealthInsuranceModule = XPathAPI.selectListOfNodes(doc, OrcaPath.HEALTH_INSURANCE_MODULE_PATH.getPath());
		
		String gongbiName1 = "";
		String gongbiName2 = "";
		String gongbiName3 = "";
		String gongbiName4 = ""; 
		
		String priority1 = "";
		String priority2 = "";
		String priority3 = "";
		String priority4 = "";
		
		if(!CollectionUtils.isEmpty(listHealthInsuranceModule)){
			Node firstHealthInsuranceModule = listHealthInsuranceModule.get(0);
			HashMap<String, String> nsp = new HashMap<String, String>();
			nsp.put("mmlHi", "http://www.medxml.net/MML/ContentModule/HealthInsurance/1.1");
			Document firstHealthInsuranceDoc = XPathAPI.node2Document(firstHealthInsuranceModule);
			
			gongbiName1 = XPathAPI.selectSingleNodeAsString(firstHealthInsuranceDoc, OrcaAcceptingRegPath.GONGBI_NAME1_SUB_PATH.getPath(), nsp);
			gongbiName2 = XPathAPI.selectSingleNodeAsString(firstHealthInsuranceDoc, OrcaAcceptingRegPath.GONGBI_NAME2_SUB_PATH.getPath(), nsp);
			gongbiName3 = XPathAPI.selectSingleNodeAsString(firstHealthInsuranceDoc, OrcaAcceptingRegPath.GONGBI_NAME3_SUB_PATH.getPath(), nsp);
			gongbiName4 = XPathAPI.selectSingleNodeAsString(firstHealthInsuranceDoc, OrcaAcceptingRegPath.GONGBI_NAME4_SUB_PATH.getPath(), nsp);
			
			gongbiName1 = gongbiName1 == null ? "" : CommonUtils.formatMmlString(gongbiName1);
			gongbiName2 = gongbiName2 == null ? "" : CommonUtils.formatMmlString(gongbiName2);
			gongbiName3 = gongbiName3 == null ? "" : CommonUtils.formatMmlString(gongbiName3);
			gongbiName4 = gongbiName4 == null ? "" : CommonUtils.formatMmlString(gongbiName4);
			
			priority1 = gongbiName1.equals("") ? "" : "1";
			priority2 = gongbiName2.equals("") ? "" : "2";
			priority3 = gongbiName3.equals("") ? "" : "3";
			priority4 = gongbiName4.equals("") ? "" : "4";
		}
		
		// [END] Get list public insurance info
		
		this.setDepartmentCode(departmentCode);
		this.setDepartmentName("");
		this.setDoctorCode(doctorCode);
		this.setDoctorName("");
		this.setExamStatus(examStatus == null ? "" : examStatus.trim());
		this.setReceptionNo("");
		this.setInsurCode(insurCode);
		this.setInsurName("");
		this.setPatientCode(patientCode == null ? "" : patientCode.trim());
		this.setComingDate(commingDate == null ? "" : commingDate.trim());
		this.setPkout1001("");
		this.setReceptionTime(receptionTime == null ? "" : receptionTime.trim());
		this.setComingStatus("Y");
		this.setComingType("0");
		this.setSunnabStatus("N");
		this.setFkinp1001("");
		this.setReceptionType(CommonUtils.formatMmlString(codeName));
		this.setInpTransStatus("N");
		this.setBigo("");
		this.setInsurCode1(gongbiName1);
		this.setInsurCode2(gongbiName2);
		this.setInsurCode3(gongbiName3);
		this.setInsurCode4(gongbiName4);
		this.setPriority1(priority1);
		this.setPriority2(priority2);
		this.setPriority3(priority3);
		this.setPriority4(priority4);
		this.setSujinNo("");
		this.setWonyoiOrderStatus("");
		this.setReserStatus("");
		this.setButton("");
		this.setCheckComing("Y");
		this.setArriveTime("");
		this.setGroupKey("");
		this.setContKey("");
		this.setDataRowState("");
		this.setDeletedRowTable("");
		this.setSysId(sysId == null ? "" : sysId.trim());
		this.setUpdId(updId == null ? "" : updId.trim()); 
		this.setOrcaGigwanCode(orcaGigwanCode == null ? "" : orcaGigwanCode.trim());
		
		Reception reception = new ReceptionImpl().toModel(doc);
		this.setReception(reception);
		this.setModifyFlg(modifyFlg);
		
		return this;
	}
	
	@Override
	public SyncExamination toModel(AcceptlstInfo info, String acceptanceDate, String gigwanCode) {
        Reception reception = new ReceptionImpl();

        String insCode1 = "";
        String insCode2 = "";
        String insCode3 = "";
        String insCode4 = "";
        String priority1 = "";
        String priority2 = "";
        String priority3 = "";
        String priority4 = "";

        String insurCode = "";
        String insurName = "";

        if(info.getHealthInsuranceInformation() != null){

            if(info.getHealthInsuranceInformation().getInsuranceProviderClass() != null){
                insurCode = OrcaUtils.getInsurCodeByClassCode(info.getHealthInsuranceInformation().getInsuranceProviderClass());
                insurName = info.getHealthInsuranceInformation().getInsuranceProviderWholeName();
                insurName = insurName == null ? "" : insurName;
            }

            if(info.getHealthInsuranceInformation().getPublicInsuranceInformation() != null){
                List<PublicInsuranceInfo> listPublicInsInfo = info.getHealthInsuranceInformation().getPublicInsuranceInformation();
                if(!CollectionUtils.isEmpty(listPublicInsInfo)){
                    if(listPublicInsInfo.size() >0){
                        insCode1 = listPublicInsInfo.get(0).getPublicInsuranceClass();
                        priority1 = "1";
                    }

                    if(listPublicInsInfo.size() >1){
                        insCode2 = listPublicInsInfo.get(1).getPublicInsuranceClass();
                        priority2 = "2";
                    }

                    if(listPublicInsInfo.size() >2){
                        insCode3 = listPublicInsInfo.get(2).getPublicInsuranceClass();
                        priority3 = "3";
                    }

                    if(listPublicInsInfo.size() >3){
                        insCode4 = listPublicInsInfo.get(3).getPublicInsuranceClass();
                        priority4 = "4";
                    }
                }
            }
        }

        this.setOrcaGigwanCode(gigwanCode);
        this.setDepartmentCode(info.getDepartmentCode());
        this.setDepartmentName(info.getDepartmentWholeName());
        this.setDoctorCode(info.getPhysicianCode());
        this.setDoctorName(info.getPhysicianWholeName());
        this.setExamStatus("");								// get from UpdateJubsuDataHandler
        this.setReceptionNo("");
        this.setInsurCode(insurCode);
        this.setInsurName(insurName);
        this.setPatientCode(info.getPatientInformation().getPatientId());
        this.setComingDate(acceptanceDate.replace("-", "/"));
        this.setPkout1001("");
        this.setReceptionTime(info.getAcceptanceTime().replace(":", "").substring(0, 4));
        this.setComingStatus("Y");
        this.setComingType("0");
        this.setSunnabStatus("N");
        this.setFkinp1001("");
        this.setReceptionType(info.getMedicalInformation());	// get from UpdateJubsuDataHandler
        this.setInpTransStatus("N");
        this.setBigo("");
        this.setInsurCode1(insCode1);
        this.setInsurCode2(insCode2);
        this.setInsurCode3(insCode3);
        this.setInsurCode4(insCode4);
        this.setPriority1(priority1);
        this.setPriority2(priority2);
        this.setPriority3(priority3);
        this.setPriority4(priority4);
        this.setSujinNo("");
        this.setWonyoiOrderStatus("");
        this.setReserStatus("");
        this.setButton("");
        this.setCheckComing("Y");
        this.setArriveTime(info.getAcceptanceTime().replace(":", ""));
        this.setGroupKey("");
        this.setContKey("");
        this.setDataRowState("");
        this.setDeletedRowTable("");
        this.setSysId("");
        this.setUpdId("");

        reception.setHospCode("");
        reception.setFkout1001("");
        reception.setOrcaReceptionId("");
        reception.setGwa(info.getDepartmentCode());
        reception.setDoctor(info.getPhysicianCode());
        reception.setOrderTime("");
        reception.setAppTime("");
        reception.setRegistTime(acceptanceDate + "T" + info.getAcceptanceTime());
        reception.setPerformTime("");
        reception.setIoFlag("false");
        reception.setTimeClass("");
        reception.setBundNum("");					// get from UpdateJubsuDataHandler
        reception.setClassCode("");					// get from UpdateJubsuDataHandler
        reception.setSubCode("");					// get from UpdateJubsuDataHandler
        reception.setActCode("");					// get from UpdateJubsuDataHandler
        reception.setActiveFlg("1");
        reception.setSysId("");
        reception.setUpdId("");
        reception.setCreated("");
        reception.setUpdated("");

        this.setReception(reception);
        return this;
	}
	
	@Override
	public String getDepartmentCode() {
		return this.departmentCode;
	}
	
	@Override
	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}
	
	@Override
	public String getDepartmentName() {
		return this.departmentName;
	}
	
	@Override
	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}
	
	@Override
	public String getDoctorCode() {
		return this.doctorCode;
	}
	
	@Override
	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}
	
	@Override
	public String getDoctorName() {
		return this.doctorName;
	}
	
	@Override
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	
	@Override
	public String getExamStatus() {
		return this.examStatus;
	}
	
	@Override
	public void setExamStatus(String examStatus) {
		this.examStatus = examStatus;
	}
	
	@Override
	public String getReceptionNo() {
		return this.receptionNo;
	}
	
	@Override
	public void setReceptionNo(String receptionNo) {
		this.receptionNo = receptionNo;
	}
	
	@Override
	public String getInsurCode() {
		return this.insurCode;
	}
	
	@Override
	public void setInsurCode(String insurCode) {
		this.insurCode = insurCode;
	}
	
	@Override
	public String getInsurName() {
		return this.insurName;
	}
	
	@Override
	public void setInsurName(String insurName) {
		this.insurName = insurName;
	}
	
	@Override
	public String getPatientCode() {
		return this.patientCode;
	}
	
	@Override
	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
	
	@Override
	public String getComingDate() {
		return this.comingDate;
	}
	
	@Override
	public void setComingDate(String comingDate) {
		this.comingDate = comingDate;
	}
	
	@Override
	public String getPkout1001() {
		return this.pkout1001;
	}
	
	@Override
	public void setPkout1001(String pkout1001) {
		this.pkout1001 = pkout1001;
	}
	
	@Override
	public String getReceptionTime() {
		return this.receptionTime;
	}
	
	@Override
	public void setReceptionTime(String receptionTime) {
		this.receptionTime = receptionTime;
	}
	
	@Override
	public String getComingStatus() {
		return this.comingStatus;
	}
	
	@Override
	public void setComingStatus(String comingStatus) {
		this.comingStatus = comingStatus;
	}
	
	@Override
	public String getComingType() {
		return this.comingType;
	}
	
	@Override
	public void setComingType(String comingType) {
		this.comingType = comingType;
	}
	
	@Override
	public String getSunnabStatus() {
		return this.sunnabStatus;
	}
	
	@Override
	public void setSunnabStatus(String sunnabStatus) {
		this.sunnabStatus = sunnabStatus;
	}
	
	@Override
	public String getFkinp1001() {
		return this.fkinp1001;
	}
	
	@Override
	public void setFkinp1001(String fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}
	
	@Override
	public String getReceptionType() {
		return this.receptionType;
	}
	
	@Override
	public void setReceptionType(String receptionType) {
		this.receptionType = receptionType;
	}
	
	@Override
	public String getInpTransStatus() {
		return this.inpTransStatus;
	}
	
	@Override
	public void setInpTransStatus(String inpTransStatus) {
		this.inpTransStatus = inpTransStatus;
	}
	
	@Override
	public String getBigo() {
		return this.bigo;
	}
	
	@Override
	public void setBigo(String bigo) {
		this.bigo = bigo;
	}
	
	@Override
	public String getInsurCode1() {
		return this.insurCode1;
	}
	
	@Override
	public void setInsurCode1(String insurCode1) {
		this.insurCode1 = insurCode1;
	}
	
	@Override
	public String getInsurCode2() {
		return this.insurCode2;
	}
	
	@Override
	public void setInsurCode2(String insurCode2) {
		this.insurCode2 = insurCode2;
	}
	
	@Override
	public String getInsurCode3() {
		return this.insurCode3;
	}
	
	@Override
	public void setInsurCode3(String insurCode3) {
		this.insurCode3 = insurCode3;
	}
	
	@Override
	public String getInsurCode4() {
		return this.insurCode4;
	}
	
	@Override
	public void setInsurCode4(String insurCode4) {
		this.insurCode4 = insurCode4;
	}
	
	@Override
	public String getPriority1() {
		return this.priority1;
	}
	
	@Override
	public void setPriority1(String priority1) {
		this.priority1 = priority1;
	}
	
	@Override
	public String getPriority2() {
		return this.priority2;
	}
	
	@Override
	public void setPriority2(String priority2) {
		this.priority2 = priority2;
	}
	
	@Override
	public String getPriority3() {
		return this.priority3;
	}
	
	@Override
	public void setPriority3(String priority3) {
		this.priority3 = priority3;
	}
	
	@Override
	public String getPriority4() {
		return this.priority4;
	}
	
	@Override
	public void setPriority4(String priority4) {
		this.priority4 = priority4;
	}
	
	@Override
	public String getSujinNo() {
		return this.sujinNo;
	}
	
	@Override
	public void setSujinNo(String sujinNo) {
		this.sujinNo = sujinNo;
	}
	
	@Override
	public String getWonyoiOrderStatus() {
		return this.wonyoiOrderStatus;
	}
	
	@Override
	public void setWonyoiOrderStatus(String wonyoiOrderStatus) {
		this.wonyoiOrderStatus = wonyoiOrderStatus;
	}
	
	@Override
	public String getReserStatus() {
		return this.reserStatus;
	}
	
	@Override
	public void setReserStatus(String reserStatus) {
		this.reserStatus = reserStatus;
	}
	
	
	@Override
	public String getButton() {
		return this.button;
	}
	
	@Override
	public void setButton(String button) {
		this.button = button;
	}
	
	@Override
	public String getCheckComing() {
		return this.checkComing;
	}
	
	@Override
	public void setCheckComing(String checkComing) {
		this.checkComing = checkComing;
	}
	
	@Override
	public String getArriveTime() {
		return this.arriveTime;
	}
	
	@Override
	public void setArriveTime(String arriveTime) {
		this.arriveTime = arriveTime;
	}
	
	@Override
	public String getGroupKey() {
		return this.groupKey;
	}
	
	@Override
	public void setGroupKey(String groupKey) {
		this.groupKey = groupKey;
	}
	
	@Override
	public String getContKey() {
		return this.contKey;
	}
	
	@Override
	public void setContKey(String contKey) {
		this.contKey = contKey;
	}
	
	@Override
	public String getDataRowState() {
		return this.dataRowState;
	}
	
	@Override
	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
	@Override
	public String getDeletedRowTable() {
		return this.deletedRowTable;
	}
	
	@Override
	public void setDeletedRowTable(String deletedRowTable) {
		this.deletedRowTable = deletedRowTable;
	}
	
	@Override
	public String getSysId() {
		return this.sysId;
	}
	
	@Override
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	
	@Override
	public String getUpdId() {
		return this.updId;
	}
	
	@Override
	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Override
	public String getOrcaGigwanCode() {
		return this.orcaGigwanCode;
	}

	@Override
	public void setOrcaGigwanCode(String orcaGigwanCode) {
		this.orcaGigwanCode = orcaGigwanCode;
	}

	public Reception getReception() {
		return reception;
	}

	public void setReception(Reception reception) {
		this.reception = reception;
	}

	@Override
	public String getModifyFlg() {
		return modifyFlg;
	}

	@Override
	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}

	@Override
	public String getHasAppointment() {
		return hasAppointment;
	}

	@Override
	public void setHasAppointment(String hasAppointment) {
		this.hasAppointment = hasAppointment;
	}

	@Override
	public String getReceptRefId() {
		return receptRefId;
	}

	@Override
	public void setReceptRefId(String receptRefId) {
		this.receptRefId = receptRefId;
	}
	
}