package nta.med.data.dao.medi.bas;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.bas.Bas0260S;


@Repository
public interface Bas0260SRepository extends JpaRepository<Bas0260S, Long>, Bas0260SRepositoryCustom {
	
}
