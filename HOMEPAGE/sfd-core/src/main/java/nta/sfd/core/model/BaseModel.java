package nta.sfd.core.model;

import java.io.Serializable;
import java.util.Date;

import org.dozer.Mapper;

// TODO: Auto-generated Javadoc
/**
 * The Class BaseModel.
 * 
 * @author DinhNX
 * @param <E>
 *            the element type
 * @CrtDate Jul 29, 2014
 */
public abstract class BaseModel<E> implements Serializable {
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 1L;
	
	/** The created. */
	private Date created; 

	/** The entity type. */
	private Class<E> entityType;

	/**
	 * Instantiates a new base model.
	 * 
	 * @param entityType
	 *            the entity type
	 */
	BaseModel(Class<E> entityType) {
		super();
		this.entityType = entityType;
	}
	
	/**
	 * To entity.
	 * 
	 * @param mapper
	 *            the mapper
	 * @return the e
	 */
	public E toEntity(Mapper mapper) {
		E entity = mapper.map(this, entityType);
		return entity;
	}
	
	/**
	 * Gets the created.
	 *
	 * @return the created
	 */
	public Date getCreated() {
		return created;
	}

	/**
	 * Sets the created.
	 *
	 * @param created the new created
	 */
	public void setCreated(Date created) {
		this.created = created;
	}
	
	/**
	 * To entity.
	 * 
	 * @param mapper
	 *            the mapper
	 * @param entity
	 *            the entity
	 * @return the e
	 */
	public E toEntity(Mapper mapper, E entity) {
		mapper.map(this, entity);
		return entity;
	}
}
