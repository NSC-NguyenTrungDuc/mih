package nta.med.data.dao.medi.out;

import nta.med.core.domain.out.Out0000;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out0000Repository extends JpaRepository<Out0000, Long>, Out0000RepositoryCustom {
}

