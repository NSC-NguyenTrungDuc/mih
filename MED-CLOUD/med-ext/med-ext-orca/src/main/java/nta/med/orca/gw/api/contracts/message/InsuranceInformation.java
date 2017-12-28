package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

import java.util.List;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class InsuranceInformation {
    private String insuranceCombinationNumber;
    private String insuranceProviderClass;
    private String insuranceProviderNumber;
    private String insuranceProviderWholeName ;
    private String healthInsuredPersonSymbol;
    private String healthInsuredPersonNumber;
    private List<PublicInsuranceInfo> publicInsuranceInformation;

    @JacksonXmlProperty(localName = "Insurance_Combination_Number")
    public String getInsuranceCombinationNumber() {
        return insuranceCombinationNumber;
    }

    public void setInsuranceCombinationNumber(String insuranceCombinationNumber) {
        this.insuranceCombinationNumber = insuranceCombinationNumber;
    }

    @JacksonXmlProperty(localName = "InsuranceProvider_Class")
    public String getInsuranceProviderClass() {
        return insuranceProviderClass;
    }

    public void setInsuranceProviderClass(String insuranceProviderClass) {
        this.insuranceProviderClass = insuranceProviderClass;
    }

    @JacksonXmlProperty(localName = "InsuranceProvider_Number")
    public String getInsuranceProviderNumber() {
        return insuranceProviderNumber;
    }

    public void setInsuranceProviderNumber(String insuranceProviderNumber) {
        this.insuranceProviderNumber = insuranceProviderNumber;
    }

    @JacksonXmlProperty(localName = "InsuranceProvider_WholeName")
    public String getInsuranceProviderWholeName() {
        return insuranceProviderWholeName;
    }

    public void setInsuranceProviderWholeName(String insuranceProviderWholeName) {
        this.insuranceProviderWholeName = insuranceProviderWholeName;
    }

    @JacksonXmlProperty(localName = "HealthInsuredPerson_Symbol")
    public String getHealthInsuredPersonSymbol() {
        return healthInsuredPersonSymbol;
    }

    public void setHealthInsuredPersonSymbol(String healthInsuredPersonSymbol) {
        this.healthInsuredPersonSymbol = healthInsuredPersonSymbol;
    }

    @JacksonXmlProperty(localName = "HealthInsuredPerson_Number")
    public String getHealthInsuredPersonNumber() {
        return healthInsuredPersonNumber;
    }

    public void setHealthInsuredPersonNumber(String healthInsuredPersonNumber) {
        this.healthInsuredPersonNumber = healthInsuredPersonNumber;
    }

    //TODO need to check again
    @JacksonXmlProperty(localName = "PublicInsurance_Information")
    public List<PublicInsuranceInfo> getPublicInsuranceInformation() {
        return publicInsuranceInformation;
    }

    public void setPublicInsuranceInformation(List<PublicInsuranceInfo> publicInsuranceInformation) {
        this.publicInsuranceInformation = publicInsuranceInformation;
    }
}
