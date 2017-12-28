package nta.med.data.dao.medi.kinki;

import nta.med.core.domain.kinki.DrugInteraction;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import org.springframework.data.domain.Pageable;
import java.math.BigDecimal;
import java.util.List;

/**
 * @author DEV-TiepNM
 */
@Repository
public interface DrugInteractionRepository extends JpaRepository<DrugInteraction, Long> {

    @Query
    public List<DrugInteraction> findByActiveFlgOrderByCreatedAsc(BigDecimal activeFlg);
}
