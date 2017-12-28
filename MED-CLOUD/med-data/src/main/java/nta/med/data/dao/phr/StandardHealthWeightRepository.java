package nta.med.data.dao.phr;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardHealthWeight;

public interface StandardHealthWeightRepository extends JpaRepository<PhrStandardHealthWeight, Long>, StandardHealthWeightRepositoryCustom {
	
	@Query("select P from PhrStandardHealthWeight P where P.profileId = :profileId and P.activeFlg = 1 order by P.datetimeRecord desc")
	public List<PhrStandardHealthWeight> getPhrStandardHealthWeightByprofileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select T from PhrStandardHealthWeight T where T.syncId = :syncId ")
	public List<PhrStandardHealthWeight> getStandardHealthWeightBySyncId(@Param("syncId") BigInteger syncId);

	@Modifying
	@Query(" UPDATE PhrStandardHealthWeight SET activeFlg = 0 WHERE syncId = :syncId ")
	public void deleteStandardHealthWeightBySyncId(@Param("syncId") BigInteger syncId);
	
	@Query("select H from PhrStandardHealthWeight H where H.id = :healthId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrStandardHealthWeight getHealthWeightByProfileId(@Param("healthId") Long healthId, @Param("profileId") Long profileId);
	
	@Modifying
	@Query("UPDATE PhrStandardHealthWeight SET activeFlg = :activeFlg WHERE id = :healthId and profileId =:profileId")
	public Integer updateActiveFlg(@Param("healthId") Long healthId, @Param("profileId") Long profileId, @Param("activeFlg") Integer activeFlg);
	
	@Query("select P from PhrStandardHealthWeight P where P.profileId = :profileId and P.activeFlg = 1 order by P.datetimeRecord desc")
	public List<PhrStandardHealthWeight> getPhrStandardHealthWeightByprofileIdAndType(@Param("profileId") Long profileId);

	@Query("select S from PhrStandardHealthWeight S where S.profileId = :profileId and S.activeFlg = 1 and S.datetimeRecord = (select max(H.datetimeRecord) from PhrStandardHealthWeight H where H.profileId = :profileId and H.activeFlg = 1 )")
	public List<PhrStandardHealthWeight> getLastestHealthWeightByProfileId(@Param("profileId") Long profileId);
}
