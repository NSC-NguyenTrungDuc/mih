package nta.med.data.dao.medi.clis;

import nta.med.core.domain.clis.ClisProtocolStatus;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ClisProtocolStatusRepository extends JpaRepository<ClisProtocolStatus, Long>, ClisProtocolStatusRepositoryCustom{

}
