package nta.med.data.model.ihis.cpls;

public class CPL3020U00SelectInOutGubunListItemInfo {
	private String inOutGubun;
	private Double fkocs;

	public CPL3020U00SelectInOutGubunListItemInfo(String inOutGubun,
			Double fkocs) {
		super();
		this.inOutGubun = inOutGubun;
		this.fkocs = fkocs;
	}

	public String getInOutGubun() {
		return inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}

	public Double getFkocs() {
		return fkocs;
	}

	public void setFkocs(Double fkocs) {
		this.fkocs = fkocs;
	}

}
