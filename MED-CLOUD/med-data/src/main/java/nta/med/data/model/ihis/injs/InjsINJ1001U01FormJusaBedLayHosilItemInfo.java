package nta.med.data.model.ihis.injs;

public class InjsINJ1001U01FormJusaBedLayHosilItemInfo {
	private String codeType;
	private String one;
	private String su;

	public InjsINJ1001U01FormJusaBedLayHosilItemInfo(String codeType,
			String one, String su) {
		super();
		this.codeType = codeType;
		this.one = one;
		this.su = su;
	}

	public String getCodeType() {
		return codeType;
	}

	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}

	public String getOne() {
		return one;
	}

	public void setOne(String one) {
		this.one = one;
	}

	public String getSu() {
		return su;
	}

	public void setSu(String su) {
		this.su = su;
	}

}
