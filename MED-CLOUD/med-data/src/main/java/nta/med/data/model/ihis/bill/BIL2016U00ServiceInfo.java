package nta.med.data.model.ihis.bill;

import java.math.BigDecimal;

/**
 * @author DEV-TiepNM
 */
public class BIL2016U00ServiceInfo {
    private String hangmogCode;
    private String hangmogName;
    private String codeName;
    private BigDecimal price1;
	private BigDecimal price2;
	private BigDecimal price3;

    public BIL2016U00ServiceInfo(String hangmogCode, String hangmogName, String codeName, BigDecimal price1,
			BigDecimal price2, BigDecimal price3) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.codeName = codeName;
		this.price1 = price1;
		this.price2 = price2;
		this.price3 = price3;
	}

	public String getHangmogCode() {
        return hangmogCode;
    }

    public void setHangmogCode(String hangmogCode) {
        this.hangmogCode = hangmogCode;
    }

    public String getHangmogName() {
        return hangmogName;
    }

    public void setHangmogName(String hangmogName) {
        this.hangmogName = hangmogName;
    }

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	public BigDecimal getPrice1() {
		return price1;
	}

	public void setPrice1(BigDecimal price1) {
		this.price1 = price1;
	}

	public BigDecimal getPrice2() {
		return price2;
	}

	public void setPrice2(BigDecimal price2) {
		this.price2 = price2;
	}

	public BigDecimal getPrice3() {
		return price3;
	}

	public void setPrice3(BigDecimal price3) {
		this.price3 = price3;
	}

}
