package nta.med.core.domain.pacs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the PACS_OP database table.
 * 
 */
@Entity
@Table(name="PACS_OP")
@NamedQuery(name="PacsOp.findAll", query="SELECT p FROM PacsOp p")
public class PacsOp extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String accesstime;
	private String backupyn;
	private String checkflag;
	private String class_;
	private String fkocs;
	private String hospCode;
	private double imagecnt;
	private String imagegubun;
	private String imageslip;
	private String inout;
	private String keyimage;
	private String modality;
	private String modelname;
	private String ocskeyuid;
	private String orderdate;
	private String patientid;
	private String puship;
	private String reserdate;
	private String reserflag;
	private String studydate;
	private String studydescription;
	private String studyinstanceuid;
	private String studytime;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public PacsOp() {
	}


	public String getAccesstime() {
		return this.accesstime;
	}

	public void setAccesstime(String accesstime) {
		this.accesstime = accesstime;
	}


	public String getBackupyn() {
		return this.backupyn;
	}

	public void setBackupyn(String backupyn) {
		this.backupyn = backupyn;
	}


	public String getCheckflag() {
		return this.checkflag;
	}

	public void setCheckflag(String checkflag) {
		this.checkflag = checkflag;
	}


	@Column(name="CLASS")
	public String getClass_() {
		return this.class_;
	}

	public void setClass_(String class_) {
		this.class_ = class_;
	}


	public String getFkocs() {
		return this.fkocs;
	}

	public void setFkocs(String fkocs) {
		this.fkocs = fkocs;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getImagecnt() {
		return this.imagecnt;
	}

	public void setImagecnt(double imagecnt) {
		this.imagecnt = imagecnt;
	}


	public String getImagegubun() {
		return this.imagegubun;
	}

	public void setImagegubun(String imagegubun) {
		this.imagegubun = imagegubun;
	}


	public String getImageslip() {
		return this.imageslip;
	}

	public void setImageslip(String imageslip) {
		this.imageslip = imageslip;
	}


	@Column(name="`INOUT`")
	public String getInout() {
		return this.inout;
	}

	public void setInout(String inout) {
		this.inout = inout;
	}


	public String getKeyimage() {
		return this.keyimage;
	}

	public void setKeyimage(String keyimage) {
		this.keyimage = keyimage;
	}


	public String getModality() {
		return this.modality;
	}

	public void setModality(String modality) {
		this.modality = modality;
	}


	public String getModelname() {
		return this.modelname;
	}

	public void setModelname(String modelname) {
		this.modelname = modelname;
	}


	public String getOcskeyuid() {
		return this.ocskeyuid;
	}

	public void setOcskeyuid(String ocskeyuid) {
		this.ocskeyuid = ocskeyuid;
	}


	public String getOrderdate() {
		return this.orderdate;
	}

	public void setOrderdate(String orderdate) {
		this.orderdate = orderdate;
	}


	public String getPatientid() {
		return this.patientid;
	}

	public void setPatientid(String patientid) {
		this.patientid = patientid;
	}


	public String getPuship() {
		return this.puship;
	}

	public void setPuship(String puship) {
		this.puship = puship;
	}


	public String getReserdate() {
		return this.reserdate;
	}

	public void setReserdate(String reserdate) {
		this.reserdate = reserdate;
	}


	public String getReserflag() {
		return this.reserflag;
	}

	public void setReserflag(String reserflag) {
		this.reserflag = reserflag;
	}


	public String getStudydate() {
		return this.studydate;
	}

	public void setStudydate(String studydate) {
		this.studydate = studydate;
	}


	public String getStudydescription() {
		return this.studydescription;
	}

	public void setStudydescription(String studydescription) {
		this.studydescription = studydescription;
	}


	public String getStudyinstanceuid() {
		return this.studyinstanceuid;
	}

	public void setStudyinstanceuid(String studyinstanceuid) {
		this.studyinstanceuid = studyinstanceuid;
	}


	public String getStudytime() {
		return this.studytime;
	}

	public void setStudytime(String studytime) {
		this.studytime = studytime;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}