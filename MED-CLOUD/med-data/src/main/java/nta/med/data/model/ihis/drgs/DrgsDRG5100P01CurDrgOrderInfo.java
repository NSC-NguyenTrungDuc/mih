package nta.med.data.model.ihis.drgs;

import java.math.BigInteger;
import java.sql.Timestamp;

public class DrgsDRG5100P01CurDrgOrderInfo {
	private String hospCode;
	private String bunho;
	private String name;
	private String nameKana;
	private String sex;
	private Timestamp birthDay;
	private String ioGubun;
	private String drgOrdGubun;
	private String ipToiwonGubun;
	private String dataGubun;
	private String hoDong;
	private String hoDongName;
	private String hoCode;
	private String hoCodeName;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private Timestamp jubsuDate;
	private Timestamp jojeDate;
	private Timestamp bogyongStartDate;
	private Double drgBunho;
	private BigInteger rpCnt;
	private BigInteger ordCmt;
	private BigInteger ordCmtCnt;
	private String drgRpNo;
	private String bogyongGubun;
	private String bogyongCode;
	private String bogyongSigiGubun;
	private String bogyongSigi;
	private String bogyongName;
	private String dv;
	private String dayDvGubun;
	private String dayDvCnt;
	private String drgCnt;
	private BigInteger drgSeq;
	private String drgCode;
	private String drgName;
	private String drgNameKana;
	private String drgGubun;
	private String drgType;
	private String danui;
	private String danuiName;
	private String dvTime;
	private Double suryang;
	private String unbalanceYn;
	private String pattern;
	private Double dv1;
	private Double dv2;
	private Double dv3;
	private Double dv4;
	private Double dv5;
	private Double dv6;
	private Double dv7;
	private Double dv8;
	private String powderYn;
	private String drgPackYn;
	private Double fkocs;
	private BigInteger drgCmt;
	private BigInteger drgCmtCnt;
	private Double fkdrg;
	public DrgsDRG5100P01CurDrgOrderInfo(String hospCode, String bunho,
			String name, String nameKana, String sex, Timestamp birthDay,
			String ioGubun, String drgOrdGubun, String ipToiwonGubun,
			String dataGubun, String hoDong, String hoDongName, String hoCode,
			String hoCodeName, String gwa, String gwaName, String doctor,
			String doctorName, Timestamp jubsuDate, Timestamp jojeDate,
			Timestamp bogyongStartDate, Double drgBunho, BigInteger rpCnt,
			BigInteger ordCmt, BigInteger ordCmtCnt, String drgRpNo,
			String bogyongGubun, String bogyongCode, String bogyongSigiGubun,
			String bogyongSigi, String bogyongName, String dv,
			String dayDvGubun, String dayDvCnt, String drgCnt,
			BigInteger drgSeq, String drgCode, String drgName,
			String drgNameKana, String drgGubun, String drgType, String danui,
			String danuiName, String dvTime, Double suryang,
			String unbalanceYn, String pattern, Double dv1, Double dv2,
			Double dv3, Double dv4, Double dv5, Double dv6, Double dv7,
			Double dv8, String powderYn, String drgPackYn, Double fkocs,
			BigInteger drgCmt, BigInteger drgCmtCnt, Double fkdrg) {
		super();
		this.hospCode = hospCode;
		this.bunho = bunho;
		this.name = name;
		this.nameKana = nameKana;
		this.sex = sex;
		this.birthDay = birthDay;
		this.ioGubun = ioGubun;
		this.drgOrdGubun = drgOrdGubun;
		this.ipToiwonGubun = ipToiwonGubun;
		this.dataGubun = dataGubun;
		this.hoDong = hoDong;
		this.hoDongName = hoDongName;
		this.hoCode = hoCode;
		this.hoCodeName = hoCodeName;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.jubsuDate = jubsuDate;
		this.jojeDate = jojeDate;
		this.bogyongStartDate = bogyongStartDate;
		this.drgBunho = drgBunho;
		this.rpCnt = rpCnt;
		this.ordCmt = ordCmt;
		this.ordCmtCnt = ordCmtCnt;
		this.drgRpNo = drgRpNo;
		this.bogyongGubun = bogyongGubun;
		this.bogyongCode = bogyongCode;
		this.bogyongSigiGubun = bogyongSigiGubun;
		this.bogyongSigi = bogyongSigi;
		this.bogyongName = bogyongName;
		this.dv = dv;
		this.dayDvGubun = dayDvGubun;
		this.dayDvCnt = dayDvCnt;
		this.drgCnt = drgCnt;
		this.drgSeq = drgSeq;
		this.drgCode = drgCode;
		this.drgName = drgName;
		this.drgNameKana = drgNameKana;
		this.drgGubun = drgGubun;
		this.drgType = drgType;
		this.danui = danui;
		this.danuiName = danuiName;
		this.dvTime = dvTime;
		this.suryang = suryang;
		this.unbalanceYn = unbalanceYn;
		this.pattern = pattern;
		this.dv1 = dv1;
		this.dv2 = dv2;
		this.dv3 = dv3;
		this.dv4 = dv4;
		this.dv5 = dv5;
		this.dv6 = dv6;
		this.dv7 = dv7;
		this.dv8 = dv8;
		this.powderYn = powderYn;
		this.drgPackYn = drgPackYn;
		this.fkocs = fkocs;
		this.drgCmt = drgCmt;
		this.drgCmtCnt = drgCmtCnt;
		this.fkdrg = fkdrg;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getNameKana() {
		return nameKana;
	}
	public void setNameKana(String nameKana) {
		this.nameKana = nameKana;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public Timestamp getBirthDay() {
		return birthDay;
	}
	public void setBirthDay(Timestamp birthDay) {
		this.birthDay = birthDay;
	}
	public String getIoGubun() {
		return ioGubun;
	}
	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}
	public String getDrgOrdGubun() {
		return drgOrdGubun;
	}
	public void setDrgOrdGubun(String drgOrdGubun) {
		this.drgOrdGubun = drgOrdGubun;
	}
	public String getIpToiwonGubun() {
		return ipToiwonGubun;
	}
	public void setIpToiwonGubun(String ipToiwonGubun) {
		this.ipToiwonGubun = ipToiwonGubun;
	}
	public String getDataGubun() {
		return dataGubun;
	}
	public void setDataGubun(String dataGubun) {
		this.dataGubun = dataGubun;
	}
	public String getHoDong() {
		return hoDong;
	}
	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}
	public String getHoDongName() {
		return hoDongName;
	}
	public void setHoDongName(String hoDongName) {
		this.hoDongName = hoDongName;
	}
	public String getHoCode() {
		return hoCode;
	}
	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}
	public String getHoCodeName() {
		return hoCodeName;
	}
	public void setHoCodeName(String hoCodeName) {
		this.hoCodeName = hoCodeName;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public Timestamp getJubsuDate() {
		return jubsuDate;
	}
	public void setJubsuDate(Timestamp jubsuDate) {
		this.jubsuDate = jubsuDate;
	}
	public Timestamp getJojeDate() {
		return jojeDate;
	}
	public void setJojeDate(Timestamp jojeDate) {
		this.jojeDate = jojeDate;
	}
	public Timestamp getBogyongStartDate() {
		return bogyongStartDate;
	}
	public void setBogyongStartDate(Timestamp bogyongStartDate) {
		this.bogyongStartDate = bogyongStartDate;
	}
	public Double getDrgBunho() {
		return drgBunho;
	}
	public void setDrgBunho(Double drgBunho) {
		this.drgBunho = drgBunho;
	}
	public BigInteger getRpCnt() {
		return rpCnt;
	}
	public void setRpCnt(BigInteger rpCnt) {
		this.rpCnt = rpCnt;
	}
	public BigInteger getOrdCmt() {
		return ordCmt;
	}
	public void setOrdCmt(BigInteger ordCmt) {
		this.ordCmt = ordCmt;
	}
	public BigInteger getOrdCmtCnt() {
		return ordCmtCnt;
	}
	public void setOrdCmtCnt(BigInteger ordCmtCnt) {
		this.ordCmtCnt = ordCmtCnt;
	}
	public String getDrgRpNo() {
		return drgRpNo;
	}
	public void setDrgRpNo(String drgRpNo) {
		this.drgRpNo = drgRpNo;
	}
	public String getBogyongGubun() {
		return bogyongGubun;
	}
	public void setBogyongGubun(String bogyongGubun) {
		this.bogyongGubun = bogyongGubun;
	}
	public String getBogyongCode() {
		return bogyongCode;
	}
	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}
	public String getBogyongSigiGubun() {
		return bogyongSigiGubun;
	}
	public void setBogyongSigiGubun(String bogyongSigiGubun) {
		this.bogyongSigiGubun = bogyongSigiGubun;
	}
	public String getBogyongSigi() {
		return bogyongSigi;
	}
	public void setBogyongSigi(String bogyongSigi) {
		this.bogyongSigi = bogyongSigi;
	}
	public String getBogyongName() {
		return bogyongName;
	}
	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}
	public String getDv() {
		return dv;
	}
	public void setDv(String dv) {
		this.dv = dv;
	}
	public String getDayDvGubun() {
		return dayDvGubun;
	}
	public void setDayDvGubun(String dayDvGubun) {
		this.dayDvGubun = dayDvGubun;
	}
	public String getDayDvCnt() {
		return dayDvCnt;
	}
	public void setDayDvCnt(String dayDvCnt) {
		this.dayDvCnt = dayDvCnt;
	}
	public String getDrgCnt() {
		return drgCnt;
	}
	public void setDrgCnt(String drgCnt) {
		this.drgCnt = drgCnt;
	}
	public BigInteger getDrgSeq() {
		return drgSeq;
	}
	public void setDrgSeq(BigInteger drgSeq) {
		this.drgSeq = drgSeq;
	}
	public String getDrgCode() {
		return drgCode;
	}
	public void setDrgCode(String drgCode) {
		this.drgCode = drgCode;
	}
	public String getDrgName() {
		return drgName;
	}
	public void setDrgName(String drgName) {
		this.drgName = drgName;
	}
	public String getDrgNameKana() {
		return drgNameKana;
	}
	public void setDrgNameKana(String drgNameKana) {
		this.drgNameKana = drgNameKana;
	}
	public String getDrgGubun() {
		return drgGubun;
	}
	public void setDrgGubun(String drgGubun) {
		this.drgGubun = drgGubun;
	}
	public String getDrgType() {
		return drgType;
	}
	public void setDrgType(String drgType) {
		this.drgType = drgType;
	}
	public String getDanui() {
		return danui;
	}
	public void setDanui(String danui) {
		this.danui = danui;
	}
	public String getDanuiName() {
		return danuiName;
	}
	public void setDanuiName(String danuiName) {
		this.danuiName = danuiName;
	}
	public String getDvTime() {
		return dvTime;
	}
	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}
	public Double getSuryang() {
		return suryang;
	}
	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}
	public String getUnbalanceYn() {
		return unbalanceYn;
	}
	public void setUnbalanceYn(String unbalanceYn) {
		this.unbalanceYn = unbalanceYn;
	}
	public String getPattern() {
		return pattern;
	}
	public void setPattern(String pattern) {
		this.pattern = pattern;
	}
	public Double getDv1() {
		return dv1;
	}
	public void setDv1(Double dv1) {
		this.dv1 = dv1;
	}
	public Double getDv2() {
		return dv2;
	}
	public void setDv2(Double dv2) {
		this.dv2 = dv2;
	}
	public Double getDv3() {
		return dv3;
	}
	public void setDv3(Double dv3) {
		this.dv3 = dv3;
	}
	public Double getDv4() {
		return dv4;
	}
	public void setDv4(Double dv4) {
		this.dv4 = dv4;
	}
	public Double getDv5() {
		return dv5;
	}
	public void setDv5(Double dv5) {
		this.dv5 = dv5;
	}
	public Double getDv6() {
		return dv6;
	}
	public void setDv6(Double dv6) {
		this.dv6 = dv6;
	}
	public Double getDv7() {
		return dv7;
	}
	public void setDv7(Double dv7) {
		this.dv7 = dv7;
	}
	public Double getDv8() {
		return dv8;
	}
	public void setDv8(Double dv8) {
		this.dv8 = dv8;
	}
	public String getPowderYn() {
		return powderYn;
	}
	public void setPowderYn(String powderYn) {
		this.powderYn = powderYn;
	}
	public String getDrgPackYn() {
		return drgPackYn;
	}
	public void setDrgPackYn(String drgPackYn) {
		this.drgPackYn = drgPackYn;
	}
	public Double getFkocs() {
		return fkocs;
	}
	public void setFkocs(Double fkocs) {
		this.fkocs = fkocs;
	}
	public BigInteger getDrgCmt() {
		return drgCmt;
	}
	public void setDrgCmt(BigInteger drgCmt) {
		this.drgCmt = drgCmt;
	}
	public BigInteger getDrgCmtCnt() {
		return drgCmtCnt;
	}
	public void setDrgCmtCnt(BigInteger drgCmtCnt) {
		this.drgCmtCnt = drgCmtCnt;
	}
	public Double getFkdrg() {
		return fkdrg;
	}
	public void setFkdrg(Double fkdrg) {
		this.fkdrg = fkdrg;
	}
	
}