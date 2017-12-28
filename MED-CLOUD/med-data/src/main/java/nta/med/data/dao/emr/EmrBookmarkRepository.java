package nta.med.data.dao.emr;

import nta.med.core.domain.emr.EmrBookmark;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

public interface EmrBookmarkRepository extends JpaRepository<EmrBookmark, Long>, EmrBookmarkRepositoryCustom {
	@Modifying	
	@Query("	UPDATE 									"
			+ "	EmrBookmark                            "
			+ "	SET                                     "
			+ "	bookmarkText = :f_bookmark_text        "
			+ "	, updId = :f_upd_id                    "
			+ "	WHERE                                   "
			+ "	emrBookmarkId = :f_emr_bookmark_id    ")
	public Integer updateOCS2015U04EditBookmark (
			@Param("f_bookmark_text") String bookmarkTest,
			@Param("f_upd_id") String updId,
			@Param("f_emr_bookmark_id") Integer emrBookmarkId
			);
	
	@Modifying	
	@Query("	UPDATE 							"
			+ "	EmrBookmark                            "
			+ "	SET                                     "
			+ "	bookmarkText = :f_bookmark_text        "
			+ "	, updId = :f_upd_id                    "
			+ "	WHERE                                   "
			+ "	emrBookmarkId = :f_emr_bookmark_id    "
			+ "	AND sysId = :f_upd_id                  "
			+ "	AND pkout1001=:f_pkout1001              ")
	public Integer updateOCS2015U04EditBookmarkByPkout1001 (
			@Param("f_bookmark_text") String bookmarkTest,
			@Param("f_upd_id") String updId,
			@Param("f_emr_bookmark_id") Integer emrBookmarkId,
			@Param("f_upd_id") String sysId,
			@Param("f_pkout1001") Double pkout1001
			);
	
	@Modifying	
	@Query("	UPDATE 								"
			+ "	EmrBookmark                        "
			+ "	SET                                 "
			+ "	activeFlg = '0'                      "
			+ "	WHERE                               "
			+ "	emrBookmarkId = :f_emr_bookmark_id    ")
	public Integer updateOCS2015U04DeleteBookmark(
			@Param("f_emr_bookmark_id") Integer emrBookmarkId
			);


}
