package nta.med.orca.gw.api.contracts.service;

import com.fasterxml.jackson.annotation.JsonIgnore;
import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;

/**
 * @author dainguyen.
 */
public abstract class AbstractRequest {

    private OrcaEnvInfo orcaEnvInfo;

    public AbstractRequest() {
    }

    public AbstractRequest(OrcaEnvInfo orcaEnvInfo) {
        this.orcaEnvInfo = orcaEnvInfo;
    }

    @JsonIgnore
    public OrcaEnvInfo getOrcaEnvInfo() {
        return orcaEnvInfo;
    }

    public void setOrcaEnvInfo(OrcaEnvInfo orcaEnvInfo) {
        this.orcaEnvInfo = orcaEnvInfo;
    }

}
