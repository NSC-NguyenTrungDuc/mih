package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.phr.PhrStandardHealthBmi;

@Repository
public interface StandardHealthBmiRepository extends JpaRepository<PhrStandardHealthBmi, Long>,  StandardHealthBmiRepositoryCustom{
	@Query("select P from PhrStandardHealthBmi P where P.profileId = :profileId and P.activeFlg = 1 order by P.datetimeRecord desc")
	public List<PhrStandardHealthBmi> getPhrStandardHealthBmiByprofileId(@Param("profileId") Long profileId, Pageable pageable);

	@Query("select H from PhrStandardHealthBmi H where H.id = :healthId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrStandardHealthBmi getHealthBmiByProfileId(@Param("healthId") Long healthId, @Param("profileId") Long profileId);

	@Modifying
	@Query("UPDATE PhrStandardHealthBmi SET activeFlg = :activeFlg WHERE id = :healthId and profileId =:profileId")
	public Integer updateActiveFlg(@Param("healthId") Long healthId, @Param("profileId") Long profileId, @Param("activeFlg") Integer activeFlg);

	@Query("select P from PhrStandardHealthBmi P where P.profileId = :profileId and P.activeFlg = 1 order by P.datetimeRecord desc")
	public List<PhrStandardHealthBmi> getPhrStandardHealthBmiByprofileIdAndType(@Param("profileId") Long profileId);

	@Query("select S from PhrStandardHealthBmi S where S.profileId = :profileId and S.activeFlg = 1 and S.datetimeRecord = (select max(H.datetimeRecord) from PhrStandardHealthBmi H where H.profileId = :profileId and H.activeFlg = 1 )")
	public List<PhrStandardHealthBmi> getLastestHealthBmiByProfileId(@Param("profileId") Long profileId);
}

