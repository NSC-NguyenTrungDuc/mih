package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class IncomeInformation {
    private String PerformDate;
    private String PerformEndDate;
    private String Inout;
    private String InvoiceNumber;
    private String InsuranceCombinationNumber;
    private String RateCd;
    private String DepartmentCode;
    private String DepartmentName;
    private CdInformation CdInformation;
    private AcPointInformation acPointInformation;

    @JacksonXmlProperty(localName = "Perform_Date")
    public String getPerformDate() {
        return PerformDate;
    }

    public void setPerformDate(String performDate) {
        PerformDate = performDate;
    }

    @JacksonXmlProperty(localName = "Perform_End_Date")
    public String getPerformEndDate() {
        return PerformEndDate;
    }

    public void setPerformEndDate(String performEndDate) {
        PerformEndDate = performEndDate;
    }

    @JacksonXmlProperty(localName = "InOut")
    public String getInout() {
        return Inout;
    }

    public void setInout(String inout) {
        Inout = inout;
    }

    @JacksonXmlProperty(localName = "Invoice_Number")
    public String getInvoiceNumber() {
        return InvoiceNumber;
    }

    public void setInvoiceNumber(String invoiceNumber) {
        InvoiceNumber = invoiceNumber;
    }

    @JacksonXmlProperty(localName = "Insurance_Combination_Number")
    public String getInsuranceCombinationNumber() {
        return InsuranceCombinationNumber;
    }

    public void setInsuranceCombinationNumber(String insuranceCombinationNumber) {
        InsuranceCombinationNumber = insuranceCombinationNumber;
    }

    @JacksonXmlProperty(localName = "Rate_Cd")
    public String getRateCd() {
        return RateCd;
    }

    public void setRateCd(String rateCd) {
        RateCd = rateCd;
    }

    @JacksonXmlProperty(localName = "Department_Code")
    public String getDepartmentCode() {
        return DepartmentCode;
    }

    public void setDepartmentCode(String departmentCode) {
        DepartmentCode = departmentCode;
    }

    @JacksonXmlProperty(localName = "Department_Name")
    public String getDepartmentName() {
        return DepartmentName;
    }

    public void setDepartmentName(String departmentName) {
        DepartmentName = departmentName;
    }

    @JacksonXmlProperty(localName = "Cd_Information")
    public CdInformation getCdInformation() {
        return CdInformation;
    }

    public void setCdInformation(CdInformation cdInformation) {
        CdInformation = cdInformation;
    }

    @JacksonXmlProperty(localName = "Ac_Point_Information")
    public AcPointInformation getAcPointInformation() {
        return acPointInformation;
    }

    public void setAcPointInformation(AcPointInformation acPointInformation) {
        this.acPointInformation = acPointInformation;
    }
}
