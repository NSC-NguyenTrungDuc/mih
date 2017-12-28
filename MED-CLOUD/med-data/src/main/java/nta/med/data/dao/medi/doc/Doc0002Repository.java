package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc0002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc0002Repository extends JpaRepository<Doc0002, Long>, Doc0002RepositoryCustom {
}

