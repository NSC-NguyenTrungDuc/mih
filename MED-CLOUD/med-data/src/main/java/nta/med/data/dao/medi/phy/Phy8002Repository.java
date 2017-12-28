package nta.med.data.dao.medi.phy;

import java.util.Date;
import java.util.List;
import nta.med.core.domain.phy.Phy8002;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Phy8002Repository extends JpaRepository<Phy8002, Long>, Phy8002RepositoryCustom {
	@Query("SELECT a FROM Phy8002 a  WHERE a.hospCode = :hospCode AND a.fkOcs = :fkOcs")
	public List<Phy8002> getByFkOcs(@Param("hospCode") String hospCode,
			@Param("fkOcs") Double fkOcs);
	
	@Modifying
	@Query("	UPDATE  Phy8002 																"
			+"	  SET  pkphy8002        =  :pkphy8002                                      "
			+"	       , userId           =  :userId                                       "
			+"	       , updDate          =  :updDate                                          "
			+"	       , iraiDate         =  :iraiDate                                     "
			+"	       , kaisibi          =  :kaisibi                                       "
			+"	       , nissuu           =  :nissuu                                        "
			+"	       , su1              =  :su1                                          "
			+"	       , su21             =  :su21                                        "
			+"	       , su22             =  :su22                                        "
			+"	       , su23             =  :su23                                        "
			+"	       , su24             =  :su24                                        "
			+"	       , su31             =  :su31                                        "
			+"	       , su32             =  :su32                                        "
			+"	       , su41             =  :su41                                        "
			+"	       , su42             =  :su42                                        "
			+"	       , su43             =  :su43                                        "
			+"	       , pt1              =  :pt1                                           "
			+"	       , pt2              =  :pt2                                           "
			+"	       , pt3              =  :pt3                                           "
			+"	       , pt4              =  :pt4                                           "
			+"	       , pt5              =  :pt5                                           "
			+"	       , pt6              =  :pt6                                           "
			+"	       , pt7              =  :pt7                                           "
			+"	       , pt8              =  :pt8                                           "
			+"	       , pt9              =  :pt9                                           "
			+"	       , pt10             =  :pt10                                          "
			+"	       , ot1              =  :ot1                                           "
			+"	       , ot2              =  :ot2                                           "
			+"	       , ot3              =  :ot3                                           "
			+"	       , ot4              =  :ot4                                           "
			+"	       , ot5              =  :ot5                                           "
			+"	       , ot6              =  :ot6                                           "
			+"	       , ot7              =  :ot7                                           "
			+"	       , ot8              =  :ot8                                           "
			+"	       , ot9              =  :ot9                                           "
			+"	       , ot10             =  :ot10                                          "
			+"	       , st1              =  :st1                                           "
			+"	       , st2              =  :st2                                           "
			+"	       , st3              =  :st3                                           "
			+"	       , st4              =  :st4                                           "
			+"	       , st5              =  :st5                                           "
			+"	       , st6              =  :st6                                           "
			+"	       , st7              =  :st7                                           "
			+"	       , st8              =  :st8                                           "
			+"	       , st9              =  :st9                                           "
			+"	       , st10             =  :st10                                          "
			+"	       , objective        =  :objective                                     "
			+"	       , consultComment   =  :consultComment                               "
			+"	       , genbyoureki      =  :genbyoureki                                   "
			+"	       , complications	  =  :complications									"
			+"	       , taboo            =  :taboo                                         "
			+"	       , stopKijyun       =  :stopKijyun                                   "
			+"	       , frequency        =  :frequency                                     "
			+"	       , infectious       =  :infectious                                    "
			+"	       , kioureki         =  :kioureki                                      "
			+"	       , syoriFlag        =  :syoriFlag                                    "
			+"	       , ptFlag           =  :ptFlag                                       "
			+"	       , otFlag           =  :otFlag                                       "
			+"	       , stFlag           =  :stFlag                                       "
			+"	       , buFlag           =  :buFlag                                       "
			+"	       , keFlag           =  :keFlag                                       "
			+"	       , syujyutubi       =  :syujyutubi                                    "
			+"	       , kyuseizouakubi   =  :kyuseizouakubi                                "
			+"	       , disuseGasyou     =  :disuseGasyou                                 "
			+"	       , disuseAdl        =  :disuseAdl                                    "
			+"	       , disuseKainyu     =  :disuseKainyu                                 "
			+"	       , disuseKaizen     =  :disuseKaizen                                 "
			+"	       , disuseContents   =  :disuseContents                               "
			+"	       , disuseFimbi      =  :disuseFimbi                                  "
			+"	       , yoinStartDate    =  :yoinStartDate                               "
			+"	       , yoinSindanDate   =  :yoinSindanDate                              "
			+"	       , image            =  :image                                         "
			+"	       , imagePath        =  :imagePath                                    "
			+"	       , imageSeq         =  :imageSeq                                     "
			+"	       , crTime             =  :crTime							          "
			+"	WHERE  fkOcs              =  :fkOcs                                              "
			+"	  AND  hospCode           =  :hospCode                                           "
			+"	  AND  ioKubun            =  :ioKubun                                            ")
	public Integer updatePhy8002U01(
			@Param("pkphy8002") Double pkphy8002,
			@Param("userId") String userId,
			@Param("updDate") Date updDate,
			@Param("iraiDate") String iraiDate,
			@Param("kaisibi") Date kaisibi,
			@Param("nissuu") Double nissuu,
			@Param("su1") String su1,
			@Param("su21") String su21,
			@Param("su22") String su22,
			@Param("su23") String su23,
			@Param("su24") String su24,
			@Param("su31") String su31,
			@Param("su32") String su32,
			@Param("su41") String su41,
			@Param("su42") String su42,
			@Param("su43") String su43,
			@Param("pt1") String pt1,
			@Param("pt2") String pt2,
			@Param("pt3") String pt3,
			@Param("pt4") String pt4,
			@Param("pt5") String pt5,
			@Param("pt6") String pt6,
			@Param("pt7") String pt7,
			@Param("pt8") String pt8,
			@Param("pt9") String pt9,
			@Param("pt10") String pt10,
			@Param("ot1") String ot1,
			@Param("ot2") String ot2,
			@Param("ot3") String ot3,
			@Param("ot4") String ot4,
			@Param("ot5") String ot5,
			@Param("ot6") String ot6,
			@Param("ot7") String ot7,
			@Param("ot8") String ot8,
			@Param("ot9") String ot9,
			@Param("ot10") String ot10,
			@Param("st1") String st1,
			@Param("st2") String st2,
			@Param("st3") String st3,
			@Param("st4") String st4,
			@Param("st5") String st5,
			@Param("st6") String st6,
			@Param("st7") String st7,
			@Param("st8") String st8,
			@Param("st9") String st9,
			@Param("st10") String st10,
			@Param("objective") String objective,
			@Param("consultComment") String consultComment,
			@Param("genbyoureki") String genbyoureki,
			@Param("complications") String complications,
			@Param("taboo") String taboo,
			@Param("stopKijyun") String stopKijyun, 
			@Param("frequency") String frequency,
			@Param("infectious") String infectious,
			@Param("kioureki") String kioureki,
			@Param("syoriFlag") String syoriFlag ,
			@Param("ptFlag") String ptFlag,
			@Param("otFlag") String otFlag,
			@Param("stFlag") String stFlag,
			@Param("buFlag") String buFlag,
			@Param("keFlag") String keFlag,
			@Param("syujyutubi") Date syujyutubi,
			@Param("kyuseizouakubi") Date kyuseizouakubi,
			@Param("disuseGasyou") String disuseGasyou,
			@Param("disuseAdl") String disuseAdl,
			@Param("disuseKainyu") String disuseKainyu,
			@Param("disuseKaizen") String disuseKaizen,
			@Param("disuseContents") String disuseContents,
			@Param("disuseFimbi") Double disuseFimbi ,
			@Param("yoinStartDate") Date yoinStartDate ,
			@Param("yoinSindanDate") Date yoinSindanDate,
			@Param("image") String image,
			@Param("imagePath") String imagePath,
			@Param("imageSeq") Double imageSeq,
			@Param("crTime") Date crTime,
			@Param("fkOcs") Double fkOcs,
			@Param("hospCode") String hospCode,
			@Param("ioKubun") String ioKubun);
	
	@Modifying
	@Query("	UPDATE  Phy8002 																"
			+"	  SET  pkphy8002        =  :pkphy8002                                      "
			+"	       , userId           =  :userId                                       "
			+"	       , updDate          =  :updDate                                          "
			+"	       , iraiDate         =  :iraiDate                                     "
			+"	       , kaisibi          =  :kaisibi                                       "
			+"	       , nissuu           =  :nissuu                                        "
			+"	       , su1              =  :su1                                          "
			+"	       , su21             =  :su21                                        "
			+"	       , su22             =  :su22                                        "
			+"	       , su23             =  :su23                                        "
			+"	       , su24             =  :su24                                        "
			+"	       , su31             =  :su31                                        "
			+"	       , su32             =  :su32                                        "
			+"	       , su41             =  :su41                                        "
			+"	       , su42             =  :su42                                        "
			+"	       , su43             =  :su43                                        "
			+"	       , pt1              =  :pt1                                           "
			+"	       , pt2              =  :pt2                                           "
			+"	       , pt3              =  :pt3                                           "
			+"	       , pt4              =  :pt4                                           "
			+"	       , pt5              =  :pt5                                           "
			+"	       , pt6              =  :pt6                                           "
			+"	       , pt7              =  :pt7                                           "
			+"	       , pt8              =  :pt8                                           "
			+"	       , pt9              =  :pt9                                           "
			+"	       , pt10             =  :pt10                                          "
			+"	       , ot1              =  :ot1                                           "
			+"	       , ot2              =  :ot2                                           "
			+"	       , ot3              =  :ot3                                           "
			+"	       , ot4              =  :ot4                                           "
			+"	       , ot5              =  :ot5                                           "
			+"	       , ot6              =  :ot6                                           "
			+"	       , ot7              =  :ot7                                           "
			+"	       , ot8              =  :ot8                                           "
			+"	       , ot9              =  :ot9                                           "
			+"	       , ot10             =  :ot10                                          "
			+"	       , st1              =  :st1                                           "
			+"	       , st2              =  :st2                                           "
			+"	       , st3              =  :st3                                           "
			+"	       , st4              =  :st4                                           "
			+"	       , st5              =  :st5                                           "
			+"	       , st6              =  :st6                                           "
			+"	       , st7              =  :st7                                           "
			+"	       , st8              =  :st8                                           "
			+"	       , st9              =  :st9                                           "
			+"	       , st10             =  :st10                                          "
			+"	       , objective        =  :objective                                     "
			+"	       , consultComment   =  :consultComment                               "
			+"	       , genbyoureki      =  :genbyoureki                                   "
			+"	       , complications    =  :complications                                 "
			+"	       , taboo            =  :taboo                                         "
			+"	       , stopKijyun       =  :stopKijyun                                   "
			+"	       , frequency        =  :frequency                                     "
			+"	       , infectious       =  :infectious                                    "
			+"	       , kioureki         =  :kioureki                                      "
			+"	       , syoriFlag        =  :syoriFlag                                    "
			+"	       , ptFlag           =  :ptFlag                                       "
			+"	       , otFlag           =  :otFlag                                       "
			+"	       , stFlag           =  :stFlag                                       "
			+"	       , buFlag           =  :buFlag                                       "
			+"	       , keFlag           =  :keFlag                                       "
			+"	       , syujyutubi       =  :syujyutubi                                    "
			+"	       , kyuseizouakubi   =  :kyuseizouakubi                                "
			+"	       , image            =  :image                                         "
			+"	       , imagePath        =  :imagePath                                    "
			+"	       , imageSeq         =  :imageSeq                                     "
			+"	       , crTime             =  :crTime,							          "
			+"	       reha1         =  :reha1,                                          "
			+"	       reha2         =  :reha2,                                          "
			+"	       reha3         =  :reha3,                                          "
			+"	       reha4         =  :reha4,                                          "
			+"	       reha5         =  :reha5                                          "
			+"	WHERE  fkOcs              =  :fkOcs                                              "
			+"	  AND  hospCode           =  :hospCode                                           "
			+"	  AND  ioKubun            =  :ioKubun                                            ")
	public Integer updatePhy8002U00(
			@Param("pkphy8002") Double pkphy8002,
			@Param("userId") String userId,
			@Param("updDate") Date updDate,
			@Param("iraiDate") String iraiDate,
			@Param("kaisibi") Date kaisibi,
			@Param("nissuu") Double nissuu,
			@Param("su1") String su1,
			@Param("su21") String su21,
			@Param("su22") String su22,
			@Param("su23") String su23,
			@Param("su24") String su24,
			@Param("su31") String su31,
			@Param("su32") String su32,
			@Param("su41") String su41,
			@Param("su42") String su42,
			@Param("su43") String su43,
			@Param("pt1") String pt1,
			@Param("pt2") String pt2,
			@Param("pt3") String pt3,
			@Param("pt4") String pt4,
			@Param("pt5") String pt5,
			@Param("pt6") String pt6,
			@Param("pt7") String pt7,
			@Param("pt8") String pt8,
			@Param("pt9") String pt9,
			@Param("pt10") String pt10,
			@Param("ot1") String ot1,
			@Param("ot2") String ot2,
			@Param("ot3") String ot3,
			@Param("ot4") String ot4,
			@Param("ot5") String ot5,
			@Param("ot6") String ot6,
			@Param("ot7") String ot7,
			@Param("ot8") String ot8,
			@Param("ot9") String ot9,
			@Param("ot10") String ot10,
			@Param("st1") String st1,
			@Param("st2") String st2,
			@Param("st3") String st3,
			@Param("st4") String st4,
			@Param("st5") String st5,
			@Param("st6") String st6,
			@Param("st7") String st7,
			@Param("st8") String st8,
			@Param("st9") String st9,
			@Param("st10") String st10,
			@Param("objective") String objective,
			@Param("consultComment") String consultComment,
			@Param("genbyoureki") String genbyoureki,
			@Param("complications") String complications ,
			@Param("taboo") String taboo,
			@Param("stopKijyun") String stopKijyun, 
			@Param("frequency") String frequency,
			@Param("infectious") String infectious,
			@Param("kioureki") String kioureki,
			@Param("syoriFlag") String syoriFlag,
			@Param("ptFlag") String ptFlag,
			@Param("otFlag") String otFlag,
			@Param("stFlag") String stFlag,
			@Param("buFlag") String buFlag,
			@Param("keFlag") String keFlag,
			@Param("syujyutubi") Date syujyutubi,
			@Param("kyuseizouakubi") Date kyuseizouakubi,
			@Param("image") String image,
			@Param("imagePath") String imagePath,
			@Param("imageSeq") Double imageSeq,
			@Param("crTime") Date crTime,
			@Param("reha1") String reha1,
			@Param("reha2") String reha2,
			@Param("reha3") String reha3,
			@Param("reha4") String reha4,
			@Param("reha5") String reha5,
			@Param("fkOcs") Double fkOcs,
			@Param("hospCode") String hospCode,
			@Param("ioKubun") String ioKubun);
}

