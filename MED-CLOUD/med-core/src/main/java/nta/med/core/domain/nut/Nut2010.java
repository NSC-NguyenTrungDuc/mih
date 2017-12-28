package nta.med.core.domain.nut;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUT2010 database table.
 * 
 */
@Entity
@Table(name="NUT2010")
public class Nut2010 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bldGubun;
	private String bunho;
	private String directGubun;
	private Double fkinp1001;
	private Double fknut2011;
	private Double fkocs2005;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private String joDirectCode;
	private String joDirectCodeD;
	private String joDirectCode1;
	private String joDirectCode1D;
	private String joDirectCode2;
	private String joDirectCode2D;
	private String joDirectCode3;
	private String joDirectCode3D;
	private Double joFkocs2005;
	private String joKumjisik;
	private String joNomimono;
	private String juDirectCode;
	private String juDirectCodeD;
	private String juDirectCode1;
	private String juDirectCode1D;
	private String juDirectCode2;
	private String juDirectCode2D;
	private String juDirectCode3;
	private String juDirectCode3D;
	private Double juFkocs2005;
	private String juKumjisik;
	private String juNomimono;
	private Double magamSeq;
	private Date nutDate;
	private Double pknut2010;
	private String seokDirectCode;
	private String seokDirectCodeD;
	private String seokDirectCode1;
	private String seokDirectCode1D;
	private String seokDirectCode2;
	private String seokDirectCode2D;
	private String seokDirectCode3;
	private String seokDirectCode3D;
	private Double seokFkocs2005;
	private String seokKumjisik;
	private String seokNomimono;
	private Date sysDate;
	private String sysId;
	private String transFlag1;
	private String transFlag2;
	private String transFlag3;
	private String transFlag4;
	private Date updDate;
	private String updId;

	public Nut2010() {
	}

	@Column(name = "BLD_GUBUN")
	public String getBldGubun() {
		return this.bldGubun;
	}

	public void setBldGubun(String bldGubun) {
		this.bldGubun = bldGubun;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "DIRECT_GUBUN")
	public String getDirectGubun() {
		return this.directGubun;
	}

	public void setDirectGubun(String directGubun) {
		this.directGubun = directGubun;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Double getFknut2011() {
		return this.fknut2011;
	}

	public void setFknut2011(Double fknut2011) {
		this.fknut2011 = fknut2011;
	}

	public Double getFkocs2005() {
		return this.fkocs2005;
	}

	public void setFkocs2005(Double fkocs2005) {
		this.fkocs2005 = fkocs2005;
	}

	@Column(name = "HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}

	@Column(name = "HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "JO_DIRECT_CODE")
	public String getJoDirectCode() {
		return this.joDirectCode;
	}

	public void setJoDirectCode(String joDirectCode) {
		this.joDirectCode = joDirectCode;
	}

	@Column(name = "JO_DIRECT_CODE_D")
	public String getJoDirectCodeD() {
		return this.joDirectCodeD;
	}

	public void setJoDirectCodeD(String joDirectCodeD) {
		this.joDirectCodeD = joDirectCodeD;
	}

	@Column(name = "JO_DIRECT_CODE1")
	public String getJoDirectCode1() {
		return this.joDirectCode1;
	}

	public void setJoDirectCode1(String joDirectCode1) {
		this.joDirectCode1 = joDirectCode1;
	}

	@Column(name = "JO_DIRECT_CODE1_D")
	public String getJoDirectCode1D() {
		return this.joDirectCode1D;
	}

	public void setJoDirectCode1D(String joDirectCode1D) {
		this.joDirectCode1D = joDirectCode1D;
	}

	@Column(name = "JO_DIRECT_CODE2")
	public String getJoDirectCode2() {
		return this.joDirectCode2;
	}

	public void setJoDirectCode2(String joDirectCode2) {
		this.joDirectCode2 = joDirectCode2;
	}

	@Column(name = "JO_DIRECT_CODE2_D")
	public String getJoDirectCode2D() {
		return this.joDirectCode2D;
	}

	public void setJoDirectCode2D(String joDirectCode2D) {
		this.joDirectCode2D = joDirectCode2D;
	}

	@Column(name = "JO_DIRECT_CODE3")
	public String getJoDirectCode3() {
		return this.joDirectCode3;
	}

	public void setJoDirectCode3(String joDirectCode3) {
		this.joDirectCode3 = joDirectCode3;
	}

	@Column(name = "JO_DIRECT_CODE3_D")
	public String getJoDirectCode3D() {
		return this.joDirectCode3D;
	}

	public void setJoDirectCode3D(String joDirectCode3D) {
		this.joDirectCode3D = joDirectCode3D;
	}

	@Column(name = "JO_FKOCS2005")
	public Double getJoFkocs2005() {
		return this.joFkocs2005;
	}

	public void setJoFkocs2005(Double joFkocs2005) {
		this.joFkocs2005 = joFkocs2005;
	}

	@Column(name = "JO_KUMJISIK")
	public String getJoKumjisik() {
		return this.joKumjisik;
	}

	public void setJoKumjisik(String joKumjisik) {
		this.joKumjisik = joKumjisik;
	}

	@Column(name = "JO_NOMIMONO")
	public String getJoNomimono() {
		return this.joNomimono;
	}

	public void setJoNomimono(String joNomimono) {
		this.joNomimono = joNomimono;
	}

	@Column(name = "JU_DIRECT_CODE")
	public String getJuDirectCode() {
		return this.juDirectCode;
	}

	public void setJuDirectCode(String juDirectCode) {
		this.juDirectCode = juDirectCode;
	}

	@Column(name = "JU_DIRECT_CODE_D")
	public String getJuDirectCodeD() {
		return this.juDirectCodeD;
	}

	public void setJuDirectCodeD(String juDirectCodeD) {
		this.juDirectCodeD = juDirectCodeD;
	}

	@Column(name = "JU_DIRECT_CODE1")
	public String getJuDirectCode1() {
		return this.juDirectCode1;
	}

	public void setJuDirectCode1(String juDirectCode1) {
		this.juDirectCode1 = juDirectCode1;
	}

	@Column(name = "JU_DIRECT_CODE1_D")
	public String getJuDirectCode1D() {
		return this.juDirectCode1D;
	}

	public void setJuDirectCode1D(String juDirectCode1D) {
		this.juDirectCode1D = juDirectCode1D;
	}

	@Column(name = "JU_DIRECT_CODE2")
	public String getJuDirectCode2() {
		return this.juDirectCode2;
	}

	public void setJuDirectCode2(String juDirectCode2) {
		this.juDirectCode2 = juDirectCode2;
	}

	@Column(name = "JU_DIRECT_CODE2_D")
	public String getJuDirectCode2D() {
		return this.juDirectCode2D;
	}

	public void setJuDirectCode2D(String juDirectCode2D) {
		this.juDirectCode2D = juDirectCode2D;
	}

	@Column(name = "JU_DIRECT_CODE3")
	public String getJuDirectCode3() {
		return this.juDirectCode3;
	}

	public void setJuDirectCode3(String juDirectCode3) {
		this.juDirectCode3 = juDirectCode3;
	}

	@Column(name = "JU_DIRECT_CODE3_D")
	public String getJuDirectCode3D() {
		return this.juDirectCode3D;
	}

	public void setJuDirectCode3D(String juDirectCode3D) {
		this.juDirectCode3D = juDirectCode3D;
	}

	@Column(name = "JU_FKOCS2005")
	public Double getJuFkocs2005() {
		return this.juFkocs2005;
	}

	public void setJuFkocs2005(Double juFkocs2005) {
		this.juFkocs2005 = juFkocs2005;
	}

	@Column(name = "JU_KUMJISIK")
	public String getJuKumjisik() {
		return this.juKumjisik;
	}

	public void setJuKumjisik(String juKumjisik) {
		this.juKumjisik = juKumjisik;
	}

	@Column(name = "JU_NOMIMONO")
	public String getJuNomimono() {
		return this.juNomimono;
	}

	public void setJuNomimono(String juNomimono) {
		this.juNomimono = juNomimono;
	}

	@Column(name = "MAGAM_SEQ")
	public Double getMagamSeq() {
		return this.magamSeq;
	}

	public void setMagamSeq(Double magamSeq) {
		this.magamSeq = magamSeq;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "NUT_DATE")
	public Date getNutDate() {
		return this.nutDate;
	}

	public void setNutDate(Date nutDate) {
		this.nutDate = nutDate;
	}

	public Double getPknut2010() {
		return this.pknut2010;
	}

	public void setPknut2010(Double pknut2010) {
		this.pknut2010 = pknut2010;
	}

	@Column(name = "SEOK_DIRECT_CODE")
	public String getSeokDirectCode() {
		return this.seokDirectCode;
	}

	public void setSeokDirectCode(String seokDirectCode) {
		this.seokDirectCode = seokDirectCode;
	}

	@Column(name = "SEOK_DIRECT_CODE_D")
	public String getSeokDirectCodeD() {
		return this.seokDirectCodeD;
	}

	public void setSeokDirectCodeD(String seokDirectCodeD) {
		this.seokDirectCodeD = seokDirectCodeD;
	}

	@Column(name = "SEOK_DIRECT_CODE1")
	public String getSeokDirectCode1() {
		return this.seokDirectCode1;
	}

	public void setSeokDirectCode1(String seokDirectCode1) {
		this.seokDirectCode1 = seokDirectCode1;
	}

	@Column(name = "SEOK_DIRECT_CODE1_D")
	public String getSeokDirectCode1D() {
		return this.seokDirectCode1D;
	}

	public void setSeokDirectCode1D(String seokDirectCode1D) {
		this.seokDirectCode1D = seokDirectCode1D;
	}

	@Column(name = "SEOK_DIRECT_CODE2")
	public String getSeokDirectCode2() {
		return this.seokDirectCode2;
	}

	public void setSeokDirectCode2(String seokDirectCode2) {
		this.seokDirectCode2 = seokDirectCode2;
	}

	@Column(name = "SEOK_DIRECT_CODE2_D")
	public String getSeokDirectCode2D() {
		return this.seokDirectCode2D;
	}

	public void setSeokDirectCode2D(String seokDirectCode2D) {
		this.seokDirectCode2D = seokDirectCode2D;
	}

	@Column(name = "SEOK_DIRECT_CODE3")
	public String getSeokDirectCode3() {
		return this.seokDirectCode3;
	}

	public void setSeokDirectCode3(String seokDirectCode3) {
		this.seokDirectCode3 = seokDirectCode3;
	}

	@Column(name = "SEOK_DIRECT_CODE3_D")
	public String getSeokDirectCode3D() {
		return this.seokDirectCode3D;
	}

	public void setSeokDirectCode3D(String seokDirectCode3D) {
		this.seokDirectCode3D = seokDirectCode3D;
	}

	@Column(name = "SEOK_FKOCS2005")
	public Double getSeokFkocs2005() {
		return this.seokFkocs2005;
	}

	public void setSeokFkocs2005(Double seokFkocs2005) {
		this.seokFkocs2005 = seokFkocs2005;
	}

	@Column(name = "SEOK_KUMJISIK")
	public String getSeokKumjisik() {
		return this.seokKumjisik;
	}

	public void setSeokKumjisik(String seokKumjisik) {
		this.seokKumjisik = seokKumjisik;
	}

	@Column(name = "SEOK_NOMIMONO")
	public String getSeokNomimono() {
		return this.seokNomimono;
	}

	public void setSeokNomimono(String seokNomimono) {
		this.seokNomimono = seokNomimono;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "TRANS_FLAG1")
	public String getTransFlag1() {
		return this.transFlag1;
	}

	public void setTransFlag1(String transFlag1) {
		this.transFlag1 = transFlag1;
	}

	@Column(name = "TRANS_FLAG2")
	public String getTransFlag2() {
		return this.transFlag2;
	}

	public void setTransFlag2(String transFlag2) {
		this.transFlag2 = transFlag2;
	}

	@Column(name = "TRANS_FLAG3")
	public String getTransFlag3() {
		return this.transFlag3;
	}

	public void setTransFlag3(String transFlag3) {
		this.transFlag3 = transFlag3;
	}

	@Column(name = "TRANS_FLAG4")
	public String getTransFlag4() {
		return this.transFlag4;
	}

	public void setTransFlag4(String transFlag4) {
		this.transFlag4 = transFlag4;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}