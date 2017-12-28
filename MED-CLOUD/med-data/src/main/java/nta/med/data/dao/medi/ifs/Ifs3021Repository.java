package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs3021;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs3021Repository extends JpaRepository<Ifs3021, Long>, Ifs3021RepositoryCustom {
}

