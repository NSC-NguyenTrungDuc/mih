package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm5100;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm5100Repository extends JpaRepository<Adm5100, Long>, Adm5100RepositoryCustom {
}

