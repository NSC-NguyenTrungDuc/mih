package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrBabyFood;

public interface BabyFoodRepository extends JpaRepository<PhrBabyFood, Long>, BabyFoodRepositoryCustom{
	
	@Query("select H from PhrBabyFood H where H.profileId = :profileId and H.activeFlg = 1 order by H.eatingTime desc")
	public List<PhrBabyFood> getListBabyFoodByProfileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select H from PhrBabyFood H where H.id = :babyFoodId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrBabyFood getBabyFoodByProfileId(@Param("babyFoodId") Long babyFoodId, @Param("profileId") Long profileId);

	@Modifying
	@Query("UPDATE PhrBabyFood SET activeFlg = :activeFlg WHERE id = :babyFoodId and profileId =:profileId")
	public Integer updateActiveFlg(@Param("babyFoodId") Long babyFoodId, @Param("profileId") Long profileId, @Param("activeFlg") Integer activeFlg);
}
	