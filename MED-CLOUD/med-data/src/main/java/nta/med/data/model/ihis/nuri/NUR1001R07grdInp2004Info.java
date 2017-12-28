package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1001R07grdInp2004Info {

	private Double fkinp1001;
	private String orderDate;
	private String fromGwa;
	private String toGwa;
	private String fromDoctor;
	private String toDoctor;
	private String fromHoDong1;
	private String toHoDong1;
	private String fromHoCode1;
	private String toHoCode1;
	private String transCnt;
	private String transTime;
	private String fromBed;
	private String toBed;

	public NUR1001R07grdInp2004Info(Double fkinp1001, String orderDate, String fromGwa, String toGwa, String fromDoctor,
			String toDoctor, String fromHoDong1, String toHoDong1, String fromHoCode1, String toHoCode1,
			String transCnt, String transTime, String fromBed, String toBed) {
		super();
		this.fkinp1001 = fkinp1001;
		this.orderDate = orderDate;
		this.fromGwa = fromGwa;
		this.toGwa = toGwa;
		this.fromDoctor = fromDoctor;
		this.toDoctor = toDoctor;
		this.fromHoDong1 = fromHoDong1;
		this.toHoDong1 = toHoDong1;
		this.fromHoCode1 = fromHoCode1;
		this.toHoCode1 = toHoCode1;
		this.transCnt = transCnt;
		this.transTime = transTime;
		this.fromBed = fromBed;
		this.toBed = toBed;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public String getOrderDate() {
		return orderDate;
	}

	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}

	public String getFromGwa() {
		return fromGwa;
	}

	public void setFromGwa(String fromGwa) {
		this.fromGwa = fromGwa;
	}

	public String getToGwa() {
		return toGwa;
	}

	public void setToGwa(String toGwa) {
		this.toGwa = toGwa;
	}

	public String getFromDoctor() {
		return fromDoctor;
	}

	public void setFromDoctor(String fromDoctor) {
		this.fromDoctor = fromDoctor;
	}

	public String getToDoctor() {
		return toDoctor;
	}

	public void setToDoctor(String toDoctor) {
		this.toDoctor = toDoctor;
	}

	public String getFromHoDong1() {
		return fromHoDong1;
	}

	public void setFromHoDong1(String fromHoDong1) {
		this.fromHoDong1 = fromHoDong1;
	}

	public String getToHoDong1() {
		return toHoDong1;
	}

	public void setToHoDong1(String toHoDong1) {
		this.toHoDong1 = toHoDong1;
	}

	public String getFromHoCode1() {
		return fromHoCode1;
	}

	public void setFromHoCode1(String fromHoCode1) {
		this.fromHoCode1 = fromHoCode1;
	}

	public String getToHoCode1() {
		return toHoCode1;
	}

	public void setToHoCode1(String toHoCode1) {
		this.toHoCode1 = toHoCode1;
	}

	public String getTransCnt() {
		return transCnt;
	}

	public void setTransCnt(String transCnt) {
		this.transCnt = transCnt;
	}

	public String getTransTime() {
		return transTime;
	}

	public void setTransTime(String transTime) {
		this.transTime = transTime;
	}

	public String getFromBed() {
		return fromBed;
	}

	public void setFromBed(String fromBed) {
		this.fromBed = fromBed;
	}

	public String getToBed() {
		return toBed;
	}

	public void setToBed(String toBed) {
		this.toBed = toBed;
	}

}
