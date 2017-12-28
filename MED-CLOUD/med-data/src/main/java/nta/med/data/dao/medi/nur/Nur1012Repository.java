package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1012;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1012Repository extends JpaRepository<Nur1012, Long>, Nur1012RepositoryCustom {
}

