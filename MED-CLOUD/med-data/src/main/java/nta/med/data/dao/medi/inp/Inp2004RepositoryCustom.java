package nta.med.data.dao.medi.inp;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.INP2004Q00grdINP2004Info;
import nta.med.data.model.ihis.inps.INP2004Q01grdINP2004Info;
import nta.med.data.model.ihis.nuri.NUR1001R07grdInp2004Info;
import nta.med.data.model.ihis.nuri.NUR1010Q00layConfirmDataInfo;
import nta.med.data.model.ihis.nuri.NUR2004U00GetInitJunipInfo;
import nta.med.data.model.ihis.nuri.NUR2004U01GetConfirmDataInfo;
import nta.med.data.model.ihis.nuri.NUR2004U01grdInp2004Info;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdINP2004Info;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListInfo;

/**
 * @author dainguyen.
 */
public interface Inp2004RepositoryCustom {
	
	public List<ORDERTRANSGrdINP2004Info> getORDERTRANSGrdINP2004Info(String hospCode, String bunho, String sendYn, String actingDate, String sunabdate, Double fkinp1001 );
	
	public List<ORDERTRANSGrdListInfo> getORDERTRANSGrdListInfoCase3(String hospCode, String language, String ioGubun, String sendYn, String bunho, String actingDate);
	
	public List<INP2004Q01grdINP2004Info> getListINP2004Q01grdINP2004Info(String hospCode, Date fromDate, Date toDate);
	
	public List<INP2004Q00grdINP2004Info> getListINP2004Q00grdINP2004Info(String hospCode, String hoDong, String hoCode, String fromDate, String toDate);
	
	public List<NUR2004U01grdInp2004Info> getNUR2004U01grdInp2004Info(String hospCode, String hoDong, String orderDate);
	
	public Integer updateNur2004U01ConfirmTrans(String hospCode, String userId, Double transCnt, String bedNo, Double fkinp1001, Double iTransCnt);
	
	public List<NUR2004U01GetConfirmDataInfo> getNUR2004U01GetConfirmDataInfo(String hospCode, Double fkinp1001, Double transCnt);
	
	public String callProcInpUpadateJengwa(String hospCode, String iudGubun, String userId, Double pkinp1001, String inpwonType, String bunho, String orderDate, String transTime,
			String toHoCode1, String toHoDong1, String toHoGrade1, String toHoCode2, String toHoDong2, String toHoGrade2, String toBedNo);
	
	public String callPrNurChangeGwaHodong(String hospCode, Double fkinp1001, String bunho, String orderDate, String userId);
	
	public List<ComboListItemInfo> getNUR2004U01layCommon(String hospCode, Double fkinp1001);
	
	public List<NUR2004U00GetInitJunipInfo> getNUR2004U00GetInitJunip(String hospCode, String language, Double fkinp1001, String hoDong, String date);
	
	public String getNUR2004U00CancelCheck(String hospCode, String bunho, String fkinp1001, String transCnt);
	
	public String getNUR2004U00CheckAfterHograde(String hospCode, String bunho, Double fkinp1001, String date);
	
	public String getNUR2004U00CheckBeforeUpdate(String hospCode, Double fkinp1001, Double transCnt, String toHoDong1,
			String toHoCode1, String toGwa, String toDoctor, String toBedNo);
	
	public String getNUR2004U00getTransCnt(String hospCode, String bunho, String fkinp1001);
	
	public String getNUR2004U00getOldTransCnt(String hospCode, String bunho, Double fkinp1001);
	
	public Integer updateNUR2004U00CancelUpdate(String userId, String cancelSayu, String hospCode, String bunho, String fkinp1001, String transCnt);
	
	public Integer updateNUR2004U00ProcessUpdate(String userId, String toGwa, String toHoDong1, String toHoCode1,
			String toHoGrade1, String toHoDong2, String toHoCode2, String toBedNo, String toBedNo2,
			String toKaikeiHodong, String toKaikeiHocode, String hospCode, Double fkinp1001, Double transCnt, String toDoctor);
	
	public Integer updateInp2004InNUR2004U00(String userId, Double transCnt, String bedNo, String hospCode, String bunho, Double fkinp1001, Double iTransCnt);
	
	public String getNUR2004U00dtpJukyong(String hospCode, Double fkinp1001, Date selectedDate);
	
	public Integer updateInp2004NUR1010Q00ConfirmTrans(String hospCode, String userId, Double transCnt, String bedNo, Double fkinp1001, Double iTransCnt);	

	public List<NUR1010Q00layConfirmDataInfo> getNUR1010Q00layConfirmDataInfo(String hospCode, Double fkinp1001, Double transCnt);

	public String getNUR1010Q00SelectCount(String hospCode, String hoDong, String orderDate);

	public String checkNUR1010Q00MoveHosilCheck1(String hospCode, String bunho, Double fkinp1001);

	public String getNUR1010Q00MoveHosilCheck4(String hospCode, String bunho, Double fkinp1001);

	public String getNUR1010Q00ChangeHosilCheck4(String hospCode, Double fkinp1001);

	public String callPrNurChangeHocode(String hospCode, Double fromFkinp1001, Double toFkinp1001, String fromBunho, String toBunho, String fromKaikeiChange,
			String toKaikeiChange, String fromTransCnt, String toTransCnt, String userId);

	public List<NUR1001R07grdInp2004Info> getNUR1001R07grdInp2004Info(String hospCode, String language, Double fkinp1001, String bunho, Integer startNum, Integer offset);
}

