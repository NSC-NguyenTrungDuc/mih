package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm0700;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0700Repository extends JpaRepository<Adm0700, Long>, Adm0700RepositoryCustom {
}

