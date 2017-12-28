package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc1002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc1002Repository extends JpaRepository<Doc1002, Long>, Doc1002RepositoryCustom {
}

