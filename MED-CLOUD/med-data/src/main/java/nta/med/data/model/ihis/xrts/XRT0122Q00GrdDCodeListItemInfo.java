package nta.med.data.model.ihis.xrts;

import java.io.Serializable;

public class XRT0122Q00GrdDCodeListItemInfo implements Serializable{
	private String bunryu;
	private String code;
	private String name;
	private Double seq;
	private String key;
	
	public XRT0122Q00GrdDCodeListItemInfo(String bunryu, String code,
			String name, Double seq, String key) {
		super();
		this.bunryu = bunryu;
		this.code = code;
		this.name = name;
		this.seq = seq;
		this.key = key;
	}
	public String getBunryu() {
		return bunryu;
	}
	public void setBunryu(String bunryu) {
		this.bunryu = bunryu;
	}
	public String getCode() {
		return code;
	}
	public void setCode(String code) {
		this.code = code;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	public String getKey() {
		return key;
	}
	public void setKey(String key) {
		this.key = key;
	}
	
}
