package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs3032;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs3032Repository extends JpaRepository<Ifs3032, Long>, Ifs3032RepositoryCustom {
}

