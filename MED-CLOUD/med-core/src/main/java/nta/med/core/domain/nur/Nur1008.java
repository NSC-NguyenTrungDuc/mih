package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1008 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1008.findAll", query="SELECT n FROM Nur1008 n")
public class Nur1008 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String data0;
	private Date data0Date;
	private String data1;
	private Date data1Date;
	private String data2;
	private Date data2Date;
	private String data3;
	private Date data3Date;
	private String data4;
	private Date data4Date;
	private String data5;
	private Date data5Date;
	private String data6;
	private Date data6Date;
	private String data7;
	private Date data7Date;
	private String data8;
	private Date data8Date;
	private String data9;
	private Date data9Date;
	private double fkinp1001;
	private String hospCode;
	private String jundoJunlakGubun;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur1008() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="DATA_0")
	public String getData0() {
		return this.data0;
	}

	public void setData0(String data0) {
		this.data0 = data0;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DATA_0_DATE")
	public Date getData0Date() {
		return this.data0Date;
	}

	public void setData0Date(Date data0Date) {
		this.data0Date = data0Date;
	}


	@Column(name="DATA_1")
	public String getData1() {
		return this.data1;
	}

	public void setData1(String data1) {
		this.data1 = data1;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DATA_1_DATE")
	public Date getData1Date() {
		return this.data1Date;
	}

	public void setData1Date(Date data1Date) {
		this.data1Date = data1Date;
	}


	@Column(name="DATA_2")
	public String getData2() {
		return this.data2;
	}

	public void setData2(String data2) {
		this.data2 = data2;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DATA_2_DATE")
	public Date getData2Date() {
		return this.data2Date;
	}

	public void setData2Date(Date data2Date) {
		this.data2Date = data2Date;
	}


	@Column(name="DATA_3")
	public String getData3() {
		return this.data3;
	}

	public void setData3(String data3) {
		this.data3 = data3;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DATA_3_DATE")
	public Date getData3Date() {
		return this.data3Date;
	}

	public void setData3Date(Date data3Date) {
		this.data3Date = data3Date;
	}


	@Column(name="DATA_4")
	public String getData4() {
		return this.data4;
	}

	public void setData4(String data4) {
		this.data4 = data4;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DATA_4_DATE")
	public Date getData4Date() {
		return this.data4Date;
	}

	public void setData4Date(Date data4Date) {
		this.data4Date = data4Date;
	}


	@Column(name="DATA_5")
	public String getData5() {
		return this.data5;
	}

	public void setData5(String data5) {
		this.data5 = data5;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DATA_5_DATE")
	public Date getData5Date() {
		return this.data5Date;
	}

	public void setData5Date(Date data5Date) {
		this.data5Date = data5Date;
	}


	@Column(name="DATA_6")
	public String getData6() {
		return this.data6;
	}

	public void setData6(String data6) {
		this.data6 = data6;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DATA_6_DATE")
	public Date getData6Date() {
		return this.data6Date;
	}

	public void setData6Date(Date data6Date) {
		this.data6Date = data6Date;
	}


	@Column(name="DATA_7")
	public String getData7() {
		return this.data7;
	}

	public void setData7(String data7) {
		this.data7 = data7;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DATA_7_DATE")
	public Date getData7Date() {
		return this.data7Date;
	}

	public void setData7Date(Date data7Date) {
		this.data7Date = data7Date;
	}


	@Column(name="DATA_8")
	public String getData8() {
		return this.data8;
	}

	public void setData8(String data8) {
		this.data8 = data8;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DATA_8_DATE")
	public Date getData8Date() {
		return this.data8Date;
	}

	public void setData8Date(Date data8Date) {
		this.data8Date = data8Date;
	}


	@Column(name="DATA_9")
	public String getData9() {
		return this.data9;
	}

	public void setData9(String data9) {
		this.data9 = data9;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DATA_9_DATE")
	public Date getData9Date() {
		return this.data9Date;
	}

	public void setData9Date(Date data9Date) {
		this.data9Date = data9Date;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JUNDO_JUNLAK_GUBUN")
	public String getJundoJunlakGubun() {
		return this.jundoJunlakGubun;
	}

	public void setJundoJunlakGubun(String jundoJunlakGubun) {
		this.jundoJunlakGubun = jundoJunlakGubun;
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