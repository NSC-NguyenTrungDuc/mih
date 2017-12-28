package nta.med.data.dao.medi.kinki;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.kinki.DrugDosageAddition;

@Repository
public interface DrugDosageAddtionRepository extends JpaRepository<DrugDosageAddition, Long>, DrugDosageAddtionRepositoryCustom{

	@Query
    public List<DrugDosageAddition> findByActiveFlgOrderByCreatedAsc(BigDecimal activeFlg);
}
