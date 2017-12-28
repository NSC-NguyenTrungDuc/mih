package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrBabyMilk;

public interface BabyMilkRepository  extends JpaRepository<PhrBabyMilk, Long>, BabyMilkRepositoryCustom{
	
	@Query("select H from PhrBabyMilk H where H.profileId = :profileId and H.activeFlg = 1 order by H.timeDrinkMilk desc")
	public List<PhrBabyMilk> getListBabyMilkByProfileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select H from PhrBabyMilk H where H.id = :babyMilkId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrBabyMilk getBabyMilkByProfileId(@Param("babyMilkId") Long babyMilkId, @Param("profileId") Long profileId);

	@Modifying
	@Query("UPDATE PhrBabyMilk SET activeFlg = :activeFlg WHERE id = :babyMilkId and profileId =:profileId")
	public Integer updateActiveFlg(@Param("babyMilkId") Long babyMilkId, @Param("profileId") Long profileId, @Param("activeFlg") Integer activeFlg);
}
	