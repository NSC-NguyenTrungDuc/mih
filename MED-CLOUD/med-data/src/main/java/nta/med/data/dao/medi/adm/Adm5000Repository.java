package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm5000;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm5000Repository extends JpaRepository<Adm5000, Long>, Adm5000RepositoryCustom {
}

