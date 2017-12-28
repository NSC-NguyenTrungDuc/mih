package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the BAS0260 database table.
 * 
 */
@Entity
@Table(name="BAS0260")
public class Bas0260 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String addDoctor;
	private String buseoCode;
	private String buseoGubun;
	private String buseoName;
	private String buseoName2;
	private Date endDate;
	private String euryoseoYn;
	private String gwa;
	private String gwaColor;
	private String gwaEname;
	private String gwaGubun;
	private String gwaName;
	private String gwaNameKana;
	private String gwaSname;
	private Double gwaSort1;
	private Double gwaSort2;
	private String hospCode;
	private String hpcHoDongYn;
	private String icuYn;
	private String inpJundalPartYn;
	private String inpSlipYn;
	private String inputGubun;
	private String ipwonYn;
	private String moveComment;
	private String nrsParentBuseo;
	private String outJubsuYn;
	private String outJundalPartYn;
	private String outMoveYn;
	private String outSlipYn;
	private String parentBuseo;
	private String parentGwa;
	private String rmk;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private String tel;
	private Date updDate;
	private String updId;
	private String language;
	private String useYn;
	private Double avgTime;

	public Bas0260() {
	}


	@Column(name="ADD_DOCTOR")
	public String getAddDoctor() {
		return this.addDoctor;
	}

	public void setAddDoctor(String addDoctor) {
		this.addDoctor = addDoctor;
	}


	@Column(name="BUSEO_CODE")
	public String getBuseoCode() {
		return this.buseoCode;
	}

	public void setBuseoCode(String buseoCode) {
		this.buseoCode = buseoCode;
	}


	@Column(name="BUSEO_GUBUN")
	public String getBuseoGubun() {
		return this.buseoGubun;
	}

	public void setBuseoGubun(String buseoGubun) {
		this.buseoGubun = buseoGubun;
	}


	@Column(name="BUSEO_NAME")
	public String getBuseoName() {
		return this.buseoName;
	}

	public void setBuseoName(String buseoName) {
		this.buseoName = buseoName;
	}


	@Column(name="BUSEO_NAME2")
	public String getBuseoName2() {
		return this.buseoName2;
	}

	public void setBuseoName2(String buseoName2) {
		this.buseoName2 = buseoName2;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="EURYOSEO_YN")
	public String getEuryoseoYn() {
		return this.euryoseoYn;
	}

	public void setEuryoseoYn(String euryoseoYn) {
		this.euryoseoYn = euryoseoYn;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="GWA_COLOR")
	public String getGwaColor() {
		return this.gwaColor;
	}

	public void setGwaColor(String gwaColor) {
		this.gwaColor = gwaColor;
	}


	@Column(name="GWA_ENAME")
	public String getGwaEname() {
		return this.gwaEname;
	}

	public void setGwaEname(String gwaEname) {
		this.gwaEname = gwaEname;
	}


	@Column(name="GWA_GUBUN")
	public String getGwaGubun() {
		return this.gwaGubun;
	}

	public void setGwaGubun(String gwaGubun) {
		this.gwaGubun = gwaGubun;
	}


	@Column(name="GWA_NAME")
	public String getGwaName() {
		return this.gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}


	@Column(name="GWA_NAME_KANA")
	public String getGwaNameKana() {
		return this.gwaNameKana;
	}

	public void setGwaNameKana(String gwaNameKana) {
		this.gwaNameKana = gwaNameKana;
	}


	@Column(name="GWA_SNAME")
	public String getGwaSname() {
		return this.gwaSname;
	}

	public void setGwaSname(String gwaSname) {
		this.gwaSname = gwaSname;
	}


	@Column(name="GWA_SORT1")
	public Double getGwaSort1() {
		return this.gwaSort1;
	}

	public void setGwaSort1(Double gwaSort1) {
		this.gwaSort1 = gwaSort1;
	}


	@Column(name="GWA_SORT2")
	public Double getGwaSort2() {
		return this.gwaSort2;
	}

	public void setGwaSort2(Double gwaSort2) {
		this.gwaSort2 = gwaSort2;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="HPC_HO_DONG_YN")
	public String getHpcHoDongYn() {
		return this.hpcHoDongYn;
	}

	public void setHpcHoDongYn(String hpcHoDongYn) {
		this.hpcHoDongYn = hpcHoDongYn;
	}


	@Column(name="ICU_YN")
	public String getIcuYn() {
		return this.icuYn;
	}

	public void setIcuYn(String icuYn) {
		this.icuYn = icuYn;
	}


	@Column(name="INP_JUNDAL_PART_YN")
	public String getInpJundalPartYn() {
		return this.inpJundalPartYn;
	}

	public void setInpJundalPartYn(String inpJundalPartYn) {
		this.inpJundalPartYn = inpJundalPartYn;
	}


	@Column(name="INP_SLIP_YN")
	public String getInpSlipYn() {
		return this.inpSlipYn;
	}

	public void setInpSlipYn(String inpSlipYn) {
		this.inpSlipYn = inpSlipYn;
	}


	@Column(name="INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}


	@Column(name="IPWON_YN")
	public String getIpwonYn() {
		return this.ipwonYn;
	}

	public void setIpwonYn(String ipwonYn) {
		this.ipwonYn = ipwonYn;
	}


	@Column(name="MOVE_COMMENT")
	public String getMoveComment() {
		return this.moveComment;
	}

	public void setMoveComment(String moveComment) {
		this.moveComment = moveComment;
	}


	@Column(name="NRS_PARENT_BUSEO")
	public String getNrsParentBuseo() {
		return this.nrsParentBuseo;
	}

	public void setNrsParentBuseo(String nrsParentBuseo) {
		this.nrsParentBuseo = nrsParentBuseo;
	}


	@Column(name="OUT_JUBSU_YN")
	public String getOutJubsuYn() {
		return this.outJubsuYn;
	}

	public void setOutJubsuYn(String outJubsuYn) {
		this.outJubsuYn = outJubsuYn;
	}


	@Column(name="OUT_JUNDAL_PART_YN")
	public String getOutJundalPartYn() {
		return this.outJundalPartYn;
	}

	public void setOutJundalPartYn(String outJundalPartYn) {
		this.outJundalPartYn = outJundalPartYn;
	}


	@Column(name="OUT_MOVE_YN")
	public String getOutMoveYn() {
		return this.outMoveYn;
	}

	public void setOutMoveYn(String outMoveYn) {
		this.outMoveYn = outMoveYn;
	}


	@Column(name="OUT_SLIP_YN")
	public String getOutSlipYn() {
		return this.outSlipYn;
	}

	public void setOutSlipYn(String outSlipYn) {
		this.outSlipYn = outSlipYn;
	}


	@Column(name="PARENT_BUSEO")
	public String getParentBuseo() {
		return this.parentBuseo;
	}

	public void setParentBuseo(String parentBuseo) {
		this.parentBuseo = parentBuseo;
	}


	@Column(name="PARENT_GWA")
	public String getParentGwa() {
		return this.parentGwa;
	}

	public void setParentGwa(String parentGwa) {
		this.parentGwa = parentGwa;
	}


	public String getRmk() {
		return this.rmk;
	}

	public void setRmk(String rmk) {
		this.rmk = rmk;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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


	public String getTel() {
		return this.tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
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
	
	@Column(name="LANGUAGE")
	public String getLanguage() {
		return this.language;
	}
	
	public void setLanguage(String language) {
		this.language = language;
	}

	@Column(name="USE_YN")
	public String getUseYn() {
		return useYn;
	}


	public void setUseYn(String useYn) {
		this.useYn = useYn;
	}

	@Column(name="AVG_TIME")
	public Double getAvgTime() {
		return avgTime;
	}


	public void setAvgTime(Double avgTime) {
		this.avgTime = avgTime;
	}

}