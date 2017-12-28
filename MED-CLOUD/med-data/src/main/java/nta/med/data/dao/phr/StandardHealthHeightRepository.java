package nta.med.data.dao.phr;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardHealthHeight;

public interface StandardHealthHeightRepository extends JpaRepository<PhrStandardHealthHeight, Long>, StandardHealthHeightRepositoryCustom {
	
	@Query("select P from PhrStandardHealthHeight P where P.profileId = :profileId and P.activeFlg = 1 order by P.datetimeRecord desc")
	public List<PhrStandardHealthHeight> getPhrStandardHealthHeightByprofileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select T from PhrStandardHealthHeight T where T.syncId = :syncId ")
	public List<PhrStandardHealthHeight> getStandardHealthHeightBySyncId(@Param("syncId") BigInteger syncId);

	@Modifying
	@Query(" UPDATE PhrStandardHealthHeight SET activeFlg = 0 WHERE syncId = :syncId ")
	public void deleteStandardHealthHeightBySyncId(@Param("syncId") BigInteger syncId);
	
	@Query("select H from PhrStandardHealthHeight H where H.id = :healthId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrStandardHealthHeight getHealthHeightByProfileId(@Param("healthId") Long healthId, @Param("profileId") Long profileId);
	
	@Modifying
	@Query("UPDATE PhrStandardHealthHeight SET activeFlg = :activeFlg WHERE id = :healthId and profileId =:profileId")
	public Integer updateActiveFlg(@Param("healthId") Long healthId, @Param("profileId") Long profileId, @Param("activeFlg") Integer activeFlg);
	
	@Query("select H from PhrStandardHealth H where H.id = :healthId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrStandardHealthHeight getHealthByProfileId(@Param("healthId") Long healthId, @Param("profileId") Long profileId);
	
	@Query("select S from PhrStandardHealthHeight S where S.profileId = :profileId and S.activeFlg = 1 order by S.datetimeRecord desc")
	public List<PhrStandardHealthHeight> getPhrStandardHealthHeightByprofileIdAndType(@Param("profileId") Long profileId);

	@Query("select S from PhrStandardHealthHeight S where S.profileId = :profileId and S.activeFlg = 1 and S.datetimeRecord = (select max(H.datetimeRecord) from PhrStandardHealthHeight H where H.profileId = :profileId and H.activeFlg = 1 )")
	public List<PhrStandardHealthHeight> getLastestHealthHeightByProfileId(@Param("profileId") Long profileId);
}
