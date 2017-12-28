package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrBabyGrowthHeight;

public interface BabyGrowthHeightRepository extends JpaRepository<PhrBabyGrowthHeight, Long>, BabyGrowthHeightRepositoryCustom {

	@Query("select H from PhrBabyGrowthHeight H where H.id = :growthId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrBabyGrowthHeight getBabyGrowthHeightByIdAndProfileIdAndActiveFlg(@Param("growthId") Long growthId, @Param("profileId") Long profileId);
	
	@Query("select H from PhrBabyGrowthHeight H where H.id = :growthId and H.profileId = :profileId ")
	public PhrBabyGrowthHeight getBabyGrowthHeightByIdAndProfileId(@Param("growthId") Long growthId, @Param("profileId") Long profileId);
	
	@Query("select P from PhrBabyGrowthHeight P where P.profileId = :profileId and P.activeFlg = 1 order by P.timeMeasure desc")
	public List<PhrBabyGrowthHeight> getBabyGrowthHeightByprofileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select S from PhrBabyGrowthHeight S where S.profileId = :profileId and S.activeFlg = 1 and S.timeMeasure = (select max(H.timeMeasure) from PhrBabyGrowthHeight H where H.profileId = :profileId and H.activeFlg = 1 )")
	public List<PhrBabyGrowthHeight> getLastestBabyGrowthHeightByProfileId(@Param("profileId") Long profileId);
}
