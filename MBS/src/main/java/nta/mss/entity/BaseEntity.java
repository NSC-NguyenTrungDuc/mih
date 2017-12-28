package nta.mss.entity;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.MappedSuperclass;
import javax.persistence.PrePersist;
import javax.persistence.PreUpdate;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;

import nta.mss.misc.enums.ActiveFlag;

import org.dozer.Mapper;

/**
 * The Class BaseEntity.
 * 
 * @author DinhNX
 * @param <E>
 *            the element type
 * @CrtDate Jul 29, 2014
 */
@MappedSuperclass
@Inheritance(strategy=InheritanceType.TABLE_PER_CLASS)
public abstract class BaseEntity<E> implements Serializable {
	private static final long serialVersionUID = 1L;

	@Transient
	private Class<E> modelType;
	
	@Column(name = "active_flg", insertable = false, updatable = true)
	private Integer activeFlg;
	
	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="created")
	private Date created;

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="updated")
	private Date updated;
	
	BaseEntity(Class<E> modelType) {
		super();
		this.modelType = modelType;
	}
	
	public Integer getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}

	public Date getCreated() {
		return this.created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}
	
	public Date getUpdated() {
		return this.updated;
	}

	public void setUpdated(Date updated) {
		this.updated = updated;
	}
	
	@PrePersist
	void prePersist() {
		this.created = new Date();
		this.updated = new Date();
	}

	@PreUpdate
	void preUpdate() {
		this.updated = new Date();
		if (this.activeFlg == null) {
			this.activeFlg = ActiveFlag.ACTIVE.toInt();
		}
	}
	
	/**
	 * To model.
	 * 
	 * @param mapper
	 *            the mapper
	 * @return the e
	 */
	public E toModel(Mapper mapper) {
		E model = mapper.map(this, this.modelType);
		return model;
	}
	
	public E toModel(Mapper mapper, String mapId) {
		E model = mapper.map(this, this.modelType, mapId);
		return model;
	}
}
