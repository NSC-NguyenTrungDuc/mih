package nta.med.data.model.ihis.adma;

import java.math.BigInteger;

public class ADM201UGrdDicMasterListItemInfo {
	private String colId;
	private String colNm;
	private String colTp;
	private Double colLen;
	private Double colScal;
	private String cmmt;
	public ADM201UGrdDicMasterListItemInfo(String colId, String colNm,
			String colTp, Double colLen, Double colScal, String cmmt) {
		super();
		this.colId = colId;
		this.colNm = colNm;
		this.colTp = colTp;
		this.colLen = colLen;
		this.colScal = colScal;
		this.cmmt = cmmt;
	}
	public String getColId() {
		return colId;
	}
	public void setColId(String colId) {
		this.colId = colId;
	}
	public String getColNm() {
		return colNm;
	}
	public void setColNm(String colNm) {
		this.colNm = colNm;
	}
	public String getColTp() {
		return colTp;
	}
	public void setColTp(String colTp) {
		this.colTp = colTp;
	}
	public Double getColLen() {
		return colLen;
	}
	public void setColLen(Double colLen) {
		this.colLen = colLen;
	}
	public Double getColScal() {
		return colScal;
	}
	public void setColScal(Double colScal) {
		this.colScal = colScal;
	}
	public String getCmmt() {
		return cmmt;
	}
	public void setCmmt(String cmmt) {
		this.cmmt = cmmt;
	}
}
