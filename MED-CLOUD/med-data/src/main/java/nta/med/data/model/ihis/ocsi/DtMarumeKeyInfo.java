package nta.med.data.model.ihis.ocsi;

public class DtMarumeKeyInfo {

	private Double pkocs2003;
	private Double fkocs2005;

	public DtMarumeKeyInfo(Double pkocs2003, Double fkocs2005) {
		super();
		this.pkocs2003 = pkocs2003;
		this.fkocs2005 = fkocs2005;
	}

	public Double getPkocs2003() {
		return pkocs2003;
	}

	public void setPkocs2003(Double pkocs2003) {
		this.pkocs2003 = pkocs2003;
	}

	public Double getFkocs2005() {
		return fkocs2005;
	}

	public void setFkocs2005(Double fkocs2005) {
		this.fkocs2005 = fkocs2005;
	}

}
