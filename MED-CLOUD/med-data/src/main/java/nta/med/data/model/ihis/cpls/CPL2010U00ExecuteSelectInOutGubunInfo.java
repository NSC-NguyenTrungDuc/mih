package nta.med.data.model.ihis.cpls;

public class CPL2010U00ExecuteSelectInOutGubunInfo {
     private String inOutGubun;
     private Double fkOcs;
	public CPL2010U00ExecuteSelectInOutGubunInfo(String inOutGubun, Double fkOcs) {
		super();
		this.inOutGubun = inOutGubun;
		this.fkOcs = fkOcs;
	}
	public String getInOutGubun() {
		return inOutGubun;
	}
	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}
	public Double getFkOcs() {
		return fkOcs;
	}
	public void setFkOcs(Double fkOcs) {
		this.fkOcs = fkOcs;
	}
     

}
