package nta.med.data.dao.medi.out;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.endo.END1001U02GrdComment3Info;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdOUT0106Info;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdCommentsInfo;
import nta.med.data.model.ihis.nuro.OUT0106U00GridItemInfo;
import nta.med.data.model.ihis.ocso.FwPaCommentGrdCmmtFwkInfo;
import nta.med.data.model.ihis.system.DetailPaInfoFormGridCommentInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdCommentInfo;

/**
 * @author dainguyen.
 */
public interface Out0106RepositoryCustom {
	
	/**
	 * @param hospCode
	 * @param patientCode
	 * @return
	 */
	public List<DetailPaInfoFormGridCommentInfo> getDetailPaInfoFormGridComment(String hospCode, String patientCode);
	
	public List<OUT0106U00GridItemInfo> getOUT0106U00GridItemInfo(String hospCode, String bunho);
	
	public Double getSerOUT0106U00SaveComments(String hospCode, String bunho);
	
	public List<String> getPatientSpecificComment(String hospCode, String bunho);
	public List<FwPaCommentGrdCmmtFwkInfo> getFwBizObjectXPaCommentLayCmmtGubunfwkInfo(String hospCode, String bunho,
			String commtGubun, String jundalTable, String jundalPart, Double fkocs);
	public List<XRT1002U00GrdCommentInfo> getXRT1002U00GrdComment(String hospCode, String bunho, String cmmtGubun, String jundalTable);
	
	public List<String> getXRT1002U00LayOrderDate(String hospCode, String jundalTable, String bunho);
	public List<ORDERTRANSGrdCommentsInfo> getORDERTRANSGrdCommentsInfo(String hospCode, String bunho);
	public List<END1001U02GrdComment3Info> getEND1001U02GrdComment3Info(String hospCode, String bunho, Date orderDate);

	public List<NUR1001U00GrdOUT0106Info> getNUR1001U00GrdOUT0106Info(String hospCode, String bunho, Integer startNum, Integer offset);
}

