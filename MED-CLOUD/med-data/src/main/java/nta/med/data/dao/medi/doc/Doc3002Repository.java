package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc3002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc3002Repository extends JpaRepository<Doc3002, Long>, Doc3002RepositoryCustom {
}

