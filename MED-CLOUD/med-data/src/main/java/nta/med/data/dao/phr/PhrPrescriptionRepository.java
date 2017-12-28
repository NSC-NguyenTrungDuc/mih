package nta.med.data.dao.phr;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.phr.PhrPrescription;

@Repository
public interface PhrPrescriptionRepository extends JpaRepository<PhrPrescription, Long>, PhrPrescriptionRepositoryCustom{
	@Query("select P from PhrPrescription P where P.profileId = :profileId and P.activeFlg = 1 order by P.datetimeRecord desc")
	public List<PhrPrescription> getPrescriptionByProfileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select P from PhrPrescription P where P.id = :id and P.activeFlg = 1 order by P.created desc")
	public List<PhrPrescription> getPrescriptionById(@Param("id") Long id, Pageable pageable);
	
	@Query("select P from PhrPrescription P where P.syncId = :syncId ")
	public List<PhrPrescription> getPrescriptionBySyncId(@Param("syncId") BigInteger syncId);

	@Query("select P from PhrPrescription P where P.prescriptionName = :prescriptionName AND P.source = 'KCCK' AND P.activeFlg = 1 ")
	public List<PhrPrescription> getPrescriptionIdByPrescriptionName(@Param("prescriptionName")  String prescriptionName);
	
	@Query("SELECT a FROM PhrPrescription a WHERE a.syncId NOT IN ( :syncIds ) AND a.profileId IN ( :profileIds ) ")
	public List<PhrPrescription> getPrescriptionByListSyncId(@Param("syncIds") List<BigInteger> syncIds, @Param("profileIds") List<Long> profileIds);
	
	@Query("select P from PhrPrescription P where P.prescriptionName = :prescriptionName AND P.profileId = :profileId AND P.source = 'KCCK' AND P.activeFlg = 1 ")
	public List<PhrPrescription> getPrescriptionIdByPrescriptionNameAndProfileId(@Param("prescriptionName")  String prescriptionName, @Param("profileId")  Long profileId);
	
	@Query("SELECT a FROM PhrPrescription a WHERE a.profileId IN ( :profileIds ) ")
	public List<PhrPrescription> getPrescriptionByListProfileIds(@Param("profileIds") List<Long> profileIds);
	
	@Query("select P from PhrPrescription P where P.id = :id AND P.activeFlg = 1 AND P.profileId = :profileId ")
	public PhrPrescription getPrescriptionByIdAndProfileId(@Param("id") Long id, @Param("profileId")  Long profileId);
}
