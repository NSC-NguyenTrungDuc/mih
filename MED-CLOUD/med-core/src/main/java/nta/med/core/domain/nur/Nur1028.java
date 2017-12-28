package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1028 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1028.findAll", query="SELECT n FROM Nur1028 n")
public class Nur1028 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String dataTransUserId;
	private String dataTransYn;
	private String data1;
	private String data10;
	private String data11;
	private String data12;
	private String data13;
	private String data14;
	private String data146;
	private String data147;
	private String data148;
	private String data149;
	private String data15;
	private String data150;
	private String data16;
	private String data17;
	private String data18;
	private String data19;
	private String data2;
	private String data20;
	private String data3;
	private String data4;
	private String data5;
	private String data6;
	private String data7;
	private String data8;
	private String data9;
	private String endYn;
	private String hoDong;
	private String hospCode;
	private String iljiGubun;
	private double iljiPage;
	private Date nurWrdt;
	private String nurWrid;
	private double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur1028() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="DATA_TRANS_USER_ID")
	public String getDataTransUserId() {
		return this.dataTransUserId;
	}

	public void setDataTransUserId(String dataTransUserId) {
		this.dataTransUserId = dataTransUserId;
	}


	@Column(name="DATA_TRANS_YN")
	public String getDataTransYn() {
		return this.dataTransYn;
	}

	public void setDataTransYn(String dataTransYn) {
		this.dataTransYn = dataTransYn;
	}


	public String getData1() {
		return this.data1;
	}

	public void setData1(String data1) {
		this.data1 = data1;
	}


	public String getData10() {
		return this.data10;
	}

	public void setData10(String data10) {
		this.data10 = data10;
	}


	public String getData11() {
		return this.data11;
	}

	public void setData11(String data11) {
		this.data11 = data11;
	}


	public String getData12() {
		return this.data12;
	}

	public void setData12(String data12) {
		this.data12 = data12;
	}


	public String getData13() {
		return this.data13;
	}

	public void setData13(String data13) {
		this.data13 = data13;
	}


	public String getData14() {
		return this.data14;
	}

	public void setData14(String data14) {
		this.data14 = data14;
	}


	public String getData146() {
		return this.data146;
	}

	public void setData146(String data146) {
		this.data146 = data146;
	}


	public String getData147() {
		return this.data147;
	}

	public void setData147(String data147) {
		this.data147 = data147;
	}


	public String getData148() {
		return this.data148;
	}

	public void setData148(String data148) {
		this.data148 = data148;
	}


	public String getData149() {
		return this.data149;
	}

	public void setData149(String data149) {
		this.data149 = data149;
	}


	public String getData15() {
		return this.data15;
	}

	public void setData15(String data15) {
		this.data15 = data15;
	}


	public String getData150() {
		return this.data150;
	}

	public void setData150(String data150) {
		this.data150 = data150;
	}


	public String getData16() {
		return this.data16;
	}

	public void setData16(String data16) {
		this.data16 = data16;
	}


	public String getData17() {
		return this.data17;
	}

	public void setData17(String data17) {
		this.data17 = data17;
	}


	public String getData18() {
		return this.data18;
	}

	public void setData18(String data18) {
		this.data18 = data18;
	}


	public String getData19() {
		return this.data19;
	}

	public void setData19(String data19) {
		this.data19 = data19;
	}


	public String getData2() {
		return this.data2;
	}

	public void setData2(String data2) {
		this.data2 = data2;
	}


	public String getData20() {
		return this.data20;
	}

	public void setData20(String data20) {
		this.data20 = data20;
	}


	public String getData3() {
		return this.data3;
	}

	public void setData3(String data3) {
		this.data3 = data3;
	}


	public String getData4() {
		return this.data4;
	}

	public void setData4(String data4) {
		this.data4 = data4;
	}


	public String getData5() {
		return this.data5;
	}

	public void setData5(String data5) {
		this.data5 = data5;
	}


	public String getData6() {
		return this.data6;
	}

	public void setData6(String data6) {
		this.data6 = data6;
	}


	public String getData7() {
		return this.data7;
	}

	public void setData7(String data7) {
		this.data7 = data7;
	}


	public String getData8() {
		return this.data8;
	}

	public void setData8(String data8) {
		this.data8 = data8;
	}


	public String getData9() {
		return this.data9;
	}

	public void setData9(String data9) {
		this.data9 = data9;
	}


	@Column(name="END_YN")
	public String getEndYn() {
		return this.endYn;
	}

	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}


	@Column(name="HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="ILJI_GUBUN")
	public String getIljiGubun() {
		return this.iljiGubun;
	}

	public void setIljiGubun(String iljiGubun) {
		this.iljiGubun = iljiGubun;
	}


	@Column(name="ILJI_PAGE")
	public double getIljiPage() {
		return this.iljiPage;
	}

	public void setIljiPage(double iljiPage) {
		this.iljiPage = iljiPage;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NUR_WRDT")
	public Date getNurWrdt() {
		return this.nurWrdt;
	}

	public void setNurWrdt(Date nurWrdt) {
		this.nurWrdt = nurWrdt;
	}


	@Column(name="NUR_WRID")
	public String getNurWrid() {
		return this.nurWrid;
	}

	public void setNurWrid(String nurWrid) {
		this.nurWrid = nurWrid;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
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