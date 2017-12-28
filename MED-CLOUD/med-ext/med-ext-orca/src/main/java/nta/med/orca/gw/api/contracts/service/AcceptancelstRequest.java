package nta.med.orca.gw.api.contracts.service;

import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;

public class AcceptancelstRequest extends AbstractRequest {

	private String acceptanceDate;

	private String reqClass;

	public AcceptancelstRequest() {
		super();
	}

	public AcceptancelstRequest(String acceptanceDate) {
		super();
		this.acceptanceDate = acceptanceDate;
	}

	public AcceptancelstRequest(String acceptanceDate, OrcaEnvInfo orcaEnvInfo) {
		super(orcaEnvInfo);
		this.acceptanceDate = acceptanceDate;
	}

	public String getAcceptanceDate() {
		return acceptanceDate;
	}

	public void setAcceptanceDate(String acceptanceDate) {
		this.acceptanceDate = acceptanceDate;
	}

	public String getReqClass() {
		return reqClass;
	}

	public void setReqClass(String reqClass) {
		this.reqClass = reqClass;
	}

}
