package nta.med.data.dao.phr;

import java.util.Date;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardFoodMenu;

public interface StandardFoodMenuRepository extends JpaRepository<PhrStandardFoodMenu, Long>,  StandardFoodMenuRepositoryCustom{
	
	@Query("select F from PhrStandardFoodMenu F where F.profileId = :profileId and F.eatingTime >= :fr_date and F.eatingTime <= :to_date and F.activeFlg = 1")
	public List<PhrStandardFoodMenu> getKcalByProfileId(@Param("profileId") Long profileId, @Param("fr_date") Date frDate, @Param("to_date") Date toDate);
	
	@Query("select a from PhrStandardFoodMenu a where a.profileId = :profileId and a.id = :id")
	public PhrStandardFoodMenu getDetailStandardFoodMenuById(@Param("profileId") Long profileId, @Param("id") Long id);
	
	@Query("select F from PhrStandardFoodMenu F where F.profileId = :profileId and F.activeFlg = 1 order by F.eatingTime desc")
	public List<PhrStandardFoodMenu> getLimitStandardFood(@Param("profileId") Long profileId, Pageable pageable);
}
