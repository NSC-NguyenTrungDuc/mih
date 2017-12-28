package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC1004 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc1004.findAll", query="SELECT d FROM Doc1004 d")
public class Doc1004 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actionYn;
	private String bigo;
	private String buwiGrade;
	private String chiryoGigan;
	private Date chojinDate;
	private String dongbanja;
	private String endYn;
	private double fkdoc1001;
	private String hospCode;
	private String inpYn;
	private String jinryoView;
	private String nextBalbyoungYn;
	private String nextChiryoView;
	private String sangCode1;
	private String sangCode10;
	private String sangCode2;
	private String sangCode3;
	private String sangCode4;
	private String sangCode5;
	private String sangCode6;
	private String sangCode7;
	private String sangCode8;
	private String sangCode9;
	private String sangName1;
	private String sangName10;
	private String sangName2;
	private String sangName3;
	private String sangName4;
	private String sangName5;
	private String sangName6;
	private String sangName7;
	private String sangName8;
	private String sangName9;
	private Date sanghaeDate;
	private String siksaYn;
	private String susulYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String wonin;

	public Doc1004() {
	}


	@Column(name="ACTION_YN")
	public String getActionYn() {
		return this.actionYn;
	}

	public void setActionYn(String actionYn) {
		this.actionYn = actionYn;
	}


	public String getBigo() {
		return this.bigo;
	}

	public void setBigo(String bigo) {
		this.bigo = bigo;
	}


	@Column(name="BUWI_GRADE")
	public String getBuwiGrade() {
		return this.buwiGrade;
	}

	public void setBuwiGrade(String buwiGrade) {
		this.buwiGrade = buwiGrade;
	}


	@Column(name="CHIRYO_GIGAN")
	public String getChiryoGigan() {
		return this.chiryoGigan;
	}

	public void setChiryoGigan(String chiryoGigan) {
		this.chiryoGigan = chiryoGigan;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHOJIN_DATE")
	public Date getChojinDate() {
		return this.chojinDate;
	}

	public void setChojinDate(Date chojinDate) {
		this.chojinDate = chojinDate;
	}


	public String getDongbanja() {
		return this.dongbanja;
	}

	public void setDongbanja(String dongbanja) {
		this.dongbanja = dongbanja;
	}


	@Column(name="END_YN")
	public String getEndYn() {
		return this.endYn;
	}

	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}


	public double getFkdoc1001() {
		return this.fkdoc1001;
	}

	public void setFkdoc1001(double fkdoc1001) {
		this.fkdoc1001 = fkdoc1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INP_YN")
	public String getInpYn() {
		return this.inpYn;
	}

	public void setInpYn(String inpYn) {
		this.inpYn = inpYn;
	}


	@Column(name="JINRYO_VIEW")
	public String getJinryoView() {
		return this.jinryoView;
	}

	public void setJinryoView(String jinryoView) {
		this.jinryoView = jinryoView;
	}


	@Column(name="NEXT_BALBYOUNG_YN")
	public String getNextBalbyoungYn() {
		return this.nextBalbyoungYn;
	}

	public void setNextBalbyoungYn(String nextBalbyoungYn) {
		this.nextBalbyoungYn = nextBalbyoungYn;
	}


	@Column(name="NEXT_CHIRYO_VIEW")
	public String getNextChiryoView() {
		return this.nextChiryoView;
	}

	public void setNextChiryoView(String nextChiryoView) {
		this.nextChiryoView = nextChiryoView;
	}


	@Column(name="SANG_CODE1")
	public String getSangCode1() {
		return this.sangCode1;
	}

	public void setSangCode1(String sangCode1) {
		this.sangCode1 = sangCode1;
	}


	@Column(name="SANG_CODE10")
	public String getSangCode10() {
		return this.sangCode10;
	}

	public void setSangCode10(String sangCode10) {
		this.sangCode10 = sangCode10;
	}


	@Column(name="SANG_CODE2")
	public String getSangCode2() {
		return this.sangCode2;
	}

	public void setSangCode2(String sangCode2) {
		this.sangCode2 = sangCode2;
	}


	@Column(name="SANG_CODE3")
	public String getSangCode3() {
		return this.sangCode3;
	}

	public void setSangCode3(String sangCode3) {
		this.sangCode3 = sangCode3;
	}


	@Column(name="SANG_CODE4")
	public String getSangCode4() {
		return this.sangCode4;
	}

	public void setSangCode4(String sangCode4) {
		this.sangCode4 = sangCode4;
	}


	@Column(name="SANG_CODE5")
	public String getSangCode5() {
		return this.sangCode5;
	}

	public void setSangCode5(String sangCode5) {
		this.sangCode5 = sangCode5;
	}


	@Column(name="SANG_CODE6")
	public String getSangCode6() {
		return this.sangCode6;
	}

	public void setSangCode6(String sangCode6) {
		this.sangCode6 = sangCode6;
	}


	@Column(name="SANG_CODE7")
	public String getSangCode7() {
		return this.sangCode7;
	}

	public void setSangCode7(String sangCode7) {
		this.sangCode7 = sangCode7;
	}


	@Column(name="SANG_CODE8")
	public String getSangCode8() {
		return this.sangCode8;
	}

	public void setSangCode8(String sangCode8) {
		this.sangCode8 = sangCode8;
	}


	@Column(name="SANG_CODE9")
	public String getSangCode9() {
		return this.sangCode9;
	}

	public void setSangCode9(String sangCode9) {
		this.sangCode9 = sangCode9;
	}


	@Column(name="SANG_NAME1")
	public String getSangName1() {
		return this.sangName1;
	}

	public void setSangName1(String sangName1) {
		this.sangName1 = sangName1;
	}


	@Column(name="SANG_NAME10")
	public String getSangName10() {
		return this.sangName10;
	}

	public void setSangName10(String sangName10) {
		this.sangName10 = sangName10;
	}


	@Column(name="SANG_NAME2")
	public String getSangName2() {
		return this.sangName2;
	}

	public void setSangName2(String sangName2) {
		this.sangName2 = sangName2;
	}


	@Column(name="SANG_NAME3")
	public String getSangName3() {
		return this.sangName3;
	}

	public void setSangName3(String sangName3) {
		this.sangName3 = sangName3;
	}


	@Column(name="SANG_NAME4")
	public String getSangName4() {
		return this.sangName4;
	}

	public void setSangName4(String sangName4) {
		this.sangName4 = sangName4;
	}


	@Column(name="SANG_NAME5")
	public String getSangName5() {
		return this.sangName5;
	}

	public void setSangName5(String sangName5) {
		this.sangName5 = sangName5;
	}


	@Column(name="SANG_NAME6")
	public String getSangName6() {
		return this.sangName6;
	}

	public void setSangName6(String sangName6) {
		this.sangName6 = sangName6;
	}


	@Column(name="SANG_NAME7")
	public String getSangName7() {
		return this.sangName7;
	}

	public void setSangName7(String sangName7) {
		this.sangName7 = sangName7;
	}


	@Column(name="SANG_NAME8")
	public String getSangName8() {
		return this.sangName8;
	}

	public void setSangName8(String sangName8) {
		this.sangName8 = sangName8;
	}


	@Column(name="SANG_NAME9")
	public String getSangName9() {
		return this.sangName9;
	}

	public void setSangName9(String sangName9) {
		this.sangName9 = sangName9;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SANGHAE_DATE")
	public Date getSanghaeDate() {
		return this.sanghaeDate;
	}

	public void setSanghaeDate(Date sanghaeDate) {
		this.sanghaeDate = sanghaeDate;
	}


	@Column(name="SIKSA_YN")
	public String getSiksaYn() {
		return this.siksaYn;
	}

	public void setSiksaYn(String siksaYn) {
		this.siksaYn = siksaYn;
	}


	@Column(name="SUSUL_YN")
	public String getSusulYn() {
		return this.susulYn;
	}

	public void setSusulYn(String susulYn) {
		this.susulYn = susulYn;
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


	public String getWonin() {
		return this.wonin;
	}

	public void setWonin(String wonin) {
		this.wonin = wonin;
	}

}