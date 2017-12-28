package nta.med.data.dao.medi.kinki;

import nta.med.core.domain.kinki.DrugKinkiDisease;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface DrugKinkiDiseaseRepository extends JpaRepository<DrugKinkiDisease, Long>, DrugKinkiDiseaseRepositoryCustom{
}
