package nta.med.data.model.ihis.emr;

public class OCS2015U00DosageInfo {
	private Double fkout1001;
	private String inputtabAndGroupser;
	private String bogyongName;
	
	public OCS2015U00DosageInfo(Double fkout1001, String inputtabAndGroupser, String bogyongName) {
		super();
		this.fkout1001 = fkout1001;
		this.inputtabAndGroupser = inputtabAndGroupser;
		this.bogyongName = bogyongName;
	}

	public Double getFkout1001() {
		return fkout1001;
	}

	public void setFkout1001(Double fkout1001) {
		this.fkout1001 = fkout1001;
	}

	public String getInputtabAndGroupser() {
		return inputtabAndGroupser;
	}

	public void setInputtabAndGroupser(String inputtabAndGroupser) {
		this.inputtabAndGroupser = inputtabAndGroupser;
	}

	public String getBogyongName() {
		return bogyongName;
	}

	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}

}