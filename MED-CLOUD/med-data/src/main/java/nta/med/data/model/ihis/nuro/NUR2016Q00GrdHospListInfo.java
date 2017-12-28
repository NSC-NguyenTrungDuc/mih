package nta.med.data.model.ihis.nuro;

/**
 * @author DEV-TiepNM
 */
public class NUR2016Q00GrdHospListInfo {
    private String hospCode;
    private String yoyangName;
    private String kanaName;
    private String address;
    private String tel;


    public NUR2016Q00GrdHospListInfo(String hospCode, String yoyangName, String kanaName, String address, String tel) {
        this.hospCode = hospCode;
        this.yoyangName = yoyangName;
        this.kanaName = kanaName;
        this.address = address;
        this.tel = tel;
    }

    public String getHospCode() {
        return hospCode;
    }

    public void setHospCode(String hospCode) {
        this.hospCode = hospCode;
    }

    public String getYoyangName() {
        return yoyangName;
    }

    public void setYoyangName(String yoyangName) {
        this.yoyangName = yoyangName;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getTel() {
        return tel;
    }

    public void setTel(String tel) {
        this.tel = tel;
    }

	public String getKanaName() {
		return kanaName;
	}

	public void setKanaName(String kanaName) {
		this.kanaName = kanaName;
	}
}
