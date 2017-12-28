package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.phr.PhrStandardHealthBfp;

@Repository
public interface StandardHealthBfpRepository extends JpaRepository<PhrStandardHealthBfp, Long>,  StandardHealthBfpRepositoryCustom{
	@Query("select P from PhrStandardHealthBfp P where P.profileId = :profileId and P.activeFlg = 1 order by P.datetimeRecord desc")
	public List<PhrStandardHealthBfp> getPhrStandardHealthBfpByprofileId(@Param("profileId") Long profileId, Pageable pageable);

	@Query("select H from PhrStandardHealthBfp H where H.id = :healthId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrStandardHealthBfp getHealthBfpByProfileId(@Param("healthId") Long healthId, @Param("profileId") Long profileId);

	@Modifying
	@Query("UPDATE PhrStandardHealthBfp SET activeFlg = :activeFlg WHERE id = :healthId and profileId =:profileId")
	public Integer updateActiveFlg(@Param("healthId") Long healthId, @Param("profileId") Long profileId, @Param("activeFlg") Integer activeFlg);
	
	@Query("select P from PhrStandardHealthBfp P where P.profileId = :profileId and P.activeFlg = 1 order by P.datetimeRecord desc")
	public List<PhrStandardHealthBfp> getPhrStandardHealthBfpByprofileIdAndType(@Param("profileId") Long profileId);

	@Query("select S from PhrStandardHealthBfp S where S.profileId = :profileId and S.activeFlg = 1 and S.datetimeRecord = (select max(H.datetimeRecord) from PhrStandardHealthBfp H where H.profileId = :profileId and H.activeFlg = 1 )")
	public List<PhrStandardHealthBfp> getLastestHealthBfpByProfileId(@Param("profileId") Long profileId);

}
