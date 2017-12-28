package nta.med.core.domain.phr;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

/**
 * The persistent class for the PHR_SYS_PROPERTY database table.
 * 
 */
@Entity
@Table(name = "PHR_SYS_PROPERTY")
@NamedQuery(name = "PhrSysProperty.findAll", query = "SELECT p FROM PhrSysProperty p")
public class PhrSysProperty extends PhrBaseEntity {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	private String code;

	@Column(name = "CODE_TYPE")
	private String codeType;

	@Column(name = "CODE_VALUE")
	private String codeValue;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "UPD_ID")
	private String updId;

	public PhrSysProperty() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getCode() {
		return this.code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getCodeType() {
		return this.codeType;
	}

	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}

	public String getCodeValue() {
		return this.codeValue;
	}

	public void setCodeValue(String codeValue) {
		this.codeValue = codeValue;
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

}