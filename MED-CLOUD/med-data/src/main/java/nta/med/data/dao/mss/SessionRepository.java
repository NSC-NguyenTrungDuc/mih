package nta.med.data.dao.mss;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.mss.Session;

@Repository
public interface SessionRepository extends JpaRepository<Session, Long> {
	
}
