package nta.med.core.domain.mss;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

/**
 * The persistent class for the session database table.
 * 
 */
@Entity
@Table(name = "session")
@NamedQuery(name = "Session.findAll", query = "SELECT s FROM Session s")
public class Session implements Serializable {
	
	private static final long serialVersionUID = 1L;
	
	private String sessionId;
	
	private String accessIp;
	
	private BigDecimal activeFlg;
	
	private Date created;
	
	@Temporal(TemporalType.TIMESTAMP)
	private Date expired;
	
	@Temporal(TemporalType.TIMESTAMP)
	private Date updated;

	public Session() {
	}

	@Id
	@Column(name = "session_id")
	public String getSessionId() {
		return this.sessionId;
	}

	public void setSessionId(String sessionId) {
		this.sessionId = sessionId;
	}

	@Column(name = "access_ip")
	public String getAccessIp() {
		return this.accessIp;
	}

	public void setAccessIp(String accessIp) {
		this.accessIp = accessIp;
	}

	@Column(name = "active_flg")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public Date getCreated() {
		return this.created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}

	@Column(name = "expired")
	public Date getExpired() {
		return this.expired;
	}

	public void setExpired(Date expired) {
		this.expired = expired;
	}

	public Date getUpdated() {
		return this.updated;
	}

	public void setUpdated(Date updated) {
		this.updated = updated;
	}

}