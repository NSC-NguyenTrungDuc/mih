package nta.med.core.domain.res;

import nta.med.core.domain.BaseEntity;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the RES0102 database table.
 * 
 */
@Entity
@Table(name="RES0102")
public class Res0102 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String amClc1;
	private String amClc2;
	private String amClc3;
	private String amClc4;
	private String amClc5;
	private String amClc6;
	private String amClc7;
	private String amEndHhmm1;
	private String amEndHhmm2;
	private String amEndHhmm3;
	private String amEndHhmm4;
	private String amEndHhmm5;
	private String amEndHhmm6;
	private String amEndHhmm7;
	private String amGwaRoom1;
	private String amGwaRoom2;
	private String amGwaRoom3;
	private String amGwaRoom4;
	private String amGwaRoom5;
	private String amGwaRoom6;
	private String amGwaRoom7;
	private String amStartHhmm1;
	private String amStartHhmm2;
	private String amStartHhmm3;
	private String amStartHhmm4;
	private String amStartHhmm5;
	private String amStartHhmm6;
	private String amStartHhmm7;
	private double amTotCnt;
	private double avgTime;
	private double docResLimit;
	private String doctor;
	private Date endDate;
	private double etcResLimit;
	private String gwa;
	private String hospCode;
	private String jinryoBreakYn;
	private String pmClc1;
	private String pmClc2;
	private String pmClc3;
	private String pmClc4;
	private String pmClc5;
	private String pmClc6;
	private String pmClc7;
	private String pmEndHhmm1;
	private String pmEndHhmm2;
	private String pmEndHhmm3;
	private String pmEndHhmm4;
	private String pmEndHhmm5;
	private String pmEndHhmm6;
	private String pmEndHhmm7;
	private String pmGwaRoom1;
	private String pmGwaRoom2;
	private String pmGwaRoom3;
	private String pmGwaRoom4;
	private String pmGwaRoom5;
	private String pmGwaRoom6;
	private String pmGwaRoom7;
	private String pmStartHhmm1;
	private String pmStartHhmm2;
	private String pmStartHhmm3;
	private String pmStartHhmm4;
	private String pmStartHhmm5;
	private String pmStartHhmm6;
	private String pmStartHhmm7;
	private double pmTotCnt;
	private String resAmEndHhmm1;
	private String resAmEndHhmm2;
	private String resAmEndHhmm3;
	private String resAmEndHhmm4;
	private String resAmEndHhmm5;
	private String resAmEndHhmm6;
	private String resAmEndHhmm7;
	private String resAmStartHhmm1;
	private String resAmStartHhmm2;
	private String resAmStartHhmm3;
	private String resAmStartHhmm4;
	private String resAmStartHhmm5;
	private String resAmStartHhmm6;
	private String resAmStartHhmm7;
	private String resPmEndHhmm1;
	private String resPmEndHhmm2;
	private String resPmEndHhmm3;
	private String resPmEndHhmm4;
	private String resPmEndHhmm5;
	private String resPmEndHhmm6;
	private String resPmEndHhmm7;
	private String resPmStartHhmm1;
	private String resPmStartHhmm2;
	private String resPmStartHhmm3;
	private String resPmStartHhmm4;
	private String resPmStartHhmm5;
	private String resPmStartHhmm6;
	private String resPmStartHhmm7;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private Integer outHospResLimit;//OUT_HOSP_RES_LIMIT

	public Res0102() {
	}


	@Column(name="AM_CLC1")
	public String getAmClc1() {
		return this.amClc1;
	}

	public void setAmClc1(String amClc1) {
		this.amClc1 = amClc1;
	}


	@Column(name="AM_CLC2")
	public String getAmClc2() {
		return this.amClc2;
	}

	public void setAmClc2(String amClc2) {
		this.amClc2 = amClc2;
	}


	@Column(name="AM_CLC3")
	public String getAmClc3() {
		return this.amClc3;
	}

	public void setAmClc3(String amClc3) {
		this.amClc3 = amClc3;
	}


	@Column(name="AM_CLC4")
	public String getAmClc4() {
		return this.amClc4;
	}

	public void setAmClc4(String amClc4) {
		this.amClc4 = amClc4;
	}


	@Column(name="AM_CLC5")
	public String getAmClc5() {
		return this.amClc5;
	}

	public void setAmClc5(String amClc5) {
		this.amClc5 = amClc5;
	}


	@Column(name="AM_CLC6")
	public String getAmClc6() {
		return this.amClc6;
	}

	public void setAmClc6(String amClc6) {
		this.amClc6 = amClc6;
	}


	@Column(name="AM_CLC7")
	public String getAmClc7() {
		return this.amClc7;
	}

	public void setAmClc7(String amClc7) {
		this.amClc7 = amClc7;
	}


	@Column(name="AM_END_HHMM1")
	public String getAmEndHhmm1() {
		return this.amEndHhmm1;
	}

	public void setAmEndHhmm1(String amEndHhmm1) {
		this.amEndHhmm1 = amEndHhmm1;
	}


	@Column(name="AM_END_HHMM2")
	public String getAmEndHhmm2() {
		return this.amEndHhmm2;
	}

	public void setAmEndHhmm2(String amEndHhmm2) {
		this.amEndHhmm2 = amEndHhmm2;
	}


	@Column(name="AM_END_HHMM3")
	public String getAmEndHhmm3() {
		return this.amEndHhmm3;
	}

	public void setAmEndHhmm3(String amEndHhmm3) {
		this.amEndHhmm3 = amEndHhmm3;
	}


	@Column(name="AM_END_HHMM4")
	public String getAmEndHhmm4() {
		return this.amEndHhmm4;
	}

	public void setAmEndHhmm4(String amEndHhmm4) {
		this.amEndHhmm4 = amEndHhmm4;
	}


	@Column(name="AM_END_HHMM5")
	public String getAmEndHhmm5() {
		return this.amEndHhmm5;
	}

	public void setAmEndHhmm5(String amEndHhmm5) {
		this.amEndHhmm5 = amEndHhmm5;
	}


	@Column(name="AM_END_HHMM6")
	public String getAmEndHhmm6() {
		return this.amEndHhmm6;
	}

	public void setAmEndHhmm6(String amEndHhmm6) {
		this.amEndHhmm6 = amEndHhmm6;
	}


	@Column(name="AM_END_HHMM7")
	public String getAmEndHhmm7() {
		return this.amEndHhmm7;
	}

	public void setAmEndHhmm7(String amEndHhmm7) {
		this.amEndHhmm7 = amEndHhmm7;
	}


	@Column(name="AM_GWA_ROOM1")
	public String getAmGwaRoom1() {
		return this.amGwaRoom1;
	}

	public void setAmGwaRoom1(String amGwaRoom1) {
		this.amGwaRoom1 = amGwaRoom1;
	}


	@Column(name="AM_GWA_ROOM2")
	public String getAmGwaRoom2() {
		return this.amGwaRoom2;
	}

	public void setAmGwaRoom2(String amGwaRoom2) {
		this.amGwaRoom2 = amGwaRoom2;
	}


	@Column(name="AM_GWA_ROOM3")
	public String getAmGwaRoom3() {
		return this.amGwaRoom3;
	}

	public void setAmGwaRoom3(String amGwaRoom3) {
		this.amGwaRoom3 = amGwaRoom3;
	}


	@Column(name="AM_GWA_ROOM4")
	public String getAmGwaRoom4() {
		return this.amGwaRoom4;
	}

	public void setAmGwaRoom4(String amGwaRoom4) {
		this.amGwaRoom4 = amGwaRoom4;
	}


	@Column(name="AM_GWA_ROOM5")
	public String getAmGwaRoom5() {
		return this.amGwaRoom5;
	}

	public void setAmGwaRoom5(String amGwaRoom5) {
		this.amGwaRoom5 = amGwaRoom5;
	}


	@Column(name="AM_GWA_ROOM6")
	public String getAmGwaRoom6() {
		return this.amGwaRoom6;
	}

	public void setAmGwaRoom6(String amGwaRoom6) {
		this.amGwaRoom6 = amGwaRoom6;
	}


	@Column(name="AM_GWA_ROOM7")
	public String getAmGwaRoom7() {
		return this.amGwaRoom7;
	}

	public void setAmGwaRoom7(String amGwaRoom7) {
		this.amGwaRoom7 = amGwaRoom7;
	}


	@Column(name="AM_START_HHMM1")
	public String getAmStartHhmm1() {
		return this.amStartHhmm1;
	}

	public void setAmStartHhmm1(String amStartHhmm1) {
		this.amStartHhmm1 = amStartHhmm1;
	}


	@Column(name="AM_START_HHMM2")
	public String getAmStartHhmm2() {
		return this.amStartHhmm2;
	}

	public void setAmStartHhmm2(String amStartHhmm2) {
		this.amStartHhmm2 = amStartHhmm2;
	}


	@Column(name="AM_START_HHMM3")
	public String getAmStartHhmm3() {
		return this.amStartHhmm3;
	}

	public void setAmStartHhmm3(String amStartHhmm3) {
		this.amStartHhmm3 = amStartHhmm3;
	}


	@Column(name="AM_START_HHMM4")
	public String getAmStartHhmm4() {
		return this.amStartHhmm4;
	}

	public void setAmStartHhmm4(String amStartHhmm4) {
		this.amStartHhmm4 = amStartHhmm4;
	}


	@Column(name="AM_START_HHMM5")
	public String getAmStartHhmm5() {
		return this.amStartHhmm5;
	}

	public void setAmStartHhmm5(String amStartHhmm5) {
		this.amStartHhmm5 = amStartHhmm5;
	}


	@Column(name="AM_START_HHMM6")
	public String getAmStartHhmm6() {
		return this.amStartHhmm6;
	}

	public void setAmStartHhmm6(String amStartHhmm6) {
		this.amStartHhmm6 = amStartHhmm6;
	}


	@Column(name="AM_START_HHMM7")
	public String getAmStartHhmm7() {
		return this.amStartHhmm7;
	}

	public void setAmStartHhmm7(String amStartHhmm7) {
		this.amStartHhmm7 = amStartHhmm7;
	}


	@Column(name="AM_TOT_CNT")
	public double getAmTotCnt() {
		return this.amTotCnt;
	}

	public void setAmTotCnt(double amTotCnt) {
		this.amTotCnt = amTotCnt;
	}


	@Column(name="AVG_TIME")
	public double getAvgTime() {
		return this.avgTime;
	}

	public void setAvgTime(double avgTime) {
		this.avgTime = avgTime;
	}


	@Column(name="DOC_RES_LIMIT")
	public double getDocResLimit() {
		return this.docResLimit;
	}

	public void setDocResLimit(double docResLimit) {
		this.docResLimit = docResLimit;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="ETC_RES_LIMIT")
	public double getEtcResLimit() {
		return this.etcResLimit;
	}

	public void setEtcResLimit(double etcResLimit) {
		this.etcResLimit = etcResLimit;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JINRYO_BREAK_YN")
	public String getJinryoBreakYn() {
		return this.jinryoBreakYn;
	}

	public void setJinryoBreakYn(String jinryoBreakYn) {
		this.jinryoBreakYn = jinryoBreakYn;
	}


	@Column(name="PM_CLC1")
	public String getPmClc1() {
		return this.pmClc1;
	}

	public void setPmClc1(String pmClc1) {
		this.pmClc1 = pmClc1;
	}


	@Column(name="PM_CLC2")
	public String getPmClc2() {
		return this.pmClc2;
	}

	public void setPmClc2(String pmClc2) {
		this.pmClc2 = pmClc2;
	}


	@Column(name="PM_CLC3")
	public String getPmClc3() {
		return this.pmClc3;
	}

	public void setPmClc3(String pmClc3) {
		this.pmClc3 = pmClc3;
	}


	@Column(name="PM_CLC4")
	public String getPmClc4() {
		return this.pmClc4;
	}

	public void setPmClc4(String pmClc4) {
		this.pmClc4 = pmClc4;
	}


	@Column(name="PM_CLC5")
	public String getPmClc5() {
		return this.pmClc5;
	}

	public void setPmClc5(String pmClc5) {
		this.pmClc5 = pmClc5;
	}


	@Column(name="PM_CLC6")
	public String getPmClc6() {
		return this.pmClc6;
	}

	public void setPmClc6(String pmClc6) {
		this.pmClc6 = pmClc6;
	}


	@Column(name="PM_CLC7")
	public String getPmClc7() {
		return this.pmClc7;
	}

	public void setPmClc7(String pmClc7) {
		this.pmClc7 = pmClc7;
	}


	@Column(name="PM_END_HHMM1")
	public String getPmEndHhmm1() {
		return this.pmEndHhmm1;
	}

	public void setPmEndHhmm1(String pmEndHhmm1) {
		this.pmEndHhmm1 = pmEndHhmm1;
	}


	@Column(name="PM_END_HHMM2")
	public String getPmEndHhmm2() {
		return this.pmEndHhmm2;
	}

	public void setPmEndHhmm2(String pmEndHhmm2) {
		this.pmEndHhmm2 = pmEndHhmm2;
	}


	@Column(name="PM_END_HHMM3")
	public String getPmEndHhmm3() {
		return this.pmEndHhmm3;
	}

	public void setPmEndHhmm3(String pmEndHhmm3) {
		this.pmEndHhmm3 = pmEndHhmm3;
	}


	@Column(name="PM_END_HHMM4")
	public String getPmEndHhmm4() {
		return this.pmEndHhmm4;
	}

	public void setPmEndHhmm4(String pmEndHhmm4) {
		this.pmEndHhmm4 = pmEndHhmm4;
	}


	@Column(name="PM_END_HHMM5")
	public String getPmEndHhmm5() {
		return this.pmEndHhmm5;
	}

	public void setPmEndHhmm5(String pmEndHhmm5) {
		this.pmEndHhmm5 = pmEndHhmm5;
	}


	@Column(name="PM_END_HHMM6")
	public String getPmEndHhmm6() {
		return this.pmEndHhmm6;
	}

	public void setPmEndHhmm6(String pmEndHhmm6) {
		this.pmEndHhmm6 = pmEndHhmm6;
	}


	@Column(name="PM_END_HHMM7")
	public String getPmEndHhmm7() {
		return this.pmEndHhmm7;
	}

	public void setPmEndHhmm7(String pmEndHhmm7) {
		this.pmEndHhmm7 = pmEndHhmm7;
	}


	@Column(name="PM_GWA_ROOM1")
	public String getPmGwaRoom1() {
		return this.pmGwaRoom1;
	}

	public void setPmGwaRoom1(String pmGwaRoom1) {
		this.pmGwaRoom1 = pmGwaRoom1;
	}


	@Column(name="PM_GWA_ROOM2")
	public String getPmGwaRoom2() {
		return this.pmGwaRoom2;
	}

	public void setPmGwaRoom2(String pmGwaRoom2) {
		this.pmGwaRoom2 = pmGwaRoom2;
	}


	@Column(name="PM_GWA_ROOM3")
	public String getPmGwaRoom3() {
		return this.pmGwaRoom3;
	}

	public void setPmGwaRoom3(String pmGwaRoom3) {
		this.pmGwaRoom3 = pmGwaRoom3;
	}


	@Column(name="PM_GWA_ROOM4")
	public String getPmGwaRoom4() {
		return this.pmGwaRoom4;
	}

	public void setPmGwaRoom4(String pmGwaRoom4) {
		this.pmGwaRoom4 = pmGwaRoom4;
	}


	@Column(name="PM_GWA_ROOM5")
	public String getPmGwaRoom5() {
		return this.pmGwaRoom5;
	}

	public void setPmGwaRoom5(String pmGwaRoom5) {
		this.pmGwaRoom5 = pmGwaRoom5;
	}


	@Column(name="PM_GWA_ROOM6")
	public String getPmGwaRoom6() {
		return this.pmGwaRoom6;
	}

	public void setPmGwaRoom6(String pmGwaRoom6) {
		this.pmGwaRoom6 = pmGwaRoom6;
	}


	@Column(name="PM_GWA_ROOM7")
	public String getPmGwaRoom7() {
		return this.pmGwaRoom7;
	}

	public void setPmGwaRoom7(String pmGwaRoom7) {
		this.pmGwaRoom7 = pmGwaRoom7;
	}


	@Column(name="PM_START_HHMM1")
	public String getPmStartHhmm1() {
		return this.pmStartHhmm1;
	}

	public void setPmStartHhmm1(String pmStartHhmm1) {
		this.pmStartHhmm1 = pmStartHhmm1;
	}


	@Column(name="PM_START_HHMM2")
	public String getPmStartHhmm2() {
		return this.pmStartHhmm2;
	}

	public void setPmStartHhmm2(String pmStartHhmm2) {
		this.pmStartHhmm2 = pmStartHhmm2;
	}


	@Column(name="PM_START_HHMM3")
	public String getPmStartHhmm3() {
		return this.pmStartHhmm3;
	}

	public void setPmStartHhmm3(String pmStartHhmm3) {
		this.pmStartHhmm3 = pmStartHhmm3;
	}


	@Column(name="PM_START_HHMM4")
	public String getPmStartHhmm4() {
		return this.pmStartHhmm4;
	}

	public void setPmStartHhmm4(String pmStartHhmm4) {
		this.pmStartHhmm4 = pmStartHhmm4;
	}


	@Column(name="PM_START_HHMM5")
	public String getPmStartHhmm5() {
		return this.pmStartHhmm5;
	}

	public void setPmStartHhmm5(String pmStartHhmm5) {
		this.pmStartHhmm5 = pmStartHhmm5;
	}


	@Column(name="PM_START_HHMM6")
	public String getPmStartHhmm6() {
		return this.pmStartHhmm6;
	}

	public void setPmStartHhmm6(String pmStartHhmm6) {
		this.pmStartHhmm6 = pmStartHhmm6;
	}


	@Column(name="PM_START_HHMM7")
	public String getPmStartHhmm7() {
		return this.pmStartHhmm7;
	}

	public void setPmStartHhmm7(String pmStartHhmm7) {
		this.pmStartHhmm7 = pmStartHhmm7;
	}


	@Column(name="PM_TOT_CNT")
	public double getPmTotCnt() {
		return this.pmTotCnt;
	}

	public void setPmTotCnt(double pmTotCnt) {
		this.pmTotCnt = pmTotCnt;
	}


	@Column(name="RES_AM_END_HHMM1")
	public String getResAmEndHhmm1() {
		return this.resAmEndHhmm1;
	}

	public void setResAmEndHhmm1(String resAmEndHhmm1) {
		this.resAmEndHhmm1 = resAmEndHhmm1;
	}


	@Column(name="RES_AM_END_HHMM2")
	public String getResAmEndHhmm2() {
		return this.resAmEndHhmm2;
	}

	public void setResAmEndHhmm2(String resAmEndHhmm2) {
		this.resAmEndHhmm2 = resAmEndHhmm2;
	}


	@Column(name="RES_AM_END_HHMM3")
	public String getResAmEndHhmm3() {
		return this.resAmEndHhmm3;
	}

	public void setResAmEndHhmm3(String resAmEndHhmm3) {
		this.resAmEndHhmm3 = resAmEndHhmm3;
	}


	@Column(name="RES_AM_END_HHMM4")
	public String getResAmEndHhmm4() {
		return this.resAmEndHhmm4;
	}

	public void setResAmEndHhmm4(String resAmEndHhmm4) {
		this.resAmEndHhmm4 = resAmEndHhmm4;
	}


	@Column(name="RES_AM_END_HHMM5")
	public String getResAmEndHhmm5() {
		return this.resAmEndHhmm5;
	}

	public void setResAmEndHhmm5(String resAmEndHhmm5) {
		this.resAmEndHhmm5 = resAmEndHhmm5;
	}


	@Column(name="RES_AM_END_HHMM6")
	public String getResAmEndHhmm6() {
		return this.resAmEndHhmm6;
	}

	public void setResAmEndHhmm6(String resAmEndHhmm6) {
		this.resAmEndHhmm6 = resAmEndHhmm6;
	}


	@Column(name="RES_AM_END_HHMM7")
	public String getResAmEndHhmm7() {
		return this.resAmEndHhmm7;
	}

	public void setResAmEndHhmm7(String resAmEndHhmm7) {
		this.resAmEndHhmm7 = resAmEndHhmm7;
	}


	@Column(name="RES_AM_START_HHMM1")
	public String getResAmStartHhmm1() {
		return this.resAmStartHhmm1;
	}

	public void setResAmStartHhmm1(String resAmStartHhmm1) {
		this.resAmStartHhmm1 = resAmStartHhmm1;
	}


	@Column(name="RES_AM_START_HHMM2")
	public String getResAmStartHhmm2() {
		return this.resAmStartHhmm2;
	}

	public void setResAmStartHhmm2(String resAmStartHhmm2) {
		this.resAmStartHhmm2 = resAmStartHhmm2;
	}


	@Column(name="RES_AM_START_HHMM3")
	public String getResAmStartHhmm3() {
		return this.resAmStartHhmm3;
	}

	public void setResAmStartHhmm3(String resAmStartHhmm3) {
		this.resAmStartHhmm3 = resAmStartHhmm3;
	}


	@Column(name="RES_AM_START_HHMM4")
	public String getResAmStartHhmm4() {
		return this.resAmStartHhmm4;
	}

	public void setResAmStartHhmm4(String resAmStartHhmm4) {
		this.resAmStartHhmm4 = resAmStartHhmm4;
	}


	@Column(name="RES_AM_START_HHMM5")
	public String getResAmStartHhmm5() {
		return this.resAmStartHhmm5;
	}

	public void setResAmStartHhmm5(String resAmStartHhmm5) {
		this.resAmStartHhmm5 = resAmStartHhmm5;
	}


	@Column(name="RES_AM_START_HHMM6")
	public String getResAmStartHhmm6() {
		return this.resAmStartHhmm6;
	}

	public void setResAmStartHhmm6(String resAmStartHhmm6) {
		this.resAmStartHhmm6 = resAmStartHhmm6;
	}


	@Column(name="RES_AM_START_HHMM7")
	public String getResAmStartHhmm7() {
		return this.resAmStartHhmm7;
	}

	public void setResAmStartHhmm7(String resAmStartHhmm7) {
		this.resAmStartHhmm7 = resAmStartHhmm7;
	}


	@Column(name="RES_PM_END_HHMM1")
	public String getResPmEndHhmm1() {
		return this.resPmEndHhmm1;
	}

	public void setResPmEndHhmm1(String resPmEndHhmm1) {
		this.resPmEndHhmm1 = resPmEndHhmm1;
	}


	@Column(name="RES_PM_END_HHMM2")
	public String getResPmEndHhmm2() {
		return this.resPmEndHhmm2;
	}

	public void setResPmEndHhmm2(String resPmEndHhmm2) {
		this.resPmEndHhmm2 = resPmEndHhmm2;
	}


	@Column(name="RES_PM_END_HHMM3")
	public String getResPmEndHhmm3() {
		return this.resPmEndHhmm3;
	}

	public void setResPmEndHhmm3(String resPmEndHhmm3) {
		this.resPmEndHhmm3 = resPmEndHhmm3;
	}


	@Column(name="RES_PM_END_HHMM4")
	public String getResPmEndHhmm4() {
		return this.resPmEndHhmm4;
	}

	public void setResPmEndHhmm4(String resPmEndHhmm4) {
		this.resPmEndHhmm4 = resPmEndHhmm4;
	}


	@Column(name="RES_PM_END_HHMM5")
	public String getResPmEndHhmm5() {
		return this.resPmEndHhmm5;
	}

	public void setResPmEndHhmm5(String resPmEndHhmm5) {
		this.resPmEndHhmm5 = resPmEndHhmm5;
	}


	@Column(name="RES_PM_END_HHMM6")
	public String getResPmEndHhmm6() {
		return this.resPmEndHhmm6;
	}

	public void setResPmEndHhmm6(String resPmEndHhmm6) {
		this.resPmEndHhmm6 = resPmEndHhmm6;
	}


	@Column(name="RES_PM_END_HHMM7")
	public String getResPmEndHhmm7() {
		return this.resPmEndHhmm7;
	}

	public void setResPmEndHhmm7(String resPmEndHhmm7) {
		this.resPmEndHhmm7 = resPmEndHhmm7;
	}


	@Column(name="RES_PM_START_HHMM1")
	public String getResPmStartHhmm1() {
		return this.resPmStartHhmm1;
	}

	public void setResPmStartHhmm1(String resPmStartHhmm1) {
		this.resPmStartHhmm1 = resPmStartHhmm1;
	}


	@Column(name="RES_PM_START_HHMM2")
	public String getResPmStartHhmm2() {
		return this.resPmStartHhmm2;
	}

	public void setResPmStartHhmm2(String resPmStartHhmm2) {
		this.resPmStartHhmm2 = resPmStartHhmm2;
	}


	@Column(name="RES_PM_START_HHMM3")
	public String getResPmStartHhmm3() {
		return this.resPmStartHhmm3;
	}

	public void setResPmStartHhmm3(String resPmStartHhmm3) {
		this.resPmStartHhmm3 = resPmStartHhmm3;
	}


	@Column(name="RES_PM_START_HHMM4")
	public String getResPmStartHhmm4() {
		return this.resPmStartHhmm4;
	}

	public void setResPmStartHhmm4(String resPmStartHhmm4) {
		this.resPmStartHhmm4 = resPmStartHhmm4;
	}


	@Column(name="RES_PM_START_HHMM5")
	public String getResPmStartHhmm5() {
		return this.resPmStartHhmm5;
	}

	public void setResPmStartHhmm5(String resPmStartHhmm5) {
		this.resPmStartHhmm5 = resPmStartHhmm5;
	}


	@Column(name="RES_PM_START_HHMM6")
	public String getResPmStartHhmm6() {
		return this.resPmStartHhmm6;
	}

	public void setResPmStartHhmm6(String resPmStartHhmm6) {
		this.resPmStartHhmm6 = resPmStartHhmm6;
	}


	@Column(name="RES_PM_START_HHMM7")
	public String getResPmStartHhmm7() {
		return this.resPmStartHhmm7;
	}

	public void setResPmStartHhmm7(String resPmStartHhmm7) {
		this.resPmStartHhmm7 = resPmStartHhmm7;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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

	@Column(name="OUT_HOSP_RES_LIMIT")
	public Integer getOutHospResLimit() {
		return outHospResLimit;
	}


	public void setOutHospResLimit(Integer outHospResLimit) {
		this.outHospResLimit = outHospResLimit;
	}

}