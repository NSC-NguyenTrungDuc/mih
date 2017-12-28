package nta.med.data.dao.phr;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardFoodTotalFat;

public interface StandardFoodTotalFatRepository extends JpaRepository<PhrStandardFoodTotalFat, Long>,  StandardFoodTotalFatRepositoryCustom{
	
	@Query("select F from PhrStandardFoodTotalFat F where F.profileId = :profileId and F.activeFlg = 1 order by F.eatingTime desc")
	public List<PhrStandardFoodTotalFat> getLimitStandardFoodTotalFat(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select a from PhrStandardFoodTotalFat a where a.profileId = :profileId and a.id = :id and a.activeFlg = 1 ")
	public PhrStandardFoodTotalFat getDetailStandardFoodTotalFatByIdAndProfileIdAndActiveFlg(@Param("profileId") Long profileId, @Param("id") Long id);
	
	@Query("select a from PhrStandardFoodTotalFat a where a.profileId = :profileId and a.id = :id")
	public PhrStandardFoodTotalFat getDetailStandardFoodTotalFatByIdAndProfileId(@Param("profileId") Long profileId, @Param("id") Long id);

	@Query("select SUM(S.totalFat) from PhrStandardFoodTotalFat S where S.profileId = :profileId and S.activeFlg = 1 and DATE_FORMAT(S.eatingTime, '%Y%m%d') = DATE_FORMAT(SYSDATE(), '%Y%m%d') ")
	public BigDecimal getLastestFoodTotalFatByProfileId(@Param("profileId") Long profileId);
}
