/**
 * 
 */
package nta.med.data.model.ihis.clis;

public class CLIS2015U04GetPatientListItemInfo {
	private Integer protocolPatientId;
	private String bunho;
	private String suname;
	private String suname2;

	public CLIS2015U04GetPatientListItemInfo(Integer protocolPatientId,
			String bunho, String suname, String suname2) {
		super();
		this.protocolPatientId = protocolPatientId;
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
	}

	public Integer getprotocolPatientId() {
		return protocolPatientId;
	}

	public void setprotocolPatientId(Integer protocolPatientId) {
		this.protocolPatientId = protocolPatientId;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getSuname2() {
		return suname2;
	}

	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}
}
