package nta.mss.repository;

import java.util.List;

import nta.mss.entity.MailSending;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * The Interface MailSendingRepository.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Repository
public interface MailSendingRepository extends JpaRepository<MailSending, Integer> {

	@Query("SELECT m FROM MailSending m WHERE m.reservation.reservationId = ?1 and m.mailTemplateId = ?2 and m.activeFlg = 1 order by created desc")
	public List<MailSending> findBySessionAndMailTemplateId(Integer reservationId, Integer mailTemplateId);
	
	@Modifying
	@Query("UPDATE MailSending m SET m.readingFlg = :readingFlg WHERE m.mailSendingId = :mailSendingId")
	public Integer updateReadingFlg(@Param("mailSendingId") Integer mailSendingId, @Param("readingFlg") Integer readingFlg);
	
}
