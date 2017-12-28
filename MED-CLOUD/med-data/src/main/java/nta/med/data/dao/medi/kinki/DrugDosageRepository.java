package nta.med.data.dao.medi.kinki;

import java.math.BigDecimal;
import java.util.List;

import nta.med.core.domain.kinki.DrugDosage;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

public interface DrugDosageRepository extends JpaRepository<DrugDosage, Long>, DrugDosageRepositoryCustom {
	
	@Query
    public List<DrugDosage> findByActiveFlgOrderByCreatedAsc(BigDecimal activeFlg);

}
