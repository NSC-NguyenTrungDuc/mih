package nta.med.data.dao.medi.out;

import nta.med.core.domain.out.Out1007;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out1007Repository extends JpaRepository<Out1007, Long>, Out1007RepositoryCustom {
}

