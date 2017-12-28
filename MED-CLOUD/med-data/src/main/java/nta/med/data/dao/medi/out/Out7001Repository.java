package nta.med.data.dao.medi.out;

import nta.med.core.domain.out.Out7001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out7001Repository extends JpaRepository<Out7001, Long>, Out7001RepositoryCustom {
}

