package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.core.domain.ocs.Ocs1801;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs1801Repository extends JpaRepository<Ocs1801, Long>, Ocs1801RepositoryCustom {
	@Query("SELECT 'Y' FROM Ocs1801 A  WHERE A.bunho  = :f_bunho  "
			+ " AND patStatus   = :f_pat_status AND A.hospCode   = :f_hosp_code")
	public List<String> getCheckY(@Param("f_hosp_code") String hospCode, 
			@Param("f_pat_status") String patStatus,
			@Param("f_bunho")String bunho);
	
	
	@Modifying
	@Query("UPDATE Ocs1801 SET updId  = :f_upd_id  , "
			+ "updDate  = SYSDATE() , "
			+ "patStatus = :f_pat_status  , "
			+ "patStatusCode  = :f_pat_status_code, "
			+ "ment   = :f_ment     , seq   = :f_seq "
			+ "WHERE bunho = :f_bunho  AND patStatus = :f_pat_status "
			+ " AND hospCode = :f_hosp_code ") 
	public Integer updateOcs1801(@Param("f_hosp_code") String hospCode, 
			@Param("f_upd_id") String updId,
			@Param("f_pat_status") String patStatus,
			@Param("f_pat_status_code") String patStatusCode, 
			@Param("f_ment") String ment, 
			@Param("f_seq") Double seq,
			@Param("f_bunho") String bunho);
}

