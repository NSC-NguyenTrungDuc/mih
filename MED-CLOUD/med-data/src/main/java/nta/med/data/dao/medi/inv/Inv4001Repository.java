package nta.med.data.dao.medi.inv;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inv.Inv4001;

@Repository
public interface Inv4001Repository extends JpaRepository<Inv4001, Long>, Inv4001RepositoryCustom{
	
	@Modifying
	@Query("UPDATE Inv4001 							"
			+ "SET remark = :f_remark , importCode = :importCode, churiDate = :churiDate				"
			+ "WHERE hospCode = :f_hosp_code 		"
			+ "AND pkinv4001 = :f_pkinv4001         ")
	public Integer updateINV4001(@Param("f_hosp_code") String hospCode,
			@Param("f_pkinv4001") Double pkinv4001,
			@Param("f_remark") String remark,
			@Param("importCode") String importCode,
			@Param("churiDate") Date churiDate);
	
	@Modifying
	@Query("DELETE FROM Inv4001 				    "
			+ "WHERE hospCode = :f_hosp_code 		"
			+ "AND pkinv4001 = :f_pkinv4001         ")
	public Integer deleteINV4001(@Param("f_hosp_code") String hospCode,
			@Param("f_pkinv4001") Double pkinv4001);
}
