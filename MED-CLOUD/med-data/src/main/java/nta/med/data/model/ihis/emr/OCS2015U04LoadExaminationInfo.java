package nta.med.data.model.ihis.emr;

import java.util.Date;

public class OCS2015U04LoadExaminationInfo {
    private Double pkout1001;
    private Date naewonDate;
    private String gwa;
	public OCS2015U04LoadExaminationInfo(Double pkout1001, Date naewonDate,
			String gwa) {
		super();
		this.pkout1001 = pkout1001;
		this.naewonDate = naewonDate;
		this.gwa = gwa;
	}
	public Double getPkout1001() {
		return pkout1001;
	}
	public void setPkout1001(Double pkout1001) {
		this.pkout1001 = pkout1001;
	}
	public Date getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
    
}
