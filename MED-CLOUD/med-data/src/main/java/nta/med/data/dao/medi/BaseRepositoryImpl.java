package nta.med.data.dao.medi;

import org.springframework.stereotype.Repository;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import java.util.List;

/**
 * @author Tiepnm
 */

@Repository
public class BaseRepositoryImpl implements BaseRepository  {
    @PersistenceContext
    private EntityManager entityManager;
    @Override
    public void saveObjects(List entities) {
        int count = 0;
        for(Object baseEntity : entities)
        {
            entityManager.persist(baseEntity);
            if ((++count % 1000) == 0) {

                entityManager.flush();
                entityManager.clear();
            }

        }
        entityManager.flush();
        entityManager.clear();
    }
}
