package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class UnpaidMoneyInformation {
    private String performDate;
    private String inOut;
    private String invoiceNumber;
    private String unpaidMoney;

    @JacksonXmlProperty(localName = "Perform_Date")
    public String getPerformDate() {
        return performDate;
    }

    public void setPerformDate(String performDate) {
        this.performDate = performDate;
    }

    @JacksonXmlProperty(localName = "InOut")
    public String getInOut() {
        return inOut;
    }

    public void setInOut(String inOut) {
        this.inOut = inOut;
    }

    @JacksonXmlProperty(localName = "Invoice_Number")
    public String getInvoiceNumber() {
        return invoiceNumber;
    }

    public void setInvoiceNumber(String invoiceNumber) {
        this.invoiceNumber = invoiceNumber;
    }

    @JacksonXmlProperty(localName = "Unpaid_Money")
    public String getUnpaidMoney() {
        return unpaidMoney;
    }

    public void setUnpaidMoney(String unpaidMoney) {
        this.unpaidMoney = unpaidMoney;
    }
}
