package nta.med.data.dao.medi.ocs;

import java.math.BigDecimal;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.ocs.Ocs0701;

public interface Ocs0701Repository extends JpaRepository<Ocs0701, Long>, Ocs0701RepositoryCustom{

	@Modifying
	@Query("UPDATE Ocs0701 SET status = :f_status, updId = :f_upd_id WHERE id = :f_id")
	public Integer updateOCS2016U00(@Param("f_status") BigDecimal status, @Param("f_upd_id") String updId,@Param("f_id") Long id);
	
	@Modifying
	@Query("UPDATE Ocs0701 SET activeFlg = 0, updId = :f_upd_id WHERE id = :f_id")
	public Integer deleteOCS2016U00(@Param("f_upd_id") String updId,@Param("f_id") Long id);
	
	@Modifying
	@Query("UPDATE Ocs0701 SET finishFlg = 'Y', updId = :f_upd_id WHERE id = :f_id")
	public Integer finishDiscusOCS2016U00(@Param("f_upd_id") String updId,@Param("f_id") Long id);
}
