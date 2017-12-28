package nta.med.data.dao.medi.ifs;

import java.math.BigDecimal;
import java.util.List;

import nta.med.core.caching.model.medi.drgs.InformationSchemaColumn;

/**
 * @author dainguyen.
 */
public interface Ifs7101RepositoryCustom {
	
	public List<InformationSchemaColumn> getInformationSchemaColumn(String schema);
	
	public BigDecimal getIfs7101Seq(String seqName);
}

