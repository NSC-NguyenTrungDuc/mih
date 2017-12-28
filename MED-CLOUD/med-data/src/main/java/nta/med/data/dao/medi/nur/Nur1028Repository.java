package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1028;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1028Repository extends JpaRepository<Nur1028, Long>, Nur1028RepositoryCustom {
}

