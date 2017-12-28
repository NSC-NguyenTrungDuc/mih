package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrBabyGrowthWeight;

public interface BabyGrowthWeightRepository extends JpaRepository<PhrBabyGrowthWeight, Long>, BabyGrowthWeightRepositoryCustom {
	
	@Query("select H from PhrBabyGrowthWeight H where H.id = :growthId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrBabyGrowthWeight getBabyGrowthWeightByIdAndProfileIdAndActiveFlg(@Param("growthId") Long growthId, @Param("profileId") Long profileId);
	
	@Query("select H from PhrBabyGrowthWeight H where H.id = :growthId and H.profileId = :profileId ")
	public PhrBabyGrowthWeight getBabyGrowthWeightByIdAndProfileId(@Param("growthId") Long growthId, @Param("profileId") Long profileId);
	
	@Query("select P from PhrBabyGrowthWeight P where P.profileId = :profileId and P.activeFlg = 1 order by P.timeMeasure desc")
	public List<PhrBabyGrowthWeight> getBabyGrowthWeightByprofileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select S from PhrBabyGrowthWeight S where S.profileId = :profileId and S.activeFlg = 1 and S.timeMeasure = (select max(H.timeMeasure) from PhrBabyGrowthWeight H where H.profileId = :profileId and H.activeFlg = 1 )")
	public List<PhrBabyGrowthWeight> getLastestBabyGrowthWeightByProfileId(@Param("profileId") Long profileId);
}
