package nta.med.orca.gw.model.patient.impl;

import nta.med.core.utils.CommonUtils;
import nta.med.ext.support.proto.PatientModelProto;
import nta.med.orca.gw.glossary.OrcaAcceptingRegPath;
import nta.med.orca.gw.glossary.OrcaPath;
import nta.med.orca.gw.model.patient.Reception;
import nta.med.orca.gw.xpath.XPathAPI;
import org.w3c.dom.Document;

public class ReceptionImpl implements Reception {

	private String orcaReceptionId;
	private String actCode;
	private String activeFlg;
	private String appTime;
	private String bundNum;
	private String classCode;
	private String created;
	private String doctor;
	private String fkout1001;
	private String gwa;
	private String hospCode;
	private String ioFlag;
	private String orderTime;
	private String performTime;
	private String registTime;
	private String subCode;
	private String sysId;
	private String timeClass;
	private String updId;
	private String updated;

	@Override
	public PatientModelProto.ReceptionInfo toProto() {
		PatientModelProto.ReceptionInfo.Builder builder = PatientModelProto.ReceptionInfo.newBuilder();
		builder.setHospCode(hospCode);
		builder.setFkout1001(fkout1001);
		builder.setOrcaReceptionId(orcaReceptionId);
		builder.setGwa(gwa);
		builder.setDoctor(doctor);
		builder.setOrderTime(orderTime);
		builder.setAppTime(appTime);
		builder.setRegistTime(registTime);
		builder.setPerformTime(performTime);
		builder.setIoFlag(ioFlag);
		builder.setTimeClazz(timeClass);
		builder.setBundNum(bundNum);
		builder.setClazzCode(classCode);
		builder.setSubCode(subCode);
		builder.setActCode(actCode);
		builder.setActiveFlg(activeFlg);
		builder.setSysId(sysId);
		builder.setUdpId(updId);
		builder.setCreated(created);
		builder.setUpdated(updated);
		
		return builder.build();
	}

	@Override
	public Reception toModel(Document doc) throws Exception {
		
		String hospCode = "";
		String fkOut1001 = "";
		String orcaReceptionId = "";
		String activeFlg = "1";
		String created = "";
		String updated = "";
		
		String gwa = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.GWA_PATH.getPath());
		String doctor = XPathAPI.selectSingleNodeAsString(doc, OrcaAcceptingRegPath.DOCTOR_CODE.getPath());
		String orderTime = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.ORDER_TIME_PATH.getPath());
		String appTime = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.APP_TIME_PATH.getPath());
		String registTime = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.REGIST_TIME_PATH.getPath());
		String performTime = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.PERFORM_TIME_PATH.getPath());
		String ioFlag = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.IO_FLAG_PATH.getPath());
		String timeClass = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.TIME_CLASS_PATH.getPath());
		
		String bundNum = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.BUND_NUM_CLASS.getPath());
		String classCode = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.CLASS_CODE_PATH.getPath());
		
		String subCode = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.SUB_CODE_PATH.getPath());
		String actCode = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.ACT_CODE_PATH.getPath());
		String sysId = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.SYS_ID_PATH.getPath());
		String udpId = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.UDP_ID_PATH.getPath());
		
		gwa = gwa == null ? "" : CommonUtils.formatMmlString(gwa);
		doctor = doctor == null ? "" : CommonUtils.formatMmlString(doctor);
		orderTime = orderTime == null ? "" : CommonUtils.formatMmlString(orderTime);
		appTime = appTime == null ? "" : CommonUtils.formatMmlString(appTime);
		registTime = registTime == null ? "" : CommonUtils.formatMmlString(registTime);
		performTime = performTime == null ? "" : CommonUtils.formatMmlString(performTime);
		ioFlag = ioFlag == null ? "" : CommonUtils.formatMmlString(ioFlag);
		timeClass = timeClass == null ? "" : CommonUtils.formatMmlString(timeClass);
		bundNum = bundNum == null ? "" : CommonUtils.formatMmlString(bundNum);
		classCode = classCode == null ? "" : CommonUtils.formatMmlString(classCode);
		subCode = subCode == null ? "" : CommonUtils.formatMmlString(subCode);
		actCode = actCode == null ? "" : CommonUtils.formatMmlString(actCode);
		sysId = sysId == null ? "" : CommonUtils.formatMmlString(sysId);
		udpId = udpId == null ? "" : CommonUtils.formatMmlString(udpId);
		
		this.setOrcaReceptionId(orcaReceptionId);
		this.setActCode(actCode);
		this.setActiveFlg(activeFlg);
		this.setAppTime(appTime);
		this.setBundNum(bundNum);
		this.setClassCode(classCode);
		this.setCreated(created);
		this.setDoctor(doctor);
		this.setFkout1001(fkOut1001);
		this.setGwa(gwa);
		this.setHospCode(hospCode);
		this.setIoFlag(ioFlag);
		this.setOrderTime(orderTime);
		this.setPerformTime(performTime);
		this.setRegistTime(registTime);
		this.setSubCode(subCode);
		this.setTimeClass(timeClass);
		this.setSysId(sysId);
		this.setUpdId(udpId);
		this.setUpdated(updated);
		
		return this;
	}
	
	@Override
	public String getOrcaReceptionId() {
		return orcaReceptionId;
	}

	@Override
	public void setOrcaReceptionId(String orcaReceptionId) {
		this.orcaReceptionId = orcaReceptionId;
	}

	@Override
	public String getActCode() {
		return actCode;
	}

	@Override
	public void setActCode(String actCode) {
		this.actCode = actCode;
	}

	@Override
	public String getActiveFlg() {
		return activeFlg;
	}

	@Override
	public void setActiveFlg(String activeFlg) {
		this.activeFlg = activeFlg;
	}

	@Override
	public String getAppTime() {
		return appTime;
	}

	@Override
	public void setAppTime(String appTime) {
		this.appTime = appTime;
	}

	@Override
	public String getBundNum() {
		return bundNum;
	}

	@Override
	public void setBundNum(String bundNum) {
		this.bundNum = bundNum;
	}

	@Override
	public String getClassCode() {
		return classCode;
	}

	@Override
	public void setClassCode(String classCode) {
		this.classCode = classCode;
	}

	@Override
	public String getCreated() {
		return created;
	}

	@Override
	public void setCreated(String created) {
		this.created = created;
	}

	@Override
	public String getDoctor() {
		return doctor;
	}

	@Override
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	@Override
	public String getFkout1001() {
		return fkout1001;
	}

	@Override
	public void setFkout1001(String fkout1001) {
		this.fkout1001 = fkout1001;
	}

	@Override
	public String getGwa() {
		return gwa;
	}

	@Override
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	@Override
	public String getHospCode() {
		return hospCode;
	}

	@Override
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Override
	public String getIoFlag() {
		return ioFlag;
	}

	@Override
	public void setIoFlag(String ioFlag) {
		this.ioFlag = ioFlag;
	}

	@Override
	public String getOrderTime() {
		return orderTime;
	}

	@Override
	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
	}

	@Override
	public String getPerformTime() {
		return performTime;
	}

	@Override
	public void setPerformTime(String performTime) {
		this.performTime = performTime;
	}

	@Override
	public String getRegistTime() {
		return registTime;
	}

	@Override
	public void setRegistTime(String registTime) {
		this.registTime = registTime;
	}

	@Override
	public String getSubCode() {
		return subCode;
	}

	@Override
	public void setSubCode(String subCode) {
		this.subCode = subCode;
	}

	@Override
	public String getSysId() {
		return sysId;
	}

	@Override
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Override
	public String getTimeClass() {
		return timeClass;
	}

	@Override
	public void setTimeClass(String timeClass) {
		this.timeClass = timeClass;
	}

	@Override
	public String getUpdId() {
		return updId;
	}
	
	@Override
	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Override
	public String getUpdated() {
		return updated;
	}

	@Override
	public void setUpdated(String updated) {
		this.updated = updated;
	}

	

}
