package nta.mss.repository;

import java.util.List;

import nta.mss.entity.MailListDetail;
import nta.mss.entity.MailListDetailPK;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author linh.nguyen.trong
 * @since 20140811
 */
@Repository
public interface MailListDetailRepository extends JpaRepository<MailListDetail, MailListDetailPK> {
	
	@Query("SELECT m FROM MailListDetail m WHERE m.id.mailListId = :mailListId and m.activeFlg = :activeFlg order by name desc")
	public List<MailListDetail> getMailListDetail(@Param("mailListId") Integer mailListId, @Param("activeFlg") Integer activeFlg);
	
	@Query("SELECT m FROM MailListDetail m WHERE m.id.mailListId = :mailListId and m.id.email = :email and m.activeFlg = 1")
	public MailListDetail findByMailListIdAndEmail(@Param("mailListId") Integer mailListId, @Param("email") String email);
	
	@Query("UPDATE MailListDetail m SET m.id.email = :email, m.name = :name WHERE m.id.mailListId = :mailListId AND m.id.email = :emailOld AND m.activeFlg = 1")
	public void updateByMailListIdAndEmail(@Param("email") String email, @Param("name") String name, @Param("mailListId") Integer mailListId, @Param("emailOld") String emailOld);
}