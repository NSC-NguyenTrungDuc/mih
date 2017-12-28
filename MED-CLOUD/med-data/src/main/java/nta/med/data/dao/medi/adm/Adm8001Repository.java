package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm8001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm8001Repository extends JpaRepository<Adm8001, Long>, Adm8001RepositoryCustom {
}

