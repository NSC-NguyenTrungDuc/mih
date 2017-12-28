package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS1002 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs1002.findAll", query="SELECT i FROM Ifs1002 i")
public class Ifs1002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actCode;
	private String bunho;
	private String commantInfo1;
	private String commantInfo2;
	private String commant1;
	private String commant2;
	private double fkout1001;
	private String gwaCode;
	private String hospCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifHospCode;
	private String ifTime;
	private String iraiDoctor;
	private String iraiGwa;
	private String kensaYoyaku;
	private String kusuriYoyaku;
	private String naewonGubun;
	private String naewonTime;
	private double pkifs1002;
	private String pointNumber;
	private String procGubun;
	private String resCaseTime;
	private String resCode;
	private String resDate;
	private String resKey;
	private String resTime;
	private String sinryoYoyaku;
	private String sonotaYoyaku;
	private String syotiYoyaku;
	private Date sysDate;
	private String sysId;
	private String tyusyaYoyaku;
	private Date updDate;
	private String updId;
	private String updateClient;
	private String updateDate;
	private String updateId;
	private String writerId;
	private String zyunbi1;
	private String zyunbi2;
	private String zyunbi3;
	private String zyunbi4;
	private String zyunbi5;

	public Ifs1002() {
	}


	@Column(name="ACT_CODE")
	public String getActCode() {
		return this.actCode;
	}

	public void setActCode(String actCode) {
		this.actCode = actCode;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="COMMANT_INFO1")
	public String getCommantInfo1() {
		return this.commantInfo1;
	}

	public void setCommantInfo1(String commantInfo1) {
		this.commantInfo1 = commantInfo1;
	}


	@Column(name="COMMANT_INFO2")
	public String getCommantInfo2() {
		return this.commantInfo2;
	}

	public void setCommantInfo2(String commantInfo2) {
		this.commantInfo2 = commantInfo2;
	}


	public String getCommant1() {
		return this.commant1;
	}

	public void setCommant1(String commant1) {
		this.commant1 = commant1;
	}


	public String getCommant2() {
		return this.commant2;
	}

	public void setCommant2(String commant2) {
		this.commant2 = commant2;
	}


	public double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(double fkout1001) {
		this.fkout1001 = fkout1001;
	}


	@Column(name="GWA_CODE")
	public String getGwaCode() {
		return this.gwaCode;
	}

	public void setGwaCode(String gwaCode) {
		this.gwaCode = gwaCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IF_DATE")
	public Date getIfDate() {
		return this.ifDate;
	}

	public void setIfDate(Date ifDate) {
		this.ifDate = ifDate;
	}


	@Column(name="IF_ERR")
	public String getIfErr() {
		return this.ifErr;
	}

	public void setIfErr(String ifErr) {
		this.ifErr = ifErr;
	}


	@Column(name="IF_FLAG")
	public String getIfFlag() {
		return this.ifFlag;
	}

	public void setIfFlag(String ifFlag) {
		this.ifFlag = ifFlag;
	}


	@Column(name="IF_HOSP_CODE")
	public String getIfHospCode() {
		return this.ifHospCode;
	}

	public void setIfHospCode(String ifHospCode) {
		this.ifHospCode = ifHospCode;
	}


	@Column(name="IF_TIME")
	public String getIfTime() {
		return this.ifTime;
	}

	public void setIfTime(String ifTime) {
		this.ifTime = ifTime;
	}


	@Column(name="IRAI_DOCTOR")
	public String getIraiDoctor() {
		return this.iraiDoctor;
	}

	public void setIraiDoctor(String iraiDoctor) {
		this.iraiDoctor = iraiDoctor;
	}


	@Column(name="IRAI_GWA")
	public String getIraiGwa() {
		return this.iraiGwa;
	}

	public void setIraiGwa(String iraiGwa) {
		this.iraiGwa = iraiGwa;
	}


	@Column(name="KENSA_YOYAKU")
	public String getKensaYoyaku() {
		return this.kensaYoyaku;
	}

	public void setKensaYoyaku(String kensaYoyaku) {
		this.kensaYoyaku = kensaYoyaku;
	}


	@Column(name="KUSURI_YOYAKU")
	public String getKusuriYoyaku() {
		return this.kusuriYoyaku;
	}

	public void setKusuriYoyaku(String kusuriYoyaku) {
		this.kusuriYoyaku = kusuriYoyaku;
	}


	@Column(name="NAEWON_GUBUN")
	public String getNaewonGubun() {
		return this.naewonGubun;
	}

	public void setNaewonGubun(String naewonGubun) {
		this.naewonGubun = naewonGubun;
	}


	@Column(name="NAEWON_TIME")
	public String getNaewonTime() {
		return this.naewonTime;
	}

	public void setNaewonTime(String naewonTime) {
		this.naewonTime = naewonTime;
	}


	public double getPkifs1002() {
		return this.pkifs1002;
	}

	public void setPkifs1002(double pkifs1002) {
		this.pkifs1002 = pkifs1002;
	}


	@Column(name="POINT_NUMBER")
	public String getPointNumber() {
		return this.pointNumber;
	}

	public void setPointNumber(String pointNumber) {
		this.pointNumber = pointNumber;
	}


	@Column(name="PROC_GUBUN")
	public String getProcGubun() {
		return this.procGubun;
	}

	public void setProcGubun(String procGubun) {
		this.procGubun = procGubun;
	}


	@Column(name="RES_CASE_TIME")
	public String getResCaseTime() {
		return this.resCaseTime;
	}

	public void setResCaseTime(String resCaseTime) {
		this.resCaseTime = resCaseTime;
	}


	@Column(name="RES_CODE")
	public String getResCode() {
		return this.resCode;
	}

	public void setResCode(String resCode) {
		this.resCode = resCode;
	}


	@Column(name="RES_DATE")
	public String getResDate() {
		return this.resDate;
	}

	public void setResDate(String resDate) {
		this.resDate = resDate;
	}


	@Column(name="RES_KEY")
	public String getResKey() {
		return this.resKey;
	}

	public void setResKey(String resKey) {
		this.resKey = resKey;
	}


	@Column(name="RES_TIME")
	public String getResTime() {
		return this.resTime;
	}

	public void setResTime(String resTime) {
		this.resTime = resTime;
	}


	@Column(name="SINRYO_YOYAKU")
	public String getSinryoYoyaku() {
		return this.sinryoYoyaku;
	}

	public void setSinryoYoyaku(String sinryoYoyaku) {
		this.sinryoYoyaku = sinryoYoyaku;
	}


	@Column(name="SONOTA_YOYAKU")
	public String getSonotaYoyaku() {
		return this.sonotaYoyaku;
	}

	public void setSonotaYoyaku(String sonotaYoyaku) {
		this.sonotaYoyaku = sonotaYoyaku;
	}


	@Column(name="SYOTI_YOYAKU")
	public String getSyotiYoyaku() {
		return this.syotiYoyaku;
	}

	public void setSyotiYoyaku(String syotiYoyaku) {
		this.syotiYoyaku = syotiYoyaku;
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


	@Column(name="TYUSYA_YOYAKU")
	public String getTyusyaYoyaku() {
		return this.tyusyaYoyaku;
	}

	public void setTyusyaYoyaku(String tyusyaYoyaku) {
		this.tyusyaYoyaku = tyusyaYoyaku;
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


	@Column(name="UPDATE_CLIENT")
	public String getUpdateClient() {
		return this.updateClient;
	}

	public void setUpdateClient(String updateClient) {
		this.updateClient = updateClient;
	}


	@Column(name="UPDATE_DATE")
	public String getUpdateDate() {
		return this.updateDate;
	}

	public void setUpdateDate(String updateDate) {
		this.updateDate = updateDate;
	}


	@Column(name="UPDATE_ID")
	public String getUpdateId() {
		return this.updateId;
	}

	public void setUpdateId(String updateId) {
		this.updateId = updateId;
	}


	@Column(name="WRITER_ID")
	public String getWriterId() {
		return this.writerId;
	}

	public void setWriterId(String writerId) {
		this.writerId = writerId;
	}


	@Column(name="ZYUNBI_1")
	public String getZyunbi1() {
		return this.zyunbi1;
	}

	public void setZyunbi1(String zyunbi1) {
		this.zyunbi1 = zyunbi1;
	}


	@Column(name="ZYUNBI_2")
	public String getZyunbi2() {
		return this.zyunbi2;
	}

	public void setZyunbi2(String zyunbi2) {
		this.zyunbi2 = zyunbi2;
	}


	@Column(name="ZYUNBI_3")
	public String getZyunbi3() {
		return this.zyunbi3;
	}

	public void setZyunbi3(String zyunbi3) {
		this.zyunbi3 = zyunbi3;
	}


	@Column(name="ZYUNBI_4")
	public String getZyunbi4() {
		return this.zyunbi4;
	}

	public void setZyunbi4(String zyunbi4) {
		this.zyunbi4 = zyunbi4;
	}


	@Column(name="ZYUNBI_5")
	public String getZyunbi5() {
		return this.zyunbi5;
	}

	public void setZyunbi5(String zyunbi5) {
		this.zyunbi5 = zyunbi5;
	}

}