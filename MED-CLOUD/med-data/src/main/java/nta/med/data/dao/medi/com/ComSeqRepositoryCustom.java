package nta.med.data.dao.medi.com;

/**
 * @author dainguyen.
 */
public interface ComSeqRepositoryCustom {
	public Double getMaxSeq(String hospCode, String keyObj, String keyType, String key);
}

