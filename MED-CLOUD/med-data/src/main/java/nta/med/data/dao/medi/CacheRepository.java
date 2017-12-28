package nta.med.data.dao.medi;

import java.util.List;

import nta.med.core.domain.BaseEntity;
import nta.med.core.domain.adm.Adm3100;

import org.springframework.stereotype.Repository;

/**
 * @author Tiepnm
 */
@Repository
public interface CacheRepository<T extends BaseEntity>  {

    public T save(T baseEntity);
    public List<T> save(List<T> entities);
    public void delete(T baseEntity);
}
