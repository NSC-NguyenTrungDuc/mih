package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class CdInformation {
    private String acMoney;
    private String icMoney;
    private String aiMoney;
    private String oeMoney;
    private String dgSmoney;
    private String omSmoney;
    private String piSmoney;
    private String mlSmoney;
    private String lsiTotalMoney;
    private String disMoney;
    private String adMoney1;
    private String adMoney2;

    @JacksonXmlProperty(localName = "Ac_Money")
    public String getAcMoney() {
        return acMoney;
    }

    public void setAcMoney(String acMoney) {
        this.acMoney = acMoney;
    }

    @JacksonXmlProperty(localName = "Ic_Money")
    public String getIcMoney() {
        return icMoney;
    }

    public void setIcMoney(String icMoney) {
        this.icMoney = icMoney;
    }

    @JacksonXmlProperty(localName = "Ai_Money")
    public String getAiMoney() {
        return aiMoney;
    }

    public void setAiMoney(String aiMoney) {
        this.aiMoney = aiMoney;
    }

    @JacksonXmlProperty(localName = "Oe_Money")
    public String getOeMoney() {
        return oeMoney;
    }

    public void setOeMoney(String oeMoney) {
        this.oeMoney = oeMoney;
    }

    @JacksonXmlProperty(localName = "Dg_Smoney")
    public String getDgSmoney() {
        return dgSmoney;
    }

    public void setDgSmoney(String dgSmoney) {
        this.dgSmoney = dgSmoney;
    }

    @JacksonXmlProperty(localName = "Om_Smoney")
    public String getOmSmoney() {
        return omSmoney;
    }

    public void setOmSmoney(String omSmoney) {
        this.omSmoney = omSmoney;
    }

    @JacksonXmlProperty(localName = "Pi_Smoney")
    public String getPiSmoney() {
        return piSmoney;
    }

    public void setPiSmoney(String piSmoney) {
        this.piSmoney = piSmoney;
    }

    @JacksonXmlProperty(localName = "Ml_Smoney")
    public String getMlSmoney() {
        return mlSmoney;
    }

    public void setMlSmoney(String mlSmoney) {
        this.mlSmoney = mlSmoney;
    }

    @JacksonXmlProperty(localName = "Lsi_Total_Money")
    public String getLsiTotalMoney() {
        return lsiTotalMoney;
    }

    public void setLsiTotalMoney(String lsiTotalMoney) {
        this.lsiTotalMoney = lsiTotalMoney;
    }

    @JacksonXmlProperty(localName = "Dis_Money")
    public String getDisMoney() {
        return disMoney;
    }

    public void setDisMoney(String disMoney) {
        this.disMoney = disMoney;
    }

    @JacksonXmlProperty(localName = "Ad_Money1")
    public String getAdMoney1() {
        return adMoney1;
    }

    public void setAdMoney1(String adMoney1) {
        this.adMoney1 = adMoney1;
    }

    @JacksonXmlProperty(localName = "Ad_Money2")
    public String getAdMoney2() {
        return adMoney2;
    }

    public void setAdMoney2(String adMoney2) {
        this.adMoney2 = adMoney2;
    }
}
