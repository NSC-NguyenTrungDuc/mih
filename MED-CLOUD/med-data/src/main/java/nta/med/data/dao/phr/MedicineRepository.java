package nta.med.data.dao.phr;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrMedicine;

public interface MedicineRepository extends JpaRepository<PhrMedicine, Long>, MedicineRepositoryCustom {

	@Query("select M from PhrMedicine M where M.profileId = :profileId and M.timeTakeMedicine >= :currentTime and M.activeFlg = 1 order by M.timeTakeMedicine ASC")
	public List<PhrMedicine> getMedicineByProfileId(@Param("profileId") Long profileId, @Param("currentTime") Date currentTime);
	
	@Query("select M from PhrMedicine M where M.profileId = :profileId and M.activeFlg = 1 order by M.timeTakeMedicine desc")
	public List<PhrMedicine> getLimitMedicine(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select P from PhrMedicine P where P.syncId = :syncId ")
	public List<PhrMedicine> getMedicineBySyncId(@Param("syncId") BigInteger syncId);

	@Query("select M from PhrMedicine M where M.prescriptionId = :prescriptionId and M.activeFlg = 1 order by M.created desc")
	public List<PhrMedicine> getMedicineDetail(@Param("prescriptionId") Long prescriptionId, Pageable pageable);
	
	@Query("SELECT a FROM PhrMedicine a WHERE a.syncId NOT IN ( :syncIds ) AND a.profileId IN ( :profileIds ) ")
	public List<PhrMedicine> getMedicineByListSyncId(@Param("syncIds") List<BigInteger> syncIds,  @Param("profileIds") List<Long> profileIds);
	
	@Query("SELECT a FROM PhrMedicine a WHERE a.profileId IN ( :profileIds ) ")
	public List<PhrMedicine> getMedicineByListProfileIds(@Param("profileIds") List<Long> profileIds);
	
	@Query("select M from PhrMedicine M where M.id = :id and M.profileId = :profileId and M.prescriptionId = :prescriptionId and M.activeFlg = 1 ")
	public PhrMedicine getMedicineByIdAndProfileIdAndPrescriptionId(@Param("id") Long id, @Param("profileId") Long profileId, @Param("prescriptionId") Long prescriptionId);
}
