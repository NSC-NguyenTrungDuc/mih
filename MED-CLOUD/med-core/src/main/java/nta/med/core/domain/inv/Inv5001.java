package nta.med.core.domain.inv;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the INV5001 database table.
 * 
 */
@Entity
@Table(name="INV5001")
public class Inv5001 extends BaseEntity{
	private static final long serialVersionUID = 1L;
	private Double fkinv6001;
	private Double fkocsKey;
	private String hospCode;
	private String ioGubun;
	private BigDecimal ipchulAmt;
	private String ipchulBuseo;
	private Double ipchulDanga;
	private Date ipchulDate;
	private String ipchulGubun;
	private Double ipchulQty;
	private String ipchulType;
	private String jaeryoCode;
	private Double pkinv5001;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Inv5001() {
	}

	public Double getFkinv6001() {
		return this.fkinv6001;
	}

	public void setFkinv6001(Double fkinv6001) {
		this.fkinv6001 = fkinv6001;
	}


	@Column(name="FKOCS_KEY")
	public Double getFkocsKey() {
		return this.fkocsKey;
	}

	public void setFkocsKey(Double fkocsKey) {
		this.fkocsKey = fkocsKey;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IO_GUBUN")
	public String getIoGubun() {
		return this.ioGubun;
	}

	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}


	@Column(name="IPCHUL_AMT")
	public BigDecimal getIpchulAmt() {
		return this.ipchulAmt;
	}

	public void setIpchulAmt(BigDecimal ipchulAmt) {
		this.ipchulAmt = ipchulAmt;
	}


	@Column(name="IPCHUL_BUSEO")
	public String getIpchulBuseo() {
		return this.ipchulBuseo;
	}

	public void setIpchulBuseo(String ipchulBuseo) {
		this.ipchulBuseo = ipchulBuseo;
	}


	@Column(name="IPCHUL_DANGA")
	public Double getIpchulDanga() {
		return this.ipchulDanga;
	}

	public void setIpchulDanga(Double ipchulDanga) {
		this.ipchulDanga = ipchulDanga;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IPCHUL_DATE")
	public Date getIpchulDate() {
		return this.ipchulDate;
	}

	public void setIpchulDate(Date ipchulDate) {
		this.ipchulDate = ipchulDate;
	}


	@Column(name="IPCHUL_GUBUN")
	public String getIpchulGubun() {
		return this.ipchulGubun;
	}

	public void setIpchulGubun(String ipchulGubun) {
		this.ipchulGubun = ipchulGubun;
	}


	@Column(name="IPCHUL_QTY")
	public Double getIpchulQty() {
		return this.ipchulQty;
	}

	public void setIpchulQty(Double ipchulQty) {
		this.ipchulQty = ipchulQty;
	}


	@Column(name="IPCHUL_TYPE")
	public String getIpchulType() {
		return this.ipchulType;
	}

	public void setIpchulType(String ipchulType) {
		this.ipchulType = ipchulType;
	}


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}


	public Double getPkinv5001() {
		return this.pkinv5001;
	}

	public void setPkinv5001(Double pkinv5001) {
		this.pkinv5001 = pkinv5001;
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


	@Column(name="UPD_ID", length=10)
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}