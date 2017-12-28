package nta.mss.info;

import java.util.List;
import nta.mss.model.VaccineModel;

public class VaccineReportAjaxRequest {

	private String fromDate;
	private String toDate;
	private List<VaccineModel> vaccineModelList;
	
	public String getFromDate() {
		return fromDate;
	}
	public void setFromDate(String fromDate) {
		this.fromDate = fromDate;
	}
	public String getToDate() {
		return toDate;
	}
	public void setToDate(String toDate) {
		this.toDate = toDate;
	}
	public List<VaccineModel> getVaccineModelList() {
		return vaccineModelList;
	}
	public void setVaccineModelList(List<VaccineModel> vaccineModelList) {
		this.vaccineModelList = vaccineModelList;
	}
	
	
}
