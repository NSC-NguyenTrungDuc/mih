package nta.med.core.domain.inv;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the INV1001 database table.
 * 
 */
@Entity
//@NamedQuery(name="Inv1001.findAll", query="SELECT i FROM Inv1001 i")
@Table(name = "INV1001")
public class Inv1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actBuseo;
	private String actHangmog;
	private Date actingDate;
	private String addtionGubun;
	private String addtionYn;
	private String bichiYn;
	private Double bomSourceKey;
	private String bomYn;
	private String bunho;
	private String chungguBuseo;
	private Date chungguDate;
	private Double chungguSeq;
	private Double dv;
	private String dvTime;
	private Double fkocs1003;
	private Double fkocs2003;
	private String gijunActBuseo;
	private String hangmogCode;
	private String hospCode;
	private String inOutGubun;
	private String inputPart;
	private Double inputQty;
	private String jaeryoCode;
	private Date jaeryoUseDate;
	private Date jaeryoUseReserDate;
	private Date jibgyeDate;
	private String jibgyeTime;
	private Double nalsu;
	private String ocsActingYn;
	private String ordDanui;
	private Date orderDate;
	private Double pkinv1001;
	private String printYn;
	private Double realSuryang;
	private String subulBuseo;
	private Date sunabDate;
	private Double suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private Double xrtRecapureSeq;
	private String xrtRecapureYn;

	public Inv1001() {
	}


	@Column(name="ACT_BUSEO")
	public String getActBuseo() {
		return this.actBuseo;
	}

	public void setActBuseo(String actBuseo) {
		this.actBuseo = actBuseo;
	}


	@Column(name="ACT_HANGMOG")
	public String getActHangmog() {
		return this.actHangmog;
	}

	public void setActHangmog(String actHangmog) {
		this.actHangmog = actHangmog;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}


	@Column(name="ADDTION_GUBUN")
	public String getAddtionGubun() {
		return this.addtionGubun;
	}

	public void setAddtionGubun(String addtionGubun) {
		this.addtionGubun = addtionGubun;
	}


	@Column(name="ADDTION_YN")
	public String getAddtionYn() {
		return this.addtionYn;
	}

	public void setAddtionYn(String addtionYn) {
		this.addtionYn = addtionYn;
	}


	@Column(name="BICHI_YN")
	public String getBichiYn() {
		return this.bichiYn;
	}

	public void setBichiYn(String bichiYn) {
		this.bichiYn = bichiYn;
	}


	@Column(name="BOM_SOURCE_KEY")
	public Double getBomSourceKey() {
		return this.bomSourceKey;
	}

	public void setBomSourceKey(Double bomSourceKey) {
		this.bomSourceKey = bomSourceKey;
	}


	@Column(name="BOM_YN")
	public String getBomYn() {
		return this.bomYn;
	}

	public void setBomYn(String bomYn) {
		this.bomYn = bomYn;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CHUNGGU_BUSEO")
	public String getChungguBuseo() {
		return this.chungguBuseo;
	}

	public void setChungguBuseo(String chungguBuseo) {
		this.chungguBuseo = chungguBuseo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHUNGGU_DATE")
	public Date getChungguDate() {
		return this.chungguDate;
	}

	public void setChungguDate(Date chungguDate) {
		this.chungguDate = chungguDate;
	}


	@Column(name="CHUNGGU_SEQ")
	public Double getChungguSeq() {
		return this.chungguSeq;
	}

	public void setChungguSeq(Double chungguSeq) {
		this.chungguSeq = chungguSeq;
	}


	public Double getDv() {
		return this.dv;
	}

	public void setDv(Double dv) {
		this.dv = dv;
	}


	@Column(name="DV_TIME")
	public String getDvTime() {
		return this.dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}


	public Double getFkocs1003() {
		return this.fkocs1003;
	}

	public void setFkocs1003(Double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}


	public Double getFkocs2003() {
		return this.fkocs2003;
	}

	public void setFkocs2003(Double fkocs2003) {
		this.fkocs2003 = fkocs2003;
	}


	@Column(name="GIJUN_ACT_BUSEO")
	public String getGijunActBuseo() {
		return this.gijunActBuseo;
	}

	public void setGijunActBuseo(String gijunActBuseo) {
		this.gijunActBuseo = gijunActBuseo;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Column(name="INPUT_PART")
	public String getInputPart() {
		return this.inputPart;
	}

	public void setInputPart(String inputPart) {
		this.inputPart = inputPart;
	}


	@Column(name="INPUT_QTY")
	public Double getInputQty() {
		return this.inputQty;
	}

	public void setInputQty(Double inputQty) {
		this.inputQty = inputQty;
	}


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JAERYO_USE_DATE")
	public Date getJaeryoUseDate() {
		return this.jaeryoUseDate;
	}

	public void setJaeryoUseDate(Date jaeryoUseDate) {
		this.jaeryoUseDate = jaeryoUseDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JAERYO_USE_RESER_DATE")
	public Date getJaeryoUseReserDate() {
		return this.jaeryoUseReserDate;
	}

	public void setJaeryoUseReserDate(Date jaeryoUseReserDate) {
		this.jaeryoUseReserDate = jaeryoUseReserDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JIBGYE_DATE")
	public Date getJibgyeDate() {
		return this.jibgyeDate;
	}

	public void setJibgyeDate(Date jibgyeDate) {
		this.jibgyeDate = jibgyeDate;
	}


	@Column(name="JIBGYE_TIME")
	public String getJibgyeTime() {
		return this.jibgyeTime;
	}

	public void setJibgyeTime(String jibgyeTime) {
		this.jibgyeTime = jibgyeTime;
	}


	public Double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}


	@Column(name="OCS_ACTING_YN")
	public String getOcsActingYn() {
		return this.ocsActingYn;
	}

	public void setOcsActingYn(String ocsActingYn) {
		this.ocsActingYn = ocsActingYn;
	}


	@Column(name="ORD_DANUI")
	public String getOrdDanui() {
		return this.ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	public Double getPkinv1001() {
		return this.pkinv1001;
	}

	public void setPkinv1001(Double pkinv1001) {
		this.pkinv1001 = pkinv1001;
	}


	@Column(name="PRINT_YN")
	public String getPrintYn() {
		return this.printYn;
	}

	public void setPrintYn(String printYn) {
		this.printYn = printYn;
	}


	@Column(name="REAL_SURYANG")
	public Double getRealSuryang() {
		return this.realSuryang;
	}

	public void setRealSuryang(Double realSuryang) {
		this.realSuryang = realSuryang;
	}


	@Column(name="SUBUL_BUSEO")
	public String getSubulBuseo() {
		return this.subulBuseo;
	}

	public void setSubulBuseo(String subulBuseo) {
		this.subulBuseo = subulBuseo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SUNAB_DATE")
	public Date getSunabDate() {
		return this.sunabDate;
	}

	public void setSunabDate(Date sunabDate) {
		this.sunabDate = sunabDate;
	}


	public Double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
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


	@Column(name="XRT_RECAPURE_SEQ")
	public Double getXrtRecapureSeq() {
		return this.xrtRecapureSeq;
	}

	public void setXrtRecapureSeq(Double xrtRecapureSeq) {
		this.xrtRecapureSeq = xrtRecapureSeq;
	}


	@Column(name="XRT_RECAPURE_YN")
	public String getXrtRecapureYn() {
		return this.xrtRecapureYn;
	}

	public void setXrtRecapureYn(String xrtRecapureYn) {
		this.xrtRecapureYn = xrtRecapureYn;
	}

}