package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC2002 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc2002.findAll", query="SELECT d FROM Doc2002 d")
public class Doc2002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double fkdoc1001;
	private String imgExt1;
	private String imgExt2;
	private double imgLen1;
	private double imgLen2;
	private String imgPath1;
	private String imgPath2;
	private Date sysDate;
	private Date updDate;
	private String userId;

	public Doc2002() {
	}

	@Column(name="FKDOC1001")
	public double getFkdoc1001() {
		return this.fkdoc1001;
	}

	public void setFkdoc1001(double fkdoc1001) {
		this.fkdoc1001 = fkdoc1001;
	}


	@Column(name="IMG_EXT1")
	public String getImgExt1() {
		return this.imgExt1;
	}

	public void setImgExt1(String imgExt1) {
		this.imgExt1 = imgExt1;
	}


	@Column(name="IMG_EXT2")
	public String getImgExt2() {
		return this.imgExt2;
	}

	public void setImgExt2(String imgExt2) {
		this.imgExt2 = imgExt2;
	}


	@Column(name="IMG_LEN1")
	public double getImgLen1() {
		return this.imgLen1;
	}

	public void setImgLen1(double imgLen1) {
		this.imgLen1 = imgLen1;
	}


	@Column(name="IMG_LEN2")
	public double getImgLen2() {
		return this.imgLen2;
	}

	public void setImgLen2(double imgLen2) {
		this.imgLen2 = imgLen2;
	}


	@Column(name="IMG_PATH1")
	public String getImgPath1() {
		return this.imgPath1;
	}

	public void setImgPath1(String imgPath1) {
		this.imgPath1 = imgPath1;
	}


	@Column(name="IMG_PATH2")
	public String getImgPath2() {
		return this.imgPath2;
	}

	public void setImgPath2(String imgPath2) {
		this.imgPath2 = imgPath2;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}