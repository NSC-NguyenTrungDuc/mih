package nta.med.data.model.ihis.adma;

import java.sql.Timestamp;

public class BAS0230U00GrdBAS0230Info {
	private String bunCode;
    private String bunName;
    private Timestamp bunYmd;
	public BAS0230U00GrdBAS0230Info(String bunCode, String bunName,
			Timestamp bunYmd) {
		super();
		this.bunCode = bunCode;
		this.bunName = bunName;
		this.bunYmd = bunYmd;
	}
	public String getBunCode() {
		return bunCode;
	}
	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}
	public String getBunName() {
		return bunName;
	}
	public void setBunName(String bunName) {
		this.bunName = bunName;
	}
	public Timestamp getBunYmd() {
		return bunYmd;
	}
	public void setBunYmd(Timestamp bunYmd) {
		this.bunYmd = bunYmd;
	}
}
