package nta.med.data.dao.medi.inj;

import java.util.List;

import nta.med.data.model.ihis.injs.INJ0101U01GrdMasterItemInfo;
import nta.med.data.model.ihis.injs.InjsComboListItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01FormJusaBedLayHosilItemInfo;

/**
 * @author dainguyen.
 */
public interface Inj0101RepositoryCustom {
	
	public List<InjsComboListItemInfo> getINJ0101U00GrdMasterInfo(String hospCode, String language);
	public List<InjsINJ1001U01FormJusaBedLayHosilItemInfo> getInjsINJ1001U01FormJusaBedLayHosilItemInfo(String hospCode, String language);
	public List<INJ0101U01GrdMasterItemInfo> getINJ0101U01GrdMasterItemInfo(String hospCode, String language);
}

