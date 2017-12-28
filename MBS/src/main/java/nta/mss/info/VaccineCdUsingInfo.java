package nta.mss.info;

import java.io.Serializable;
import java.math.BigInteger;
import java.sql.Timestamp;

public class VaccineCdUsingInfo implements Serializable {

	private static final long serialVersionUID = 5596896164072811814L;
	
	private String vaccineCd;
	private BigInteger injectedNo;
	private Timestamp injectedDate;
	
	public VaccineCdUsingInfo(String vaccineCd, BigInteger injectedNo,
			Timestamp injectedDate) {
		super();
		this.vaccineCd = vaccineCd;
		this.injectedNo = injectedNo;
		this.injectedDate = injectedDate;
	}
	
	public String getVaccineCd() {
		return vaccineCd;
	}
	public void setVaccineCd(String vaccineCd) {
		this.vaccineCd = vaccineCd;
	}
	public BigInteger getInjectedNo() {
		return injectedNo;
	}
	public void setInjectedNo(BigInteger injectedNo) {
		this.injectedNo = injectedNo;
	}
	public Timestamp getInjectedDate() {
		return injectedDate;
	}
	public void setInjectedDate(Timestamp injectedDate) {
		this.injectedDate = injectedDate;
	}

	@Override
	public String toString() {
		return "VaccineCdUsingInfo [vaccineCd=" + vaccineCd + ", injectedNo="
				+ injectedNo + ", injectedDate=" + injectedDate + "]";
	}
	
}