package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs3022;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs3022Repository extends JpaRepository<Ifs3022, Long>, Ifs3022RepositoryCustom {
}

