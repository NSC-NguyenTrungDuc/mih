package nta.med.data.model.ihis.cpls;

public class CPL3020U00GetSpecimenInfoListItemInfo {
	private String gwaName;
	private String hoDongName;

	public CPL3020U00GetSpecimenInfoListItemInfo(String gwaName,
			String hoDongName) {
		super();
		this.gwaName = gwaName;
		this.hoDongName = hoDongName;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}

	public String getHoDongName() {
		return hoDongName;
	}

	public void setHoDongName(String hoDongName) {
		this.hoDongName = hoDongName;
	}

}
