package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm4500;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm4500Repository extends JpaRepository<Adm4500, Long>, Adm4500RepositoryCustom {
}

