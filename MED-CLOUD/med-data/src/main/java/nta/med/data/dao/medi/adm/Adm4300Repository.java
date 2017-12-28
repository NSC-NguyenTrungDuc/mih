package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm4300;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm4300Repository extends JpaRepository<Adm4300, Long>, Adm4300RepositoryCustom {
}

