package nta.med.data.dao.medi.drg;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.drgs.DRG3041P01grdChulgoJUSAOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3041P01grdChulgoListInfo;
import nta.med.data.model.ihis.drgs.DRG3041P05grdIpgoJUSAOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3041P05grdMixListInfo;
import nta.med.data.model.ihis.drgs.DRG3041P06grdActListInfo;
import nta.med.data.model.ihis.drgs.PrDrgMakeBarCodeResultInfo;

/**
 * @author dainguyen.
 */
public interface Drg3041RepositoryCustom {

	public List<DRG3041P01grdChulgoListInfo> getDRG3041P01grdChulgoListInfo(String hospCode, String bunho, String hoDong, String chulgoDate);

	public List<DRG3041P01grdChulgoJUSAOrderInfo> getDRG3041P01grdChulgoJUSAOrderInfo(String hospCode, String language, String serialV, String jusuDate, String drgBunho);
	
	public PrDrgMakeBarCodeResultInfo callPrDrgMakeBarCode(String hospCode, String barCodeNo, String iudGubun, String userId, Date iDate, String userGubun, String bunho);
	
	public List<DRG3041P05grdMixListInfo> getDRG3041P05grdMixListInfo(String hospCode, String bunryu1, String hoDong, String ipGoDate, String bunho);
	
	public List<DRG3041P05grdIpgoJUSAOrderInfo> getDRG3041P05grdIpgoJUSAOrderInfo(String hospCode, String language, String serialV, String jusuDate, Double drgBunho);
	
	public List<DRG3041P06grdActListInfo> getDRG3041P06grdActListInfo(String hospCode, String ipgoDate, String bunho, String bunryu1, String hoDong);

	public Integer drg3010P99DeleteDrg3041(String hospCode, String jubsuDate, Double drgBunho);
	
}
