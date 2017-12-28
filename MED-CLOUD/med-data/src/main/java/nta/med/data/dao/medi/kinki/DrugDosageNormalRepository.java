package nta.med.data.dao.medi.kinki;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.kinki.DrugDosageNormal;

@Repository
public interface DrugDosageNormalRepository extends JpaRepository<DrugDosageNormal, Long>, DrugDosageNormalRepositoryCustom{

	@Query
    public List<DrugDosageNormal> findByActiveFlgOrderByCreatedAsc(BigDecimal activeFlg);
}
