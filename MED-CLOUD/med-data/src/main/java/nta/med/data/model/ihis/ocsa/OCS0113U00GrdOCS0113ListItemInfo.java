package nta.med.data.model.ihis.ocsa;

import java.util.Date;

public class OCS0113U00GrdOCS0113ListItemInfo {
	private String hangmogCode;
	private Double seq;
	private String defaultYn;
	private String specimenCode;
	private String specimenName;
	private Date hangmogStatDate;
	private String rowState;

	public OCS0113U00GrdOCS0113ListItemInfo(String hangmogCode, Double seq,
			String defaultYn, String specimenCode, String specimenName,
			Date hangmogStatDate, String rowState) {
		super();
		this.hangmogCode = hangmogCode;
		this.seq = seq;
		this.defaultYn = defaultYn;
		this.specimenCode = specimenCode;
		this.specimenName = specimenName;
		this.hangmogStatDate = hangmogStatDate;
		this.rowState = rowState;
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

	public Date getHangmogStatDate() {
		return hangmogStatDate;
	}

	public void setHangmogStatDate(Date hangmogStatDate) {
		this.hangmogStatDate = hangmogStatDate;
	}

	public String getRowState() {
		return rowState;
	}

	public void setRowState(String rowState) {
		this.rowState = rowState;
	}

}
