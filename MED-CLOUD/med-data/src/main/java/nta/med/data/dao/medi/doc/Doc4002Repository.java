package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc4002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc4002Repository extends JpaRepository<Doc4002, Long>, Doc4002RepositoryCustom {
}

