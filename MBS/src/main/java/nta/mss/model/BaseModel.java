package nta.mss.model;

import java.io.Serializable;

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
