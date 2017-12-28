package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur4005;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur4005Repository extends JpaRepository<Nur4005, Long>, Nur4005RepositoryCustom {

	@Query("SELECT T FROM Nur4005 T WHERE T.hospCode = :hospCode AND T.fknur4001 = :fknur4001")
	public List<Nur4005> findByHospCodeFknur4001(@Param("hospCode") String hospCode,
			@Param("fknur4001") Double fknur4001);
	
	@Modifying
	@Query(   " UPDATE Nur4005                            "
			+ "    SET updDate         = SYSDATE()        "
			+ "      , updId           = :f_user_id       "
			+ "      , gubun           = :f_gubun         "
			+ "      , valuContens     = :f_valu_contents "
			+ "      , valuDate        = :f_valu_date     "
			+ "      , valuer          = :f_valuer        "
			+ "  WHERE hospCode        = :f_hosp_code     "
			+ "    AND fknur4001       = :f_fknur4001     "
			+ "    AND rerserDate      = :f_reser_date    ")
	public Integer updateByHospCodeFknur4001RerserDate(@Param("f_user_id") String updId      ,
													   @Param("f_gubun") String gubun      	,
													   @Param("f_valu_contents") String valuContens,
													   @Param("f_valu_date") Date valuDate   ,
													   @Param("f_valuer") String valuer     ,
													   @Param("f_hosp_code") String hospCode   ,
													   @Param("f_fknur4001") Double fknur4001  ,
													   @Param("f_reser_date") Date rerserDate );
	
	@Modifying
	@Query(   " DELETE Nur4005                            "
			+ "  WHERE hospCode        = :f_hosp_code     "
			+ "    AND fknur4001       = :f_fknur4001     "
			+ "    AND rerserDate      = :f_reser_date    ")
	public Integer deleteByHospCodeFknur4001RerserDate(@Param("f_hosp_code") String hospCode   ,
													   @Param("f_fknur4001") Double fknur4001  ,
													   @Param("f_reser_date") Date rerserDate );
}

