package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1020Q00layNutInfo {

	private Date ymd;
	private String nutGubun;
	private String nutValue;
	private String nutValue2;
	private String sikGubun;
	private String sikJong;
	private String sikJusik;
	private String sikBusik;

	public NUR1020Q00layNutInfo(Date ymd, String nutGubun, String nutValue, String nutValue2, String sikGubun,
			String sikJong, String sikJusik, String sikBusik) {
		super();
		this.ymd = ymd;
		this.nutGubun = nutGubun;
		this.nutValue = nutValue;
		this.nutValue2 = nutValue2;
		this.sikGubun = sikGubun;
		this.sikJong = sikJong;
		this.sikJusik = sikJusik;
		this.sikBusik = sikBusik;
	}

	public Date getYmd() {
		return ymd;
	}

	public void setYmd(Date ymd) {
		this.ymd = ymd;
	}

	public String getNutGubun() {
		return nutGubun;
	}

	public void setNutGubun(String nutGubun) {
		this.nutGubun = nutGubun;
	}

	public String getNutValue() {
		return nutValue;
	}

	public void setNutValue(String nutValue) {
		this.nutValue = nutValue;
	}

	public String getNutValue2() {
		return nutValue2;
	}

	public void setNutValue2(String nutValue2) {
		this.nutValue2 = nutValue2;
	}

	public String getSikGubun() {
		return sikGubun;
	}

	public void setSikGubun(String sikGubun) {
		this.sikGubun = sikGubun;
	}

	public String getSikJong() {
		return sikJong;
	}

	public void setSikJong(String sikJong) {
		this.sikJong = sikJong;
	}

	public String getSikJusik() {
		return sikJusik;
	}

	public void setSikJusik(String sikJusik) {
		this.sikJusik = sikJusik;
	}

	public String getSikBusik() {
		return sikBusik;
	}

	public void setSikBusik(String sikBusik) {
		this.sikBusik = sikBusik;
	}

}
