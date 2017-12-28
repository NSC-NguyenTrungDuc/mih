package nta.med.data.dao.medi.bas;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.bas.Bas0253;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0253Repository extends JpaRepository<Bas0253, Long>, Bas0253RepositoryCustom {
	
	@Query(" SELECT T FROM Bas0253 T WHERE hospCode = :f_hosp_code AND hoDong = :f_ho_dong "
			+ "AND hoCode = :f_ho_code AND bedNo = :f_bed_no AND fromBedDate = STR_TO_DATE(:f_from_bed_date, '%Y/%m/%d') ")
	public List<Bas0253> findByHoDongHoCodeBedNoFromBedDate(@Param("f_hosp_code") String hospCode, 
															@Param("f_ho_dong") String hoDong,
															@Param("f_ho_code") String hoCode,
															@Param("f_bed_no") String bedNo,
															@Param("f_from_bed_date") String fromBedDate); 
	
	@Modifying
	@Query("DELETE FROM Bas0253 WHERE hospCode = :f_hosp_code AND hoCode = :f_ho_code AND hoDong = :f_ho_dong AND bedNo = :f_bed_no AND fromBedDate = STR_TO_DATE(:f_from_bed_date,'%Y/%m/%d')	")
	public Integer deleteByHospCodeHoCodeHoDongBedNoFromBedDate(@Param("f_hosp_code") String hospCode,
																@Param("f_ho_code") String hoCode,
																@Param("f_ho_dong") String hoDong,
																@Param("f_bed_no") String bedNo,
																@Param("f_from_bed_date") String fromBedDate);
	
	@Modifying
	@Query("UPDATE Bas0253 SET bedStatus = :f_bed_status, bedLockText = :f_bed_lock_text WHERE hospCode = :f_hosp_code AND hoCode = :f_ho_code AND hoDong = :f_ho_dong AND bedNo = :f_bed_no "
			+ "AND SYSDATE() BETWEEN fromBedDate AND IFNULL(toBedDate, STR_TO_DATE('99981231','%Y%m%d')) ")
	public Integer updateSetBedStatus(	@Param("f_hosp_code") String hospCode,
										@Param("f_ho_code") String hoCode,
										@Param("f_ho_dong") String hoDong,
										@Param("f_bed_no") String bedNo,
										@Param("f_bed_status") String bedStatus,
										@Param("f_bed_lock_text") String bedLockText);
}

