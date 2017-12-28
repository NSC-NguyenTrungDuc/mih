package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur9001;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur9001Repository extends JpaRepository<Nur9001, Long>, Nur9001RepositoryCustom {
	
	@Modifying
	@Query(   " UPDATE Nur9001                          "
			+ " SET updId          = :f_user_id,        "
			+ "     updDate        = SYSDATE(),         "
			+ "     recordDate     = :f_record_date,    "
			+ "     recordTime     = :f_record_time,    "
			+ "     soapGubun      = :f_soap_gubun,     "
			+ "     recordContents = :f_record_contents,"
			+ "     nurPlanJin     = :f_nur_plan_jin,   "
			+ "     recordUser     = :f_record_user,    "
			+ "     vald           = 'Y',               "
			+ "     dcYn           = :f_dc_yn,          "
			+ "     dcUser         = :f_dc_user,        "
			+ "     mayakUseYn     = :f_mayak_use_yn,   "
			+ "     fknur4001      = :f_fknur4001       "
			+ " WHERE hospCode     = :f_hosp_code       "
			+ " AND pknur9001      = :f_pknur9001       ")
	public Integer updateByHospCodePknur9001(@Param("f_user_id") 		    String updId        ,
											 @Param("f_record_date") 	    Date   recordDate   ,
											 @Param("f_record_time") 	    String recordTime   ,
											 @Param("f_soap_gubun") 	    String soapGubun    ,
											 @Param("f_record_contents") 	String recordContens,
											 @Param("f_nur_plan_jin") 		String nurPlanJin   ,
											 @Param("f_record_user") 		String recordUser   ,
											 @Param("f_dc_yn") 				String dcYn         ,
											 @Param("f_dc_user") 			String dcUser       ,
											 @Param("f_mayak_use_yn") 		String mayakUseYn   ,
											 @Param("f_fknur4001") 			Double fknur4001    ,
											 @Param("f_hosp_code") 			String hospCode     ,
											 @Param("f_pknur9001") 			Double pknur9001    );
	
	@Modifying
	@Query(   " UPDATE Nur9001                          "
			+ " SET vald           = 'N'                "
			+ " WHERE hospCode     = :f_hosp_code       "
			+ " AND pknur9001      = :f_pknur9001       ")
	public Integer updateValdByHospCodePknur9001(@Param("f_hosp_code")	String hospCode     ,
											 	 @Param("f_pknur9001") 	Double pknur9001    );
	
}

