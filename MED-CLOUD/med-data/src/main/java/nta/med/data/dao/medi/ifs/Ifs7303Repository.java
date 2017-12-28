package nta.med.data.dao.medi.ifs;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.ifs.Ifs7303;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7303Repository extends JpaRepository<Ifs7303, Long>, Ifs7303RepositoryCustom {
}
