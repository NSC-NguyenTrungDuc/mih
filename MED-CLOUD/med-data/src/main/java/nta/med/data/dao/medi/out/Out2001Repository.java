package nta.med.data.dao.medi.out;

import nta.med.core.domain.out.Out2001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out2001Repository extends JpaRepository<Out2001, Long>, Out2001RepositoryCustom {
}

