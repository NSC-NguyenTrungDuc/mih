package nta.med.data.model.ihis.drgs;

public class DrgsDRG5100P01LoadMakayJungboInfo {
	private String OMayakDoctor;
	private String OMayakLicense;
	private String OMayakAddress1;
	private String OMayakAddress2;
	public DrgsDRG5100P01LoadMakayJungboInfo(String oMayakDoctor,
			String oMayakLicense, String oMayakAddress1, String oMayakAddress2) {
		super();
		OMayakDoctor = oMayakDoctor;
		OMayakLicense = oMayakLicense;
		OMayakAddress1 = oMayakAddress1;
		OMayakAddress2 = oMayakAddress2;
	}
	public String getOMayakDoctor() {
		return OMayakDoctor;
	}
	public void setOMayakDoctor(String oMayakDoctor) {
		OMayakDoctor = oMayakDoctor;
	}
	public String getOMayakLicense() {
		return OMayakLicense;
	}
	public void setOMayakLicense(String oMayakLicense) {
		OMayakLicense = oMayakLicense;
	}
	public String getOMayakAddress1() {
		return OMayakAddress1;
	}
	public void setOMayakAddress1(String oMayakAddress1) {
		OMayakAddress1 = oMayakAddress1;
	}
	public String getOMayakAddress2() {
		return OMayakAddress2;
	}
	public void setOMayakAddress2(String oMayakAddress2) {
		OMayakAddress2 = oMayakAddress2;
	}
}
