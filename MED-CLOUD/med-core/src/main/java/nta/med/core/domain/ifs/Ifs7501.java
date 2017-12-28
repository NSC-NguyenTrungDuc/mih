package nta.med.core.domain.ifs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the IFS7501 database table.
 * 
 */
@Entity
@Table(name="IFS7501")
public class Ifs7501 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String addSik1;
	private String addSik2;
	private String addSik3;
	private String addSik4;
	private String addSik5;
	private String addSik6;
	private String bigo1;
	private String bigo2;
	private String birth;
	private String bloodType;
	private String bohumCode;
	private String bunho;
	private String bunryuiCode1;
	private String bunryuiCode2;
	private String busik1;
	private String busik2;
	private String busik3;
	private String busik4;
	private String busik5;
	private String busik6;
	private String changeSik1;
	private String changeSik2;
	private String changeSik3;
	private String changeSik4;
	private String changeSik5;
	private String changeSik6;
	private String complications;
	private String dataCreateTime;
	private String dataGubun;
	private String dongCode;
	private String drg;
	private Double fkinp1001;
	private Double fknut2011;
	private String floorCode;
	private String gasanSiksaYn;
	private String gubunCode;
	private String height;
	private String hoCode;
	private String hospCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifTime;
	private String jusikChange1;
	private String jusikChange2;
	private String jusikChange3;
	private String jusikChange4;
	private String jusikChange5;
	private String jusikChange6;
	private String jusikRyang1;
	private String jusikRyang2;
	private String jusikRyang3;
	private String jusikRyang4;
	private String jusikRyang5;
	private String jusikRyang6;
	private String jusik1;
	private String jusik2;
	private String jusik3;
	private String jusik4;
	private String jusik5;
	private String jusik6;
	private String kaigoDgreeCode;
	private String kiho;
	private String memo1;
	private String memo2;
	private String memo3;
	private String nameKana;
	private String nameKanji;
	private String nomimono1;
	private String nomimono2;
	private String nomimono3;
	private String nomimono4;
	private String nomimono5;
	private String nomimono6;
	private Double pkifs7501;
	private String sangCode;
	private String sex;
	private String sikjong1;
	private String sikjong2;
	private String sikjong3;
	private String sikjong4;
	private String sikjong5;
	private String sikjong6;
	private String siksaEndDate;
	private String siksaEndGubun;
	private String siksaStartDate;
	private String siksaStartGubun;
	private String stopSiksaCode;
	private String sup1;
	private String sup2;
	private String sup3;
	private String sup4;
	private String sup5;
	private String sup6;
	private String syozokuSisetsuCode;
	private Date sysDate;
	private String sysId;
	private String tantouiName;
	private String tongjiGubun;
	private Date updDate;
	private String updId;
	private String useSisetsuCode;
	private String weight;

	public Ifs7501() {
	}

	@Column(name = "ADD_SIK1")
	public String getAddSik1() {
		return this.addSik1;
	}

	public void setAddSik1(String addSik1) {
		this.addSik1 = addSik1;
	}

	@Column(name = "ADD_SIK2")
	public String getAddSik2() {
		return this.addSik2;
	}

	public void setAddSik2(String addSik2) {
		this.addSik2 = addSik2;
	}

	@Column(name = "ADD_SIK3")
	public String getAddSik3() {
		return this.addSik3;
	}

	public void setAddSik3(String addSik3) {
		this.addSik3 = addSik3;
	}

	@Column(name = "ADD_SIK4")
	public String getAddSik4() {
		return this.addSik4;
	}

	public void setAddSik4(String addSik4) {
		this.addSik4 = addSik4;
	}

	@Column(name = "ADD_SIK5")
	public String getAddSik5() {
		return this.addSik5;
	}

	public void setAddSik5(String addSik5) {
		this.addSik5 = addSik5;
	}

	@Column(name = "ADD_SIK6")
	public String getAddSik6() {
		return this.addSik6;
	}

	public void setAddSik6(String addSik6) {
		this.addSik6 = addSik6;
	}

	public String getBigo1() {
		return this.bigo1;
	}

	public void setBigo1(String bigo1) {
		this.bigo1 = bigo1;
	}

	public String getBigo2() {
		return this.bigo2;
	}

	public void setBigo2(String bigo2) {
		this.bigo2 = bigo2;
	}

	public String getBirth() {
		return this.birth;
	}

	public void setBirth(String birth) {
		this.birth = birth;
	}

	@Column(name = "BLOOD_TYPE")
	public String getBloodType() {
		return this.bloodType;
	}

	public void setBloodType(String bloodType) {
		this.bloodType = bloodType;
	}

	@Column(name = "BOHUM_CODE")
	public String getBohumCode() {
		return this.bohumCode;
	}

	public void setBohumCode(String bohumCode) {
		this.bohumCode = bohumCode;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "BUNRYUI_CODE1")
	public String getBunryuiCode1() {
		return this.bunryuiCode1;
	}

	public void setBunryuiCode1(String bunryuiCode1) {
		this.bunryuiCode1 = bunryuiCode1;
	}

	@Column(name = "BUNRYUI_CODE2")
	public String getBunryuiCode2() {
		return this.bunryuiCode2;
	}

	public void setBunryuiCode2(String bunryuiCode2) {
		this.bunryuiCode2 = bunryuiCode2;
	}

	public String getBusik1() {
		return this.busik1;
	}

	public void setBusik1(String busik1) {
		this.busik1 = busik1;
	}

	public String getBusik2() {
		return this.busik2;
	}

	public void setBusik2(String busik2) {
		this.busik2 = busik2;
	}

	public String getBusik3() {
		return this.busik3;
	}

	public void setBusik3(String busik3) {
		this.busik3 = busik3;
	}

	public String getBusik4() {
		return this.busik4;
	}

	public void setBusik4(String busik4) {
		this.busik4 = busik4;
	}

	public String getBusik5() {
		return this.busik5;
	}

	public void setBusik5(String busik5) {
		this.busik5 = busik5;
	}

	public String getBusik6() {
		return this.busik6;
	}

	public void setBusik6(String busik6) {
		this.busik6 = busik6;
	}

	@Column(name = "CHANGE_SIK1")
	public String getChangeSik1() {
		return this.changeSik1;
	}

	public void setChangeSik1(String changeSik1) {
		this.changeSik1 = changeSik1;
	}

	@Column(name = "CHANGE_SIK2")
	public String getChangeSik2() {
		return this.changeSik2;
	}

	public void setChangeSik2(String changeSik2) {
		this.changeSik2 = changeSik2;
	}

	@Column(name = "CHANGE_SIK3")
	public String getChangeSik3() {
		return this.changeSik3;
	}

	public void setChangeSik3(String changeSik3) {
		this.changeSik3 = changeSik3;
	}

	@Column(name = "CHANGE_SIK4")
	public String getChangeSik4() {
		return this.changeSik4;
	}

	public void setChangeSik4(String changeSik4) {
		this.changeSik4 = changeSik4;
	}

	@Column(name = "CHANGE_SIK5")
	public String getChangeSik5() {
		return this.changeSik5;
	}

	public void setChangeSik5(String changeSik5) {
		this.changeSik5 = changeSik5;
	}

	@Column(name = "CHANGE_SIK6")
	public String getChangeSik6() {
		return this.changeSik6;
	}

	public void setChangeSik6(String changeSik6) {
		this.changeSik6 = changeSik6;
	}

	public String getComplications() {
		return this.complications;
	}

	public void setComplications(String complications) {
		this.complications = complications;
	}

	@Column(name = "DATA_CREATE_TIME")
	public String getDataCreateTime() {
		return this.dataCreateTime;
	}

	public void setDataCreateTime(String dataCreateTime) {
		this.dataCreateTime = dataCreateTime;
	}

	@Column(name = "DATA_GUBUN")
	public String getDataGubun() {
		return this.dataGubun;
	}

	public void setDataGubun(String dataGubun) {
		this.dataGubun = dataGubun;
	}

	@Column(name = "DONG_CODE")
	public String getDongCode() {
		return this.dongCode;
	}

	public void setDongCode(String dongCode) {
		this.dongCode = dongCode;
	}

	public String getDrg() {
		return this.drg;
	}

	public void setDrg(String drg) {
		this.drg = drg;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Double getFknut2011() {
		return this.fknut2011;
	}

	public void setFknut2011(Double fknut2011) {
		this.fknut2011 = fknut2011;
	}

	@Column(name = "FLOOR_CODE")
	public String getFloorCode() {
		return this.floorCode;
	}

	public void setFloorCode(String floorCode) {
		this.floorCode = floorCode;
	}

	@Column(name = "GASAN_SIKSA_YN")
	public String getGasanSiksaYn() {
		return this.gasanSiksaYn;
	}

	public void setGasanSiksaYn(String gasanSiksaYn) {
		this.gasanSiksaYn = gasanSiksaYn;
	}

	@Column(name = "GUBUN_CODE")
	public String getGubunCode() {
		return this.gubunCode;
	}

	public void setGubunCode(String gubunCode) {
		this.gubunCode = gubunCode;
	}

	public String getHeight() {
		return this.height;
	}

	public void setHeight(String height) {
		this.height = height;
	}

	@Column(name = "HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "IF_DATE")
	public Date getIfDate() {
		return this.ifDate;
	}

	public void setIfDate(Date ifDate) {
		this.ifDate = ifDate;
	}

	@Column(name = "IF_ERR")
	public String getIfErr() {
		return this.ifErr;
	}

	public void setIfErr(String ifErr) {
		this.ifErr = ifErr;
	}

	@Column(name = "IF_FLAG")
	public String getIfFlag() {
		return this.ifFlag;
	}

	public void setIfFlag(String ifFlag) {
		this.ifFlag = ifFlag;
	}

	@Column(name = "IF_TIME")
	public String getIfTime() {
		return this.ifTime;
	}

	public void setIfTime(String ifTime) {
		this.ifTime = ifTime;
	}

	@Column(name = "JUSIK_CHANGE1")
	public String getJusikChange1() {
		return this.jusikChange1;
	}

	public void setJusikChange1(String jusikChange1) {
		this.jusikChange1 = jusikChange1;
	}

	@Column(name = "JUSIK_CHANGE2")
	public String getJusikChange2() {
		return this.jusikChange2;
	}

	public void setJusikChange2(String jusikChange2) {
		this.jusikChange2 = jusikChange2;
	}

	@Column(name = "JUSIK_CHANGE3")
	public String getJusikChange3() {
		return this.jusikChange3;
	}

	public void setJusikChange3(String jusikChange3) {
		this.jusikChange3 = jusikChange3;
	}

	@Column(name = "JUSIK_CHANGE4")
	public String getJusikChange4() {
		return this.jusikChange4;
	}

	public void setJusikChange4(String jusikChange4) {
		this.jusikChange4 = jusikChange4;
	}

	@Column(name = "JUSIK_CHANGE5")
	public String getJusikChange5() {
		return this.jusikChange5;
	}

	public void setJusikChange5(String jusikChange5) {
		this.jusikChange5 = jusikChange5;
	}

	@Column(name = "JUSIK_CHANGE6")
	public String getJusikChange6() {
		return this.jusikChange6;
	}

	public void setJusikChange6(String jusikChange6) {
		this.jusikChange6 = jusikChange6;
	}

	@Column(name = "JUSIK_RYANG1")
	public String getJusikRyang1() {
		return this.jusikRyang1;
	}

	public void setJusikRyang1(String jusikRyang1) {
		this.jusikRyang1 = jusikRyang1;
	}

	@Column(name = "JUSIK_RYANG2")
	public String getJusikRyang2() {
		return this.jusikRyang2;
	}

	public void setJusikRyang2(String jusikRyang2) {
		this.jusikRyang2 = jusikRyang2;
	}

	@Column(name = "JUSIK_RYANG3")
	public String getJusikRyang3() {
		return this.jusikRyang3;
	}

	public void setJusikRyang3(String jusikRyang3) {
		this.jusikRyang3 = jusikRyang3;
	}

	@Column(name = "JUSIK_RYANG4")
	public String getJusikRyang4() {
		return this.jusikRyang4;
	}

	public void setJusikRyang4(String jusikRyang4) {
		this.jusikRyang4 = jusikRyang4;
	}

	@Column(name = "JUSIK_RYANG5")
	public String getJusikRyang5() {
		return this.jusikRyang5;
	}

	public void setJusikRyang5(String jusikRyang5) {
		this.jusikRyang5 = jusikRyang5;
	}

	@Column(name = "JUSIK_RYANG6")
	public String getJusikRyang6() {
		return this.jusikRyang6;
	}

	public void setJusikRyang6(String jusikRyang6) {
		this.jusikRyang6 = jusikRyang6;
	}

	public String getJusik1() {
		return this.jusik1;
	}

	public void setJusik1(String jusik1) {
		this.jusik1 = jusik1;
	}

	public String getJusik2() {
		return this.jusik2;
	}

	public void setJusik2(String jusik2) {
		this.jusik2 = jusik2;
	}

	public String getJusik3() {
		return this.jusik3;
	}

	public void setJusik3(String jusik3) {
		this.jusik3 = jusik3;
	}

	public String getJusik4() {
		return this.jusik4;
	}

	public void setJusik4(String jusik4) {
		this.jusik4 = jusik4;
	}

	public String getJusik5() {
		return this.jusik5;
	}

	public void setJusik5(String jusik5) {
		this.jusik5 = jusik5;
	}

	public String getJusik6() {
		return this.jusik6;
	}

	public void setJusik6(String jusik6) {
		this.jusik6 = jusik6;
	}

	@Column(name = "KAIGO_DGREE_CODE")
	public String getKaigoDgreeCode() {
		return this.kaigoDgreeCode;
	}

	public void setKaigoDgreeCode(String kaigoDgreeCode) {
		this.kaigoDgreeCode = kaigoDgreeCode;
	}

	public String getKiho() {
		return this.kiho;
	}

	public void setKiho(String kiho) {
		this.kiho = kiho;
	}

	public String getMemo1() {
		return this.memo1;
	}

	public void setMemo1(String memo1) {
		this.memo1 = memo1;
	}

	public String getMemo2() {
		return this.memo2;
	}

	public void setMemo2(String memo2) {
		this.memo2 = memo2;
	}

	public String getMemo3() {
		return this.memo3;
	}

	public void setMemo3(String memo3) {
		this.memo3 = memo3;
	}

	@Column(name = "NAME_KANA")
	public String getNameKana() {
		return this.nameKana;
	}

	public void setNameKana(String nameKana) {
		this.nameKana = nameKana;
	}

	@Column(name = "NAME_KANJI")
	public String getNameKanji() {
		return this.nameKanji;
	}

	public void setNameKanji(String nameKanji) {
		this.nameKanji = nameKanji;
	}

	public String getNomimono1() {
		return this.nomimono1;
	}

	public void setNomimono1(String nomimono1) {
		this.nomimono1 = nomimono1;
	}

	public String getNomimono2() {
		return this.nomimono2;
	}

	public void setNomimono2(String nomimono2) {
		this.nomimono2 = nomimono2;
	}

	public String getNomimono3() {
		return this.nomimono3;
	}

	public void setNomimono3(String nomimono3) {
		this.nomimono3 = nomimono3;
	}

	public String getNomimono4() {
		return this.nomimono4;
	}

	public void setNomimono4(String nomimono4) {
		this.nomimono4 = nomimono4;
	}

	public String getNomimono5() {
		return this.nomimono5;
	}

	public void setNomimono5(String nomimono5) {
		this.nomimono5 = nomimono5;
	}

	public String getNomimono6() {
		return this.nomimono6;
	}

	public void setNomimono6(String nomimono6) {
		this.nomimono6 = nomimono6;
	}

	public Double getPkifs7501() {
		return this.pkifs7501;
	}

	public void setPkifs7501(Double pkifs7501) {
		this.pkifs7501 = pkifs7501;
	}

	@Column(name = "SANG_CODE")
	public String getSangCode() {
		return this.sangCode;
	}

	public void setSangCode(String sangCode) {
		this.sangCode = sangCode;
	}

	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getSikjong1() {
		return this.sikjong1;
	}

	public void setSikjong1(String sikjong1) {
		this.sikjong1 = sikjong1;
	}

	public String getSikjong2() {
		return this.sikjong2;
	}

	public void setSikjong2(String sikjong2) {
		this.sikjong2 = sikjong2;
	}

	public String getSikjong3() {
		return this.sikjong3;
	}

	public void setSikjong3(String sikjong3) {
		this.sikjong3 = sikjong3;
	}

	public String getSikjong4() {
		return this.sikjong4;
	}

	public void setSikjong4(String sikjong4) {
		this.sikjong4 = sikjong4;
	}

	public String getSikjong5() {
		return this.sikjong5;
	}

	public void setSikjong5(String sikjong5) {
		this.sikjong5 = sikjong5;
	}

	public String getSikjong6() {
		return this.sikjong6;
	}

	public void setSikjong6(String sikjong6) {
		this.sikjong6 = sikjong6;
	}

	@Column(name = "SIKSA_END_DATE")
	public String getSiksaEndDate() {
		return this.siksaEndDate;
	}

	public void setSiksaEndDate(String siksaEndDate) {
		this.siksaEndDate = siksaEndDate;
	}

	@Column(name = "SIKSA_END_GUBUN")
	public String getSiksaEndGubun() {
		return this.siksaEndGubun;
	}

	public void setSiksaEndGubun(String siksaEndGubun) {
		this.siksaEndGubun = siksaEndGubun;
	}

	@Column(name = "SIKSA_START_DATE")
	public String getSiksaStartDate() {
		return this.siksaStartDate;
	}

	public void setSiksaStartDate(String siksaStartDate) {
		this.siksaStartDate = siksaStartDate;
	}

	@Column(name = "SIKSA_START_GUBUN")
	public String getSiksaStartGubun() {
		return this.siksaStartGubun;
	}

	public void setSiksaStartGubun(String siksaStartGubun) {
		this.siksaStartGubun = siksaStartGubun;
	}

	@Column(name = "STOP_SIKSA_CODE")
	public String getStopSiksaCode() {
		return this.stopSiksaCode;
	}

	public void setStopSiksaCode(String stopSiksaCode) {
		this.stopSiksaCode = stopSiksaCode;
	}

	public String getSup1() {
		return this.sup1;
	}

	public void setSup1(String sup1) {
		this.sup1 = sup1;
	}

	public String getSup2() {
		return this.sup2;
	}

	public void setSup2(String sup2) {
		this.sup2 = sup2;
	}

	public String getSup3() {
		return this.sup3;
	}

	public void setSup3(String sup3) {
		this.sup3 = sup3;
	}

	public String getSup4() {
		return this.sup4;
	}

	public void setSup4(String sup4) {
		this.sup4 = sup4;
	}

	public String getSup5() {
		return this.sup5;
	}

	public void setSup5(String sup5) {
		this.sup5 = sup5;
	}

	public String getSup6() {
		return this.sup6;
	}

	public void setSup6(String sup6) {
		this.sup6 = sup6;
	}

	@Column(name = "SYOZOKU_SISETSU_CODE")
	public String getSyozokuSisetsuCode() {
		return this.syozokuSisetsuCode;
	}

	public void setSyozokuSisetsuCode(String syozokuSisetsuCode) {
		this.syozokuSisetsuCode = syozokuSisetsuCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "TANTOUI_NAME")
	public String getTantouiName() {
		return this.tantouiName;
	}

	public void setTantouiName(String tantouiName) {
		this.tantouiName = tantouiName;
	}

	@Column(name = "TONGJI_GUBUN")
	public String getTongjiGubun() {
		return this.tongjiGubun;
	}

	public void setTongjiGubun(String tongjiGubun) {
		this.tongjiGubun = tongjiGubun;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Column(name = "USE_SISETSU_CODE")
	public String getUseSisetsuCode() {
		return this.useSisetsuCode;
	}

	public void setUseSisetsuCode(String useSisetsuCode) {
		this.useSisetsuCode = useSisetsuCode;
	}

	public String getWeight() {
		return this.weight;
	}

	public void setWeight(String weight) {
		this.weight = weight;
	}

}