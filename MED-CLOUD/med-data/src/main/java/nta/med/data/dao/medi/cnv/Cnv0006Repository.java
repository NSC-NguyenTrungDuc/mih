package nta.med.data.dao.medi.cnv;

import nta.med.core.domain.cnv.Cnv0006;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cnv0006Repository extends JpaRepository<Cnv0006, Long>, Cnv0006RepositoryCustom {
}

