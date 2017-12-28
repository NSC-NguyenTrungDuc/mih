package nta.med.data.dao.medi.kinki;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import nta.med.core.domain.kinki.DrugChecking;

public interface DrugCheckingRepository extends JpaRepository<DrugChecking, Long>{

	@Query
    public List<DrugChecking> findByActiveFlgOrderByCreatedAsc(BigDecimal activeFlg);
}
