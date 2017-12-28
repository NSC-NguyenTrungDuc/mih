package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs0102;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs0102Repository extends JpaRepository<Ifs0102, Long>, Ifs0102RepositoryCustom {
}

