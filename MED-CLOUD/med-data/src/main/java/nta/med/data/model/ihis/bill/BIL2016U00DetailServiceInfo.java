package nta.med.data.model.ihis.bill;

import java.math.BigDecimal;

/**
 * @author DEV-TiepNM
 */
public class BIL2016U00DetailServiceInfo {

    private String hangmogCode;
    private BigDecimal insurance_price;
    private BigDecimal servicePrice;
    private BigDecimal foreignerPrice;

    public BIL2016U00DetailServiceInfo(String hangmogCode, BigDecimal insurance_price, BigDecimal servicePrice, BigDecimal foreignerPrice) {
        this.hangmogCode = hangmogCode;
        this.insurance_price = insurance_price;
        this.servicePrice = servicePrice;
        this.foreignerPrice = foreignerPrice;
    }

    public String getHangmogCode() {
        return hangmogCode;
    }

    public void setHangmogCode(String hangmogCode) {
        this.hangmogCode = hangmogCode;
    }

    public BigDecimal getInsurance_price() {
        return insurance_price;
    }

    public void setInsurance_price(BigDecimal insurance_price) {
        this.insurance_price = insurance_price;
    }

    public BigDecimal getServicePrice() {
        return servicePrice;
    }

    public void setServicePrice(BigDecimal servicePrice) {
        this.servicePrice = servicePrice;
    }

    public BigDecimal getForeignerPrice() {
        return foreignerPrice;
    }

    public void setForeignerPrice(BigDecimal foreignerPrice) {
        this.foreignerPrice = foreignerPrice;
    }
}
