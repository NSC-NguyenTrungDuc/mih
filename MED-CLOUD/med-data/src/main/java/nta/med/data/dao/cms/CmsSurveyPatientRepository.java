package nta.med.data.dao.cms;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.cms.CmsSurveyPatient;

@Repository
public interface CmsSurveyPatientRepository extends JpaRepository<CmsSurveyPatient, Long>, CmsSurveyPatientRepositoryCustom{
	
	@Query(" SELECT S FROM CmsSurveyPatient S WHERE S.id =:id AND S.hospCode = :hospCode AND S.activeFlg = 1 ")
	public CmsSurveyPatient getSurveyPatientById(@Param("id") Long id,  @Param("hospCode") String hospCode);
	
	@Query(" SELECT S FROM CmsSurveyPatient S WHERE S.token = :token AND S.activeFlg = 1 ")
	public CmsSurveyPatient getSurveyPatientByToken( @Param("token") String token);

	@Query(" SELECT S.result FROM CmsSurveyPatient S WHERE S.id =:id")
	public String getXmlResult(@Param("id") Long id);

	@Query(" SELECT S FROM CmsSurveyPatient S WHERE S.cmsSurveyId = :id AND S.patientCode = :bunho AND S.departmentCode = :gwa AND S.hospCode = :hospCode AND S.activeFlg = 1 ")
	public List<CmsSurveyPatient> findByPatientId(@Param("id") BigInteger id,
			@Param("bunho") String bunho,
			@Param("gwa") String gwa,
			@Param("hospCode") String hospCode);

	@Query(" SELECT S FROM CmsSurveyPatient S WHERE S.patientCode = :bunho AND S.departmentCode = :gwa AND S.hospCode = :hospCode AND S.reservationCode = :reservationCode ")
	public List<CmsSurveyPatient> findByPatientIdAndReservationCodeAnDepartmentCode(
												  @Param("bunho") String bunho,
												  @Param("gwa") String gwa,
												  @Param("hospCode") String hospCode,   
												  @Param("reservationCode") String reservationCode);

	@Query(" SELECT S FROM CmsSurveyPatient S WHERE S.patientCode = :bunho AND S.hospCode = :hospCode and S.statusFlg = 1 order by created desc ")
	public List<CmsSurveyPatient> findByPatientIdAndHospCode(
			@Param("bunho") String bunho,
			@Param("hospCode") String hospCode);

	@Modifying
	@Query(" UPDATE CmsSurveyPatient SET result = :xmlRecord WHERE id = :id AND hospCode = :hospCode AND patientCode = :patientCode")
	public Integer updateCmsSurveyPatient(@Param("xmlRecord") String xmlRecord, @Param("id") Long id,
			@Param("hospCode") String hospCode,
			@Param("patientCode") String patientCode
			);
	
	@Query(" SELECT S FROM CmsSurveyPatient S WHERE S.id != :id AND S.patientCode = :patientCode AND S.statusFlg = :statusFlg order by S.id desc")
	public List<CmsSurveyPatient> findByPatientCodeAndStatusFlg(@Param("id") Long id, 
			@Param("patientCode")String patientCode, 
			@Param("statusFlg")BigDecimal statusFlg);

	
	@Modifying
	@Query(" UPDATE CmsSurveyPatient SET cmsSurveyId = :cmsSurveyId WHERE id = :id AND hospCode = :hospCode")
	public Integer changeSurvey(@Param("cmsSurveyId") BigInteger cmsSurveyId, 
			@Param("id") Long id,
			@Param("hospCode") String hospCode);
	
	@Query(" SELECT S FROM CmsSurveyPatient S WHERE S.patientCode = :bunho AND S.departmentCode = :gwa AND S.hospCode = :hospCode AND S.reservationCode = :reservationCode AND S.activeFlg = 1 ")
	public List<CmsSurveyPatient> findByPatientIdReservationCodeDepartmentCode(
												  @Param("bunho") String bunho,
												  @Param("gwa") String gwa,
												  @Param("hospCode") String hospCode,   
												  @Param("reservationCode") String reservationCode);

	
}
