package nta.med.data.dao.medi.xrt;

import java.util.List;

import nta.med.data.model.ihis.xrts.XRT0001U00GrdXRTInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00DsvXrayGubunInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00LayPrintOrderInfo;
import nta.med.data.model.ihis.xrts.XRT9001R01Lay9001RListItemInfo;
import nta.med.data.model.ihis.xrts.XRT9001R03Lay9003RListItemInfo;
import nta.med.data.model.ihis.xrts.XRT9001R05lay9005RInfo;
import nta.med.data.model.ihis.xrts.XRT9001R06lay9006RInfo;

/**
 * @author dainguyen.
 */
public interface Xrt0001RepositoryCustom {
	public List<XRT9001R01Lay9001RListItemInfo> getXRT9001R01Lay9001RListItemInfo(String hospCode,String date);
	public List<XRT9001R03Lay9003RListItemInfo> getXRT9001R03Lay9003RListItemInfo(String hospCode,String date);
	public List<XRT0001U00GrdXRTInfo>   getXRT0001U00GrdXRTListItemInfo(String hospCode,String language,String txtParam,String xrayGubun,String specialYn);
	public String getSpeciFicCommentInputYnRequest(String hospCode,String tableId,String colId,Double pkOcsKey);
	public List<XRT1002U00DsvXrayGubunInfo> getXRT1002U00DsvXrayGubunInfo(String hospCode,String code);
	public List<XRT1002U00LayPrintOrderInfo> getXRT1002U00LayPrintOrderInfo(String hospCode, String language, String orderDate, String gwa, String inOutGubun, Double pkocs);
	
	public List<XRT9001R06lay9006RInfo> getXRT9001R06lay9006RInfo(String hospCode, String date);
	
	public List<XRT9001R05lay9005RInfo> getXRT9001R05lay9005RInfo(String hospCode, String date);
}

