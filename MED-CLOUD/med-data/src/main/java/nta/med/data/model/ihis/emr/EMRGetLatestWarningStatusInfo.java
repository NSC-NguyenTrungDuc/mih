package nta.med.data.model.ihis.emr;

import java.util.Date;

/**
 * @author Tiepnm
 */
public class EMRGetLatestWarningStatusInfo {

    private Integer clisProtocolId;
    private String statusId;
    private String codeName;
    private Date updated;
    private String displayFlg;

    public EMRGetLatestWarningStatusInfo(Integer clisProtocolId, String statusId, String codeName, Date updated, String displayFlg) {

        this.clisProtocolId = clisProtocolId;
        this.statusId = statusId;
        this.codeName = codeName;
        this.updated = updated;
        this.displayFlg = displayFlg;
    }

    public Integer getClisProtocolId() {
        return clisProtocolId;
    }

    public void setClisProtocolId(Integer clisProtocolId) {
        this.clisProtocolId = clisProtocolId;
    }

    public String getStatusId() {
        return statusId;
    }

    public void setStatusId(String statusId) {
        this.statusId = statusId;
    }

    public String getCodeName() {
        return codeName;
    }

    public void setCodeName(String codeName) {
        this.codeName = codeName;
    }

    public Date getUpdated() {
        return updated;
    }

    public void setUpdated(Date updated) {
        this.updated = updated;
    }

    public String getDisplayFlg() {
        return displayFlg;
    }

    public void setDisplayFlg(String displayFlg) {
        this.displayFlg = displayFlg;
    }

}
