package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.data.model.ihis.system.PrOcsConvertHangmogCodeInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0118RepositoryCustom {
	public PrOcsConvertHangmogCodeInfo callPrOcsConvertHangmogCode(String hospCode,
			String convClass, String convGubun, String hangmogCode,
			String bunho, Date gijunDate, String ioHangmogCode, String ioMsgYn, String ioRemark);
	
	public PrOcsConvertHangmogCodeInfo callPrOcsConvertHangmogCodeCommonYn(String hospCode,
			String convClass, String convGubun, String hangmogCode,
			String bunho, Date gijunDate, String ioHangmogCode, String ioMsgYn, String ioRemark);
}

