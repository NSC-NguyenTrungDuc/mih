package nta.med.data.dao.medi.inv;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inv.Inv6000;

@Repository
public interface Inv6000Repository extends JpaRepository<Inv6000, Long>, Inv6000RepositoryCustom {

}
