package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2016;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2016Repository extends JpaRepository<Ocs2016, Long>, Ocs2016RepositoryCustom {
	
	@Modifying
	@Query("	UPDATE Ocs2016                            												"
		 + "        SET suryang     	= :f_suryang,           										"
		 + "        	bloodSugar     	= :f_blood_sugar,           									"
         + "			updDate    		= SYSDATE(),														"
	     + "            seq     		= :f_seq,      													"
	     + "            timeGubun		= :f_time_gubun          										"
	     + "        WHERE 	hospCode		= :f_hosp_code         										"
	     + "          		AND pkocs2016 	= :f_pkocs2016        										")
	public Integer updateOCS6010U10PopupIASaveLayout(
			@Param("f_suryang") 	Double suryang,
			@Param("f_blood_sugar") Double bloodSugar,
			@Param("f_seq") 		Double seq,
			@Param("f_time_gubun") 	String timeGubun,
			@Param("f_hosp_code") 	String hospCode,
			@Param("f_pkocs2016") 	Double fkocs2016);
	
	@Modifying
	@Query("DELETE FROM Ocs2016 WHERE hospCode = :f_hosp_code AND fkocs2015 = :f_pkocs2015")
	public Integer deleteOcs2016InOCS6010(@Param("f_hosp_code") String hospCode,
										  @Param("f_pkocs2015") Double pkocs2015);
	
	@Query("SELECT T FROM Ocs2016 T WHERE hospCode = :f_hosp_code AND pkocs2016 = :f_pkocs2016")
	public List<Ocs2016> findByHospCodePkOcs2016(@Param("f_hosp_code") String hospCode,
			  									 @Param("f_pkocs2016") Double pkocs2016);
	
	@Modifying
	@Query("DELETE FROM Ocs2016 WHERE hospCode = :f_hosp_code AND pkocs2016 = :f_pkocs2016")
	public Integer deleteByHospCodePkOcs2016(@Param("f_hosp_code") String hospCode,
										  @Param("f_pkocs2016") Double pkocs2016);
}

