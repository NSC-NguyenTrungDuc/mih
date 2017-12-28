package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc1007;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc1007Repository extends JpaRepository<Doc1007, Long>, Doc1007RepositoryCustom {
}

