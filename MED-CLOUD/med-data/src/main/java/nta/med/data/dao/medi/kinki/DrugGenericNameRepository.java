package nta.med.data.dao.medi.kinki;

import java.math.BigDecimal;
import java.util.List;

import nta.med.core.domain.kinki.DrugGenericName;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

public interface DrugGenericNameRepository extends JpaRepository<DrugGenericName, Long> {
	
	@Query
    public List<DrugGenericName> findByActiveFlgOrderByCreatedAsc(BigDecimal activeFlg);

}
