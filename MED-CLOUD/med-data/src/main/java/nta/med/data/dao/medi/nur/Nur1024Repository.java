package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1024;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1024Repository extends JpaRepository<Nur1024, Long>, Nur1024RepositoryCustom {
}

