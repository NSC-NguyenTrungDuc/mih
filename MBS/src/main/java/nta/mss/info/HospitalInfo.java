package nta.mss.info;

import java.util.List;

import nta.mss.model.DepartmentModel;
import nta.mss.model.HospitalModel;

/**
 * The Class HospitalInfo. 
 *
 * @author MinhLS
 * @crtDate Aug 29, 2014
 */
public class HospitalInfo {
	private HospitalModel hospital;
	private List<DepartmentModel> internalDepts;
	private List<DepartmentModel> surgeryDepts;
	private List<DepartmentModel> vaccineDepts;
	private List<DepartmentModel> newBorns;
	
	public HospitalModel getHospital() {
		return hospital;
	}
	public void setHospital(HospitalModel hospital) {
		this.hospital = hospital;
	}
	public List<DepartmentModel> getInternalDepts() {
		return internalDepts;
	}
	public void setInternalDepts(List<DepartmentModel> internalDepts) {
		this.internalDepts = internalDepts;
	}
	public List<DepartmentModel> getSurgeryDepts() {
		return surgeryDepts;
	}
	public void setSurgeryDepts(List<DepartmentModel> surgeryDepts) {
		this.surgeryDepts = surgeryDepts;
	}
	public List<DepartmentModel> getVaccineDepts() {
		return vaccineDepts;
	}
	public void setVaccineDepts(List<DepartmentModel> vaccineDepts) {
		this.vaccineDepts = vaccineDepts;
	}
	public List<DepartmentModel> getNewBorns() {
		return newBorns;
	}
	public void setNewBorns(List<DepartmentModel> newBorns) {
		this.newBorns = newBorns;
	}
	
}
