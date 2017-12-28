package nta.med.data.dao.phr;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardFoodCalory;

public interface StandardFoodCaloryRepository extends JpaRepository<PhrStandardFoodCalory, Long>,  StandardFoodCaloryRepositoryCustom{
	
	@Query("select F from PhrStandardFoodCalory F where F.profileId = :profileId and F.activeFlg = 1 order by F.eatingTime desc")
	public List<PhrStandardFoodCalory> getLimitStandardFoodCalory(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select a from PhrStandardFoodCalory a where a.profileId = :profileId and a.id = :id and a.activeFlg = 1 ")
	public PhrStandardFoodCalory getDetailStandardFoodCaloryByIdAndProfileIdAndActiveFlg(@Param("profileId") Long profileId, @Param("id") Long id);
	
	@Query("select a from PhrStandardFoodCalory a where a.profileId = :profileId and a.id = :id")
	public PhrStandardFoodCalory getDetailStandardFoodCaloryByIdAndProfileId(@Param("profileId") Long profileId, @Param("id") Long id);

	@Query("select SUM(S.kcal) from PhrStandardFoodCalory S where S.profileId = :profileId and S.activeFlg = 1 and DATE_FORMAT(S.eatingTime, '%Y%m%d') = DATE_FORMAT(SYSDATE(), '%Y%m%d') ")
	public BigDecimal getLastestFoodCaloryByProfileId(@Param("profileId") Long profileId);
}
