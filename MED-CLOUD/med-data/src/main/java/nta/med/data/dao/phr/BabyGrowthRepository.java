package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrBabyGrowth;

public interface BabyGrowthRepository extends JpaRepository<PhrBabyGrowth, Long>,  BabyGrowthRepositoryCustom{

	@Query("SELECT bb FROM PhrBabyGrowth bb WHERE bb.profileId = :f_profileId and bb.activeFlg = 1")
	public List<PhrBabyGrowth> getListBabyGrowByProfileId(@Param("f_profileId") Long profileId);
	
	@Query("select bb from PhrBabyGrowth bb where bb.profileId = :profileId and bb.activeFlg = 1 order by bb.timeMeasure desc")
	public List<PhrBabyGrowth> getLimitBabyGrowth(@Param("profileId") Long profileId, Pageable pageable);
}
