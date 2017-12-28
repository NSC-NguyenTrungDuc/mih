package nta.med.orca.gw.api.contracts.service;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import nta.med.orca.gw.api.contracts.message.IncomeInformation;
import nta.med.orca.gw.api.contracts.message.InsuranceInformation;
import nta.med.orca.gw.api.contracts.message.PatientInformation;
import nta.med.orca.gw.api.contracts.message.UnpaidMoneyInformation;

import java.util.List;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class ShunouResponse {
    private String informationDate;
    private String informationTime;
    private String apiResult;
    private String apiResultMessage;
    private PatientInformation patientInformation;
    private String incomeInformationOverflow;
    private List<IncomeInformation> incomeInformation;
    private List<InsuranceInformation>  insuranceInformation;
    private String unpaidMoneyTotal;
    private String unpaidMoneyInformationOverflow;
    private List<UnpaidMoneyInformation> unpaidMoneyInformation;

    public ShunouResponse() {
    }

    @JacksonXmlProperty(localName = "Information_Date")
    public String getInformationDate() {
        return informationDate;
    }

    public void setInformationDate(String informationDate) {
        this.informationDate = informationDate;
    }

    @JacksonXmlProperty(localName = "Information_Time")
    public String getInformationTime() {
        return informationTime;
    }

    public void setInformationTime(String informationTime) {
        this.informationTime = informationTime;
    }

    @JacksonXmlProperty(localName = "Api_Result")
    public String getApiResult() {
        return apiResult;
    }

    public void setApiResult(String apiResult) {
        this.apiResult = apiResult;
    }

    @JacksonXmlProperty(localName = "Api_Result_Message")
    public String getApiResultMessage() {
        return apiResultMessage;
    }

    public void setApiResultMessage(String apiResultMessage) {
        this.apiResultMessage = apiResultMessage;
    }

    @JacksonXmlProperty(localName = "Patient_Information")
    public PatientInformation getPatientInformation() {
        return patientInformation;
    }

    public void setPatientInformation(PatientInformation patientInformation) {
        this.patientInformation = patientInformation;
    }

    @JacksonXmlProperty(localName = "Income_Information_Overflow")
    public String getIncomeInformationOverflow() {
        return incomeInformationOverflow;
    }

    public void setIncomeInformationOverflow(String incomeInformationOverflow) {
        this.incomeInformationOverflow = incomeInformationOverflow;
    }

    @JacksonXmlProperty(localName = "Income_Information")
    public List<IncomeInformation> getIncomeInformation() {
        return incomeInformation;
    }

    public void setIncomeInformation(List<IncomeInformation> incomeInformation) {
        this.incomeInformation = incomeInformation;
    }

    @JacksonXmlProperty(localName = "Insurance_Information")
    public List<InsuranceInformation> getInsuranceInformation() {
        return insuranceInformation;
    }

    public void setInsuranceInformation(List<InsuranceInformation> insuranceInformation) {
        this.insuranceInformation = insuranceInformation;
    }

    @JacksonXmlProperty(localName = "Unpaid_Money_Total")
    public String getUnpaidMoneyTotal() {
        return unpaidMoneyTotal;
    }

    public void setUnpaidMoneyTotal(String unpaidMoneyTotal) {
        this.unpaidMoneyTotal = unpaidMoneyTotal;
    }

    @JacksonXmlProperty(localName = "Unpaid_Money_Information_Overflow")
    public String getUnpaidMoneyInformationOverflow() {
        return unpaidMoneyInformationOverflow;
    }

    public void setUnpaidMoneyInformationOverflow(String unpaidMoneyInformationOverflow) {
        this.unpaidMoneyInformationOverflow = unpaidMoneyInformationOverflow;
    }

    @JacksonXmlProperty(localName = "Unpaid_Money_Information")
    public List<UnpaidMoneyInformation> getUnpaidMoneyInformation() {
        return unpaidMoneyInformation;
    }

    public void setUnpaidMoneyInformation(List<UnpaidMoneyInformation> unpaidMoneyInformation) {
        this.unpaidMoneyInformation = unpaidMoneyInformation;
    }
}
