package nta.med.core.domain.fabric;

import javax.persistence.*;
import java.io.Serializable;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the FABRIC_GROUP database table.
 *
 */
@Entity
@Table(name="FABRIC_GROUP")
@NamedQuery(name="FabricGroup.findAll", query="SELECT f FROM FabricGroup f")
public class FabricGroup implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@Column(name="HOSP_GROUP_CD")
	private String hospGroupCd;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	private Timestamp created;

	@Column(name="HOSP_GROUP_NAME")
	private String hospGroupName;

	@Column(name="MAINTENANCE_MODE")
	private BigDecimal maintenanceMode;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;

//	//bi-directional many-to-one association to FabricSharding
//	@OneToMany(mappedBy="fabricGroup")
//	private List<FabricSharding> fabricShardings;

	public FabricGroup() {
	}

	public String getHospGroupCd() {
		return this.hospGroupCd;
	}

	public void setHospGroupCd(String hospGroupCd) {
		this.hospGroupCd = hospGroupCd;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public String getHospGroupName() {
		return this.hospGroupName;
	}

	public void setHospGroupName(String hospGroupName) {
		this.hospGroupName = hospGroupName;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

	public BigDecimal getMaintenanceMode() {
		return maintenanceMode;
	}

	public void setMaintenanceMode(BigDecimal maintenanceMode) {
		this.maintenanceMode = maintenanceMode;
	}

//	public List<FabricSharding> getFabricShardings() {
//		return this.fabricShardings;
//	}
//
//	public void setFabricShardings(List<FabricSharding> fabricShardings) {
//		this.fabricShardings = fabricShardings;
//	}
//
//	public FabricSharding addFabricSharding(FabricSharding fabricSharding) {
//		getFabricShardings().add(fabricSharding);
//		fabricSharding.setFabricGroup(this);
//
//		return fabricSharding;
//	}
//
//	public FabricSharding removeFabricSharding(FabricSharding fabricSharding) {
//		getFabricShardings().remove(fabricSharding);
//		fabricSharding.setFabricGroup(null);
//
//		return fabricSharding;
//	}

}