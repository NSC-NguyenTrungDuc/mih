package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1060;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1060Repository extends JpaRepository<Nur1060, Long>, Nur1060RepositoryCustom {
}

