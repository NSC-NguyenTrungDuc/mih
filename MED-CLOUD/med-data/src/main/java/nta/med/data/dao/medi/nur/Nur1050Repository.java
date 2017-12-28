package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1050;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1050Repository extends JpaRepository<Nur1050, Long>, Nur1050RepositoryCustom {
}

