package nta.med.core.domain.fabric;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import java.io.Serializable;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the FABRIC_SHARDING database table.
 * 
 */
@Entity
@Table(name="FABRIC_SHARDING")
public class FabricSharding implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@Column(name="SHARDING_ID")
	private int shardingId;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	private Timestamp created;

	@Column(name="HOSP_MAX")
	private int hospMax;

	@Column(name="HOSP_MIN")
	private int hospMin;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;

	//bi-directional many-to-one association to FabricGroup
//	@ManyToOne
//	@JoinColumn(name="HOSP_GROUP_CD")
//	private FabricGroup fabricGroup;

	@Column(name="HOSP_GROUP_CD")
	private String hospGroupCD;

	public FabricSharding() {
	}

	public int getShardingId() {
		return this.shardingId;
	}

	public void setShardingId(int shardingId) {
		this.shardingId = shardingId;
	}

	@Column(name="ACTIVE_FLG")
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
	@Column(name="HOSP_MAX")
	public int getHospMax() {
		return this.hospMax;
	}

	public void setHospMax(int hospMax) {
		this.hospMax = hospMax;
	}
	@Column(name="HOSP_MIN")
	public int getHospMin() {
		return this.hospMin;
	}

	public void setHospMin(int hospMin) {
		this.hospMin = hospMin;
	}
	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	@Column(name="UPD_ID")
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
	@Column(name="HOSP_GROUP_CD")
	public String getHospGroupCD() {
		return hospGroupCD;
	}

	public void setHospGroupCD(String hospGroupCD) {
		this.hospGroupCD = hospGroupCD;
	}
}