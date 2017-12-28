package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS8002 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs8002.findAll", query="SELECT i FROM Ifs8002 i")
public class Ifs8002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String buFlag;
	private String byousituCode;
	private String byoutouCode;
	private String complications;
	private String consultComment;
	private String dataKubun;
	private double fkOcsIrai;
	private String frequency;
	private String genbyoureki;
	private String hospCode;
	private double iSeq;
	private String infectious;
	private String ioKubun;
	private String iraiDate;
	private String iraiKubun;
	private String kaisibi;
	private String kanjaNo;
	private String kioureki;
	private String kyuseizouakubi;
	private double nissuu;
	private String nyuuinnbi;
	private String objective;
	private String otFlag;
	private String ot1;
	private String ot10;
	private String ot2;
	private String ot3;
	private String ot4;
	private String ot5;
	private String ot6;
	private String ot7;
	private String ot8;
	private String ot9;
	private double pkIfsIrai;
	private String ptFlag;
	private String pt1;
	private String pt10;
	private String pt2;
	private String pt3;
	private String pt4;
	private String pt5;
	private String pt6;
	private String pt7;
	private String pt8;
	private String pt9;
	private String reha1;
	private String reha2;
	private String reha3;
	private String reha4;
	private String reha5;
	private String remark;
	private String sindanisi;
	private String sinryouka;
	private String stFlag;
	private String st1;
	private String st10;
	private String st2;
	private String st3;
	private String st4;
	private String st5;
	private String st6;
	private String st7;
	private String st8;
	private String st9;
	private String stopKijyun;
	private String su1;
	private String su21;
	private String su22;
	private String su23;
	private String su24;
	private String su31;
	private String su32;
	private String su41;
	private String su42;
	private String su43;
	private String syoriFlag;
	private Date sysDate;
	private String syujyutubi;
	private String taboo;
	private String tantoui;
	private Date updDate;
	private String userId;

	public Ifs8002() {
	}


	@Column(name="BU_FLAG")
	public String getBuFlag() {
		return this.buFlag;
	}

	public void setBuFlag(String buFlag) {
		this.buFlag = buFlag;
	}


	@Column(name="BYOUSITU_CODE")
	public String getByousituCode() {
		return this.byousituCode;
	}

	public void setByousituCode(String byousituCode) {
		this.byousituCode = byousituCode;
	}


	@Column(name="BYOUTOU_CODE")
	public String getByoutouCode() {
		return this.byoutouCode;
	}

	public void setByoutouCode(String byoutouCode) {
		this.byoutouCode = byoutouCode;
	}


	public String getComplications() {
		return this.complications;
	}

	public void setComplications(String complications) {
		this.complications = complications;
	}


	@Column(name="CONSULT_COMMENT")
	public String getConsultComment() {
		return this.consultComment;
	}

	public void setConsultComment(String consultComment) {
		this.consultComment = consultComment;
	}


	@Column(name="DATA_KUBUN")
	public String getDataKubun() {
		return this.dataKubun;
	}

	public void setDataKubun(String dataKubun) {
		this.dataKubun = dataKubun;
	}


	@Column(name="FK_OCS_IRAI")
	public double getFkOcsIrai() {
		return this.fkOcsIrai;
	}

	public void setFkOcsIrai(double fkOcsIrai) {
		this.fkOcsIrai = fkOcsIrai;
	}


	public String getFrequency() {
		return this.frequency;
	}

	public void setFrequency(String frequency) {
		this.frequency = frequency;
	}


	public String getGenbyoureki() {
		return this.genbyoureki;
	}

	public void setGenbyoureki(String genbyoureki) {
		this.genbyoureki = genbyoureki;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="I_SEQ")
	public double getISeq() {
		return this.iSeq;
	}

	public void setISeq(double iSeq) {
		this.iSeq = iSeq;
	}


	public String getInfectious() {
		return this.infectious;
	}

	public void setInfectious(String infectious) {
		this.infectious = infectious;
	}


	@Column(name="IO_KUBUN")
	public String getIoKubun() {
		return this.ioKubun;
	}

	public void setIoKubun(String ioKubun) {
		this.ioKubun = ioKubun;
	}


	@Column(name="IRAI_DATE")
	public String getIraiDate() {
		return this.iraiDate;
	}

	public void setIraiDate(String iraiDate) {
		this.iraiDate = iraiDate;
	}


	@Column(name="IRAI_KUBUN")
	public String getIraiKubun() {
		return this.iraiKubun;
	}

	public void setIraiKubun(String iraiKubun) {
		this.iraiKubun = iraiKubun;
	}


	public String getKaisibi() {
		return this.kaisibi;
	}

	public void setKaisibi(String kaisibi) {
		this.kaisibi = kaisibi;
	}


	@Column(name="KANJA_NO")
	public String getKanjaNo() {
		return this.kanjaNo;
	}

	public void setKanjaNo(String kanjaNo) {
		this.kanjaNo = kanjaNo;
	}


	public String getKioureki() {
		return this.kioureki;
	}

	public void setKioureki(String kioureki) {
		this.kioureki = kioureki;
	}


	public String getKyuseizouakubi() {
		return this.kyuseizouakubi;
	}

	public void setKyuseizouakubi(String kyuseizouakubi) {
		this.kyuseizouakubi = kyuseizouakubi;
	}


	public double getNissuu() {
		return this.nissuu;
	}

	public void setNissuu(double nissuu) {
		this.nissuu = nissuu;
	}


	public String getNyuuinnbi() {
		return this.nyuuinnbi;
	}

	public void setNyuuinnbi(String nyuuinnbi) {
		this.nyuuinnbi = nyuuinnbi;
	}


	public String getObjective() {
		return this.objective;
	}

	public void setObjective(String objective) {
		this.objective = objective;
	}


	@Column(name="OT_FLAG")
	public String getOtFlag() {
		return this.otFlag;
	}

	public void setOtFlag(String otFlag) {
		this.otFlag = otFlag;
	}


	public String getOt1() {
		return this.ot1;
	}

	public void setOt1(String ot1) {
		this.ot1 = ot1;
	}


	public String getOt10() {
		return this.ot10;
	}

	public void setOt10(String ot10) {
		this.ot10 = ot10;
	}


	public String getOt2() {
		return this.ot2;
	}

	public void setOt2(String ot2) {
		this.ot2 = ot2;
	}


	public String getOt3() {
		return this.ot3;
	}

	public void setOt3(String ot3) {
		this.ot3 = ot3;
	}


	public String getOt4() {
		return this.ot4;
	}

	public void setOt4(String ot4) {
		this.ot4 = ot4;
	}


	public String getOt5() {
		return this.ot5;
	}

	public void setOt5(String ot5) {
		this.ot5 = ot5;
	}


	public String getOt6() {
		return this.ot6;
	}

	public void setOt6(String ot6) {
		this.ot6 = ot6;
	}


	public String getOt7() {
		return this.ot7;
	}

	public void setOt7(String ot7) {
		this.ot7 = ot7;
	}


	public String getOt8() {
		return this.ot8;
	}

	public void setOt8(String ot8) {
		this.ot8 = ot8;
	}


	public String getOt9() {
		return this.ot9;
	}

	public void setOt9(String ot9) {
		this.ot9 = ot9;
	}


	@Column(name="PK_IFS_IRAI")
	public double getPkIfsIrai() {
		return this.pkIfsIrai;
	}

	public void setPkIfsIrai(double pkIfsIrai) {
		this.pkIfsIrai = pkIfsIrai;
	}


	@Column(name="PT_FLAG")
	public String getPtFlag() {
		return this.ptFlag;
	}

	public void setPtFlag(String ptFlag) {
		this.ptFlag = ptFlag;
	}


	public String getPt1() {
		return this.pt1;
	}

	public void setPt1(String pt1) {
		this.pt1 = pt1;
	}


	public String getPt10() {
		return this.pt10;
	}

	public void setPt10(String pt10) {
		this.pt10 = pt10;
	}


	public String getPt2() {
		return this.pt2;
	}

	public void setPt2(String pt2) {
		this.pt2 = pt2;
	}


	public String getPt3() {
		return this.pt3;
	}

	public void setPt3(String pt3) {
		this.pt3 = pt3;
	}


	public String getPt4() {
		return this.pt4;
	}

	public void setPt4(String pt4) {
		this.pt4 = pt4;
	}


	public String getPt5() {
		return this.pt5;
	}

	public void setPt5(String pt5) {
		this.pt5 = pt5;
	}


	public String getPt6() {
		return this.pt6;
	}

	public void setPt6(String pt6) {
		this.pt6 = pt6;
	}


	public String getPt7() {
		return this.pt7;
	}

	public void setPt7(String pt7) {
		this.pt7 = pt7;
	}


	public String getPt8() {
		return this.pt8;
	}

	public void setPt8(String pt8) {
		this.pt8 = pt8;
	}


	public String getPt9() {
		return this.pt9;
	}

	public void setPt9(String pt9) {
		this.pt9 = pt9;
	}


	public String getReha1() {
		return this.reha1;
	}

	public void setReha1(String reha1) {
		this.reha1 = reha1;
	}


	public String getReha2() {
		return this.reha2;
	}

	public void setReha2(String reha2) {
		this.reha2 = reha2;
	}


	public String getReha3() {
		return this.reha3;
	}

	public void setReha3(String reha3) {
		this.reha3 = reha3;
	}


	public String getReha4() {
		return this.reha4;
	}

	public void setReha4(String reha4) {
		this.reha4 = reha4;
	}


	public String getReha5() {
		return this.reha5;
	}

	public void setReha5(String reha5) {
		this.reha5 = reha5;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	public String getSindanisi() {
		return this.sindanisi;
	}

	public void setSindanisi(String sindanisi) {
		this.sindanisi = sindanisi;
	}


	public String getSinryouka() {
		return this.sinryouka;
	}

	public void setSinryouka(String sinryouka) {
		this.sinryouka = sinryouka;
	}


	@Column(name="ST_FLAG")
	public String getStFlag() {
		return this.stFlag;
	}

	public void setStFlag(String stFlag) {
		this.stFlag = stFlag;
	}


	public String getSt1() {
		return this.st1;
	}

	public void setSt1(String st1) {
		this.st1 = st1;
	}


	public String getSt10() {
		return this.st10;
	}

	public void setSt10(String st10) {
		this.st10 = st10;
	}


	public String getSt2() {
		return this.st2;
	}

	public void setSt2(String st2) {
		this.st2 = st2;
	}


	public String getSt3() {
		return this.st3;
	}

	public void setSt3(String st3) {
		this.st3 = st3;
	}


	public String getSt4() {
		return this.st4;
	}

	public void setSt4(String st4) {
		this.st4 = st4;
	}


	public String getSt5() {
		return this.st5;
	}

	public void setSt5(String st5) {
		this.st5 = st5;
	}


	public String getSt6() {
		return this.st6;
	}

	public void setSt6(String st6) {
		this.st6 = st6;
	}


	public String getSt7() {
		return this.st7;
	}

	public void setSt7(String st7) {
		this.st7 = st7;
	}


	public String getSt8() {
		return this.st8;
	}

	public void setSt8(String st8) {
		this.st8 = st8;
	}


	public String getSt9() {
		return this.st9;
	}

	public void setSt9(String st9) {
		this.st9 = st9;
	}


	@Column(name="STOP_KIJYUN")
	public String getStopKijyun() {
		return this.stopKijyun;
	}

	public void setStopKijyun(String stopKijyun) {
		this.stopKijyun = stopKijyun;
	}


	@Column(name="SU_1")
	public String getSu1() {
		return this.su1;
	}

	public void setSu1(String su1) {
		this.su1 = su1;
	}


	@Column(name="SU_2_1")
	public String getSu21() {
		return this.su21;
	}

	public void setSu21(String su21) {
		this.su21 = su21;
	}


	@Column(name="SU_2_2")
	public String getSu22() {
		return this.su22;
	}

	public void setSu22(String su22) {
		this.su22 = su22;
	}


	@Column(name="SU_2_3")
	public String getSu23() {
		return this.su23;
	}

	public void setSu23(String su23) {
		this.su23 = su23;
	}


	@Column(name="SU_2_4")
	public String getSu24() {
		return this.su24;
	}

	public void setSu24(String su24) {
		this.su24 = su24;
	}


	@Column(name="SU_3_1")
	public String getSu31() {
		return this.su31;
	}

	public void setSu31(String su31) {
		this.su31 = su31;
	}


	@Column(name="SU_3_2")
	public String getSu32() {
		return this.su32;
	}

	public void setSu32(String su32) {
		this.su32 = su32;
	}


	@Column(name="SU_4_1")
	public String getSu41() {
		return this.su41;
	}

	public void setSu41(String su41) {
		this.su41 = su41;
	}


	@Column(name="SU_4_2")
	public String getSu42() {
		return this.su42;
	}

	public void setSu42(String su42) {
		this.su42 = su42;
	}


	@Column(name="SU_4_3")
	public String getSu43() {
		return this.su43;
	}

	public void setSu43(String su43) {
		this.su43 = su43;
	}


	@Column(name="SYORI_FLAG")
	public String getSyoriFlag() {
		return this.syoriFlag;
	}

	public void setSyoriFlag(String syoriFlag) {
		this.syoriFlag = syoriFlag;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	public String getSyujyutubi() {
		return this.syujyutubi;
	}

	public void setSyujyutubi(String syujyutubi) {
		this.syujyutubi = syujyutubi;
	}


	public String getTaboo() {
		return this.taboo;
	}

	public void setTaboo(String taboo) {
		this.taboo = taboo;
	}


	public String getTantoui() {
		return this.tantoui;
	}

	public void setTantoui(String tantoui) {
		this.tantoui = tantoui;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}