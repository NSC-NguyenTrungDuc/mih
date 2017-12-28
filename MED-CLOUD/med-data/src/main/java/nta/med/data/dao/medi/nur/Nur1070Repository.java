package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1070;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1070Repository extends JpaRepository<Nur1070, Long>, Nur1070RepositoryCustom {
}

