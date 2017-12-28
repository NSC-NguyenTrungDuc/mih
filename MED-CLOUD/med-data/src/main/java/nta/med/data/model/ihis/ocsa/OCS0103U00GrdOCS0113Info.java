package nta.med.data.model.ihis.ocsa;

import java.util.Date;

public class OCS0103U00GrdOCS0113Info {
	private String hangmogCode          ;
	private Double seq                   ;
	private String defaultYn            ;
	private String specimenCode         ;
	private String specimenName         ;
	private String hospCode             ;
	private Date hangmogStartDate    ;
	public OCS0103U00GrdOCS0113Info(String hangmogCode, Double seq,
			String defaultYn, String specimenCode, String specimenName,
			String hospCode, Date hangmogStartDate) {
		super();
		this.hangmogCode = hangmogCode;
		this.seq = seq;
		this.defaultYn = defaultYn;
		this.specimenCode = specimenCode;
		this.specimenName = specimenName;
		this.hospCode = hospCode;
		this.hangmogStartDate = hangmogStartDate;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	public String getDefaultYn() {
		return defaultYn;
	}
	public void setDefaultYn(String defaultYn) {
		this.defaultYn = defaultYn;
	}
	public String getSpecimenCode() {
		return specimenCode;
	}
	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}
	public String getSpecimenName() {
		return specimenName;
	}
	public void setSpecimenName(String specimenName) {
		this.specimenName = specimenName;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public Date getHangmogStartDate() {
		return hangmogStartDate;
	}
	public void setHangmogStartDate(Date hangmogStartDate) {
		this.hangmogStartDate = hangmogStartDate;
	}
	

}
