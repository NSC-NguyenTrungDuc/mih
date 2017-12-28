package nta.med.data.dao.medi.nur;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0115;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0115Repository extends JpaRepository<Nur0115, Long>, Nur0115RepositoryCustom {
	
	@Modifying
	@Query(   " UPDATE Nur0115                             "
			+ "  SET updDate         = SYSDATE()         , "
			+ "      updId           = :q_user_id        , "
			+ "      hangmogCode     = :f_hangmog_code   , "
			+ "      suryang         = :f_suryang        , "
			+ "      dv              = :f_dv             , "
			+ "      dvTime          = :f_dv_time        , "
			+ "      nalsu           = :f_nalsu          , "
			+ "      bogyongCode     = :f_bogyong_code   , "
			+ "      jusaCode        = :f_jusa_code      , "
			+ "      jusaSpdGubun    = :f_jusa_spd_gubun , "
			+ "      ordDanui        = :f_ord_danui      , "
			+ "      bomSourceKey    = :f_bom_source_key , "
			+ "      startDate       = :f_start_date     , "
			+ "      endDate         = :f_end_date         "
			+ " WHERE hospCode       = :f_hosp_code        "
			+ "  AND nurGrCode       = :f_nur_gr_code      "
			+ "  AND nurMdCode       = :f_nur_md_code      "
			+ "  AND nurSoCode       = :f_nur_so_code      "
			+ "  AND seq             = :f_seq              ")
	public Integer updateByHospCodeNurGrCodeNurMdCodeNurSoCodeSeq(@Param("q_user_id") String updId,
																@Param("f_hangmog_code") String hangmogCode,
																@Param("f_suryang") Double suryang,
																@Param("f_dv") Double dv,
																@Param("f_dv_time") String dvTime,
																@Param("f_nalsu") Double nalsu,
																@Param("f_bogyong_code") String bogyongCode,
																@Param("f_jusa_code") String jusaCode,
																@Param("f_jusa_spd_gubun") String jusaSpdGubun,
																@Param("f_ord_danui") String ordDanui,
																@Param("f_bom_source_key") String bomSourceKey,
																@Param("f_start_date") Date startDate,
																@Param("f_end_date") Date endDate,
																@Param("f_hosp_code") String hospCode,
																@Param("f_nur_gr_code") String nurGrCode,
																@Param("f_nur_md_code") String nurMdCode,
																@Param("f_nur_so_code") String nurSoCode,
																@Param("f_seq") Double seq);
	
	@Modifying
	@Query(   " DELETE Nur0115                             "
			+ " WHERE hospCode       = :f_hosp_code        "
			+ "  AND nurGrCode       = :f_nur_gr_code      "
			+ "  AND nurMdCode       = :f_nur_md_code      "
			+ "  AND nurSoCode       = :f_nur_so_code      "
			+ "  AND seq             = :f_seq              ")
	public Integer deleteByHospCodeNurGrCodeNurMdCodeNurSoCodeSeq(@Param("f_hosp_code") String hospCode,
																  @Param("f_nur_gr_code") String nurGrCode,
																  @Param("f_nur_md_code") String nurMdCode,
																  @Param("f_nur_so_code") String nurSoCode,
																  @Param("f_seq") Double seq);
	
}

