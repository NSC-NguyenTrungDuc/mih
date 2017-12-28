package nta.med.data.dao.medi.pfe;

import java.util.List;

import nta.med.core.domain.pfe.Pfe1000;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Pfe1000Repository extends JpaRepository<Pfe1000, Long>, Pfe1000RepositoryCustom {
	@Query(" SELECT 'Y' FROM Pfe1000 A  WHERE A.fkocs  = :f_fkocs AND A.hospCode = :f_hosp_code")
	public List<String> getYByHospCodeAndFk0cs(@Param("f_hosp_code") String hospCode, @Param("f_fkocs") Double fkocs);
	
	@Modifying
	@Query("UPDATE Pfe1000 SET updId       = :f_upd_id"
			+ ", updDate     = SYSDATE() "
			+ ", c3           = :f_c3"
			+ " , bunho        = :f_bunho"
			+ " , hangmogCode = :f_hangmog_code   "
			+ " , residentYn  = :f_resident_yn  "
			+ "WHERE fkocs        = :f_fkocs "
			+ "AND hospCode    = :f_hosp_code ")
	public Integer updatePfe1000ByHospCodeAndFkocs(@Param("f_hosp_code") String hospCode,
			@Param("f_fkocs") Double fkocs,
			@Param("f_upd_id") String updId,
			@Param("f_c3") String c3,
			@Param("f_bunho") String bunho,
			@Param("f_hangmog_code") String hangmogCode,
			@Param("f_resident_yn") String residentYn);
	
}

