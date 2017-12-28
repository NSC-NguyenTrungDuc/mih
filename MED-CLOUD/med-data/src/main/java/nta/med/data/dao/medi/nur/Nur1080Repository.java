package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1080;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1080Repository extends JpaRepository<Nur1080, Long>, Nur1080RepositoryCustom {
}

