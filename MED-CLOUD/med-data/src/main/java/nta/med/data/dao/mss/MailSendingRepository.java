package nta.med.data.dao.mss;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.mss.MailSending;

@Repository
public interface MailSendingRepository extends JpaRepository<MailSending, Integer> {
	
}
