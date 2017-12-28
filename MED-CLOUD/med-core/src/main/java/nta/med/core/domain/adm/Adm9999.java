package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM9999 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm9999.findAll", query="SELECT a FROM Adm9999 a")
public class Adm9999 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String barcode;
	private String chubangYn;
	private String commentJuCode;
	private String continueYn;
	private String cultureYn;
	private String danui;
	private String defaultResult;
	private String defaultYn;
	private String detailInfo;
	private String displayYn;
	private String emergency;
	private String groupGubun;
	private String gumsaName;
	private String gumsaNameRe;
	private String hangmogCode;
	private String hangmogMarkName;
	private String hospCode;
	private String jangbiCode;
	private String jangbiCode2;
	private String jangbiCode3;
	private String jangbiOutCode;
	private String jangbiOutCode2;
	private String jangbiOutCode3;
	private Date jukyongDate;
	private String jundalGubun;
	private String jundalGubunName;
	private String jundalGubunText;
	private String manySpecimenYn;
	private String medicalJundal;
	private String middleResult;
	private String ocsHangmog;
	private String oldSlipCode;
	private String outTube;
	private String outTube2;
	private double point;
	private double point2;
	private double point3;
	private String resultForm;
	private double resultLen;
	private String resultYn;
	private double serial;
	private double serial1;
	private String slipCode;
	private String spcialName;
	private String specialYn;
	private double specimenAmt;
	private String specimenAmtGubun;
	private String specimenCode;
	private double sugaAmt;
	private String sugaCode;
	private String sutakCode;
	private Date sysDate;
	private String sysId;
	private String systemGubun;
	private String tongGubun;
	private double tongSerial;
	private String tubeCode;
	private String uitakCode;
	private Date updDate;
	private String updId;
	private String userGubun;
	private String workLoad;

	public Adm9999() {
	}


	public String getBarcode() {
		return this.barcode;
	}

	public void setBarcode(String barcode) {
		this.barcode = barcode;
	}


	@Column(name="CHUBANG_YN")
	public String getChubangYn() {
		return this.chubangYn;
	}

	public void setChubangYn(String chubangYn) {
		this.chubangYn = chubangYn;
	}


	@Column(name="COMMENT_JU_CODE")
	public String getCommentJuCode() {
		return this.commentJuCode;
	}

	public void setCommentJuCode(String commentJuCode) {
		this.commentJuCode = commentJuCode;
	}


	@Column(name="CONTINUE_YN")
	public String getContinueYn() {
		return this.continueYn;
	}

	public void setContinueYn(String continueYn) {
		this.continueYn = continueYn;
	}


	@Column(name="CULTURE_YN")
	public String getCultureYn() {
		return this.cultureYn;
	}

	public void setCultureYn(String cultureYn) {
		this.cultureYn = cultureYn;
	}


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	@Column(name="DEFAULT_RESULT")
	public String getDefaultResult() {
		return this.defaultResult;
	}

	public void setDefaultResult(String defaultResult) {
		this.defaultResult = defaultResult;
	}


	@Column(name="DEFAULT_YN")
	public String getDefaultYn() {
		return this.defaultYn;
	}

	public void setDefaultYn(String defaultYn) {
		this.defaultYn = defaultYn;
	}


	@Column(name="DETAIL_INFO")
	public String getDetailInfo() {
		return this.detailInfo;
	}

	public void setDetailInfo(String detailInfo) {
		this.detailInfo = detailInfo;
	}


	@Column(name="DISPLAY_YN")
	public String getDisplayYn() {
		return this.displayYn;
	}

	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	@Column(name="GROUP_GUBUN")
	public String getGroupGubun() {
		return this.groupGubun;
	}

	public void setGroupGubun(String groupGubun) {
		this.groupGubun = groupGubun;
	}


	@Column(name="GUMSA_NAME")
	public String getGumsaName() {
		return this.gumsaName;
	}

	public void setGumsaName(String gumsaName) {
		this.gumsaName = gumsaName;
	}


	@Column(name="GUMSA_NAME_RE")
	public String getGumsaNameRe() {
		return this.gumsaNameRe;
	}

	public void setGumsaNameRe(String gumsaNameRe) {
		this.gumsaNameRe = gumsaNameRe;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HANGMOG_MARK_NAME")
	public String getHangmogMarkName() {
		return this.hangmogMarkName;
	}

	public void setHangmogMarkName(String hangmogMarkName) {
		this.hangmogMarkName = hangmogMarkName;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JANGBI_CODE")
	public String getJangbiCode() {
		return this.jangbiCode;
	}

	public void setJangbiCode(String jangbiCode) {
		this.jangbiCode = jangbiCode;
	}


	@Column(name="JANGBI_CODE2")
	public String getJangbiCode2() {
		return this.jangbiCode2;
	}

	public void setJangbiCode2(String jangbiCode2) {
		this.jangbiCode2 = jangbiCode2;
	}


	@Column(name="JANGBI_CODE3")
	public String getJangbiCode3() {
		return this.jangbiCode3;
	}

	public void setJangbiCode3(String jangbiCode3) {
		this.jangbiCode3 = jangbiCode3;
	}


	@Column(name="JANGBI_OUT_CODE")
	public String getJangbiOutCode() {
		return this.jangbiOutCode;
	}

	public void setJangbiOutCode(String jangbiOutCode) {
		this.jangbiOutCode = jangbiOutCode;
	}


	@Column(name="JANGBI_OUT_CODE2")
	public String getJangbiOutCode2() {
		return this.jangbiOutCode2;
	}

	public void setJangbiOutCode2(String jangbiOutCode2) {
		this.jangbiOutCode2 = jangbiOutCode2;
	}


	@Column(name="JANGBI_OUT_CODE3")
	public String getJangbiOutCode3() {
		return this.jangbiOutCode3;
	}

	public void setJangbiOutCode3(String jangbiOutCode3) {
		this.jangbiOutCode3 = jangbiOutCode3;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUKYONG_DATE")
	public Date getJukyongDate() {
		return this.jukyongDate;
	}

	public void setJukyongDate(Date jukyongDate) {
		this.jukyongDate = jukyongDate;
	}


	@Column(name="JUNDAL_GUBUN")
	public String getJundalGubun() {
		return this.jundalGubun;
	}

	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}


	@Column(name="JUNDAL_GUBUN_NAME")
	public String getJundalGubunName() {
		return this.jundalGubunName;
	}

	public void setJundalGubunName(String jundalGubunName) {
		this.jundalGubunName = jundalGubunName;
	}


	@Column(name="JUNDAL_GUBUN_TEXT")
	public String getJundalGubunText() {
		return this.jundalGubunText;
	}

	public void setJundalGubunText(String jundalGubunText) {
		this.jundalGubunText = jundalGubunText;
	}


	@Column(name="MANY_SPECIMEN_YN")
	public String getManySpecimenYn() {
		return this.manySpecimenYn;
	}

	public void setManySpecimenYn(String manySpecimenYn) {
		this.manySpecimenYn = manySpecimenYn;
	}


	@Column(name="MEDICAL_JUNDAL")
	public String getMedicalJundal() {
		return this.medicalJundal;
	}

	public void setMedicalJundal(String medicalJundal) {
		this.medicalJundal = medicalJundal;
	}


	@Column(name="MIDDLE_RESULT")
	public String getMiddleResult() {
		return this.middleResult;
	}

	public void setMiddleResult(String middleResult) {
		this.middleResult = middleResult;
	}


	@Column(name="OCS_HANGMOG")
	public String getOcsHangmog() {
		return this.ocsHangmog;
	}

	public void setOcsHangmog(String ocsHangmog) {
		this.ocsHangmog = ocsHangmog;
	}


	@Column(name="OLD_SLIP_CODE")
	public String getOldSlipCode() {
		return this.oldSlipCode;
	}

	public void setOldSlipCode(String oldSlipCode) {
		this.oldSlipCode = oldSlipCode;
	}


	@Column(name="OUT_TUBE")
	public String getOutTube() {
		return this.outTube;
	}

	public void setOutTube(String outTube) {
		this.outTube = outTube;
	}


	@Column(name="OUT_TUBE2")
	public String getOutTube2() {
		return this.outTube2;
	}

	public void setOutTube2(String outTube2) {
		this.outTube2 = outTube2;
	}


	public double getPoint() {
		return this.point;
	}

	public void setPoint(double point) {
		this.point = point;
	}


	public double getPoint2() {
		return this.point2;
	}

	public void setPoint2(double point2) {
		this.point2 = point2;
	}


	public double getPoint3() {
		return this.point3;
	}

	public void setPoint3(double point3) {
		this.point3 = point3;
	}


	@Column(name="RESULT_FORM")
	public String getResultForm() {
		return this.resultForm;
	}

	public void setResultForm(String resultForm) {
		this.resultForm = resultForm;
	}


	@Column(name="RESULT_LEN")
	public double getResultLen() {
		return this.resultLen;
	}

	public void setResultLen(double resultLen) {
		this.resultLen = resultLen;
	}


	@Column(name="RESULT_YN")
	public String getResultYn() {
		return this.resultYn;
	}

	public void setResultYn(String resultYn) {
		this.resultYn = resultYn;
	}


	public double getSerial() {
		return this.serial;
	}

	public void setSerial(double serial) {
		this.serial = serial;
	}


	@Column(name="SERIAL_1")
	public double getSerial1() {
		return this.serial1;
	}

	public void setSerial1(double serial1) {
		this.serial1 = serial1;
	}


	@Column(name="SLIP_CODE")
	public String getSlipCode() {
		return this.slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}


	@Column(name="SPCIAL_NAME")
	public String getSpcialName() {
		return this.spcialName;
	}

	public void setSpcialName(String spcialName) {
		this.spcialName = spcialName;
	}


	@Column(name="SPECIAL_YN")
	public String getSpecialYn() {
		return this.specialYn;
	}

	public void setSpecialYn(String specialYn) {
		this.specialYn = specialYn;
	}


	@Column(name="SPECIMEN_AMT")
	public double getSpecimenAmt() {
		return this.specimenAmt;
	}

	public void setSpecimenAmt(double specimenAmt) {
		this.specimenAmt = specimenAmt;
	}


	@Column(name="SPECIMEN_AMT_GUBUN")
	public String getSpecimenAmtGubun() {
		return this.specimenAmtGubun;
	}

	public void setSpecimenAmtGubun(String specimenAmtGubun) {
		this.specimenAmtGubun = specimenAmtGubun;
	}


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}


	@Column(name="SUGA_AMT")
	public double getSugaAmt() {
		return this.sugaAmt;
	}

	public void setSugaAmt(double sugaAmt) {
		this.sugaAmt = sugaAmt;
	}


	@Column(name="SUGA_CODE")
	public String getSugaCode() {
		return this.sugaCode;
	}

	public void setSugaCode(String sugaCode) {
		this.sugaCode = sugaCode;
	}


	@Column(name="SUTAK_CODE")
	public String getSutakCode() {
		return this.sutakCode;
	}

	public void setSutakCode(String sutakCode) {
		this.sutakCode = sutakCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Column(name="SYSTEM_GUBUN")
	public String getSystemGubun() {
		return this.systemGubun;
	}

	public void setSystemGubun(String systemGubun) {
		this.systemGubun = systemGubun;
	}


	@Column(name="TONG_GUBUN")
	public String getTongGubun() {
		return this.tongGubun;
	}

	public void setTongGubun(String tongGubun) {
		this.tongGubun = tongGubun;
	}


	@Column(name="TONG_SERIAL")
	public double getTongSerial() {
		return this.tongSerial;
	}

	public void setTongSerial(double tongSerial) {
		this.tongSerial = tongSerial;
	}


	@Column(name="TUBE_CODE")
	public String getTubeCode() {
		return this.tubeCode;
	}

	public void setTubeCode(String tubeCode) {
		this.tubeCode = tubeCode;
	}


	@Column(name="UITAK_CODE")
	public String getUitakCode() {
		return this.uitakCode;
	}

	public void setUitakCode(String uitakCode) {
		this.uitakCode = uitakCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}


	@Column(name="USER_GUBUN")
	public String getUserGubun() {
		return this.userGubun;
	}

	public void setUserGubun(String userGubun) {
		this.userGubun = userGubun;
	}


	@Column(name="WORK_LOAD")
	public String getWorkLoad() {
		return this.workLoad;
	}

	public void setWorkLoad(String workLoad) {
		this.workLoad = workLoad;
	}

}