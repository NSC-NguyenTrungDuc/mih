package nta.med.data.dao.medi.out;

import nta.med.core.domain.out.Out5001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out5001Repository extends JpaRepository<Out5001, Long>, Out5001RepositoryCustom {
}

