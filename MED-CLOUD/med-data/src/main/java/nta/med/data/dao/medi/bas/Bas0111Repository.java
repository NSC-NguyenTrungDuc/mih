package nta.med.data.dao.medi.bas;


import java.util.Date;

import nta.med.core.domain.bas.Bas0111;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.stereotype.Repository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0111Repository extends JpaRepository<Bas0111, Long>, Bas0111RepositoryCustom {
	
	@Modifying
	@Query("DELETE Bas0111 WHERE hospCode   = :f_hosp_code "
			+ "AND johapGubun = :f_johap_gubun "
			+ " AND johap       = :f_johap "
			+ "   AND gaein       = :f_gaein")
	public Integer deleteBas0111(@Param("f_hosp_code") String hospCode,
			@Param("f_johap_gubun") String johapGubun,
			@Param("f_johap") String johap,
			@Param("f_gaein") String gaein);
	
	@Modifying
	@Query("UPDATE Bas0111  SET updId  = :q_user_id , "
			+ "updDate    = :f_upd_date , useYn      = :f_use_yn , "
			+ " zipCode1   = :f_zip_code1 , zipCode2   = :f_zip_code2 "
			+ " , address     = :f_address , address1    = :f_address1 "
			+ " , gaeinName  = :f_gaein_name "
			+ "WHERE hospCode   = :f_hosp_code "
			+ " AND johapGubun = :f_johap_gubun "
			+ " AND johap       = :f_johap "
			+ " AND gaein       = :f_gaein")
	public Integer updateBas0111(@Param("f_hosp_code") String hospCode,
			@Param("q_user_id") String updId,
			@Param("f_upd_date") Date updDate,
			@Param("f_use_yn") String useYn,
			@Param("f_zip_code1") String zipCode1,
			@Param("f_zip_code2") String zipCode2,
			@Param("f_address") String address,
			@Param("f_address1") String address1,
			@Param("f_johap_gubun") String johapGubun,
			@Param("f_johap") String johap,
			@Param("f_gaein") String gaein);
	
	@Query("SELECT 'Y'  FROM Bas0111 "
			+ " WHERE hospCode   = :f_hosp_code "
			+ "AND johapGubun = :f_johap_gubun "
			+ " AND johap       = :f_johap "
			+ "AND gaein       = :f_gaein")
	public String getY(@Param("f_hosp_code") String hospCode,
			@Param("f_johap_gubun") String johapGubun,
			@Param("f_johap") String johap,
			@Param("f_gaein") String gaein);
}

