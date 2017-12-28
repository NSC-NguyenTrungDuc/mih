package nta.med.data.dao.medi.out;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.out.Out0101;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out0101Repository extends JpaRepository<Out0101, Long>, Out0101RepositoryCustom {
	
	@Modifying
	@Query(  "UPDATE Out0101												  	   "								
			+"          SET updId          = :f_user_id                            "
			+"            , updDate        = SYSDATE()                             "
			+"            , suname          = :f_suname                            "
			+"            , sex             = :f_sex                               "
			+"            , birth           = :f_birth                             "
			+"            , zipCode1       = :f_zip_code1                          "
			+"            , zipCode2       = :f_zip_code2                          "
			+"            , address1        = :f_address1                          "
			+"            , address2        = :f_address2                          "
			+"            , tel             = :f_tel                               "
			+"            , tel1            = :f_tel1                              "
			+"            , gubun           = :f_gubun                             "
			+"            , telHp          = :f_tel_hp                             "
			+"            , email           = :f_email                             "
			+"            , suname2         = :f_suname2                           "
			+"            , telGubun       = :f_tel_gubun                          "
			+"            , telGubun2     = :f_tel_gubun2                          "
			+"            , telGubun3      = :f_tel_gubun3                         "
			+"            , deleteYn       = :f_delete_yn                          "
			+"            , paceMakerYn   = :f_pace_maker_yn                       "
			+"            , selfPaceMaker = :f_self_pace_maker                     "
			+"            , bunhoType      = IFNULL(:f_bunho_type, '0')            "
			+"            , bunhoExt       = 	:f_ref_id                    	   "
			+"            , billingType       = 	:billingType                   "
			+"           WHERE hospCode       = :f_hosp_code                       "
			+"             AND bunho           = :f_bunho               ")
		public Integer updateNuroOUT0101U02Patient(@Param("f_user_id") String userId, 
				@Param("f_suname") String suname,
				@Param("f_sex") String sex,
				@Param("f_birth") Date birth,
				@Param("f_zip_code1") String zipcode1,
				@Param("f_zip_code2") String zipcode2,
				@Param("f_address1") String address1,
				@Param("f_address2") String address2,
				@Param("f_tel") String tel,
				@Param("f_tel1") String tel1,
				@Param("f_gubun") String gubun,
				@Param("f_tel_hp") String telHp,
				@Param("f_email") String email,
				@Param("f_suname2") String suname2,
				@Param("f_tel_gubun") String telGubun,
				@Param("f_tel_gubun2") String telGubun2,
				@Param("f_tel_gubun3") String telGubun3,
				@Param("f_delete_yn") String deleteYn,
				@Param("f_pace_maker_yn") String paceMakerYn,
				@Param("f_self_pace_maker") String selfPaceMaker,
				@Param("f_bunho_type") String bunhoType,
				@Param("f_ref_id") String bunhoExt,
				@Param("f_hosp_code") String hospCode,
				@Param("f_bunho") String bunho,
				@Param("billingType") String billingType);
	
	@Query("select a from Out0101 a where hospCode = :hospCode AND bunho = :bunho")
	List<Out0101> getByBunho(@Param("hospCode") String hospCode, @Param("bunho") String bunho);
	
	@Modifying
	@Query("Update Out0101                             "
      +"   SET zipCode1      = :zipCode1               "
      +"     , zipCode2      = :zipCode2               "
      +"     , address1      = :address1               "
      +"     , address2      = :address2               "
      +"     , tel           = :tel                    "
      +"     , tel1          = :tel1                   "
      +"     , telHp         = :telHp                  "
      +"     , telGubun      = :telGubun               "
      +"     , telGubun2     = :telGubun2              "
      +"     , telGubun3     = :telGubun3              "
      +"     , email         = :email                  "
      +"     , paceMakerYn   = :paceMakerYn            "
      +"     , selfPaceMaker = :selfPaceMaker          "
      +" where hospCode = :hospCode AND bunho = :bunho ")
	public Integer updateOUT0101U04(
			@Param("zipCode1") String zipCode1,
			@Param("zipCode2") String zipCode2,
			@Param("address1") String address1,
			@Param("address2") String address2,
			@Param("tel") String tel,
			@Param("tel1") String tel1,
			@Param("telHp") String telHp,
			@Param("telGubun") String telGubun,
			@Param("telGubun2") String telGubun2,
			@Param("telGubun3") String telGubun3,
			@Param("email") String email,
			@Param("paceMakerYn") String paceMakerYn,
			@Param("selfPaceMaker") String selfPaceMaker,
			@Param("hospCode") String hospCode,
			@Param("bunho") String bunho);

	@Modifying
	@Query("Update Out0101                               "
      +"     SET 										 "
      +"      bunhoType      	     =  3                "
      +" where hospCode = :hospCode AND bunho = :bunho   ")
	public Integer updateOut0101OrcaPatient(@Param("hospCode") String hospCode, 
			@Param("bunho") String bunho);
	
	@Modifying
	@Query(  "UPDATE Out0101												  	   "								
			+"          SET updId          = :f_user_id                            "
			+"            , updDate        = SYSDATE()                             "
			+"            , suname          = :f_suname                            "
			+"            , zipCode1       = :f_zip_code1                          "
			+"            , zipCode2       = :f_zip_code2                          "
			+"            , address1        = :f_address1                          "
			+"            , address2        = :f_address2                          "
			+"            , tel             = :f_tel                               "
			+"            , tel1            = :f_tel1                              "
			+"            , gubun           = :f_gubun                             "
			+"            , telHp          = :f_tel_hp                             "
			+"            , email           = :f_email                             "
			+"            , suname2         = :f_suname2                           "
			+"            , telGubun       = :f_tel_gubun                          "
			+"            , telGubun2     = :f_tel_gubun2                          "
			+"            , telGubun3      = :f_tel_gubun3                         "
			+"            , deleteYn       = :f_delete_yn                          "
			+"            , paceMakerYn   = :f_pace_maker_yn                       "
			+"            , selfPaceMaker = :f_self_pace_maker                     "
			+"            , bunhoType      = IFNULL(:f_bunho_type, '0')            "
			+"            , bunhoExt       = 	:f_ref_id                    	   "
			+"            , billingType       = 	:billingType                   "
			+"           WHERE hospCode       = :f_hosp_code                       "
			+"             AND bunho           = :f_bunho               ")
		public Integer updateNuroOUT0101U02PatientCaseSexIsC(@Param("f_user_id") String userId, 
				@Param("f_suname") String suname,
				@Param("f_zip_code1") String zipcode1,
				@Param("f_zip_code2") String zipcode2,
				@Param("f_address1") String address1,
				@Param("f_address2") String address2,
				@Param("f_tel") String tel,
				@Param("f_tel1") String tel1,
				@Param("f_gubun") String gubun,
				@Param("f_tel_hp") String telHp,
				@Param("f_email") String email,
				@Param("f_suname2") String suname2,
				@Param("f_tel_gubun") String telGubun,
				@Param("f_tel_gubun2") String telGubun2,
				@Param("f_tel_gubun3") String telGubun3,
				@Param("f_delete_yn") String deleteYn,
				@Param("f_pace_maker_yn") String paceMakerYn,
				@Param("f_self_pace_maker") String selfPaceMaker,
				@Param("f_bunho_type") String bunhoType,
				@Param("f_ref_id") String bunhoExt,
				@Param("f_hosp_code") String hospCode,
				@Param("f_bunho") String bunho,
				@Param("billingType") String billingType);
	
	@Modifying
	@Query(" UPDATE Out0101 set pwd = :f_new_pwd WHERE hospCode = :f_hosp_code AND  bunho = :f_bunho ")
	public Integer updatePWD(@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_new_pwd") String newPWD);
	
	@Modifying
	@Query(" UPDATE Out0101 set parentCode = :parentCode WHERE hospCode = :hospCode AND  bunho in ( :childCode ) ")
	public Integer updateParentCodeByPatient(@Param("parentCode") String parentCode,
			@Param("childCode") List<String> childCode,
			@Param("hospCode") String hospCode);
	
	@Query(" SELECT email FROM Out0101 WHERE hospCode = :hospCode AND  bunho = :bunho  ")
	public List<String> getPatientEmail(@Param("hospCode") String hospCode,
			@Param("bunho") String bunho);
	
}

