package nta.med.data.dao.medi.drg;

import java.util.List;

import nta.med.data.model.ihis.drgs.DRG3010P10DsvOrderPrint4Info;
import nta.med.data.model.ihis.drgs.DRG3010P99OrdPrnSerialInfo;

/**
 * @author dainguyen.
 */
public interface Drg3011RepositoryCustom {

	public List<DRG3010P99OrdPrnSerialInfo> getDRG3010P99OrdPrnSerialInfo(String hospCode, String language, Double drgBunho, String serialText, String jubsuDate);

	public List<DRG3010P10DsvOrderPrint4Info> getDRG3010P10DsvOrderPrint4Info(String hospCode, String language, String jubsuDate, String drgBunho, String serialText);
}

