package nta.med.data.dao.medi.out;

import java.util.List;

/**
 * @author dainguyen.
 */
public interface Out0123RepositoryCustom {
	public List<String> getNuroRES1001U00CheckingPatientExistence(String hospitalCode, String bunho, Double pkout1001);
}

