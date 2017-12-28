package nta.mss.model;

import java.io.Serializable;

/**
 * The Class ReservationKpiModel.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class ReservationKpiModel implements Serializable {
	private static final long serialVersionUID = 5563790812903172957L;
	private Long totalReservation;
	private Long kpi;
	
	/**
	 * Instantiates a new reservation kpi model.
	 */
	public ReservationKpiModel() {
	}
	
	/**
	 * Instantiates a new reservation kpi model.
	 * 
	 * @param totalReservation
	 *            the total reservation
	 * @param kpi
	 *            the kpi
	 */
	public ReservationKpiModel(Long totalReservation, Long kpi) {
		super();
		this.totalReservation = totalReservation;
		this.kpi = kpi;
	}
	
	public Long getTotalReservation() {
		return totalReservation;
	}
	
	public void setTotalReservation(Long totalReservation) {
		this.totalReservation = totalReservation;
	}
	
	public Long getKpi() {
		return kpi;
	}
	
	public void setKpi(Long kpi) {
		this.kpi = kpi;
	}
	
}
