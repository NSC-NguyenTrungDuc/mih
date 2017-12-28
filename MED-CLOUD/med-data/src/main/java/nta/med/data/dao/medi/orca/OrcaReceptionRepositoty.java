package nta.med.data.dao.medi.orca;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.orca.OrcaReception;

@Repository
public interface OrcaReceptionRepositoty extends JpaRepository<OrcaReception, Long>, OrcaReceptionRepositotyCustom{

}
