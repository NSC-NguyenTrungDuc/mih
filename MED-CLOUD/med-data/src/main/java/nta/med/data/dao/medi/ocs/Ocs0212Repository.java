package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0212;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0212Repository extends JpaRepository<Ocs0212, Long>, Ocs0212RepositoryCustom {
	@Query(" DELETE FROM Ocs0212 A WHERE A.hospCode = :f_hospCode AND A.membGubun = :f_memb_gubun AND A.memb  = :f_memb  AND A.hangmogCode = :f_hangmog_code ")
	public Integer deleteOftenUsedHangmog(@Param("f_hospCode") String hospCode,@Param("f_memb_gubun") String membGubun,
			@Param("f_memb") String memb,@Param("f_hangmog_code") String hangmogCode);
	
	@Modifying
	@Query("UPDATE Ocs0212 SET oftenUse = :f_often_use WHERE membGubun = :f_memb_gubun "
			+ "AND hangmogCode = :f_hangmog_code AND hospCode = :f_hospCode")
	public Integer updateOfenUsedHangmogInfo(@Param("f_often_use") String oftenUse,
			@Param("f_memb_gubun") String membGubun,
			@Param("f_hangmog_code") String hangmogCode,
			@Param("f_hospCode") String hospCode);
	@Modifying
	@Query("UPDATE Ocs0212 SET oftenUse = :f_often_use  WHERE membGubun   = :f_memb_gubun AND memb    = :f_memb "
			+ " AND hangmogCode = :f_hangmog_code  AND hospCode    = :f_hospCode ")
	public Integer updateSaveOfenUsedHangmogInfo(@Param("f_hospCode") String hospCode,
			@Param("f_often_use") String oftenUse,
			@Param("f_memb_gubun") String membGubun,
			@Param("f_memb") String memb,
			@Param("f_hangmog_code") String hangmogCode);
	
	@Query("SELECT DISTINCT 'Y' FROM Ocs0212 WHERE memb = :f_memb AND hangmogCode = :f_hangmog_code AND hospCode = :f_hospCode")
	public String getRetValOCS0203U00SaveLayout(
			@Param("f_memb") String memb,
			@Param("f_hangmog_code") String hangmogCode,
			@Param("f_hospCode") String hospCode);
	
	@Modifying
	@Query("UPDATE Ocs0212 SET updId = :f_user_id, updDate = :f_sys_date, seq = :f_seq, oftenUse = :f_often_use "
			+ " WHERE memb = :f_memb AND hangmogCode = :f_hangmog_code AND hospCode = :f_hospCode")
	public Integer updateOCS0203U00SaveLayout(
			@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_seq") Double seq,
			@Param("f_often_use") String oftenUse,
			@Param("f_memb") String memb,
			@Param("f_hangmog_code") String hangmogCode,
			@Param("f_hospCode") String hospCode);
}

