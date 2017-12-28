package nta.mss.info;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;

public class VaccineReportInfo implements Serializable {
	
	private static final long serialVersionUID = 1962332264840417984L;
	
	private Integer vaccineId;
	private String date;
	private BigDecimal numberOfFinished;
	private BigInteger total;

	public VaccineReportInfo(Integer vaccineId, String date,
			BigDecimal numberOfFinished, BigInteger total) {
		super();
		this.vaccineId = vaccineId;
		this.date = date;
		this.numberOfFinished = numberOfFinished;
		this.total = total;
	}
		
	public Integer getVaccineId() {
		return vaccineId;
	}

	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
	}

	public String getDate() {
		return date;
	}

	public void setDate(String date) {
		this.date = date;
	}

	public BigDecimal getNumberOfFinished() {
		return numberOfFinished;
	}

	public void setNumberOfFinished(BigDecimal numberOfFinished) {
		this.numberOfFinished = numberOfFinished;
	}

	public BigInteger getTotal() {
		return total;
	}

	public void setTotal(BigInteger total) {
		this.total = total;
	}
			
	@Override
    public int hashCode() {  
        return 31 * vaccineId.hashCode() + date.hashCode();
    }
 
    //Compare vaccineId, injectedDate
    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null || !(obj instanceof VaccineReportInfo))
            return false;
        VaccineReportInfo vri = (VaccineReportInfo) obj;
        if (!vaccineId.equals(vri.getVaccineId()) || !date.equals(vri.getDate()))
            return false;
        return true;
    }
}
