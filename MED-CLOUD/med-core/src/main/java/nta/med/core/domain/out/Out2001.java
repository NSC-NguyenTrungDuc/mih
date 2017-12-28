package nta.med.core.domain.out;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OUT2001 database table.
 * 
 */
@Entity
@NamedQuery(name="Out2001.findAll", query="SELECT o FROM Out2001 o")
public class Out2001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actingDate;
	private String bogyongCode;
	private double bomSourceKey;
	private String bunCode;
	private String bunho;
	private String danui;
	private String doctor;
	private double dv;
	private double dv1;
	private double dv2;
	private double dv3;
	private double dv4;
	private double dv5;
	private double dv6;
	private double dv7;
	private double dv8;
	private String dvTime;
	private String emergency;
	private double fkocs1003;
	private double fkout1001;
	private double fkout1003;
	private double gasanSourceKey;
	private double groupSer;
	private String gubun;
	private String gwa;
	private String hospCode;
	private String hubalChangeYn;
	private String jaeryoYn;
	private String jusa;
	private String marumeGubun;
	private String muhyo;
	private double nalsu;
	private String nuCode;
	private Date orderDate;
	private String orderRemark;
	private double pkout2001;
	private String recordGubun;
	private double seq;
	private String sgCode;
	private double sourceFkout2001;
	private String sourceSgBun;
	private String sourceSgCode;
	private String specimenCode;
	private String sunabDanui;
	private double sunabNalsu;
	private double sunabSuryang;
	private double suryang;
	private String susuryoGubun;
	private Date sysDate;
	private String sysId;
	private String timeInputYn;
	private Date updDate;
	private String updId;
	private String validYn;
	private String wonyoiOrderYn;

	public Out2001() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}


	@Column(name="BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}


	@Column(name="BOM_SOURCE_KEY")
	public double getBomSourceKey() {
		return this.bomSourceKey;
	}

	public void setBomSourceKey(double bomSourceKey) {
		this.bomSourceKey = bomSourceKey;
	}


	@Column(name="BUN_CODE")
	public String getBunCode() {
		return this.bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getDv() {
		return this.dv;
	}

	public void setDv(double dv) {
		this.dv = dv;
	}


	@Column(name="DV_1")
	public double getDv1() {
		return this.dv1;
	}

	public void setDv1(double dv1) {
		this.dv1 = dv1;
	}


	@Column(name="DV_2")
	public double getDv2() {
		return this.dv2;
	}

	public void setDv2(double dv2) {
		this.dv2 = dv2;
	}


	@Column(name="DV_3")
	public double getDv3() {
		return this.dv3;
	}

	public void setDv3(double dv3) {
		this.dv3 = dv3;
	}


	@Column(name="DV_4")
	public double getDv4() {
		return this.dv4;
	}

	public void setDv4(double dv4) {
		this.dv4 = dv4;
	}


	@Column(name="DV_5")
	public double getDv5() {
		return this.dv5;
	}

	public void setDv5(double dv5) {
		this.dv5 = dv5;
	}


	@Column(name="DV_6")
	public double getDv6() {
		return this.dv6;
	}

	public void setDv6(double dv6) {
		this.dv6 = dv6;
	}


	@Column(name="DV_7")
	public double getDv7() {
		return this.dv7;
	}

	public void setDv7(double dv7) {
		this.dv7 = dv7;
	}


	@Column(name="DV_8")
	public double getDv8() {
		return this.dv8;
	}

	public void setDv8(double dv8) {
		this.dv8 = dv8;
	}


	@Column(name="DV_TIME")
	public String getDvTime() {
		return this.dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	public double getFkocs1003() {
		return this.fkocs1003;
	}

	public void setFkocs1003(double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}


	public double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(double fkout1001) {
		this.fkout1001 = fkout1001;
	}


	public double getFkout1003() {
		return this.fkout1003;
	}

	public void setFkout1003(double fkout1003) {
		this.fkout1003 = fkout1003;
	}


	@Column(name="GASAN_SOURCE_KEY")
	public double getGasanSourceKey() {
		return this.gasanSourceKey;
	}

	public void setGasanSourceKey(double gasanSourceKey) {
		this.gasanSourceKey = gasanSourceKey;
	}


	@Column(name="GROUP_SER")
	public double getGroupSer() {
		return this.groupSer;
	}

	public void setGroupSer(double groupSer) {
		this.groupSer = groupSer;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="HUBAL_CHANGE_YN")
	public String getHubalChangeYn() {
		return this.hubalChangeYn;
	}

	public void setHubalChangeYn(String hubalChangeYn) {
		this.hubalChangeYn = hubalChangeYn;
	}


	@Column(name="JAERYO_YN")
	public String getJaeryoYn() {
		return this.jaeryoYn;
	}

	public void setJaeryoYn(String jaeryoYn) {
		this.jaeryoYn = jaeryoYn;
	}


	public String getJusa() {
		return this.jusa;
	}

	public void setJusa(String jusa) {
		this.jusa = jusa;
	}


	@Column(name="MARUME_GUBUN")
	public String getMarumeGubun() {
		return this.marumeGubun;
	}

	public void setMarumeGubun(String marumeGubun) {
		this.marumeGubun = marumeGubun;
	}


	public String getMuhyo() {
		return this.muhyo;
	}

	public void setMuhyo(String muhyo) {
		this.muhyo = muhyo;
	}


	public double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(double nalsu) {
		this.nalsu = nalsu;
	}


	@Column(name="NU_CODE")
	public String getNuCode() {
		return this.nuCode;
	}

	public void setNuCode(String nuCode) {
		this.nuCode = nuCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="ORDER_REMARK")
	public String getOrderRemark() {
		return this.orderRemark;
	}

	public void setOrderRemark(String orderRemark) {
		this.orderRemark = orderRemark;
	}


	public double getPkout2001() {
		return this.pkout2001;
	}

	public void setPkout2001(double pkout2001) {
		this.pkout2001 = pkout2001;
	}


	@Column(name="RECORD_GUBUN")
	public String getRecordGubun() {
		return this.recordGubun;
	}

	public void setRecordGubun(String recordGubun) {
		this.recordGubun = recordGubun;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Column(name="SOURCE_FKOUT2001")
	public double getSourceFkout2001() {
		return this.sourceFkout2001;
	}

	public void setSourceFkout2001(double sourceFkout2001) {
		this.sourceFkout2001 = sourceFkout2001;
	}


	@Column(name="SOURCE_SG_BUN")
	public String getSourceSgBun() {
		return this.sourceSgBun;
	}

	public void setSourceSgBun(String sourceSgBun) {
		this.sourceSgBun = sourceSgBun;
	}


	@Column(name="SOURCE_SG_CODE")
	public String getSourceSgCode() {
		return this.sourceSgCode;
	}

	public void setSourceSgCode(String sourceSgCode) {
		this.sourceSgCode = sourceSgCode;
	}


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}


	@Column(name="SUNAB_DANUI")
	public String getSunabDanui() {
		return this.sunabDanui;
	}

	public void setSunabDanui(String sunabDanui) {
		this.sunabDanui = sunabDanui;
	}


	@Column(name="SUNAB_NALSU")
	public double getSunabNalsu() {
		return this.sunabNalsu;
	}

	public void setSunabNalsu(double sunabNalsu) {
		this.sunabNalsu = sunabNalsu;
	}


	@Column(name="SUNAB_SURYANG")
	public double getSunabSuryang() {
		return this.sunabSuryang;
	}

	public void setSunabSuryang(double sunabSuryang) {
		this.sunabSuryang = sunabSuryang;
	}


	public double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(double suryang) {
		this.suryang = suryang;
	}


	@Column(name="SUSURYO_GUBUN")
	public String getSusuryoGubun() {
		return this.susuryoGubun;
	}

	public void setSusuryoGubun(String susuryoGubun) {
		this.susuryoGubun = susuryoGubun;
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


	@Column(name="TIME_INPUT_YN")
	public String getTimeInputYn() {
		return this.timeInputYn;
	}

	public void setTimeInputYn(String timeInputYn) {
		this.timeInputYn = timeInputYn;
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


	@Column(name="VALID_YN")
	public String getValidYn() {
		return this.validYn;
	}

	public void setValidYn(String validYn) {
		this.validYn = validYn;
	}


	@Column(name="WONYOI_ORDER_YN")
	public String getWonyoiOrderYn() {
		return this.wonyoiOrderYn;
	}

	public void setWonyoiOrderYn(String wonyoiOrderYn) {
		this.wonyoiOrderYn = wonyoiOrderYn;
	}

}