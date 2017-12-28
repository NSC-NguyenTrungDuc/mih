package nta.med.orca.gw.service.system;

import java.util.List;

import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;

/**
 * @author dainguyen
 */
public interface SystemAdministrator {

	public OrcaEnvInfo findOrcaInfoByGigwanCode(String gigwanCode);

	public List<OrcaEnvInfo> getOrcaEnvInfo();
}
