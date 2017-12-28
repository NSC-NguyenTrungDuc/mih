package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm0750;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0750Repository extends JpaRepository<Adm0750, Long>, Adm0750RepositoryCustom {
}

