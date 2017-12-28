package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.phr.PhrAccountClinic;

@Repository
public interface AccountClinicRepository extends JpaRepository<PhrAccountClinic, Long>, AccountClinicRepositoryCustom {

	@Modifying
	@Query("SELECT a FROM PhrAccountClinic a WHERE a.profileId = :f_profile_id AND a.activeFlg = 1")
	public List<PhrAccountClinic> findByProfileId(@Param("f_profile_id") Long profileId);
	
	@Modifying
	@Query("SELECT a FROM PhrAccountClinic a WHERE a.profileId = :f_profile_id")
	public List<PhrAccountClinic> findByProfileIdMbs(@Param("f_profile_id") Long profileId);
	
	@Modifying
	@Query("SELECT a FROM PhrAccountClinic a WHERE a.profileId = :f_profile_id AND a.activeFlg = 1 AND username NOT LIKE CONCAT(:f_common_username,'%')")
	public List<PhrAccountClinic> findByProfileIdIgnoreCommonAccount(@Param("f_profile_id") Long profileId, @Param("f_common_username") String commonUsername);
	
	@Modifying
	@Query("SELECT a FROM PhrAccountClinic a WHERE a.username = :f_username")
	public List<PhrAccountClinic> findByUsername(@Param("f_username") String username);
	
	@Modifying
	@Query("UPDATE PhrAccountClinic T SET T.activeClinicAccountFlg = 0 WHERE T.profileId = :f_profile_id AND T.activeFlg = 1 AND T.activeClinicAccountFlg = 1")
	public Integer deactiveByProfileId(@Param("f_profile_id") Long profileId);
	
	@Modifying
	@Query("UPDATE PhrAccountClinic T SET T.activeClinicAccountFlg = 1 WHERE T.profileId = :f_profile_id AND id = :f_account_id AND T.activeFlg = 1")
	public Integer setActiveAccount(@Param("f_profile_id") Long profileId, @Param("f_account_id") Long accountId);

	@Modifying
	@Query("SELECT T FROM PhrAccountClinic T WHERE T.profileId = :f_profile_id AND T.activeFlg = 1 AND T.activeClinicAccountFlg = 1")
	public List<PhrAccountClinic> findActiveAccountByProfileId(@Param("f_profile_id") Long profileId);
	
	@Modifying
	@Query("SELECT T FROM PhrAccountClinic T WHERE T.hospCode = :f_hosp_code AND T.patientCode = :f_patient_code AND T.profileId = :f_profileId AND T.activeFlg = 1 ")
	public List<PhrAccountClinic> findByHospCodeAndPatientCodeAndProfileId(@Param("f_hosp_code") String hospCode, @Param("f_patient_code") String patientCode, @Param("f_profileId") Long profileId);

	@Modifying
	@Query("SELECT T FROM PhrAccountClinic T WHERE T.hospCode = :f_hosp_code AND T.patientCode = :f_patient_code  AND T.activeFlg = 1 ")
	public List<PhrAccountClinic> findByHospCodeAndPatientCode(@Param("f_hosp_code") String hospCode, @Param("f_patient_code") String patientCode);

	@Query("SELECT T.profileId FROM PhrAccountClinic T WHERE T.hospCode = :f_hosp_code AND T.patientCode = :f_patient_code AND T.activeClinicAccountFlg = 1 AND T.activeFlg = 1 ")
	public List<Long> getProfileIdByHospCodeAndPatientCode(@Param("f_hosp_code") String hospCode, @Param("f_patient_code") String patientCode);
	
	@Modifying
	@Query("UPDATE PhrAccountClinic T SET T.patientCode = :f_patient_code WHERE T.profileId = :f_profile_id AND hospCode = :f_hosp_code AND T.sysId = 'MBSO'")
	public Integer updatePatientCode(@Param("f_patient_code") String patientCode, @Param("f_profile_id") Long profileId, @Param("f_hosp_code") String hopsCode);
	
}
