package nta.med.data.dao.medi.ocs;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.ocs.Ocs0702;

public interface Ocs0702Repository extends JpaRepository<Ocs0702, Long>, Ocs0702RepositoryCustom{

	@Modifying
	@Query("UPDATE Ocs0702 SET content = :f_content, updId = :f_upd_id, editedFlg = 2 WHERE id = :f_id")
	public Integer updateOCS2016U00(@Param("f_content") String content, @Param("f_upd_id") String updId,@Param("f_id") Long id);
	
}
