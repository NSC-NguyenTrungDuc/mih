package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0204;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0204Repository extends JpaRepository<Ocs0204, Long>, Ocs0204RepositoryCustom {
	@Modifying
	@Query("UPDATE Ocs0204 SET updId = :f_user_id, updDate = :f_sys_date, seq = :f_seq, sangGubunName = :f_sang_gubun_name "
			+ "WHERE memb = :f_memb AND membGubun = '1' AND sangGubun = :f_sang_gubun AND hospCode = :f_hosp_code AND language = :f_language ")
	public Integer updateOcsaOCS0204U00UpdateOCS0204(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_seq") Double seq,
			@Param("f_sang_gubun_name") String sangGubunName,
			@Param("f_memb") String memb,
			@Param("f_sang_gubun") String sangGubun,
			@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language);
	
	@Modifying
	@Query("DELETE Ocs0204 WHERE memb = :f_memb AND membGubun = '1' AND sangGubun = :f_sang_gubun AND hospCode = :f_hosp_code AND language = :f_language ")
	public Integer deleteOcsaOCS0204U00DeleteOCS0204(@Param("f_memb") String memb,
			@Param("f_sang_gubun") String sangGubun,
			@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language);
	
	@Query("SELECT A.sangGubunName FROM Ocs0204 A WHERE A.hospCode = :f_hosp_code "
			+ "AND A.memb = :f_memb AND A.membGubun = '1' AND A.sangGubun = :f_code AND language = :f_language ")
	public String getSangGubunNameOcsaOCS0204U00CommonData(@Param("f_hosp_code") String hospCode,
			@Param("f_memb") String memb,
			@Param("f_code") String sangGubun,
			@Param("f_language") String language);
}

