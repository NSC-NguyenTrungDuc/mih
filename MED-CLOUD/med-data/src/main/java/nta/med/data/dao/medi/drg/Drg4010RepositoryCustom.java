package nta.med.data.dao.medi.drg;

import java.math.BigDecimal;

/**
 * @author dainguyen.
 */
public interface Drg4010RepositoryCustom {
	
	public BigDecimal getDrg4010Seq(String seqName);
	
	public Double getMaxSeq(String hospCode, String seqKey);
}

