package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.bas.Bas0260;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0260Repository extends JpaRepository<Bas0260, Long>, Bas0260RepositoryCustom {
	@Query("SELECT a FROM Bas0260 a WHERE a.hospCode = :hosp_code AND a.language = :language AND a.gwa LIKE :code "+
		   " AND STR_TO_DATE(:buseo_ymd, '%Y/%m/%d') BETWEEN a.startDate AND a.endDate "+
		   " AND(a.gwa LIKE :find1 OR a.gwaName LIKE :find1) AND a.buseoGubun = '1' AND a.useYn = 'Y' ORDER BY a.gwa ")
	public List<Bas0260> getBas0270ComboListItemInfo(
			@Param("hosp_code") String hospCode,
			@Param("language") String language,
			@Param("code") String code,
			@Param("buseo_ymd") String buseo_ymd,
			@Param("find1") String find1 );

	@Query("SELECT a.gwaName FROM Bas0260 a WHERE a.hospCode = :hosp_code AND a.language = :language AND "
			+ "STR_TO_DATE(:buseo_ymd, '%Y/%m/%d') BETWEEN a.startDate AND a.endDate "+
			" AND a.gwa = :gwa ")
	public List<String> getBAS0270LayGwa(
			@Param("hosp_code") String hospCode,
			@Param("language") String language,
			@Param("buseo_ymd") String buseo_ymd,
			@Param("gwa") String gwa );
	
	@Modifying
	@Query("	UPDATE Bas0260																		 "
			+"	SET updId   = :updId                                                                 "
			+"	  , updDate  = SYSDATE()                                                             "
			+"	  , endDate   = :endDate						                                     "
			+"	WHERE hospCode  = :hospCode                                                          "
			+"	  AND buseoCode = :buseoCode                                                         "
			+"	  AND startDate <> STR_TO_DATE(:startDate,  '%Y/%m/%d')                                "
			+"	  AND STR_TO_DATE(:startDate,  '%Y/%m/%d') BETWEEN startDate AND endDate             "
			+ "	  AND language = :language                                                           ")
	public Integer updateBas0260U00TransactionAdded(
			@Param("updId") String updId,
			@Param("hospCode") String hospCode,
			@Param("buseoCode") String buseoCode,
			@Param("endDate") Date endDate,
			@Param("startDate") String startDate,
			@Param("language") String language);

	@Modifying                                                 
	@Query("	UPDATE Bas0260								   "
			+"	  SET updDate            = SYSDATE()           " 
			+"	    , updId              = :updId              " 
			+"	    , buseoName          = :buseoName          " 
			+"	    , parentBuseo        = :parentBuseo        " 
			+"	    , buseoGubun         = :buseoGubun         " 
			+"	    , gwaGubun           = :gwaGubun           " 
			+"	    , gwa                = :gwa                " 
			+"	    , gwaName            = :gwaName            " 
			+"	    , parentGwa          = :parentGwa          " 
			+"	    , outJubsuYn         = :outJubsuYn         " 
			+"	    , ipwonYn            = :ipwonYn            " 
			+"	    , outSlipYn          = :outSlipYn          " 
			+"	    , inpSlipYn          = :inpSlipYn          " 
			+"	    , euryoseoYn         = :euryoseoYn         " 
			+"	    , outMoveYn          = :outMoveYn          " 
			+"	    , outJundalPartYn    = :outJundalPartYn    " 
			+"	    , inpJundalPartYn    = :inpJundalPartYn    " 
			+"	    , inputGubun        = :inputGubun          " 
			+"	    , moveComment       = :moveComment         " 
			+"	    , tel               = :tel                " 
			+"	    , gwaEname          = :gwaEname            " 
			+"	    , gwaSname          = :gwaSname            " 
			+"	    , gwaSort1          = :gwaSort1            " 
			+"	    , gwaSort2          = :gwaSort2            " 
			+"	    , rmk               = :rmk                 " 
			+"	    , endDate           = :endDate             " 
			+"	    , buseoName2        = :buseoName2          " 
			+"	    , gwaColor          = :gwaColor       	   " 
			+"	    , hpcHoDongYn       = :hpcHoDongYn         "
			+"	    , addDoctor         = :addDoctor           " 
			+"	    , gwaNameKana       = :gwaNameKana         " 
			+"	    , useYn             = :useYn               "
			+"	WHERE hospCode          = :hospCode            " 
			+"	  AND buseoCode         = :buseoCode           " 
			+"	  AND startDate         = :startDate         "
			+ "	  AND language = :language                   ")
	public Integer updateBas0260U00TransactionModified(
			@Param("updId") String updId,
			@Param("buseoName") String buseoName,
			@Param("parentBuseo") String parentBuseo,
			@Param("buseoGubun") String buseoGubun,
			@Param("gwaGubun") String gwaGubun,
			@Param("gwa") String gwa,
			@Param("gwaName") String gwaName,
			@Param("parentGwa") String parentGwa,
			@Param("outJubsuYn") String outJubsuYn,
			@Param("ipwonYn") String ipwonYn,
			@Param("outSlipYn") String outSlipYn,
			@Param("inpSlipYn") String inpSlipYn,
			@Param("euryoseoYn") String euryoseoYn,
			@Param("outMoveYn") String outMoveYn,
			@Param("outJundalPartYn") String outJundalPartYn,
			@Param("inpJundalPartYn") String inpJundalPartYn,
			@Param("inputGubun") String inputGubun,
			@Param("moveComment") String moveComment,
			@Param("tel") String tel,
			@Param("gwaEname") String gwaEname,
			@Param("gwaSname") String gwaSname,
			@Param("gwaSort1") Double gwaSort1,
			@Param("gwaSort2") Double gwaSort2,
			@Param("rmk") String rmk,
			@Param("endDate") Date endDate,
			@Param("buseoName2") String buseoName2,
			@Param("gwaColor") String gwaColor,
			@Param("hpcHoDongYn") String hpcHoDongYn,
			@Param("addDoctor") String addDoctor,
			@Param("gwaNameKana") String gwaNameKana,
			@Param("hospCode") String hospCode,
			@Param("buseoCode") String buseoCode,
			@Param("startDate") Date startDate,
			@Param("language") String language,
			@Param("useYn") String useYn);
	
	@Modifying
	@Query("	UPDATE Bas0260											   "
			+"	SET updId      = :updId                                    "
			+"	    , updDate    = :updDate                             "
			+"	    , endDate    = STR_TO_DATE('9998/12/31', '%Y/%m/%d')   "
			+"	WHERE hospCode   = :hospCode                               "
			+"	  AND buseoCode  = :buseoCode                              "
			+"	  AND endDate    = :endDate                                "
			+ "	  AND language = :language                                 ")
	public Integer updateBas0260U00TransactionDeleted(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("hospCode") String hospCode,
			@Param("buseoCode") String buseoCode,
			@Param("endDate") Date endDate,
			@Param("language") String language);
	
	@Modifying
	@Query("	DELETE FROM Bas0260 					  "
			+"	WHERE hospCode        = :hospCode         "
			+"	  AND buseoCode       = :buseoCode        "
			+"	  AND startDate       = :startDate        "
			+ "	  AND language = :language                ")
	public Integer delete0260U00TransactionDeleted(
			@Param("hospCode") String hospCode,
			@Param("buseoCode") String buseoCode,
			@Param("startDate") Date startDate,
			@Param("language") String language);
	
	@Modifying
	@Query("	UPDATE Bas0260											   "
			+"	SET updId      = :updId                                    "
			+"	    , updDate            = SYSDATE()                       "
			+"	    , avgTime    = :avgTime   							   "
			+"	WHERE hospCode   = :hospCode                               "
			+"	  AND gwa    	= :gwa                                	   "
			+ "	  AND language = :language                                 ")
	public Integer updateBas0260U00FromMbs(
			@Param("updId") String updId,
			@Param("avgTime") Double avgTime,
			@Param("hospCode") String hospCode,
			@Param("gwa") String gwa,
			@Param("language") String language);
	
	@Query("SELECT a FROM Bas0260 a WHERE a.hospCode = :hosp_code AND a.language = :language AND a.buseoGubun = :buseoGubun ORDER BY gwa ")
	public List<Bas0260> findByHospCodeBuseoGubun(
			@Param("hosp_code") String hospCode,
			@Param("language") String language,
			@Param("buseoGubun") String buseoGubun);
	
	@Query("SELECT a FROM Bas0260 a WHERE a.hospCode = :hosp_code AND a.language = :language AND a.gwa = :gwa AND STR_TO_DATE(:fDate, '%Y/%m/%d') BETWEEN a.startDate AND a.endDate ")
	public List<Bas0260> findByHospCodeGwaFDate(@Param("hosp_code") String hospCode,
												@Param("language") String language,
												@Param("gwa") String gwa,
												@Param("fDate") String fDate);
	
	@Query("SELECT a FROM Bas0260 a WHERE a.hospCode = :hosp_code AND a.language = :language AND a.gwa = :gwa AND a.buseoGubun = :buseoGubun AND STR_TO_DATE(:fDate, '%Y/%m/%d') BETWEEN a.startDate AND a.endDate ")
	public List<Bas0260> findByHospCodeGwaBuseoGubunFDate(@Param("hosp_code") String hospCode,
												@Param("language") String language,
												@Param("gwa") String gwa,
												@Param("buseoGubun") String buseoGubun,
												@Param("fDate") String fDate);
	
	@Query("SELECT a FROM Bas0260 a WHERE a.hospCode = :hosp_code AND a.language = :language AND a.buseoGubun = :buseoGubun AND SYSDATE() BETWEEN a.startDate AND a.endDate ")
	public List<Bas0260> findByHospCodeGwaBuseoGubunSysDate(@Param("hosp_code") String hospCode, @Param("language") String language, @Param("buseoGubun") String buseoGubun);
}

