package nta.med.data.dao.medi.kinki;

import nta.med.core.domain.kinki.DrugDosageStandard;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface DrugDosageStandardRepository extends JpaRepository<DrugDosageStandard, Long>, DrugDosageStandardRepositoryCustom{

}
