package nta.med.data.dao.medi.inv;

import java.util.List;

import nta.med.data.model.ihis.invs.CountReserveQtyInfo;

public interface Inv0001RepositoryCustom {
	public List<CountReserveQtyInfo> countReserveQtyByFkocs1003(String hospCode, List<Double> fkocs1003s);
}
